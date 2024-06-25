using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.Aplicacion.Dto
{
    public class DocumenDto
    {
    }
    public class UploadDocumentRequest
    {
        public string? filename { get; set; }
        public string? base64content { get; set; }
        public string? category { get; set; }
    }
    public class DocumentInsertRequest
    {
        public string? filename { get; set; }
        public string? base64content { get; set; }
    }
    public class DownloadDocumentRequest
    {
        public string? category { get; set; }
        public string? filename { get; set; }
        public string? extension { get; set; }
    }

    public class DownloadDocumentResponse
    {
        public string? filename { get; set; }
        public string? extension { get; set; }
        public string? base64content { get; set; }
    }
}
