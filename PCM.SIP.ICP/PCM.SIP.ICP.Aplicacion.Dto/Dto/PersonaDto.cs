using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.Aplicacion.Dto
{
    public class PersonaDto : EntidadBase
    {
        public string? nombres { get; set; }
        public string? apellido_paterno { get; set; }
        public string? apellido_materno { get; set; }
        public string? numdocumento { get; set; }
        public string? email { get; set; }
        public string? telefono_movil { get; set; }
    }
    public class PersonaIdRequest
    {
        public string? SerialKey { get; set; }
    }
    public class PersonaInsertRequest
    {
        public string? nombres { get; set; }
        public string? apellido_paterno { get; set; }
        public string? apellido_materno { get; set; }
        public string? numdocumento { get; set; }
        public string? email { get; set; }
        public string? telefono_movil { get; set; }
    }
    public class PersonaUpdateRequest
    {
        public string? SerialKey { get; set; }
        public string? nombres { get; set; }
        public string? apellido_paterno { get; set; }
        public string? apellido_materno { get; set; }
        public string? numdocumento { get; set; }
        public string? email { get; set; }
        public string? telefono_movil { get; set; }
    }
    public class PersonaFilterRequest
    {
        public string? SerialKey { get; set; }
        public string? filtro { get; set; }
    }
    public class PersonaResponse
    {
        public string? SerialKey { get; set; }
        public string? nombres { get; set; }
        public string? apellido_paterno { get; set; }
        public string? apellido_materno { get; set; }
        public string? numdocumento { get; set; }
        public string? email { get; set; }
        public string? telefono_movil { get; set; }
    }
}
