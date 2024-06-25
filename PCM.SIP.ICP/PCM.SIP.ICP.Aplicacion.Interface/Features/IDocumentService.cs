using PCM.SIP.ICP.Aplicacion.Dto;
using PCM.SIP.ICP.Transversal.Common.Generics;

namespace PCM.SIP.ICP.Aplicacion.Interface.Features
{
    public interface IDocumentService
    {
        Task<PcmResponse> UploadDocumentAsync(UploadDocumentRequest request);
        Task<PcmResponse> DownloadDocumentAsync(DownloadDocumentRequest request);
    }
}
