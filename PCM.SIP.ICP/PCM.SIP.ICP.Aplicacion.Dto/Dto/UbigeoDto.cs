
namespace PCM.SIP.ICP.Aplicacion.Dto
{
    public class UbigeoDto
    {
        public string? SerialKey { get; set; }
        public string? departamento_inei { get; set; }
        public string? provincia_inei { get; set; }
        public string? departamento { get; set; }
        public string? provincia { get; set; }
        public string? distrito { get; set; }
    }
    public class ProvinciaFilterRequest
    {
        public string? departamento_inei { get; set; }
    }
    public class DistritoFilterRequest
    {
        public string? provincia_inei { get; set; }
    }
    public class DepartamentoResponse
    {
        public string? departamento_inei { get; set; }
        public string? departamento { get; set; }
    }
    public class ProvinciaResponse
    {
        public string? departamento_inei { get; set; }
        public string? provincia_inei { get; set; }
        public string? provincia { get; set; }
    }
    public class DistritoResponse
    {
        public string? SerialKey { get; set; }
        public string? distrito { get; set; }
    }
    public class UbigeoEntidadResponse
    {
        public string? departamento_inei { get; set; }
        public string? provincia_inei { get; set; }
        public string? departamento { get; set; }
        public string? provincia { get; set; }
        public string? distrito { get; set; }
    }
}
