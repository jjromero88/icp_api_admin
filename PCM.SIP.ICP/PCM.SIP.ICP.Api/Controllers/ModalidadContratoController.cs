using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCM.SIP.ICP.Api.Filters;
using PCM.SIP.ICP.Aplicacion.Dto;
using PCM.SIP.ICP.Aplicacion.Features;
using PCM.SIP.ICP.Aplicacion.Interface.Features;
using PCM.SIP.ICP.Transversal.Common.Generics;
using PCM.SIP.ICP.Transversal.Common;
using System.Net;

namespace PCM.SIP.ICP.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ModalidadContratoController : Controller
    {
        private readonly IModalidadContratoApplication _modalidadContratoApplication;
        private readonly IMapper _mapper;

        public ModalidadContratoController(IModalidadContratoApplication modalidadContratoApplication, IMapper mapper)
        {
            _modalidadContratoApplication = modalidadContratoApplication;
            _mapper = mapper;
        }

        [HttpGet("GetList")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> GetList([FromQuery] ModalidadContratoFilterRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _modalidadContratoApplication.GetList(new Request<ModalidadContratoDto>() { entidad = _mapper.Map<ModalidadContratoDto>(request) });
        }
    }
}
