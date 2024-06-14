using AutoMapper;
using PCM.SIP.ICP.Aplicacion.Dto;
using PCM.SIP.ICP.Aplicacion.Interface;
using PCM.SIP.ICP.Aplicacion.Interface.Features;
using PCM.SIP.ICP.Aplicacion.Interface.Infraestructure;
using PCM.SIP.ICP.Aplicacion.Validator;
using PCM.SIP.ICP.Domain.Entities;
using PCM.SIP.ICP.Transversal.Common;
using PCM.SIP.ICP.Transversal.Common.Constants;
using PCM.SIP.ICP.Transversal.Common.Generics;
using PCM.SIP.ICP.Transversal.Contracts.Seguridad.Request;
using PCM.SIP.ICP.Transversal.Contracts.Seguridad.Response;
using PCM.SIP.ICP.Transversal.Util.Encryptions;

namespace PCM.SIP.ICP.Aplicacion.Features
{
    public class PersonaApplication : IPersonaApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppLogger<PersonaApplication> _logger;
        private readonly PersonaValidationManager _personaValidationManager;
        private readonly IUserService _userService;
        private readonly IUsuarioService _uarioService;

        public PersonaApplication(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IAppLogger<PersonaApplication> logger,
            PersonaValidationManager personaValidationManager,
            IUserService userService,
            IUsuarioService usuarioService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _personaValidationManager = personaValidationManager;
            _userService = userService;
            _uarioService = usuarioService;
        }
        public async Task<PcmResponse> Insert(Request<PersonaDto> request)
        {
            try
            {
                // ejecutamos las validaciones
                var validation = _personaValidationManager.Validate(_mapper.Map<PersonaInsertRequest>(request.entidad));

                // si es invalido retornamos el error
                if (!validation.IsValid)
                {
                    _logger.LogError(Validation.InvalidMessage);
                    return ResponseUtil.BadRequest(validation.Errors != null ? validation.Errors : null, Validation.InvalidMessage);
                }

                // mapeamos la entidad y seteamos sus valores internos
                var entidad = _mapper.Map<Persona>(request.entidad);
                entidad.usuario_reg = _userService.GetUser().username;

                // se inserta la persona en bd
                var result = _unitOfWork.Persona.Insert(entidad, out int id);

                // si ocurrio un error retorna el mensaje
                if (result.Error)
                {
                    _logger.LogError(result.Message);
                    return ResponseUtil.InternalError(message: result.Message);
                }

                // mapeamos los valores de la personaDto a usuarioRequest
                var usuarioRequest = _mapper.Map<InsertUsuarioRequest>(_mapper.Map<PersonaDto>(entidad));

                // actualizamos las propiedades de usuariorequest
                usuarioRequest.personakey = string.IsNullOrEmpty(id.ToString()) ? null : CShrapEncryption.EncryptString(id.ToString(), _userService.GetUser().authkey);

                // consumimos el servicio de usuario para insertar un nuevo usuario a la persona
                var resultUsuario = await _uarioService.InsertUsuario(usuarioRequest, _userService.GetToken());

                // retornamos la respuesta
                _logger.LogInformation(result.Message ?? TransactionMessage.SaveSuccess);
                return ResponseUtil.Created(message: TransactionMessage.SaveSuccess);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseUtil.InternalError(message: ex.Message);
            }
        }

        public async Task<PcmResponse> Update(Request<PersonaDto> request)
        {
            // ejecutamos las validaciones
            var validation = _personaValidationManager.Validate(_mapper.Map<PersonaUpdateRequest>(request.entidad));

            // verificamos si es invalido
            if (!validation.IsValid)
            {
                _logger.LogError(Validation.InvalidMessage);
                return ResponseUtil.BadRequest(validation.Errors != null ? validation.Errors : null, Validation.InvalidMessage);
            }

            try
            {
                // mapeamos la entidad
                var entidad = _mapper.Map<Persona>(request.entidad);

                // seteamos las propiedades de la entidad
                entidad.persona_id = string.IsNullOrEmpty(request.entidad.SerialKey) ? 0 : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.SerialKey, _userService.GetUser().authkey));
                entidad.usuario_act = _userService.GetUser().username;

                // actualizamos en bd
                var result = _unitOfWork.Persona.Update(entidad);

                // verificamos si ocurrio un error
                if (result.Error)
                {
                    _logger.LogError(result.Message);
                    return ResponseUtil.InternalError(message: result.Message);
                }

                // listamos al usuario mediante la personakey
                List<UsuarioResponse> usuarioList = await _uarioService.ListUsuario(new UsuarioFilterRequest { personakey = entidad.SerialKey }, _userService.GetToken());

                // obtenemos el pk del usuario
                var usuarioKey = usuarioList.FirstOrDefault()?.serialKey;

                // mapeamos los valores de la personaDto a usuarioRequest
                var usuarioRequest = _mapper.Map<UpdateUsuarioRequest>(_mapper.Map<PersonaDto>(entidad));

                // actualizamos las propiedades de usuariorequest
                usuarioRequest.SerialKey = usuarioKey;
                usuarioRequest.personakey = entidad.SerialKey;

                // consumimos el servicio de usuario para actualizarlo
                var resultUsuario = await _uarioService.UpdateUsuario(usuarioRequest, _userService.GetToken());

