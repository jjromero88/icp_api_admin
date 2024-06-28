using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.Aplicacion.Dto
{
    public class PreguntaDto: EntidadBase
    {
        public string? componentekey { get; set; }
        public string? codigo { get; set; }
        public int? numero { get; set; }
        public string? descripcion { get; set; }
        public bool? calculo_icp { get; set; }
        public bool? habilitado { get; set; }
        public ComponenteDto? componente { get; set; }
        public List<AlternativaDto>? lista_alternativas { get; set; }
    }
    public class PreguntaIdRequest
    {
        public string? SerialKey { get; set; }
    }
    public class PreguntaInsertRequest
    {
        public string? componentekey { get; set; }
        public string? codigo { get; set; }
        public int? numero { get; set; }
        public string? descripcion { get; set; }
        public bool? calculo_icp { get; set; }
        public bool? habilitado { get; set; }
        public List<AlternativaInsertRequest>? lista_alternativas { get; set; }
    }
    public class PreguntaUpdateRequest
    {
        public string? SerialKey { get; set; }
        public string? componentekey { get; set; }
        public string? codigo { get; set; }
        public int? numero { get; set; }
        public string? descripcion { get; set; }
        public bool? calculo_icp { get; set; }
        public bool? habilitado { get; set; }
        public List<AlternativaUpdateRequest>? lista_alternativas { get; set; }
    }
    public class PreguntaFilterRequest
    {
        public string? SerialKey { get; set; }
        public string? componentekey { get; set; }
        public string? filtro { get; set; }
    }
    public class PreguntaResponse
    {
        public string? SerialKey { get; set; }
        public string? componentekey { get; set; }
        public string? codigo { get; set; }
        public int? numero { get; set; }
        public string? descripcion { get; set; }
        public bool? calculo_icp { get; set; }
        public bool? habilitado { get; set; }
        public ComponenteResponse? componente { get; set; }
        public List<AlternativaResponse>? lista_alternativas { get; set; }
    }
}
