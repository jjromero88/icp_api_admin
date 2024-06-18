
namespace PCM.SIP.ICP.Aplicacion.Dto
{
    public class EntidadDto : EntidadBase
    {
        public string? entidadgrupokey { get; set; }
        public string? entidadsectorkey { get; set; }
        public string? modalidadintegridadkey { get; set; }
        public string? ubigeokey { get; set; }
        public string? numero_ruc { get; set; }
        public string? codigo { get; set; }
        public string? acronimo { get; set; }
        public string? nombre { get; set; }
        public UbigeoDto? ubigeo { get; set; }
        public ModalidadIntegridadDto? modalidadintegridad { get; set; }
        public EntidadSectorDto? entidadsector { get; set; }
        public EntidadGrupoDto? entidadgrupo { get; set; }
    }
    public class EntidadIdRequest
    {
        public string? SerialKey { get; set; }
    }
    public class EntidadInsertRequest
    {
        public string? entidadgrupokey { get; set; }
        public string? entidadsectorkey { get; set; }
        public string? modalidadintegridadkey { get; set; }
        public string? ubigeokey { get; set; }
        public string? numero_ruc { get; set; }
        public string? codigo { get; set; }
        public string? acronimo { get; set; }
        public string? nombre { get; set; }
    }
    public class EntidadUpdateRequest
    {
        public string? SerialKey { get; set; }
        public string? entidadgrupokey { get; set; }
        public string? entidadsectorkey { get; set; }
        public string? modalidadintegridadkey { get; set; }
        public string? ubigeokey { get; set; }
        public string? numero_ruc { get; set; }
        public string? codigo { get; set; }
        public string? acronimo { get; set; }
        public string? nombre { get; set; }
    }
    public class EntidadFilterRequest
    {
        public string? SerialKey { get; set; }
        public string? entidadgrupokey { get; set; }
        public string? entidadsectorkey { get; set; }
        public string? modalidadintegridadkey { get; set; }
        public string? ubigeokey { get; set; }
        public string? filtro { get; set; }
    }
    public class EntidadResponse
    {
        public string? SerialKey { get; set; }
        public string? entidadgrupokey { get; set; }
        public string? entidadsectorkey { get; set; }
        public string? modalidadintegridadkey { get; set; }
        public string? ubigeokey { get; set; }
        public string? numero_ruc { get; set; }
        public string? codigo { get; set; }
        public string? acronimo { get; set; }
        public string? nombre { get; set; }
        public UbigeoDto? ubigeo { get; set; }
        public ModalidadIntegridadDto? modalidadintegridad { get; set; }
        public EntidadSectorDto? entidadsector { get; set; }
        public EntidadGrupoDto? entidadgrupo { get; set; }
    }
}
