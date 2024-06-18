using AutoMapper;
using PCM.SIP.ICP.Aplicacion.Dto;
using PCM.SIP.ICP.Aplicacion.Interface;
using PCM.SIP.ICP.Aplicacion.Interface.Features;
using PCM.SIP.ICP.Aplicacion.Interface.Infraestructure;
using PCM.SIP.ICP.Domain.Entities;
using PCM.SIP.ICP.Transversal.Common;
using PCM.SIP.ICP.Transversal.Common.Constants;
using PCM.SIP.ICP.Transversal.Common.Generics;
using PCM.SIP.ICP.Transversal.Util.Encryptions;

namespace PCM.SIP.ICP.Aplicacion.Features
{
    public class UbigeoApplication : IUbigeoApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppLogger<UbigeoApplication> _logger;
        private readonly IUserService _userService;

        public UbigeoApplication(
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            IAppLogger<UbigeoApplication> logger, 
            IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _userService = userService;
        }

        public async Task<PcmResponse> GetListDepartamento()
        {
            try
            {
                var result = _unitOfWork.Ubigeo.GetListDepartamentos();

                if (result.Error)
                {
                    _logger.LogError(result.Message);
                    return ResponseUtil.InternalError(message: result.Message);
                }

                List<Ubigeo> Lista = new List<Ubigeo>();

                if (result.Data != null)
                {
                    foreach (var item in result.Data)
                    {
                        Lista.Add(new Ubigeo()
                        {
                            departamento_inei = item.departamento_inei,
                            departamento = item.departamento
                        });
                    }
                }

                _logger.LogInformation(TransactionMessage.QuerySuccess);
                return result != null ? ResponseUtil.Ok(
                    _mapper.Map<List<DepartamentoResponse>>(_mapper.Map<List<UbigeoDto>>(Lista)),
                    result.Message ?? TransactionMessage.QuerySuccess
                    ) : ResponseUtil.NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseUtil.InternalError(message: ex.Message);
            }
        }

        public async Task<PcmResponse> GetListProvincia(Request<UbigeoDto> request)
        {
            try
            {
                var entidad = _mapper.Map<Ubigeo>(request.entidad);

                var result = _unitOfWork.Ubigeo.GetListProvincias(entidad);

                if (result.Error)
                {
                    _logger.LogError(result.Message);
                    return ResponseUtil.InternalError(message: result.Message);
                }

                List<Ubigeo> Lista = new List<Ubigeo>();

                if (result.Data != null)
                {
                    foreach (var item in result.Data)
                    {
                        Lista.Add(new Ubigeo()
                        {
                            departamento_inei = item.departamento_inei,
                            provincia_inei = item.provincia_inei,
                            provincia = item.provincia
                        });
                    }
                }

                _logger.LogInformation(TransactionMessage.QuerySuccess);
                return result != null ? ResponseUtil.Ok(
                    _mapper.Map<List<ProvinciaResponse>>(_mapper.Map<List<UbigeoDto>>(Lista)),
                    result.Message ?? TransactionMessage.QuerySuccess
                    ) : ResponseUtil.NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseUtil.InternalError(message: ex.Message);
            }
        }

        public async Task<PcmResponse> GetListDistrito(Request<UbigeoDto> request)
        {
            try
            {
                var entidad = _mapper.Map<Ubigeo>(request.entidad);

                var result = _unitOfWork.Ubigeo.GetListDistritos(entidad);

                if (result.Error)
                {
                    _logger.LogError(result.Message);
                    return ResponseUtil.InternalError(message: result.Message);
                }

                List<Ubigeo> Lista = new List<Ubigeo>();

                if (result.Data != null)
                {
                    foreach (var item in result.Data)
                    {
                        Lista.Add(new Ubigeo()
                        {
                            SerialKey = string.IsNullOrEmpty(item.ubigeo_id.ToString()) ? null : CShrapEncryption.EncryptString(item.ubigeo_id.ToString(), _userService.GetUser().authkey),
                            distrito = item.distrito
                        });
                    }
                }

                _logger.LogInformation(TransactionMessage.QuerySuccess);
                return result != null ? ResponseUtil.Ok(
                    _mapper.Map<List<DistritoResponse>>(_mapper.Map<List<UbigeoDto>>(Lista)),
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
