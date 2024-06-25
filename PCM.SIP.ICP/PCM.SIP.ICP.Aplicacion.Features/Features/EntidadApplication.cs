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
    public class EntidadApplication : IEntidadApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppLogger<EntidadApplication> _logger;
        private readonly EntidadValidationManager _entidadValidationManager;
        private readonly IUserService _userService;

        public EntidadApplication(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IAppLogger<EntidadApplication> logger,
            EntidadValidationManager entidadValidationManager,
            IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _entidadValidationManager = entidadValidationManager;
            _userService = userService;
        }

        public async Task<PcmResponse> Insert(Request<EntidadDto> request)
        {
            try
            {
                var validation = _entidadValidationManager.Validate(_mapper.Map<EntidadInsertRequest>(request.entidad));

                if (!validation.IsValid)
                {
                    _logger.LogError(Validation.InvalidMessage);
                    return ResponseUtil.BadRequest(validation.Errors != null ? validation.Errors : null, Validation.InvalidMessage);
                }

                var entidad = _mapper.Map<Entidad>(request.entidad);

                entidad.entidadgrupo_id = string.IsNullOrEmpty(request.entidad.entidadgrupokey) ? 0 : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.entidadgrupokey, _userService.GetUser().authkey));
                entidad.entidadsector_id = string.IsNullOrEmpty(request.entidad.entidadsectorkey) ? 0 : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.entidadsectorkey, _userService.GetUser().authkey));
                entidad.usuario_reg = _userService.GetUser().username;

                var result = _unitOfWork.Entidad.Insert(entidad);

                if (result.Error)
                {
                    _logger.LogError(result.Message);
                    return ResponseUtil.BadRequest(message: result.Message, error: null);
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

        public async Task<PcmResponse> Update(Request<EntidadDto> request)
        {
            var validation = _entidadValidationManager.Validate(_mapper.Map<EntidadUpdateRequest>(request.entidad));

            if (!validation.IsValid)
            {
                _logger.LogError(Validation.InvalidMessage);
                return ResponseUtil.BadRequest(validation.Errors != null ? validation.Errors : null, Validation.InvalidMessage);
            }

            try
            {
                var entidad = _mapper.Map<Entidad>(request.entidad);

                entidad.entidad_id = string.IsNullOrEmpty(request.entidad.SerialKey) ? 0 : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.SerialKey, _userService.GetUser().authkey));
                entidad.entidadgrupo_id = string.IsNullOrEmpty(request.entidad.entidadgrupokey) ? 0 : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.entidadgrupokey, _userService.GetUser().authkey));
                entidad.entidadsector_id = string.IsNullOrEmpty(request.entidad.entidadsectorkey) ? 0 : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.entidadsectorkey, _userService.GetUser().authkey));
                entidad.usuario_act = _userService.GetUser().username;

                var result = _unitOfWork.Entidad.Update(entidad);

                if (result.Error)
                {
                    _logger.LogError(result.Message);
                    return ResponseUtil.BadRequest(message: result.Message, error: null);
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

        public async Task<PcmResponse> Delete(Request<EntidadDto> request)
        {
            var validation = _entidadValidationManager.Validate(_mapper.Map<EntidadIdRequest>(request.entidad));

            if (!validation.IsValid)
            {
                _logger.LogError(Validation.InvalidMessage);
                return ResponseUtil.BadRequest(validation.Errors != null ? validation.Errors : null, Validation.InvalidMessage);
            }

            try
            {
                var entidad = _mapper.Map<Entidad>(request.entidad);

                entidad.entidad_id = string.IsNullOrEmpty(request.entidad.SerialKey) ? 0 : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.SerialKey, _userService.GetUser().authkey));
                entidad.usuario_act = _userService.GetUser().username;

                var result = _unitOfWork.Entidad.Delete(entidad);

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

        public async Task<PcmResponse> GetById(Request<EntidadDto> request)
        {
            try
            {
                var validation = _entidadValidationManager.Validate(_mapper.Map<EntidadIdRequest>(request.entidad));

                if (!validation.IsValid)
                {
                    _logger.LogError(Validation.InvalidMessage);
                    return ResponseUtil.BadRequest(validation.Errors != null ? validation.Errors : null, Validation.InvalidMessage);
                }

                var entidad = _mapper.Map<Entidad>(request.entidad);

                entidad.entidad_id = string.IsNullOrEmpty(request.entidad.SerialKey) ? 0 : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.SerialKey, _userService.GetUser().authkey));
                entidad.entidadgrupo_id = string.IsNullOrEmpty(request.entidad.entidadgrupokey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.entidadgrupokey, _userService.GetUser().authkey));
                entidad.entidadsector_id = string.IsNullOrEmpty(request.entidad.entidadsectorkey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.entidadsectorkey, _userService.GetUser().authkey));

                var result = _unitOfWork.Entidad.GetById(entidad);

                if (result.Error)
                {
                    _logger.LogError(result.Message);
                    return ResponseUtil.BadRequest(message: result.Message, error: null);
                }

                if (result.Data != null)
                {
                    entidad = new Entidad
                    {
                        SerialKey = string.IsNullOrEmpty(result.Data.entidad_id.ToString()) ? null : CShrapEncryption.EncryptString(result.Data.entidad_id.ToString(), _userService.GetUser().authkey),
                        entidadgrupokey = string.IsNullOrEmpty(result.Data.entidadgrupo_id == null ? null : result.Data.entidadgrupo_id.ToString()) ? null : CShrapEncryption.EncryptString(result.Data.entidadgrupo_id.ToString(), _userService.GetUser().authkey),
                        entidadsectorkey = string.IsNullOrEmpty(result.Data.entidadsector_id == null ? null : result.Data.entidadsector_id.ToString()) ? null : CShrapEncryption.EncryptString(result.Data.entidadsector_id.ToString(), _userService.GetUser().authkey),
                        numero_ruc = result.Data.numero_ruc,
                        codigo = result.Data.codigo,
                        acronimo = result.Data.acronimo,
                        nombre = result.Data.nombre,
                        entidadgrupo = new EntidadGrupo
                        {
                            codigo = result.Data.entidadgrupo_codigo,
                            descripcion = result.Data.entidadgrupo_descripcion,
                            abreviatura = result.Data.entidadgrupo_abreviatura
                        },
                        entidadsector = new EntidadSector
                        {
                            codigo = result.Data.entidadsector_codigo,
                            descripcion = result.Data.entidadsector_descripcion,
                            abreviatura = result.Data.entidadsector_abreviatura
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
                    _mapper.Map<EntidadResponse>(_mapper.Map<EntidadDto>(entidad)), result.Message ?? TransactionMessage.QuerySuccess
                    ) : ResponseUtil.NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseUtil.InternalError(message: ex.Message);
            }
        }

        public async Task<PcmResponse> GetList(Request<EntidadDto> request)
        {
            try
            {
                var entidad = _mapper.Map<Entidad>(request.entidad);

                entidad.entidad_id = string.IsNullOrEmpty(request.entidad.SerialKey) ? 0 : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.SerialKey, _userService.GetUser().authkey));
                entidad.entidadgrupo_id = string.IsNullOrEmpty(request.entidad.entidadgrupokey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.entidadgrupokey, _userService.GetUser().authkey));
                entidad.entidadsector_id = string.IsNullOrEmpty(request.entidad.entidadsectorkey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.entidadsectorkey, _userService.GetUser().authkey));

                var result = _unitOfWork.Entidad.GetList(entidad);

                if (result.Error)
                {
                    _logger.LogError(result.Message);
                    return ResponseUtil.BadRequest(message: result.Message, error: null);
                }

                List<Entidad> Lista = new List<Entidad>();

                if (result.Data != null)
                {
                    foreach (var item in result.Data)
                    {
                        Lista.Add(new Entidad()
                        {
                            SerialKey = string.IsNullOrEmpty(item.entidad_id.ToString()) ? null : CShrapEncryption.EncryptString(item.entidad_id.ToString(), _userService.GetUser().authkey),
                            entidadgrupokey = string.IsNullOrEmpty(item.entidadgrupo_id == null ? null : item.entidadgrupo_id.ToString()) ? null : CShrapEncryption.EncryptString(item.entidadgrupo_id.ToString(), _userService.GetUser().authkey),
                            entidadsectorkey = string.IsNullOrEmpty(item.entidadsector_id == null ? null : item.entidadsector_id.ToString()) ? null : CShrapEncryption.EncryptString(item.entidadsector_id.ToString(), _userService.GetUser().authkey),
                            numero_ruc = item.numero_ruc,
                            codigo = item.codigo,
                            acronimo = item.acronimo,
                            nombre = item.nombre,
                            entidadgrupo = new EntidadGrupo
                            {
                                codigo = item.entidadgrupo_codigo,
                                descripcion = item.entidadgrupo_descripcion,
                                abreviatura = item.entidadgrupo_abreviatura
                            },
                            entidadsector = new EntidadSector
                            {
                                codigo = item.entidadsector_codigo,
                                descripcion = item.entidadsector_descripcion,
                                abreviatura = item.entidadsector_abreviatura
                            },
                            usuario_reg = item.usuario_reg,
                            fecha_reg = item.fecha_reg
                        });
                    }
                }

                _logger.LogInformation(TransactionMessage.QuerySuccess);
                return result != null ? ResponseUtil.Ok(
                    _mapper.Map<List<EntidadResponse>>(_mapper.Map<List<EntidadDto>>(Lista)),
                    result.Message ?? TransactionMessage.QuerySuccess
                    ) : ResponseUtil.NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseUtil.InternalError(message: ex.Message);
            }
        }

        public async Task<PcmResponse> UpdateGeneralidades(Request<EntidadDto> request)
        {
            var validation = _entidadValidationManager.Validate(_mapper.Map<GeneralidadesUpdateRequest>(request.entidad));

            if (!validation.IsValid)
            {
                _logger.LogError(Validation.InvalidMessage);
                return ResponseUtil.BadRequest(validation.Errors != null ? validation.Errors : null, Validation.InvalidMessage);
            }

            try
            {
                var entidad = _mapper.Map<Entidad>(request.entidad);

                entidad.entidad_id = string.IsNullOrEmpty(request.entidad.SerialKey) ? 0 : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.SerialKey, _userService.GetUser().authkey));
                entidad.ubigeo_id = string.IsNullOrEmpty(request.entidad.ubigeokey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.ubigeokey, _userService.GetUser().authkey));
                entidad.documentoestructura_id = string.IsNullOrEmpty(request.entidad.documentoestructurakey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.documentoestructurakey, _userService.GetUser().authkey));
                entidad.modalidadintegridad_id = string.IsNullOrEmpty(request.entidad.modalidadintegridadkey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.modalidadintegridadkey, _userService.GetUser().authkey));
                entidad.usuario_act = _userService.GetUser().username;

                // guardamos los documentos y obtenemos la metadata
                entidad.documentoestructura_doc = await _unitOfWork.DocumentRepository.SaveDocumentAsync(request.entidad.documento_estructura.filename, request.entidad.documento_estructura.base64content, PathKey.DocEstructura);
                entidad.documentointegridad_doc = await _unitOfWork.DocumentRepository.SaveDocumentAsync(request.entidad.documento_integridad.filename, request.entidad.documento_integridad.base64content, PathKey.DocModalidadIntegridad);
                entidad.modalidadintegridad_doc = await _unitOfWork.DocumentRepository.SaveDocumentAsync(request.entidad.documento_modalidadintegridad.filename, request.entidad.documento_modalidadintegridad.base64content, PathKey.DocIntegridad);

                var result = _unitOfWork.Entidad.UpdateGeneralidades(entidad);

                if (result.Error)
                {
                    _logger.LogError(result.Message);
                    return ResponseUtil.BadRequest(message: result.Message, error: null);
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

        public async Task<PcmResponse> GetListGeneralidades(Request<EntidadDto> request)
        {
            try
            {
                var entidad = _mapper.Map<Entidad>(request.entidad);

                entidad.entidad_id = string.IsNullOrEmpty(request.entidad.SerialKey) ? 0 : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.SerialKey, _userService.GetUser().authkey));
                entidad.entidadgrupo_id = string.IsNullOrEmpty(request.entidad.entidadgrupokey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.entidadgrupokey, _userService.GetUser().authkey));
                entidad.entidadsector_id = string.IsNullOrEmpty(request.entidad.entidadsectorkey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.entidadsectorkey, _userService.GetUser().authkey));
                entidad.ubigeo_id = string.IsNullOrEmpty(request.entidad.ubigeokey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.ubigeokey, _userService.GetUser().authkey));
                entidad.documentoestructura_id = string.IsNullOrEmpty(request.entidad.documentoestructurakey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.documentoestructurakey, _userService.GetUser().authkey));
                entidad.modalidadintegridad_id = string.IsNullOrEmpty(request.entidad.modalidadintegridadkey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.modalidadintegridadkey, _userService.GetUser().authkey));

                var result = _unitOfWork.Entidad.GetListGeneralidades(entidad);

                if (result.Error)
                {
                    _logger.LogError(result.Message);
                    return ResponseUtil.BadRequest(message: result.Message, error: null);
                }

                List<Entidad> Lista = new List<Entidad>();

                if (result.Data != null)
                {
                    foreach (var item in result.Data)
                    {
                        Lista.Add(new Entidad()
                        {
                            SerialKey = string.IsNullOrEmpty(item.entidad_id.ToString()) ? null : CShrapEncryption.EncryptString(item.entidad_id.ToString(), _userService.GetUser().authkey),
                            entidadgrupokey = string.IsNullOrEmpty(item.entidadgrupo_id == null ? null : item.entidadgrupo_id.ToString()) ? null : CShrapEncryption.EncryptString(item.entidadgrupo_id.ToString(), _userService.GetUser().authkey),
                            entidadsectorkey = string.IsNullOrEmpty(item.entidadsector_id == null ? null : item.entidadsector_id.ToString()) ? null : CShrapEncryption.EncryptString(item.entidadsector_id.ToString(), _userService.GetUser().authkey),
                            documentoestructurakey = string.IsNullOrEmpty(item.documentoestructura_id == null ? null : item.documentoestructura_id.ToString()) ? null : CShrapEncryption.EncryptString(item.documentoestructura_id.ToString(), _userService.GetUser().authkey),
                            ubigeokey = string.IsNullOrEmpty(item.ubigeo_id == null ? null : item.ubigeo_id.ToString()) ? null : CShrapEncryption.EncryptString(item.ubigeo_id.ToString(), _userService.GetUser().authkey),
                            modalidadintegridadkey = string.IsNullOrEmpty(item.modalidadintegridad_id == null ? null : item.modalidadintegridad_id.ToString()) ? null : CShrapEncryption.EncryptString(item.modalidadintegridad_id.ToString(), _userService.GetUser().authkey),
                            numero_ruc = item.numero_ruc,
                            codigo = item.codigo,
                            acronimo = item.acronimo,
                            nombre = item.nombre,
                            generalidades = item.generalidades,                            
                            modalidadintegridad_doc = item.modalidadintegridad_doc,
                            modalidadintegridad_anterior = item.modalidadintegridad_anterior,
                            documentointegridad_desc = item.documentointegridad_desc,
                            documentointegridad_doc = item.documentointegridad_doc,
                            num_servidores = item.num_servidores,
                            documento_estructura = string.IsNullOrEmpty(item.documentoestructura_doc) ? null : JsonSerializer.Deserialize<Document>(item.documentoestructura_doc),
                            documento_modalidadintegridad = string.IsNullOrEmpty(item.modalidadintegridad_doc) ? null : JsonSerializer.Deserialize<Document>(item.modalidadintegridad_doc),
                            documento_integridad = string.IsNullOrEmpty(item.documentointegridad_doc) ? null : JsonSerializer.Deserialize<Document>(item.documentointegridad_doc),
                            ubigeo = new Ubigeo
                            {
                                departamento_inei = item.ubigeo_departamento_inei,
                                provincia_inei = item.ubigeo_provincia_inei,
                                departamento = item.ubigeo_departamento,
                                provincia = item.ubigeo_provincia,
                                distrito = item.ubigeo_distrito
                            },
                            entidadgrupo = new EntidadGrupo
                            {
                                codigo = item.entidadgrupo_codigo,
                                descripcion = item.entidadgrupo_descripcion,
                                abreviatura = item.entidadgrupo_abreviatura
                            },
                            entidadsector = new EntidadSector
                            {
                                codigo = item.entidadsector_codigo,
                                descripcion = item.entidadsector_descripcion,
                                abreviatura = item.entidadsector_abreviatura
                            },
                            documentoestructura = new DocumentoEstructura
                            {
                                codigo = item.doccumentoestructura_codigo,
                                descripcion = item.doccumentoestructura_abreviatura,
                                abreviatura = item.doccumentoestructura_descripcion
                            },
                            modalidadintegridad = new ModalidadIntegridad
                            {
                                codigo = item.modalidadintegridad_codigo,
                                abreviatura = item.modalidadintegridad_abreviatura,
                                descripcion = item.modalidadintegridad_descripcion
                            },
                            usuario_reg = item.usuario_reg,
                            fecha_reg = item.fecha_reg
                        });
                    }
                }

                _logger.LogInformation(TransactionMessage.QuerySuccess);
                return result != null ? ResponseUtil.Ok(
                    _mapper.Map<List<GeneralidadesResponse>>(_mapper.Map<List<EntidadDto>>(Lista)),
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
