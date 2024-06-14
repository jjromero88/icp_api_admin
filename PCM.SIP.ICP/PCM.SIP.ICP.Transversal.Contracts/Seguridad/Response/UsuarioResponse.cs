using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.Transversal.Contracts.Seguridad.Response
{
    public class UsuarioResponse
    {
        public string? serialKey { get; set; }
        public string? personakey { get; set; }
        public string? username { get; set; }
        public bool? interno { get; set; }
        public string? numdocumento { get; set; }
        public string? nombre_completo { get; set; }
        public string? password { get; set; }
        public List<PerfilUsuarioResponse> lista_perfiles { get; set; } = new List<PerfilUsuarioResponse> { };
    }
}
