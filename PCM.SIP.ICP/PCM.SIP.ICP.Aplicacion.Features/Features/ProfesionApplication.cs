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
    public class ProfesionApplication : IProfesionApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppLogger<ProfesionApplication> _logger;
        private readonly IUserService _userService;

        public ProfesionApplication(
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            IAppLogger<ProfesionApplication> logger, 
            IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _userService = userService;
        }

        public async Task<PcmResponse> GetList(Request<ProfesionDto> request)
        {
            try
            {
                var entidad = _mapper.Map<Profesion>(request.entidad);

                entidad.profesion_id = string.IsNullOrEmpty(request.entidad.SerialKey) ? 0 : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.SerialKey, _userService.GetUser().authkey));

                var result = _unitOfWork.Profesion.GetList(entidad);

                if (result.Error)
                {
                    _logger.LogError(result.Message);
                    return ResponseUtil.InternalError(message: result.Message);
                }

                List<Profesion> Lista = new List<Profesion>();

                if (result.Data != null)
                {
                    foreach (var item in result.Data)
                    {
                        Lista.Add(new Profesion()
                        {
                            SerialKey = string.IsNullOrEmpty(item.profesion_id.ToString()) ? null : CShrapEncryption.EncryptString(item.profesion_id.ToString(), _userService.GetUser().authkey),
                            codigo = item.codigo,
                            descripcion = item.descripcion,
                            usuario_reg = item.usuario_reg,
                            fecha_reg = item.fecha_reg
                        });
                    }
                }

                _logger.LogInformation(TransactionMessage.QuerySuccess);
                return result != null ? ResponseUtil.Ok(
                    _mapper.Map<List<ProfesionResponse>>(_mapper.Map<List<ProfesionDto>>(Lista)),
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
