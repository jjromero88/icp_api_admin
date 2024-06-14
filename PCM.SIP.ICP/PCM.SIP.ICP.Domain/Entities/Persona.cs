using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.Domain.Entities
{
    public class Persona: EntidadBase
    {
        public int persona_id { get; set; }
        public string? nombres { get; set; }
        public string? apellido_paterno { get; set; }
        public string? apellido_materno { get; set; }
        public string? numdocumento { get; set; }
        public string? email { get; set; }
        public string? telefono_movil { get; set; }
        public string? username { get; set; }
        public string? password { get; set; }
        public bool? interno { get; set; }
        public string? perfileskey { get; set; }
        public Usuario? usuario { get; set; }
    }
}
