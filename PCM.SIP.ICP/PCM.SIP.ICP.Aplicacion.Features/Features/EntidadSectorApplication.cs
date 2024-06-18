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
    public class EntidadSectorApplication : IEntidadSectorApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppLogger<EntidadSectorApplication> _logger;
        private readonly IUserService _userService;

        public EntidadSectorApplication(
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            IAppLogger<EntidadSectorApplication> logger, 
            IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _userService = userService;
        }

        public async Task<PcmResponse> GetList(Request<EntidadSectorDto> request)
        {
            try
            {
                var entidad = _mapper.Map<EntidadSector>(request.entidad);

                entidad.entidadsector_id = string.IsNullOrEmpty(request.entidad.SerialKey) ? 0 : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.SerialKey, _userService.GetUser().authkey));

                var result = _unitOfWork.EntidadSector.GetList(entidad);

                if (result.Error)
                {
                    _logger.LogError(result.Message);
                    return ResponseUtil.InternalError(message: result.Message);
                }

                List<EntidadSector> Lista = new List<EntidadSector>();

                if (result.Data != null)
                {

                    foreach (var item in result.Data)
                    {
                        var tiposectorkey = string.IsNullOrEmpty(item.tiposector_id.ToString()) ? null : CShrapEncryption.EncryptString(item.tiposector_id.ToString(), _userService.GetUser().authkey);

                        Lista.Add(new EntidadSector()
                        {
                            SerialKey = string.IsNullOrEmpty(item.entidadsector_id.ToString()) ? null : CShrapEncryption.EncryptString(item.entidadsector_id.ToString(), _userService.GetUser().authkey),
                            tiposectorkey = tiposectorkey,
                            codigo = item.codigo,
                            abreviatura = item.abreviatura,
                            descripcion = item.descripcion,
                            usuario_reg = item.usuario_reg,
                            fecha_reg = item.fecha_reg,
                            tiposector = new TipoSector
                            {
                                SerialKey = tiposectorkey,
                                codigo = item.tiposector_codigo,
                                descripcion = item.tiposector_descripcion
                            }
                        });
                    }
                }

                _logger.LogInformation(TransactionMessage.QuerySuccess);
                return result != null ? ResponseUtil.Ok(
                    _mapper.Map<List<EntidadSectorResponse>>(_mapper.Map<List<EntidadSectorDto>>(Lista)),
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
