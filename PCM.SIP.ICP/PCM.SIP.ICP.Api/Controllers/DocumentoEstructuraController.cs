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
    public class DocumentoEstructuraController : Controller
    {
        private readonly IDocumentoEstructuraApplication _documentoEstructuraApplication;
        private readonly IMapper _mapper;

        public DocumentoEstructuraController(IDocumentoEstructuraApplication documentoEstructuraApplication, IMapper mapper)
        {
            _documentoEstructuraApplication = documentoEstructuraApplication;
            _mapper = mapper;
        }

        [HttpGet("GetList")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> GetList([FromQuery] DocumentoEstructuraFilterRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _documentoEstructuraApplication.GetList(new Request<DocumentoEstructuraDto>() { entidad = _mapper.Map<DocumentoEstructuraDto>(request) });
        }
    }
}
