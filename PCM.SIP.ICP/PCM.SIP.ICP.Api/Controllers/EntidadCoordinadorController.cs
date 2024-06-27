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
    public class EntidadCoordinadorController : Controller
    {
        private readonly IEntidadCoordinadorApplication _entidadCoordinadorApplication;
        private readonly IMapper _mapper;

        public EntidadCoordinadorController(IEntidadCoordinadorApplication entidadCoordinadorApplication, IMapper mapper)
        {
            _entidadCoordinadorApplication = entidadCoordinadorApplication;
            _mapper = mapper;
        }

        [HttpGet("GetById")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> GetById([FromQuery] EntidadCoordinadorIdRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _entidadCoordinadorApplication.GetById(new Request<EntidadCoordinadorDto>() { entidad = _mapper.Map<EntidadCoordinadorDto>(request) });
        }

        [HttpGet("GetList")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> GetList([FromQuery] EntidadCoordinadorFilterRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _entidadCoordinadorApplication.GetList(new Request<EntidadCoordinadorDto>() { entidad = _mapper.Map<EntidadCoordinadorDto>(request) });
        }

        [HttpPost("Insert")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> Insert([FromBody] EntidadCoordinadorInsertRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _entidadCoordinadorApplication.Insert(new Request<EntidadCoordinadorDto>() { entidad = _mapper.Map<EntidadCoordinadorDto>(request) });
        }

        [HttpPut("Update")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> Update([FromBody] EntidadCoordinadorUpdateRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _entidadCoordinadorApplication.Update(new Request<EntidadCoordinadorDto>() { entidad = _mapper.Map<EntidadCoordinadorDto>(request) });
        }

        [HttpDelete("Delete")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> DeleteObject([FromBody] EntidadCoordinadorIdRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _entidadCoordinadorApplication.Delete(new Request<EntidadCoordinadorDto>() { entidad = _mapper.Map<EntidadCoordinadorDto>(request) });
        }
    }
}
