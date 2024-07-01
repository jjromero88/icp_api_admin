using AutoMapper;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCM.SIP.ICP.Api.Filters;
using PCM.SIP.ICP.Aplicacion.Dto;
using PCM.SIP.ICP.Aplicacion.Interface.Features;
using PCM.SIP.ICP.Transversal.Common.Generics;
using PCM.SIP.ICP.Transversal.Common;

namespace PCM.SIP.ICP.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EtapaController : Controller
    {
        private readonly IEtapaApplication _etapaApplication;
        private readonly IMapper _mapper;

        public EtapaController(IEtapaApplication etapaApplication, IMapper mapper)
        {
            _etapaApplication = etapaApplication;
            _mapper = mapper;
        }

        [HttpGet("GetList")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> GetList([FromQuery] EtapaFilterRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _etapaApplication.GetList(new Request<EtapaDto>() { entidad = _mapper.Map<EtapaDto>(request) });
        }
    }
}
