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

        public PersonaApplication(
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            IAppLogger<PersonaApplication> logger, 
            PersonaValidationManager personaValidationManager, 
            IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _personaValidationManager = personaValidationManager;
            _userService = userService;
        }
        public async Task<PcmResponse> Insert(Request<PersonaDto> request)
        {
            try
            {
                var validation = _personaValidationManager.Validate(_mapper.Map<PersonaInsertRequest>(request.entidad));

                if (!validation.IsValid)
                {
                    _logger.LogError(Validation.InvalidMessage);
                    return ResponseUtil.BadRequest(validation.Errors != null ? validation.Errors : null, Validation.InvalidMessage);
                }

                var entidad = _mapper.Map<Persona>(request.entidad);
                entidad.usuario_reg = _userService.GetUser().username;

                var result = _unitOfWork.Persona.Insert(entidad, out string id);

                var idpersona = id;

                if (result.Error)
                {
                    _logger.LogError(result.Message);
                    return ResponseUtil.InternalError(message: result.Message);
                }

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
            var validation = _personaValidationManager.Validate(_mapper.Map<PersonaUpdateRequest>(request.entidad));

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

                var result = _unitOfWork.Persona.Update(entidad);

                if (result.Error)
                {
                    _logger.LogError(result.Message);
                    return ResponseUtil.InternalError(message: result.Message);
                }

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
