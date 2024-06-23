using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCM.SIP.ICP.Api.Filters;
using PCM.SIP.ICP.Aplicacion.Dto;
using PCM.SIP.ICP.Aplicacion.Interface.Features;
using PCM.SIP.ICP.Transversal.Common.Generics;
using PCM.SIP.ICP.Transversal.Common;
using System.Net;

namespace PCM.SIP.ICP.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralidadesController : Controller
    {
        private readonly IEntidadApplication _entidadApplication;
        private readonly IMapper _mapper;

        public GeneralidadesController(IEntidadApplication entidadApplication, IMapper mapper)
        {
            _entidadApplication = entidadApplication;
            _mapper = mapper;
        }

        [HttpPut("Update")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> Update([FromBody] GeneralidadesUpdateRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _entidadApplication.UpdateGeneralidades(new Request<EntidadDto>() { entidad = _mapper.Map<EntidadDto>(request) });
        }

        [HttpGet("GetList")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> GetList([FromQuery] GeneralidadesFilterRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _entidadApplication.GetListGeneralidades(new Request<EntidadDto>() { entidad = _mapper.Map<EntidadDto>(request) });
        }

    }
}
