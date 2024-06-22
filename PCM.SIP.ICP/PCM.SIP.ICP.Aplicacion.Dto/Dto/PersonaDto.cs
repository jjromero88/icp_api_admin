using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.Aplicacion.Dto
{
    public class PersonaDto : EntidadBase
    {
        public string? entidadkey { get; set; }
        public string? nombres { get; set; }
        public string? apellido_paterno { get; set; }
        public string? apellido_materno { get; set; }
        public string? numdocumento { get; set; }
        public string? email { get; set; }
        public string? telefono_movil { get; set; }
        public string? username { get; set; }
        public string? password { get; set; }
        public bool? interno { get; set; }
        public bool? habilitado { get; set; }
        public string? perfileskey { get; set; }
        public EntidadDto? entidad { get; set; }
        public UsuarioDto? usuario { get; set; }
    }
    public class PersonaIdRequest
    {
        public string? SerialKey { get; set; }
    }
    public class PersonaInsertRequest
    {
        public string? entidadkey { get; set; }
        public string? nombres { get; set; }
        public string? apellido_paterno { get; set; }
        public string? apellido_materno { get; set; }
        public string? numdocumento { get; set; }
        public string? email { get; set; }
        public string? telefono_movil { get; set; }
        public bool? interno { get; set; }
        public bool? habilitado { get; set; }
        public string? perfileskey { get; set; }

    }
    public class PersonaUpdateRequest
    {
        public string? SerialKey { get; set; }
        public string? entidadkey { get; set; }
        public string? nombres { get; set; }
        public string? apellido_paterno { get; set; }
        public string? apellido_materno { get; set; }
        public string? numdocumento { get; set; }
        public string? email { get; set; }
        public string? telefono_movil { get; set; }
        public string? perfileskey { get; set; }
        public string? username { get; set; }
        public string? password { get; set; }
        public bool? interno { get; set; }
        public bool? habilitado { get; set; }
    }
    public class PersonaFilterRequest
    {
        public string? SerialKey { get; set; }
        public string? filtro { get; set; }
    }
    public class PersonaResponse
    {
        public string? SerialKey { get; set; }
        public string? entidadkey { get; set; }
        public string? nombres { get; set; }
        public string? apellido_paterno { get; set; }
        public string? apellido_materno { get; set; }
        public string? numdocumento { get; set; }
        public string? email { get; set; }
        public string? telefono_movil { get; set; }
        public EntidadPersonaResponse? entidad { get; set; }
        public UsuarioDto? usuario { get; set; }
    }
}
