using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.Aplicacion.Dto
{
    public class EntidadSectorDto : EntidadBase
    {
        public string? tiposectorkey { get; set; }
        public string? codigo { get; set; }
        public string? abreviatura { get; set; }
        public string? descripcion { get; set; }
        public TipoSectorDto? tiposector { get; set; }
    }
    public class EntidadSectorFilterRequest
    {
        public string? SerialKey { get; set; }
        public string? filtro { get; set; }
    }
    public class EntidadSectorResponse
    {
        public string? SerialKey { get; set; }
        public string? tiposectorkey { get; set; }
        public string? codigo { get; set; }
        public string? abreviatura { get; set; }
        public string? descripcion { get; set; }
        public TipoSectorResponse? tiposector { get; set; }
    }
}
