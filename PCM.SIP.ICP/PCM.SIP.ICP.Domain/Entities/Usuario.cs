using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.Domain.Entities
{
    public class Usuario
    {
        public string? username { get; set; }
        public string? password { get; set; }
        public bool? interno { get; set; }
        public List<Perfil>? lista_perfiles { get; set; }
    }
}
