namespace PCM.SIP.ICP.Domain.Entities
{
    public class Ubigeo
    {
        public string? SerialKey { get; set; }
        public int ubigeo_id { get; set; }
        public string? departamento_inei { get; set; }
        public string? provincia_inei { get; set; }
        public string? departamento { get; set; }
        public string? provincia { get; set; }
        public string? distrito { get; set; }
    }
}
