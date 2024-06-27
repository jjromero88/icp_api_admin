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
    public class EntidadOficialApplication : IEntidadOficialApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppLogger<EntidadOficialApplication> _logger;
        private readonly EntidadOficialValidationManager _entidadOficialValidationManager;
        private readonly IUserService _userService;

        public EntidadOficialApplication(
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            IAppLogger<EntidadOficialApplication> logger, 
            EntidadOficialValidationManager entidadOficialValidationManager, 
            IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _entidadOficialValidationManager = entidadOficialValidationManager;
            _userService = userService;
        }

        public async Task<PcmResponse> Insert(Request<EntidadOficialDto> request)
        {
            try
            {
                var validation = _entidadOficialValidationManager.Validate(_mapper.Map<EntidadOficialInsertRequest>(request.entidad));

                if (!validation.IsValid)
                {
                    _logger.LogError(Validation.InvalidMessage);
                    return ResponseUtil.BadRequest(validation.Errors != null ? validation.Errors : null, Validation.InvalidMessage);
                }

                var entidad = _mapper.Map<EntidadOficial>(request.entidad);

                // desencriptamos los fk
                entidad.entidad_id = string.IsNullOrEmpty(request.entidad.entidadkey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.entidadkey, _userService.GetUser().authkey));
                entidad.modalidad_id = string.IsNullOrEmpty(request.entidad.modalidadkey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.modalidadkey, _userService.GetUser().authkey));
                entidad.profesion_id = string.IsNullOrEmpty(request.entidad.profesionkey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.profesionkey, _userService.GetUser().authkey));
                entidad.usuario_reg = _userService.GetUser().username;

                // guardamos el documento en el directorio y almacenamos la metadata
                entidad.designacion_doc = request.entidad.documento_designacion == null ? null : await _unitOfWork.DocumentRepository.SaveDocumentAsync(request.entidad.documento_designacion.filename, request.entidad.documento_designacion.base64content, PathKey.DocDesignacionOficial);

                // guardamos en base de datos
                var result = _unitOfWork.EntidadOficial.Insert(entidad);

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

        public async Task<PcmResponse> Update(Request<EntidadOficialDto> request)
        {
            var validation = _entidadOficialValidationManager.Validate(_mapper.Map<EntidadOficialUpdateRequest>(request.entidad));

            if (!validation.IsValid)
            {
                _logger.LogError(Validation.InvalidMessage);
                return ResponseUtil.BadRequest(validation.Errors != null ? validation.Errors : null, Validation.InvalidMessage);
            }

            try
            {
                var entidad = _mapper.Map<EntidadOficial>(request.entidad);

                // desencriptamos la pk y fk
                entidad.entidadoficial_id = string.IsNullOrEmpty(request.entidad.SerialKey) ? 0 : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.SerialKey, _userService.GetUser().authkey));
                entidad.entidad_id = string.IsNullOrEmpty(request.entidad.entidadkey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.entidadkey, _userService.GetUser().authkey));
                entidad.modalidad_id = string.IsNullOrEmpty(request.entidad.modalidadkey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.modalidadkey, _userService.GetUser().authkey));
                entidad.profesion_id = string.IsNullOrEmpty(request.entidad.profesionkey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.profesionkey, _userService.GetUser().authkey));
                entidad.usuario_act = _userService.GetUser().username;

                // guardamos el documento en el directorio y almacenamos la metadata
                entidad.designacion_doc = request.entidad.documento_designacion == null ? null : await _unitOfWork.DocumentRepository.SaveDocumentAsync(request.entidad.documento_designacion.filename, request.entidad.documento_designacion.base64content, PathKey.DocDesignacionOficial);

                // actualizamos la informacion
                var result = _unitOfWork.EntidadOficial.Update(entidad);

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
        public async Task<PcmResponse> Delete(Request<EntidadOficialDto> request)
        {
            var validation = _entidadOficialValidationManager.Validate(_mapper.Map<EntidadOficialIdRequest>(request.entidad));

            if (!validation.IsValid)
            {
                _logger.LogError(Validation.InvalidMessage);
                return ResponseUtil.BadRequest(validation.Errors != null ? validation.Errors : null, Validation.InvalidMessage);
            }

            try
            {
                var entidad = _mapper.Map<EntidadOficial>(request.entidad);

                entidad.entidadoficial_id = string.IsNullOrEmpty(request.entidad.SerialKey) ? 0 : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.SerialKey, _userService.GetUser().authkey));
                entidad.usuario_act = _userService.GetUser().username;

                var result = _unitOfWork.EntidadOficial.Delete(entidad);

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

        public async Task<PcmResponse> GetById(Request<EntidadOficialDto> request)
        {
            try
            {
                var validation = _entidadOficialValidationManager.Validate(_mapper.Map<EntidadOficialIdRequest>(request.entidad));

                if (!validation.IsValid)
                {
                    _logger.LogError(Validation.InvalidMessage);
                    return ResponseUtil.BadRequest(validation.Errors != null ? validation.Errors : null, Validation.InvalidMessage);
                }

                var entidad = _mapper.Map<EntidadOficial>(request.entidad);

                entidad.entidadoficial_id = string.IsNullOrEmpty(request.entidad.SerialKey) ? 0 : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.SerialKey, _userService.GetUser().authkey));
                entidad.entidad_id = string.IsNullOrEmpty(request.entidad.entidadkey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.entidadkey, _userService.GetUser().authkey));
                entidad.modalidad_id = string.IsNullOrEmpty(request.entidad.modalidadkey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.modalidadkey, _userService.GetUser().authkey));
                entidad.profesion_id = string.IsNullOrEmpty(request.entidad.profesionkey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.profesionkey, _userService.GetUser().authkey));
                
                var result = _unitOfWork.EntidadOficial.GetById(entidad);

                if (result.Error)
                {
                    _logger.LogError(result.Message);
                    return ResponseUtil.BadRequest(result.Message);
                }

                if (result.Data != null)
                {
                    entidad = new EntidadOficial
                    {
                        SerialKey = string.IsNullOrEmpty(result.Data.entidadoficial_id.ToString()) ? null : CShrapEncryption.EncryptString(result.Data.entidadoficial_id.ToString(), _userService.GetUser().authkey),
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
                    _mapper.Map<EntidadOficialResponse>(_mapper.Map<EntidadOficialDto>(entidad)), result.Message ?? TransactionMessage.QuerySuccess
                    ) : ResponseUtil.NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseUtil.InternalError(message: ex.Message);
            }
        }

        public async Task<PcmResponse> GetList(Request<EntidadOficialDto> request)
        {
            try
            {
                var entidad = _mapper.Map<EntidadOficial>(request.entidad);

                entidad.entidadoficial_id = string.IsNullOrEmpty(request.entidad.SerialKey) ? 0 : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.SerialKey, _userService.GetUser().authkey));
                entidad.entidad_id = string.IsNullOrEmpty(request.entidad.entidadkey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.entidadkey, _userService.GetUser().authkey));
                entidad.modalidad_id = string.IsNullOrEmpty(request.entidad.modalidadkey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.modalidadkey, _userService.GetUser().authkey));
                entidad.profesion_id = string.IsNullOrEmpty(request.entidad.profesionkey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.profesionkey, _userService.GetUser().authkey));

                var result = _unitOfWork.EntidadOficial.GetList(entidad);

                if (result.Error)
                {
                    _logger.LogError(result.Message);
                    return ResponseUtil.BadRequest(result.Message);
                }

                List<EntidadOficial> Lista = new List<EntidadOficial>();

                if (result.Data != null)
                {
                    foreach (var item in result.Data)
                    {
                        Lista.Add(new EntidadOficial()
                        {
                            SerialKey = string.IsNullOrEmpty(item.entidadoficial_id.ToString()) ? null : CShrapEncryption.EncryptString(item.entidadoficial_id.ToString(), _userService.GetUser().authkey),
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
                    _mapper.Map<List<EntidadOficialResponse>>(_mapper.Map<List<EntidadOficialDto>>(Lista)),
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
