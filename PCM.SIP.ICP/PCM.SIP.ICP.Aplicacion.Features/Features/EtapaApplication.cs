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
    public class EtapaApplication : IEtapaApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppLogger<EtapaApplication> _logger;
        private readonly IUserService _userService;

        public EtapaApplication(
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            IAppLogger<EtapaApplication> logger, 
            IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _userService = userService;
        }

        public async Task<PcmResponse> GetList(Request<EtapaDto> request)
        {
            try
            {
                var entidad = _mapper.Map<Etapa>(request.entidad);

                entidad.etapa_id = string.IsNullOrEmpty(request.entidad.SerialKey) ? 0 : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.SerialKey, _userService.GetUser().authkey));

                var result = _unitOfWork.Etapa.GetList(entidad);

                if (result.Error)
                {
                    _logger.LogError(result.Message);
                    return ResponseUtil.InternalError(message: result.Message);
                }

                List<Etapa> Lista = new List<Etapa>();

                if (result.Data != null)
                {
                    foreach (var item in result.Data)
                    {
                        Lista.Add(new Etapa()
                        {
                            SerialKey = string.IsNullOrEmpty(item.etapa_id.ToString()) ? null : CShrapEncryption.EncryptString(item.etapa_id.ToString(), _userService.GetUser().authkey),
                            codigo = item.codigo,
                            nombre = item.nombre,
                            descripcion = item.descripcion,
                            abreviatura = item.abreviatura,
                            usuario_reg = item.usuario_reg,
                            fecha_reg = item.fecha_reg
                        });
                    }
                }

                _logger.LogInformation(TransactionMessage.QuerySuccess);
                return result != null ? ResponseUtil.Ok(
                    _mapper.Map<List<EtapaResponse>>(_mapper.Map<List<EtapaDto>>(Lista)),
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
