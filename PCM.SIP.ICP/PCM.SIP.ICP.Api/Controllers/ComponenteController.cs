using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCM.SIP.ICP.Api.Filters;
using PCM.SIP.ICP.Aplicacion.Dto;
using PCM.SIP.ICP.Aplicacion.Features;
using PCM.SIP.ICP.Aplicacion.Interface.Features;
using PCM.SIP.ICP.Transversal.Common.Generics;
using PCM.SIP.ICP.Transversal.Common;
using System.Net;

namespace PCM.SIP.ICP.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ComponenteController : Controller
    {
        private readonly IComponenteApplication _componenteApplication;
        private readonly IMapper _mapper;

        public ComponenteController(IComponenteApplication componenteApplication, IMapper mapper)
        {
            _componenteApplication = componenteApplication;
            _mapper = mapper;
        }

        [HttpGet("GetList")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> GetList([FromQuery] ComponenteFilterRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _componenteApplication.GetList(new Request<ComponenteDto>() { entidad = _mapper.Map<ComponenteDto>(request) });
        }
    }
}
