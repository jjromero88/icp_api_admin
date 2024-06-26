using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.Domain.Entities
{
    public class Profesion : EntidadBase
    {
        public int profesion_id { get; set; }
        public string? codigo { get; set; }
        public string? descripcion { get; set; }
    }
}
