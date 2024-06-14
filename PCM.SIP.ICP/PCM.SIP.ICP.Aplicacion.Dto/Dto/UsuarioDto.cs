using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.Aplicacion.Dto
{
    public class UsuarioDto
    {
        public string? username { get; set; }
        public string? password { get; set; }
        public bool? interno { get; set; }
        public List<PerfilDto>? lista_perfiles { get; set; }
    }
}
