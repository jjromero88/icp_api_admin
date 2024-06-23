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
    public class EntidadController : Controller
    {
        private readonly IEntidadApplication _entidadApplication;
        private readonly IMapper _mapper;

        public EntidadController(IEntidadApplication entidadApplication, IMapper mapper)
        {
            _entidadApplication = entidadApplication;
            _mapper = mapper;
        }

        [HttpGet("GetById")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> GetById([FromQuery] EntidadIdRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _entidadApplication.GetById(new Request<EntidadDto>() { entidad = _mapper.Map<EntidadDto>(request) });
        }

        [HttpGet("GetList")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> GetList([FromQuery] EntidadFilterRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _entidadApplication.GetList(new Request<EntidadDto>() { entidad = _mapper.Map<EntidadDto>(request) });
        }

        [HttpPost("Insert")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> Insert([FromBody] EntidadInsertRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _entidadApplication.Insert(new Request<EntidadDto>() { entidad = _mapper.Map<EntidadDto>(request) });
        }

        [HttpPut("Update")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> Update([FromBody] EntidadUpdateRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _entidadApplication.Update(new Request<EntidadDto>() { entidad = _mapper.Map<EntidadDto>(request) });
        }

        [HttpDelete("Delete")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> DeleteObject([FromBody] EntidadIdRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _entidadApplication.Delete(new Request<EntidadDto>() { entidad = _mapper.Map<EntidadDto>(request) });
        }

    }
}
