using Microsoft.Extensions.Configuration;
using PCM.SIP.ICP.Aplicacion.Dto;
using PCM.SIP.ICP.Aplicacion.Interface;
using PCM.SIP.ICP.Aplicacion.Interface.Features;
using PCM.SIP.ICP.Transversal.Common;
using PCM.SIP.ICP.Transversal.Common.Constants;
using PCM.SIP.ICP.Transversal.Common.Generics;

namespace PCM.SIP.ICP.Aplicacion.Features
{
    public class DocumentService : IDocumentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly IAppLogger<DocumentService> _logger;

        public DocumentService(IUnitOfWork unitOfWork, IConfiguration configuration, IAppLogger<DocumentService> logger)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<PcmResponse> UploadDocumentAsync(UploadDocumentRequest request)
        {
            try
            {
                var result = await _unitOfWork.DocumentRepository.SaveDocumentAsync(request.filename, request.base64content, request.category);

                _logger.LogInformation(TransactionMessage.QuerySuccess);
                return !string.IsNullOrEmpty(result) ? ResponseUtil.Ok(result, TransactionMessage.SaveSuccess) : ResponseUtil.NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseUtil.InternalError(message: ex.Message);
            }
        }

        public async Task<PcmResponse> DownloadDocumentAsync(DownloadDocumentRequest request)
        {
            try
            {
                var (fileName, base64Content) = await _unitOfWork.DocumentRepository.DownloadDocumentAsync(request.category, request.filename);

                var result = new DownloadDocumentResponse
                {
                    filename = fileName,
                    extension = request.extension,
                    base64content = base64Content
                };

                _logger.LogInformation(TransactionMessage.QuerySuccess);
                return result != null ? ResponseUtil.Ok(result, TransactionMessage.QuerySuccess) : ResponseUtil.NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseUtil.InternalError(message: ex.Message);
            }
        }
        
    }
}
