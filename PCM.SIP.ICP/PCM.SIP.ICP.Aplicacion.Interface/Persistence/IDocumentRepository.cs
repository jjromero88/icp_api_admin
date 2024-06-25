
using PCM.SIP.ICP.Domain.Entities;

namespace PCM.SIP.ICP.Aplicacion.Interface.Persistence
{
    public interface IDocumentRepository
    {
        Task<string> SaveDocumentAsync(string fileName, string base64Content, string category);
        Task<(string FileName, string Base64Content)> DownloadDocumentAsync(string categoryPath, string fileName);
    }
}
