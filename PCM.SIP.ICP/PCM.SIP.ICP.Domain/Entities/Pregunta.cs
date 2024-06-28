
namespace PCM.SIP.ICP.Domain.Entities
{
    public class Pregunta : EntidadBase
    {
        public int pregunta_id { get; set; }
        public int? componente_id { get; set; }
        public string? componentekey { get; set; }
        public string? codigo { get; set; }
        public int? numero { get; set; }
        public string? descripcion { get; set; }
        public bool? calculo_icp { get; set; }
        public bool? habilitado { get; set; }
        public Componente? componente { get; set; }
        public List<TypeAlternativa>? alternativas { get; set; }
        public List<Alternativa>? lista_alternativas { get; set; }
    }
}
