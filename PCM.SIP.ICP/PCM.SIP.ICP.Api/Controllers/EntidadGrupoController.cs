using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCM.SIP.ICP.Aplicacion.Features;
using PCM.SIP.ICP.Transversal.Common.Generics;
using PCM.SIP.ICP.Transversal.Common;
using System.Net;
using PCM.SIP.ICP.Aplicacion.Dto;
using PCM.SIP.ICP.Api.Filters;

namespace PCM.SIP.ICP.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EntidadGrupoController : Controller
    {
        private readonly IEntidadGrupoApplication _EntidadGrupoApplication;
        private readonly IMapper _mapper;

        public EntidadGrupoController(IEntidadGrupoApplication entidadGrupoApplication, IMapper mapper)
        {
            _EntidadGrupoApplication = entidadGrupoApplication;
            _mapper = mapper;
        }

        [HttpGet("GetList")]
        //[ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> GetList([FromQuery] EntidadGrupoFilterRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _EntidadGrupoApplication.GetList(new Request<EntidadGrupoDto>() { entidad = _mapper.Map<EntidadGrupoDto>(request) });
        }

    }
}
