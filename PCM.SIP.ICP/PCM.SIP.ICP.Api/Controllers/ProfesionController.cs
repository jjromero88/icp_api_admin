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
    public class ProfesionController : Controller
    {
        private readonly IProfesionApplication _profesionApplication;
        private readonly IMapper _mapper;

        public ProfesionController(IProfesionApplication profesionApplication, IMapper mapper)
        {
            _profesionApplication = profesionApplication;
            _mapper = mapper;
        }

        [HttpGet("GetList")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> GetList([FromQuery] ProfesionFilterRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _profesionApplication.GetList(new Request<ProfesionDto>() { entidad = _mapper.Map<ProfesionDto>(request) });
        }

    }
}
