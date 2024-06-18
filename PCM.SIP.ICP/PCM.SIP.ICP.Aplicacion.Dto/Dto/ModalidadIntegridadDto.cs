
namespace PCM.SIP.ICP.Aplicacion.Dto
{
    public class ModalidadIntegridadDto : EntidadBase
    {
        public string? codigo { get; set; }
        public string? abreviatura { get; set; }
        public string? descripcion { get; set; }
    }
    public class ModalidadIntegridadFilterRequest
    {
        public string? SerialKey { get; set; }
        public string? filtro { get; set; }
    }
    public class ModalidadIntegridadResponse
    {
        public string? SerialKey { get; set; }
        public string? codigo { get; set; }
        public string? abreviatura { get; set; }
        public string? descripcion { get; set; }
    }
}
