
namespace PCM.SIP.ICP.Aplicacion.Dto
{
    public class EntidadGrupoDto : EntidadBase
    {
        public string? codigo { get; set; }
        public string? abreviatura { get; set; }
        public string? descripcion { get; set; }
    }
    public class EntidadGrupoIdRequest
    {
        public string? SerialKey { get; set; }
    }
    public class EntidadGrupoInsertRequest
    {
        public string? abreviatura { get; set; }
        public string? descripcion { get; set; }
    }
    public class EntidadGrupoUpdateRequest
    {
        public string? SerialKey { get; set; }
        public string? abreviatura { get; set; }
        public string? descripcion { get; set; }
    }
    public class EntidadGrupoFilterRequest
    {
        public string? SerialKey { get; set; }
        public string? filtro { get; set; }
    }
    public class EntidadGrupoResponse
    {
        public string? SerialKey { get; set; }
        public string? codigo { get; set; }
        public string? abreviatura { get; set; }
        public string? descripcion { get; set; }
    }
}
