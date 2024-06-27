using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.Domain.Entities
{
    public class EntidadCoordinador : EntidadBase
    {
        public int entidadcoordinador_id { get; set; }
        public int? entidad_id { get; set; }
        public int? modalidad_id { get; set; }
        public int? profesion_id { get; set; }
        public string? entidadkey { get; set; }
        public string? modalidadkey { get; set; }
        public string? profesionkey { get; set; }
        public string? nombres { get; set; }
        public string? apellidos { get; set; }
        public string? numero_celular { get; set; }
        public string? correo_institucional { get; set; }
        public DateTime? fecha_inicio { get; set; }
        public DateTime? fecha_fin { get; set; }
        public string? designacion_doc { get; set; }
        public bool? actual { get; set; }
        public Document? documento_designacion { get; set; }
        public Profesion? profesion { get; set; }
        public ModalidadContrato? modalidadcontrato { get; set; }
    }
}
