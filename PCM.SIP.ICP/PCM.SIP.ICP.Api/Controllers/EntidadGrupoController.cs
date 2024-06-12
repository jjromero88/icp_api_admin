using AutoMapper;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PCM.SIP.ICP.Transversal.Common.Generics;
using PCM.SIP.ICP.Transversal.Common;
using PCM.SIP.ICP.Aplicacion.Dto;
using PCM.SIP.ICP.Api.Filters;
using PCM.SIP.ICP.Aplicacion.Interface.Features;

namespace PCM.SIP.ICP.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EntidadGrupoController : Controller
    {
        private readonly IEntidadGrupoApplication _entidadGrupoApplication;
        private readonly IMapper _mapper;

        public EntidadGrupoController(IEntidadGrupoApplication entidadGrupoApplication, IMapper mapper)
        {
            _entidadGrupoApplication = entidadGrupoApplication;
            _mapper = mapper;
        }

        [HttpGet("GetById")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> GetById([FromQuery] EntidadGrupoIdRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _entidadGrupoApplication.GetById(new Request<EntidadGrupoDto>() { entidad = _mapper.Map<EntidadGrupoDto>(request) });
        }

        [HttpGet("GetList")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> GetList([FromQuery] EntidadGrupoFilterRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _entidadGrupoApplication.GetList(new Request<EntidadGrupoDto>() { entidad = _mapper.Map<EntidadGrupoDto>(request) });
        }

        [HttpPost("Insert")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> Insert([FromBody] EntidadGrupoInsertRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _entidadGrupoApplication.Insert(new Request<EntidadGrupoDto>() { entidad = _mapper.Map<EntidadGrupoDto>(request) });
        }

        [HttpPut("Update")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> Update([FromBody] EntidadGrupoUpdateRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _entidadGrupoApplication.Update(new Request<EntidadGrupoDto>() { entidad = _mapper.Map<EntidadGrupoDto>(request) });
        }

        [HttpDelete("Delete")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> DeleteObject([FromBody] EntidadGrupoIdRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _entidadGrupoApplication.Delete(new Request<EntidadGrupoDto>() { entidad = _mapper.Map<EntidadGrupoDto>(request) });
        }

    }
}
