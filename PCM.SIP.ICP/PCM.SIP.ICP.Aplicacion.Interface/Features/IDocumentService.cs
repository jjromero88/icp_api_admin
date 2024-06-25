using PCM.SIP.ICP.Aplicacion.Dto;

namespace PCM.SIP.ICP.Aplicacion.Interface.Features
{
    public interface IDocumentService
    {
        Task<string> UploadDocumentAsync(string fileName, string base64Content, string category);
        Task<DownloadDocumentResponse> DownloadDocumentAsync(DownloadDocumentRequest request);
    }
}
