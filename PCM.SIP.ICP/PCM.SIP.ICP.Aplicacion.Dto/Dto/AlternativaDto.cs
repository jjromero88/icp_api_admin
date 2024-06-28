
namespace PCM.SIP.ICP.Aplicacion.Dto
{
    public class AlternativaDto: EntidadBase
    {
        public string? preguntakey { get; set; }
        public string? codigo { get; set; }
        public string? alternativa { get; set; }
        public string? descripcion { get; set; }
        public decimal? valor { get; set; }
        public bool? medio_verificacion { get; set; }
        public int? numero_orden { get; set; }
    }
    public class AlternativaIdRequest
    {
        public string? SerialKey { get; set; }
    }
    public class AlternativaFilterRequest
    {
        public string? SerialKey { get; set; }
        public string? filtro { get; set; }
    }
    public class AlternativaInsertRequest
    {
        public string? preguntakey { get; set; }
        public string? codigo { get; set; }
        public string? alternativa { get; set; }
        public string? descripcion { get; set; }
        public decimal? valor { get; set; }
        public bool? medio_verificacion { get; set; }
        public int? numero_orden { get; set; }
    }
    public class AlternativaUpdateRequest
    {
        public string? SerialKey { get; set; }
        public string? preguntakey { get; set; }
        public string? codigo { get; set; }
        public string? alternativa { get; set; }
        public string? descripcion { get; set; }
        public decimal? valor { get; set; }
        public bool? medio_verificacion { get; set; }
        public int? numero_orden { get; set; }
    }
    public class AlternativaResponse
    {
        public string? SerialKey { get; set; }
        public string? preguntakey { get; set; }
        public string? codigo { get; set; }
        public string? alternativa { get; set; }
        public string? descripcion { get; set; }
        public decimal? valor { get; set; }
        public bool? medio_verificacion { get; set; }
        public int? numero_orden { get; set; }
    }
}
