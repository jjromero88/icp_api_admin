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
    public class EntidadOficialController : Controller
    {
        private readonly IEntidadOficialApplication _entidadOficialApplication;
        private readonly IMapper _mapper;

        public EntidadOficialController(IEntidadOficialApplication entidadOficialApplication, IMapper mapper)
        {
            _entidadOficialApplication = entidadOficialApplication;
            _mapper = mapper;
        }

        [HttpGet("GetById")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> GetById([FromQuery] EntidadOficialIdRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _entidadOficialApplication.GetById(new Request<EntidadOficialDto>() { entidad = _mapper.Map<EntidadOficialDto>(request) });
        }

        [HttpGet("GetList")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> GetList([FromQuery] EntidadOficialFilterRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _entidadOficialApplication.GetList(new Request<EntidadOficialDto>() { entidad = _mapper.Map<EntidadOficialDto>(request) });
        }

        [HttpPost("Insert")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> Insert([FromBody] EntidadOficialInsertRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _entidadOficialApplication.Insert(new Request<EntidadOficialDto>() { entidad = _mapper.Map<EntidadOficialDto>(request) });
        }

        [HttpPut("Update")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> Update([FromBody] EntidadOficialUpdateRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _entidadOficialApplication.Update(new Request<EntidadOficialDto>() { entidad = _mapper.Map<EntidadOficialDto>(request) });
        }

        [HttpDelete("Delete")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> DeleteObject([FromBody] EntidadOficialIdRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _entidadOficialApplication.Delete(new Request<EntidadOficialDto>() { entidad = _mapper.Map<EntidadOficialDto>(request) });
        }

    }
}
