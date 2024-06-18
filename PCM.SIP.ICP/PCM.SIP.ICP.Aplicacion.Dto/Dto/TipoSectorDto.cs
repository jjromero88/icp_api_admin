using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.Aplicacion.Dto
{
    public class TipoSectorDto: EntidadBase
    {
        public string? codigo { get; set; }
        public string? abreviatura { get; set; }
        public string? descripcion { get; set; }
    }
    public class TipoSectorFilterRequest
    {
        public string? SerialKey { get; set; }
        public string? filtro { get; set; }
    }
    public class TipoSectorResponse
    {
        public string? SerialKey { get; set; }
        public string? codigo { get; set; }
        public string? descripcion { get; set; }
    }
}