                // verifiamos si hubo un error al actualizar usuario
                if (resultUsuario.error)
                {
                    _logger.LogError(resultUsuario.message);
                    return ResponseUtil.BadRequest(message: resultUsuario.message, error: resultUsuario.payload);
                }

                // retornamos el response de insertar
                _logger.LogInformation(result.Message ?? TransactionMessage.UpdateSuccess);
                return ResponseUtil.Created(message: TransactionMessage.UpdateSuccess);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseUtil.InternalError(message: ex.Message);
            }
        }

        public async Task<PcmResponse> Delete(Request<PersonaDto> request)
        {
            var validation = _personaValidationManager.Validate(_mapper.Map<PersonaIdRequest>(request.entidad));

            if (!validation.IsValid)
            {
                _logger.LogError(Validation.InvalidMessage);
                return ResponseUtil.BadRequest(validation.Errors != null ? validation.Errors : null, Validation.InvalidMessage);
            }

            try
            {
                var entidad = _mapper.Map<Persona>(request.entidad);

                entidad.persona_id = string.IsNullOrEmpty(request.entidad.SerialKey) ? 0 : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.SerialKey, _userService.GetUser().authkey));
                entidad.usuario_act = _userService.GetUser().username;

                var result = _unitOfWork.Persona.Delete(entidad);

                if (result.Error)
                {
                    _logger.LogError(result.Message);
                    return ResponseUtil.InternalError(message: result.Message);
                }

                _logger.LogInformation(TransactionMessage.DeleteSuccess);
                return ResponseUtil.Created(message: result.Message ?? TransactionMessage.DeleteSuccess);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseUtil.InternalError(message: ex.Message);
            }
        }

        public async Task<PcmResponse> GetById(Request<PersonaDto> request)
        {
            try
            {
                var validation = _personaValidationManager.Validate(_mapper.Map<PersonaIdRequest>(request.entidad));

                if (!validation.IsValid)
                {
                    _logger.LogError(Validation.InvalidMessage);
                    return ResponseUtil.BadRequest(validation.Errors != null ? validation.Errors : null, Validation.InvalidMessage);
                }

                var entidad = _mapper.Map<Persona>(request.entidad);
                entidad.persona_id = string.IsNullOrEmpty(request.entidad.SerialKey) ? 0 : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.SerialKey, _userService.GetUser().authkey));

                var result = _unitOfWork.Persona.GetById(entidad);

                if (result.Error)
                {
                    _logger.LogError(result.Message);
                    return ResponseUtil.InternalError(message: result.Message);
                }

                if (result.Data != null)
                {
                    entidad = new Persona
                    {
                        SerialKey = string.IsNullOrEmpty(result.Data.persona_id.ToString()) ? null : CShrapEncryption.EncryptString(result.Data.persona_id.ToString(), _userService.GetUser().authkey),
                        nombres = result.Data.nombres,
                        apellido_paterno = result.Data.apellido_paterno,
                        apellido_materno = result.Data.apellido_materno,
                        numdocumento = result.Data.numdocumento,
                        email = result.Data.email,
                        telefono_movil = result.Data.telefono_movil,
                        estado = result.Data.estado,
                        usuario_reg = result.Data.usuario_reg,
                        fecha_reg = result.Data.fecha_reg,
                        usuario_act = result.Data.usuario_act,
                        fecha_act = result.Data.fecha_act
                    };
                }

                _logger.LogInformation(TransactionMessage.QuerySuccess);
                return result.Data != null ? ResponseUtil.Ok(
                    _mapper.Map<PersonaResponse>(_mapper.Map<PersonaDto>(entidad)), result.Message ?? TransactionMessage.QuerySuccess
                    ) : ResponseUtil.NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseUtil.InternalError(message: ex.Message);
            }
        }

        public async Task<PcmResponse> GetList(Request<PersonaDto> request)
        {
            try
            {
                var entidad = _mapper.Map<Persona>(request.entidad);

                entidad.persona_id = string.IsNullOrEmpty(request.entidad.SerialKey) ? 0 : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.SerialKey, _userService.GetUser().authkey));

                var result = _unitOfWork.Persona.GetList(entidad);

                if (result.Error)
                {
                    _logger.LogError(result.Message);
                    return ResponseUtil.InternalError(message: result.Message);
                }

                List<Persona> Lista = new List<Persona>();

                if (result.Data != null)
                {

                    foreach (var item in result.Data)
                    {
                        Lista.Add(new Persona()
                        {
                            SerialKey = string.IsNullOrEmpty(item.persona_id.ToString()) ? null : CShrapEncryption.EncryptString(item.persona_id.ToString(), _userService.GetUser().authkey),
                            nombres = item.nombres,
                            apellido_paterno = item.apellido_paterno,
                            apellido_materno = item.apellido_materno,
                            numdocumento = item.numdocumento,
                            email = item.email,
                            telefono_movil = item.telefono_movil,
                            usuario_reg = item.usuario_reg,
                            fecha_reg = item.fecha_reg
                        });
                    }
                }

                _logger.LogInformation(TransactionMessage.QuerySuccess);
                return result != null ? ResponseUtil.Ok(
                    _mapper.Map<List<PersonaResponse>>(_mapper.Map<List<PersonaDto>>(Lista)),
                    result.Message ?? TransactionMessage.QuerySuccess
                    ) : ResponseUtil.NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseUtil.InternalError(message: ex.Message);
            }
        }
    }
}
