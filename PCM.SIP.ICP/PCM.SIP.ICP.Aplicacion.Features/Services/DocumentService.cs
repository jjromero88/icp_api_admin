using Microsoft.Extensions.Configuration;
using PCM.SIP.ICP.Aplicacion.Dto;
using PCM.SIP.ICP.Aplicacion.Interface;
using PCM.SIP.ICP.Aplicacion.Interface.Features;

namespace PCM.SIP.ICP.Aplicacion.Features
{
    public class DocumentService : IDocumentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public DocumentService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public async Task<string> UploadDocumentAsync(string fileName, string base64Content, string category)
        {
            try
            {
                return await _unitOfWork.DocumentRepository.SaveDocumentAsync(fileName, base64Content, category);
            }
            catch (Exception ex)
            { throw new Exception($"UploadDocumentAsync: {ex.Message}"); }
        }


        public async Task<DownloadDocumentResponse> DownloadDocumentAsync(DownloadDocumentRequest request)
        {
            try
            {
                var (fileName, base64Content) = await _unitOfWork.DocumentRepository.DownloadDocumentAsync(request.category, request.filename);

                return new DownloadDocumentResponse
                {
                    filename = fileName,
                    extension = request.extension,
                    base64content = base64Content
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"DownloadDocumentAsync: {ex.Message}");
            }
        }

    }
}
