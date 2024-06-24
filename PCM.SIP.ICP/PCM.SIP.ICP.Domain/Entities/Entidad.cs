
namespace PCM.SIP.ICP.Domain.Entities
{
    public class Entidad : EntidadBase
    {
        public int entidad_id { get; set; }
        public int? entidadgrupo_id { get; set; }
        public int? entidadsector_id { get; set; }
        public int? modalidadintegridad_id { get; set; }
        public int? documentoestructura_id { get; set; }
        public int? ubigeo_id { get; set; }
        public string? documentoestructurakey { get; set; }
        public string? entidadgrupokey { get; set; }
        public string? entidadsectorkey { get; set; }
        public string? modalidadintegridadkey { get; set; }
        public string? ubigeokey { get; set; }
        public string? numero_ruc { get; set; }
        public string? codigo { get; set; }
        public string? acronimo { get; set; }
        public string? nombre { get; set; }        
        public string? documentoestructura_doc { get; set; }
        public string? modalidadintegridad_doc { get; set; }
        public string? modalidadintegridad_anterior { get; set; }
        public string? documentointegridad_desc { get; set; }
        public string? documentointegridad_doc { get; set; }
        public int? num_servidores { get; set; }
        public Ubigeo? ubigeo { get; set; }
        public ModalidadIntegridad? modalidadintegridad { get; set; }
        public DocumentoEstructura? documentoestructura { get; set; }
        public EntidadSector? entidadsector { get; set; }
        public EntidadGrupo? entidadgrupo { get; set; }
    }
}
