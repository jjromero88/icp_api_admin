using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.Transversal.Contracts.Seguridad.Request
{
    public class UsuarioFilterRequest
    {
        public string? SerialKey { get; set; }
        public string? personakey { get; set; }
        public string? numdocumento { get; set; }
        public string? filtro { get; set; }
    }
}
