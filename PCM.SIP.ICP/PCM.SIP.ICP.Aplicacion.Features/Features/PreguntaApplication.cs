using AutoMapper;
using System.Text.Json;
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
    public class PreguntaApplication : IPreguntaApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppLogger<PreguntaApplication> _logger;
        private readonly PreguntaValidationManager _preguntaValidationManager;
        private readonly IUserService _userService;
        private readonly IUsuarioService _uarioService;

        public PreguntaApplication(
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            IAppLogger<PreguntaApplication> logger, 
            PreguntaValidationManager preguntaValidationManager, 
            IUserService userService, 
            IUsuarioService uarioService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _preguntaValidationManager = preguntaValidationManager;
            _userService = userService;
            _uarioService = uarioService;
        }

        public async Task<PcmResponse> Insert(Request<PreguntaDto> request)
        {
            try
            {
                var validation = _preguntaValidationManager.Validate(_mapper.Map<PreguntaInsertRequest>(request.entidad));

                if (!validation.IsValid)
                {
                    _logger.LogError(Validation.InvalidMessage);
                    return ResponseUtil.BadRequest(validation.Errors != null ? validation.Errors : null, Validation.InvalidMessage);
                }

                var entidad = _mapper.Map<Pregunta>(request.entidad);

                entidad.componente_id = string.IsNullOrEmpty(request.entidad.componentekey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.componentekey, _userService.GetUser().authkey));
                entidad.alternativas = _mapper.Map<List<TypeAlternativa>>(entidad.lista_alternativas);
                entidad.usuario_reg = _userService.GetUser().username;

                var result = _unitOfWork.Pregunta.Insert(entidad);

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

        public async Task<PcmResponse> Update(Request<PreguntaDto> request)
        {
            var validation = _preguntaValidationManager.Validate(_mapper.Map<PreguntaUpdateRequest>(request.entidad));

            if (!validation.IsValid)
            {
                _logger.LogError(Validation.InvalidMessage);
                return ResponseUtil.BadRequest(validation.Errors != null ? validation.Errors : null, Validation.InvalidMessage);
            }

            try
            {
                var entidad = _mapper.Map<Pregunta>(request.entidad);

                entidad.pregunta_id = string.IsNullOrEmpty(request.entidad.SerialKey) ? 0 : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.SerialKey, _userService.GetUser().authkey));
                entidad.componente_id = string.IsNullOrEmpty(request.entidad.componentekey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.componentekey, _userService.GetUser().authkey));
                entidad.alternativas = _mapper.Map<List<TypeAlternativa>>(entidad.lista_alternativas);
                entidad.usuario_act = _userService.GetUser().username;

                var result = _unitOfWork.Pregunta.Update(entidad);

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

        public async Task<PcmResponse> Delete(Request<PreguntaDto> request)
        {
            var validation = _preguntaValidationManager.Validate(_mapper.Map<PreguntaIdRequest>(request.entidad));

            if (!validation.IsValid)
            {
                _logger.LogError(Validation.InvalidMessage);
                return ResponseUtil.BadRequest(validation.Errors != null ? validation.Errors : null, Validation.InvalidMessage);
            }

            try
            {
                var entidad = _mapper.Map<Pregunta>(request.entidad);

                entidad.pregunta_id = string.IsNullOrEmpty(request.entidad.SerialKey) ? 0 : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.SerialKey, _userService.GetUser().authkey));
                entidad.usuario_act = _userService.GetUser().username;

                var result = _unitOfWork.Pregunta.Delete(entidad);

                if (result.Error)
                {
                    _logger.LogError(result.Message);
                    return ResponseUtil.BadRequest(message: result.Message, error: null);
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

        public async Task<PcmResponse> GetById(Request<PreguntaDto> request)
        {
            try
            {
                var validation = _preguntaValidationManager.Validate(_mapper.Map<PreguntaIdRequest>(request.entidad));

                if (!validation.IsValid)
                {
                    _logger.LogError(Validation.InvalidMessage);
                    return ResponseUtil.BadRequest(validation.Errors != null ? validation.Errors : null, Validation.InvalidMessage);
                }

                var entidad = _mapper.Map<Pregunta>(request.entidad);

                entidad.pregunta_id = string.IsNullOrEmpty(request.entidad.SerialKey) ? 0 : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.SerialKey, _userService.GetUser().authkey));
                entidad.componente_id = string.IsNullOrEmpty(request.entidad.componentekey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.componentekey, _userService.GetUser().authkey));

                var result = _unitOfWork.Pregunta.GetById(entidad);

                if (result.Error)
                {
                    _logger.LogError(result.Message);
                    return ResponseUtil.BadRequest(result.Message);
                }

                if (result.Data != null)
                {
                    var componentekey = string.IsNullOrEmpty(result.Data.componente_id == null ? null : result.Data.componente_id.ToString()) ? null : CShrapEncryption.EncryptString(result.Data.componente_id.ToString(), _userService.GetUser().authkey);
                    entidad = new Pregunta
                    {
                        SerialKey = string.IsNullOrEmpty(result.Data.pregunta_id.ToString()) ? null : CShrapEncryption.EncryptString(result.Data.pregunta_id.ToString(), _userService.GetUser().authkey),
                        componentekey = componentekey,
                        codigo = result.Data.codigo,
                        numero = result.Data.numero,
                        descripcion = result.Data.descripcion,
                        calculo_icp = result.Data.calculo_icp,
                        habilitado = result.Data.habilitado,
                        lista_alternativas = string.IsNullOrEmpty(result.Data.lista_alternativas) ? new List<Alternativa>() : JsonSerializer.Deserialize<List<Alternativa>>(result.Data.lista_alternativas),
                        componente = new Componente
                        {
                            SerialKey = componentekey,
                            codigo = result.Data.componente_codigo,
                            abreviatura = result.Data.componente_abreviatura,
                            descripcion = result.Data.componente_descripcion
                        },
                        estado = result.Data.estado,
                        usuario_reg = result.Data.usuario_reg,
                        fecha_reg = result.Data.fecha_reg,
                        usuario_act = result.Data.usuario_act,
                        fecha_act = result.Data.fecha_act
                    };
                }

                _logger.LogInformation(TransactionMessage.QuerySuccess);
                return result.Data != null ? ResponseUtil.Ok(
                    _mapper.Map<PreguntaResponse>(_mapper.Map<PreguntaDto>(entidad)), result.Message ?? TransactionMessage.QuerySuccess
                    ) : ResponseUtil.NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseUtil.InternalError(message: ex.Message);
            }
        }

        public async Task<PcmResponse> GetList(Request<PreguntaDto> request)
        {
            try
            {
                var entidad = _mapper.Map<Pregunta>(request.entidad);

                entidad.pregunta_id = string.IsNullOrEmpty(request.entidad.SerialKey) ? 0 : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.SerialKey, _userService.GetUser().authkey));
                entidad.componente_id = string.IsNullOrEmpty(request.entidad.componentekey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.componentekey, _userService.GetUser().authkey));

                var result = _unitOfWork.Pregunta.GetList(entidad);

                if (result.Error)
                {
                    _logger.LogError(result.Message);
                    return ResponseUtil.BadRequest(result.Message);
                }

                List<Pregunta> Lista = new List<Pregunta>();

                if (result.Data != null)
                {
                    foreach (var item in result.Data)
                    {
                        var componentekey = string.IsNullOrEmpty(item.componente_id == null ? null : item.componente_id.ToString()) ? null : CShrapEncryption.EncryptString(item.componente_id.ToString(), _userService.GetUser().authkey);

                        Lista.Add(new Pregunta()
                        {
                            SerialKey = string.IsNullOrEmpty(item.pregunta_id.ToString()) ? null : CShrapEncryption.EncryptString(item.pregunta_id.ToString(), _userService.GetUser().authkey),
                            componentekey = componentekey,
                            codigo = item.codigo,
                            numero = item.numero,
                            descripcion = item.descripcion,
                            calculo_icp = item.calculo_icp,
                            habilitado = item.habilitado,
                            componente = new Componente
                            {
                                SerialKey = componentekey,
                                codigo = item.componente_codigo,
                                abreviatura = item.componente_abreviatura,
                                descripcion = item.componente_descripcion
                            },
                            estado = item.estado,
                            usuario_reg = item.usuario_reg,
                            fecha_reg = item.fecha_reg
                        });
                    }
                }

                _logger.LogInformation(TransactionMessage.QuerySuccess);
                return result != null ? ResponseUtil.Ok(
                    _mapper.Map<List<PreguntaResponse>>(_mapper.Map<List<PreguntaDto>>(Lista)),
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
