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
    public class EntidadCoordinadorApplication : IEntidadCoordinadorApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppLogger<EntidadCoordinadorApplication> _logger;
        private readonly EntidadCoordinadorValidationManager _entidadCoordinadorValidationManager;
        private readonly IUserService _userService;

        public EntidadCoordinadorApplication(
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            IAppLogger<EntidadCoordinadorApplication> logger, 
            EntidadCoordinadorValidationManager entidadCoordinadorValidationManager, 
            IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _entidadCoordinadorValidationManager = entidadCoordinadorValidationManager;
            _userService = userService;
        }
        public async Task<PcmResponse> Insert(Request<EntidadCoordinadorDto> request)
        {
            try
            {
                var validation = _entidadCoordinadorValidationManager.Validate(_mapper.Map<EntidadCoordinadorInsertRequest>(request.entidad));

                if (!validation.IsValid)
                {
                    _logger.LogError(Validation.InvalidMessage);
                    return ResponseUtil.BadRequest(validation.Errors != null ? validation.Errors : null, Validation.InvalidMessage);
                }

                var entidad = _mapper.Map<EntidadCoordinador>(request.entidad);

                // desencriptamos los fk
                entidad.entidad_id = string.IsNullOrEmpty(request.entidad.entidadkey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.entidadkey, _userService.GetUser().authkey));
                entidad.modalidad_id = string.IsNullOrEmpty(request.entidad.modalidadkey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.modalidadkey, _userService.GetUser().authkey));
                entidad.profesion_id = string.IsNullOrEmpty(request.entidad.profesionkey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.profesionkey, _userService.GetUser().authkey));
                entidad.usuario_reg = _userService.GetUser().username;

                // guardamos el documento en el directorio y almacenamos la metadata
                entidad.designacion_doc = request.entidad.documento_designacion == null ? null : await _unitOfWork.DocumentRepository.SaveDocumentAsync(request.entidad.documento_designacion.filename, request.entidad.documento_designacion.base64content, PathKey.DocDesignacionCoordinador);

                // guardamos en base de datos
                var result = _unitOfWork.EntidadCoordinador.Insert(entidad);

                if (result.Error)
                {
                    _logger.LogError(result.Message);
                    return ResponseUtil.BadRequest(result.Message);
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

        public async Task<PcmResponse> Update(Request<EntidadCoordinadorDto> request)
        {
            var validation = _entidadCoordinadorValidationManager.Validate(_mapper.Map<EntidadCoordinadorUpdateRequest>(request.entidad));

            if (!validation.IsValid)
            {
                _logger.LogError(Validation.InvalidMessage);
                return ResponseUtil.BadRequest(validation.Errors != null ? validation.Errors : null, Validation.InvalidMessage);
            }

            try
            {
                var entidad = _mapper.Map<EntidadCoordinador>(request.entidad);

                // desencriptamos la pk y fk
                entidad.entidadcoordinador_id = string.IsNullOrEmpty(request.entidad.SerialKey) ? 0 : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.SerialKey, _userService.GetUser().authkey));
                entidad.entidad_id = string.IsNullOrEmpty(request.entidad.entidadkey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.entidadkey, _userService.GetUser().authkey));
                entidad.modalidad_id = string.IsNullOrEmpty(request.entidad.modalidadkey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.modalidadkey, _userService.GetUser().authkey));
                entidad.profesion_id = string.IsNullOrEmpty(request.entidad.profesionkey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.profesionkey, _userService.GetUser().authkey));
                entidad.usuario_act = _userService.GetUser().username;

                // guardamos el documento en el directorio y almacenamos la metadata
                entidad.designacion_doc = request.entidad.documento_designacion == null ? null : await _unitOfWork.DocumentRepository.SaveDocumentAsync(request.entidad.documento_designacion.filename, request.entidad.documento_designacion.base64content, PathKey.DocDesignacionCoordinador);

                // actualizamos la informacion
                var result = _unitOfWork.EntidadCoordinador.Update(entidad);

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

        public async Task<PcmResponse> Delete(Request<EntidadCoordinadorDto> request)
        {
            var validation = _entidadCoordinadorValidationManager.Validate(_mapper.Map<EntidadCoordinadorIdRequest>(request.entidad));

            if (!validation.IsValid)
            {
                _logger.LogError(Validation.InvalidMessage);
                return ResponseUtil.BadRequest(validation.Errors != null ? validation.Errors : null, Validation.InvalidMessage);
            }

            try
            {
                var entidad = _mapper.Map<EntidadCoordinador>(request.entidad);

                entidad.entidadcoordinador_id = string.IsNullOrEmpty(request.entidad.SerialKey) ? 0 : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.SerialKey, _userService.GetUser().authkey));
                entidad.usuario_act = _userService.GetUser().username;

                var result = _unitOfWork.EntidadCoordinador.Delete(entidad);

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

        public async Task<PcmResponse> GetById(Request<EntidadCoordinadorDto> request)
        {
            try
            {
                var validation = _entidadCoordinadorValidationManager.Validate(_mapper.Map<EntidadCoordinadorIdRequest>(request.entidad));

                if (!validation.IsValid)
                {
                    _logger.LogError(Validation.InvalidMessage);
                    return ResponseUtil.BadRequest(validation.Errors != null ? validation.Errors : null, Validation.InvalidMessage);
                }

                var entidad = _mapper.Map<EntidadCoordinador>(request.entidad);

                entidad.entidadcoordinador_id = string.IsNullOrEmpty(request.entidad.SerialKey) ? 0 : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.SerialKey, _userService.GetUser().authkey));
                entidad.entidad_id = string.IsNullOrEmpty(request.entidad.entidadkey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.entidadkey, _userService.GetUser().authkey));
                entidad.modalidad_id = string.IsNullOrEmpty(request.entidad.modalidadkey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.modalidadkey, _userService.GetUser().authkey));
                entidad.profesion_id = string.IsNullOrEmpty(request.entidad.profesionkey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.profesionkey, _userService.GetUser().authkey));

                var result = _unitOfWork.EntidadCoordinador.GetById(entidad);

                if (result.Error)
                {
                    _logger.LogError(result.Message);
                    return ResponseUtil.BadRequest(result.Message);
                }

                if (result.Data != null)
                {
                    entidad = new EntidadCoordinador
                    {
                        SerialKey = string.IsNullOrEmpty(result.Data.entidadcoordinador_id.ToString()) ? null : CShrapEncryption.EncryptString(result.Data.entidadcoordinador_id.ToString(), _userService.GetUser().authkey),
                        entidadkey = string.IsNullOrEmpty(result.Data.entidad_id == null ? null : result.Data.entidad_id.ToString()) ? null : CShrapEncryption.EncryptString(result.Data.entidad_id.ToString(), _userService.GetUser().authkey),
                        profesionkey = string.IsNullOrEmpty(result.Data.profesion_id == null ? null : result.Data.profesion_id.ToString()) ? null : CShrapEncryption.EncryptString(result.Data.profesion_id.ToString(), _userService.GetUser().authkey),
                        modalidadkey = string.IsNullOrEmpty(result.Data.modalidad_id == null ? null : result.Data.modalidad_id.ToString()) ? null : CShrapEncryption.EncryptString(result.Data.modalidad_id.ToString(), _userService.GetUser().authkey),
                        nombres = result.Data.nombres,
                        apellidos = result.Data.apellidos,
                        numero_celular = result.Data.numero_celular,
                        correo_institucional = result.Data.correo_institucional,
                        fecha_inicio = result.Data.fecha_inicio,
                        fecha_fin = result.Data.fecha_fin,
                        actual = result.Data.actual,
                        documento_designacion = string.IsNullOrEmpty(result.Data.designacion_doc) ? null : JsonSerializer.Deserialize<Document>(result.Data.designacion_doc),
                        estado = result.Data.estado,
                        usuario_reg = result.Data.usuario_reg,
                        fecha_reg = result.Data.fecha_reg,
                        usuario_act = result.Data.usuario_act,
                        fecha_act = result.Data.fecha_act
                    };
                }

                _logger.LogInformation(TransactionMessage.QuerySuccess);
                return result.Data != null ? ResponseUtil.Ok(
                    _mapper.Map<EntidadCoordinadorResponse>(_mapper.Map<EntidadCoordinadorDto>(entidad)), result.Message ?? TransactionMessage.QuerySuccess
                    ) : ResponseUtil.NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseUtil.InternalError(message: ex.Message);
            }
        }

        public async Task<PcmResponse> GetList(Request<EntidadCoordinadorDto> request)
        {
            try
            {
                var entidad = _mapper.Map<EntidadCoordinador>(request.entidad);

                entidad.entidadcoordinador_id = string.IsNullOrEmpty(request.entidad.SerialKey) ? 0 : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.SerialKey, _userService.GetUser().authkey));
                entidad.entidad_id = string.IsNullOrEmpty(request.entidad.entidadkey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.entidadkey, _userService.GetUser().authkey));
                entidad.modalidad_id = string.IsNullOrEmpty(request.entidad.modalidadkey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.modalidadkey, _userService.GetUser().authkey));
                entidad.profesion_id = string.IsNullOrEmpty(request.entidad.profesionkey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.profesionkey, _userService.GetUser().authkey));

                var result = _unitOfWork.EntidadCoordinador.GetList(entidad);

                if (result.Error)
                {
                    _logger.LogError(result.Message);
                    return ResponseUtil.BadRequest(result.Message);
                }

                List<EntidadCoordinador> Lista = new List<EntidadCoordinador>();

                if (result.Data != null)
                {
                    foreach (var item in result.Data)
                    {
                        Lista.Add(new EntidadCoordinador()
                        {
                            SerialKey = string.IsNullOrEmpty(item.entidadcoordinador_id.ToString()) ? null : CShrapEncryption.EncryptString(item.entidadcoordinador_id.ToString(), _userService.GetUser().authkey),
                            entidadkey = string.IsNullOrEmpty(item.entidad_id == null ? null : item.entidad_id.ToString()) ? null : CShrapEncryption.EncryptString(item.entidad_id.ToString(), _userService.GetUser().authkey),
                            profesionkey = string.IsNullOrEmpty(item.profesion_id == null ? null : item.profesion_id.ToString()) ? null : CShrapEncryption.EncryptString(item.profesion_id.ToString(), _userService.GetUser().authkey),
                            modalidadkey = string.IsNullOrEmpty(item.modalidad_id == null ? null : item.modalidad_id.ToString()) ? null : CShrapEncryption.EncryptString(item.modalidad_id.ToString(), _userService.GetUser().authkey),
                            nombres = item.nombres,
                            apellidos = item.apellidos,
                            numero_celular = item.numero_celular,
                            correo_institucional = item.correo_institucional,
                            fecha_inicio = item.fecha_inicio,
                            fecha_fin = item.fecha_fin,
                            actual = item.actual,
                            documento_designacion = string.IsNullOrEmpty(item.designacion_doc) ? null : JsonSerializer.Deserialize<Document>(item.designacion_doc),
                            profesion = new Profesion
                            {
                                codigo = item.profesion_codigo,
                                descripcion = item.profesion_descripcion
                            },
                            modalidadcontrato = new ModalidadContrato
                            {
                                codigo = item.modalidad_codigo,
                                descripcion = item.modalidad_descripcion,
                                abreviatura = item.modalidad_abreviatura,
                            },
                            usuario_reg = item.usuario_reg,
                            fecha_reg = item.fecha_reg
                        });
                    }
                }

                _logger.LogInformation(TransactionMessage.QuerySuccess);
                return result != null ? ResponseUtil.Ok(
                    _mapper.Map<List<EntidadCoordinadorResponse>>(_mapper.Map<List<EntidadCoordinadorDto>>(Lista)),
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
