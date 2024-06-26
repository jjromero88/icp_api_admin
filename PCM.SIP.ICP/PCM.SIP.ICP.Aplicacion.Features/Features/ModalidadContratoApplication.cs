using AutoMapper;
using PCM.SIP.ICP.Aplicacion.Interface.Infraestructure;
using PCM.SIP.ICP.Aplicacion.Interface;
using PCM.SIP.ICP.Transversal.Common;
using PCM.SIP.ICP.Aplicacion.Interface.Features;
using PCM.SIP.ICP.Transversal.Common.Generics;
using PCM.SIP.ICP.Aplicacion.Dto;
using PCM.SIP.ICP.Domain.Entities;
using PCM.SIP.ICP.Transversal.Common.Constants;
using PCM.SIP.ICP.Transversal.Util.Encryptions;

namespace PCM.SIP.ICP.Aplicacion.Features
{
    public class ModalidadContratoApplication: IModalidadContratoApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppLogger<ModalidadContratoApplication> _logger;
        private readonly IUserService _userService;

        public ModalidadContratoApplication(
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            IAppLogger<ModalidadContratoApplication> logger, 
            IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _userService = userService;
        }

        public async Task<PcmResponse> GetList(Request<ModalidadContratoDto> request)
        {
            try
            {
                var entidad = _mapper.Map<ModalidadContrato>(request.entidad);

                entidad.modalidad_id = string.IsNullOrEmpty(request.entidad.SerialKey) ? 0 : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.SerialKey, _userService.GetUser().authkey));

                var result = _unitOfWork.ModalidadContrato.GetList(entidad);

                if (result.Error)
                {
                    _logger.LogError(result.Message);
                    return ResponseUtil.InternalError(message: result.Message);
                }

                List<ModalidadContrato> Lista = new List<ModalidadContrato>();

                if (result.Data != null)
                {
                    foreach (var item in result.Data)
                    {
                        Lista.Add(new ModalidadContrato()
                        {
                            SerialKey = string.IsNullOrEmpty(item.modalidad_id.ToString()) ? null : CShrapEncryption.EncryptString(item.modalidad_id.ToString(), _userService.GetUser().authkey),
                            codigo = item.codigo,
                            descripcion = item.descripcion,
                            abreviatura = item.abreviatura,
                            usuario_reg = item.usuario_reg,
                            fecha_reg = item.fecha_reg
                        });
                    }
                }

                _logger.LogInformation(TransactionMessage.QuerySuccess);
                return result != null ? ResponseUtil.Ok(
                    _mapper.Map<List<ModalidadContratoResponse>>(_mapper.Map<List<ModalidadContratoDto>>(Lista)),
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
