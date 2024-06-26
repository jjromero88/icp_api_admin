using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.Aplicacion.Dto
{
    public class ModalidadContratoDto : EntidadBase
    {
        public string? codigo { get; set; }
        public string? descripcion { get; set; }
        public string? abreviatura { get; set; }
    }
    public class ModalidadContratoFilterRequest
    {
        public string? SerialKey { get; set; }
        public string? filtro { get; set; }
    }
    public class ModalidadContratoResponse
    {
        public string? SerialKey { get; set; }
        public string? codigo { get; set; }
        public string? descripcion { get; set; }
        public string? abreviatura { get; set; }
    }
}
