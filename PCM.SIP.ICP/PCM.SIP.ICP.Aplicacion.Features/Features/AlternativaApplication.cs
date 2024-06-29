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
    public class AlternativaApplication : IAlternativaApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppLogger<AlternativaApplication> _logger;
        private readonly IUserService _userService;

        public AlternativaApplication(
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            IAppLogger<AlternativaApplication> logger, 
            IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _userService = userService;
        }

        public async Task<PcmResponse> GetList(Request<AlternativaDto> request)
        {
            try
            {
                var entidad = _mapper.Map<Alternativa>(request.entidad);

                entidad.alternativa_id = string.IsNullOrEmpty(request.entidad.SerialKey) ? 0 : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.SerialKey, _userService.GetUser().authkey));
                entidad.pregunta_id = string.IsNullOrEmpty(request.entidad.preguntakey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.preguntakey, _userService.GetUser().authkey));

                var result = _unitOfWork.Alternativa.GetList(entidad);

                if (result.Error)
                {
                    _logger.LogError(result.Message);
                    return ResponseUtil.InternalError(message: result.Message);
                }

                List<Alternativa> Lista = new List<Alternativa>();

                if (result.Data != null)
                {
                    foreach (var item in result.Data)
                    {
                        Lista.Add(new Alternativa()
                        {
                            SerialKey = string.IsNullOrEmpty(item.alternativa_id.ToString()) ? null : CShrapEncryption.EncryptString(item.alternativa_id.ToString(), _userService.GetUser().authkey),
                            codigo = item.codigo,
                            alternativa = item.alternativa,
                            descripcion = item.descripcion,
                            valor = item.valor,
                            medio_verificacion = item.medio_verificacion,
                            numero_orden = item.numero_orden,
                            usuario_reg = item.usuario_reg,
                            fecha_reg = item.fecha_reg
                        });
                    }
                }

                _logger.LogInformation(TransactionMessage.QuerySuccess);
                return result != null ? ResponseUtil.Ok(
                    _mapper.Map<List<AlternativaResponse>>(_mapper.Map<List<AlternativaDto>>(Lista)),
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
