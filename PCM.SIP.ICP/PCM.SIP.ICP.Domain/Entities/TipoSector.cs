using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.Domain.Entities
{
    public class TipoSector: EntidadBase
    {
        public int tiposector_id { get; set; }
        public string? codigo { get; set; }
        public string? abreviatura { get; set; }
        public string? descripcion { get; set; }
    }
}
