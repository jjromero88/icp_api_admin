using AutoMapper;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
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
    public class PersonaController : Controller
    {
        private readonly IPersonaApplication _personaApplication;
        private readonly IMapper _mapper;

        public PersonaController(IPersonaApplication personaApplication, IMapper mapper)
        {
            _personaApplication = personaApplication;
            _mapper = mapper;
        }

        [HttpGet("GetById")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> GetById([FromQuery] PersonaIdRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _personaApplication.GetById(new Request<PersonaDto>() { entidad = _mapper.Map<PersonaDto>(request) });
        }

        [HttpGet("GetList")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> GetList([FromQuery] PersonaFilterRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _personaApplication.GetList(new Request<PersonaDto>() { entidad = _mapper.Map<PersonaDto>(request) });
        }

        [HttpPost("Insert")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> Insert([FromBody] PersonaInsertRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _personaApplication.Insert(new Request<PersonaDto>() { entidad = _mapper.Map<PersonaDto>(request) });
        }

        [HttpPut("Update")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> Update([FromBody] PersonaUpdateRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _personaApplication.Update(new Request<PersonaDto>() { entidad = _mapper.Map<PersonaDto>(request) });
        }

        [HttpDelete("Delete")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> DeleteObject([FromBody] PersonaIdRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _personaApplication.Delete(new Request<PersonaDto>() { entidad = _mapper.Map<PersonaDto>(request) });
        }

    }
}
