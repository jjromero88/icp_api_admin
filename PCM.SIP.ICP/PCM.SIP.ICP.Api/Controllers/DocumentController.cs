using AutoMapper;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PCM.SIP.ICP.Api.Filters;
using PCM.SIP.ICP.Aplicacion.Dto;
using PCM.SIP.ICP.Aplicacion.Interface.Features;
using PCM.SIP.ICP.Transversal.Common.Generics;

namespace PCM.SIP.ICP.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : Controller
    {
        private readonly IDocumentService _documentService;
        private readonly IMapper _mapper;

        public DocumentController(IDocumentService documentService, IMapper mapper)
        {
            _documentService = documentService;
            _mapper = mapper;
        }

        [HttpPost("Upload")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> UploadDocument([FromBody] UploadDocumentRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _documentService.UploadDocumentAsync(request);
        }

        [HttpPost("Download")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> DownloadDocument([FromBody] DownloadDocumentRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _documentService.DownloadDocumentAsync(request);
        }

    }
}
