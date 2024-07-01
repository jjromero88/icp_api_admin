using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.Aplicacion.Dto
{
    public class EtapaDto : EntidadBase
    {
        public string? codigo { get; set; }
        public string? nombre { get; set; }
        public string? abreviatura { get; set; }
        public string? descripcion { get; set; }
    }
    public class EtapaFilterRequest
    {
        public string? SerialKey { get; set; }
        public string? filtro { get; set; }
    }
    public class EtapaResponse
    {
        public string? SerialKey { get; set; }
        public string? codigo { get; set; }
        public string? nombre { get; set; }
        public string? abreviatura { get; set; }
        public string? descripcion { get; set; }
    }
}
