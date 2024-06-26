using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.Aplicacion.Dto
{
    public class ProfesionDto : EntidadBase
    {
        public string? codigo { get; set; }
        public string? descripcion { get; set; }
    }
    public class ProfesionFilterRequest
    {
        public string? SerialKey { get; set; }
        public string? filtro { get; set; }
    }
    public class ProfesionResponse
    {
        public string? SerialKey { get; set; }
        public string? codigo { get; set; }
        public string? descripcion { get; set; }
    }
}
