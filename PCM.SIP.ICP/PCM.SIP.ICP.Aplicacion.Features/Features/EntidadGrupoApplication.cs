using AutoMapper;
using PCM.SIP.ICP.Aplicacion.Dto;
using PCM.SIP.ICP.Aplicacion.Interface;
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
        private readonly ISecurityService _securityService;

        public EntidadGrupoApplication(
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            IAppLogger<EntidadGrupoApplication> logger, 
            EntidadGrupoValidationManager perfilValidationManager,
            ISecurityService securityService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _perfilValidationManager = perfilValidationManager;
            _securityService = securityService;
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
            var cache = _securityService.GetSessionDataAsync("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Impqcm9tZXJvODgiLCJpZHNlc3Npb24iOiIzNGM2MzU1MS1iMjU4LTQ3MDItYTRlOS02MWNjNWMxZjQ0NTciLCJuYmYiOjE3MTgxMzE4MDgsImV4cCI6MTcxODE2MDYwOCwiaWF0IjoxNzE4MTMxODA4LCJpc3MiOiJnb2IucGUiLCJhdWQiOiJnb2IucGUifQ.FHQhZuuiqC4Jud0nQkqZJVinkKKuRKWYIYlVrj0ltD4");
            throw new NotImplementedException();
        }

        public Task<PcmResponse> Insert(Request<EntidadGrupoDto> request)
        {
            throw new NotImplementedException();
        }

        public Task<PcmResponse> Update(Request<EntidadGrupoDto> request)
        {
            throw new NotImplementedException();
        }
    }
}
