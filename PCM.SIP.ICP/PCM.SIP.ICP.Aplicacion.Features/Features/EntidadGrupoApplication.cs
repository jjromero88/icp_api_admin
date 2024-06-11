using AutoMapper;
using PCM.SIP.ICP.Aplicacion.Dto;
using PCM.SIP.ICP.Aplicacion.Interface;
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

        public EntidadGrupoApplication(
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            IAppLogger<EntidadGrupoApplication> logger, 
            EntidadGrupoValidationManager perfilValidationManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _perfilValidationManager = perfilValidationManager;
        }

        public PcmResponse Insert(Request<EntidadGrupoDto> request)
        {
            throw new NotImplementedException();
        }

        public PcmResponse Update(Request<EntidadGrupoDto> request)
        {
            throw new NotImplementedException();
        }

        public PcmResponse Delete(Request<EntidadGrupoDto> request)
        {
            throw new NotImplementedException();
        }

        public PcmResponse GetById(Request<EntidadGrupoDto> request)
        {
            throw new NotImplementedException();
        }

        public PcmResponse GetList(Request<EntidadGrupoDto> request)
        {
            throw new NotImplementedException();
        }
    }
}
