using AutoMapper;
using PCM.SIP.ICP.Aplicacion.Dto;
using PCM.SIP.ICP.Aplicacion.Interface;
using PCM.SIP.ICP.Aplicacion.Interface.Features;
using PCM.SIP.ICP.Aplicacion.Interface.Infraestructure;
using PCM.SIP.ICP.Aplicacion.Validator;
using PCM.SIP.ICP.Transversal.Common;
using PCM.SIP.ICP.Transversal.Common.Generics;

namespace PCM.SIP.ICP.Aplicacion.Features
{
    public class EntidadGrupoApplication : IEntidadGrupoApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppLogger<EntidadGrupoApplication> _logger;
        private readonly EntidadGrupoValidationManager _perfilValidationManager;
        private readonly IUserService _userService;

        public EntidadGrupoApplication(
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            IAppLogger<EntidadGrupoApplication> logger, 
            EntidadGrupoValidationManager perfilValidationManager,
            IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _perfilValidationManager = perfilValidationManager;
            _userService = userService;
        }

        public Task<PcmResponse> Insert(Request<EntidadGrupoDto> request)
        {
            throw new NotImplementedException();
        }

        public Task<PcmResponse> Update(Request<EntidadGrupoDto> request)
        {
            throw new NotImplementedException();
        }

        public Task<PcmResponse> Delete(Request<EntidadGrupoDto> request)
        {
            throw new NotImplementedException();
        }

        public Task<PcmResponse> GetById(Request<EntidadGrupoDto> request)
        {
            throw new NotImplementedException();
        }

        public Task<PcmResponse> GetList(Request<EntidadGrupoDto> request)
        {
            var user = _userService.GetUser();
            throw new NotImplementedException();
        }        
    }
}
