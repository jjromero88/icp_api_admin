using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCM.SIP.ICP.Api.Filters;
using PCM.SIP.ICP.Aplicacion.Dto;
using PCM.SIP.ICP.Aplicacion.Interface.Features;
using PCM.SIP.ICP.Transversal.Common.Generics;
using PCM.SIP.ICP.Transversal.Common;
using System.Net;
using PCM.SIP.ICP.Aplicacion.Features;

namespace PCM.SIP.ICP.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PreguntaController : Controller
    {
        private readonly IPreguntaApplication _preguntaApplication;
        private readonly IMapper _mapper;

        public PreguntaController(IPreguntaApplication preguntaApplication, IMapper mapper)
        {
            _preguntaApplication = preguntaApplication;
            _mapper = mapper;
        }

        [HttpGet("GetById")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> GetById([FromQuery] PreguntaIdRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _preguntaApplication.GetById(new Request<PreguntaDto>() { entidad = _mapper.Map<PreguntaDto>(request) });
        }

        [HttpGet("GetList")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> GetList([FromQuery] PreguntaFilterRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _preguntaApplication.GetList(new Request<PreguntaDto>() { entidad = _mapper.Map<PreguntaDto>(request) });
        }

        [HttpPost("Insert")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> Insert([FromBody] PreguntaInsertRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _preguntaApplication.Insert(new Request<PreguntaDto>() { entidad = _mapper.Map<PreguntaDto>(request) });
        }

        [HttpPut("Update")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> Update([FromBody] PreguntaUpdateRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _preguntaApplication.Update(new Request<PreguntaDto>() { entidad = _mapper.Map<PreguntaDto>(request) });
        }

        [HttpDelete("Delete")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> DeleteObject([FromBody] PreguntaIdRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _preguntaApplication.Delete(new Request<PreguntaDto>() { entidad = _mapper.Map<PreguntaDto>(request) });
        }

    }
}
