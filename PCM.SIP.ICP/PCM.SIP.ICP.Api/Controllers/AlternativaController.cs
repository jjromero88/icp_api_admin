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
    public class AlternativaController : Controller
    {
        private readonly IAlternativaApplication _alternativaApplication;
        private readonly IMapper _mapper;

        public AlternativaController(IAlternativaApplication alternativaApplication, IMapper mapper)
        {
            _alternativaApplication = alternativaApplication;
            _mapper = mapper;
        }

        [HttpGet("GetList")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> GetList([FromQuery] AlternativaFilterRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _alternativaApplication.GetList(new Request<AlternativaDto>() { entidad = _mapper.Map<AlternativaDto>(request) });
        }

    }
}
