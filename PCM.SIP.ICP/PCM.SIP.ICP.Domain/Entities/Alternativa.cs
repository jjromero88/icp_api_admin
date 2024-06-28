
namespace PCM.SIP.ICP.Domain.Entities
{
    public class Alternativa : EntidadBase
    {
        public int alternativa_id { get; set; }
        public int? pregunta_id { get; set; }
        public string? preguntakey { get; set; }
        public string? codigo { get; set; }
        public string? alternativa { get; set; }
        public string? descripcion { get; set; }
        public decimal? valor { get; set; }
        public bool? medio_verificacion { get; set; }
        public int? numero_orden { get; set; }
    }
}
