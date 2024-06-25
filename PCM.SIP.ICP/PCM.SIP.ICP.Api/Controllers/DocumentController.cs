using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCM.SIP.ICP.Aplicacion.Dto;
using PCM.SIP.ICP.Aplicacion.Interface.Features;

namespace PCM.SIP.ICP.Api.Controllers
{
    [AllowAnonymous]
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

        [HttpPost("upload")]
        public async Task<IActionResult> UploadDocument([FromBody] UploadDocumentRequest request)
        {
            var documentJson = await _documentService.UploadDocumentAsync(request.filename, request.base64content, request.category);
            return Ok(new { DocumentJson = documentJson });
        }
        [HttpPost("download")]
        public async Task<IActionResult> DownloadDocument([FromBody] DownloadDocumentRequest request)
        {
            var documentResponse = await _documentService.DownloadDocumentAsync(request);
            return Ok(documentResponse);
        }

    }
}
