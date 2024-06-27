namespace PCM.SIP.ICP.Aplicacion.Dto
{
    public class EntidadCoordinadorDto : EntidadBase
    {
        public string? entidadkey { get; set; }
        public string? modalidadkey { get; set; }
        public string? profesionkey { get; set; }
        public string? nombres { get; set; }
        public string? apellidos { get; set; }
        public string? numero_celular { get; set; }
        public string? correo_institucional { get; set; }
        public DateTime? fecha_inicio { get; set; }
        public DateTime? fecha_fin { get; set; }
        public string? designacion_doc { get; set; }
        public bool? actual { get; set; }
        public DocumentDto? documento_designacion { get; set; }
        public ProfesionDto? profesion { get; set; }
        public ModalidadContratoDto? modalidadcontrato { get; set; }
    }
    public class EntidadCoordinadorIdRequest
    {
        public string? SerialKey { get; set; }
    }
    public class EntidadCoordinadorInsertRequest
    {
        public string? entidadkey { get; set; }
        public string? modalidadkey { get; set; }
        public string? profesionkey { get; set; }
        public string? nombres { get; set; }
        public string? apellidos { get; set; }
        public string? numero_celular { get; set; }
        public string? correo_institucional { get; set; }
        public DateTime? fecha_inicio { get; set; }
        public DateTime? fecha_fin { get; set; }
        public bool? actual { get; set; }
        public DocumentInsertRequest? documento_designacion { get; set; }
    }
    public class EntidadCoordinadorUpdateRequest
    {
        public string? SerialKey { get; set; }
        public string? entidadkey { get; set; }
        public string? modalidadkey { get; set; }
        public string? profesionkey { get; set; }
        public string? nombres { get; set; }
        public string? apellidos { get; set; }
        public string? numero_celular { get; set; }
        public string? correo_institucional { get; set; }
        public DateTime? fecha_inicio { get; set; }
        public DateTime? fecha_fin { get; set; }
        public bool? actual { get; set; }
        public DocumentInsertRequest? documento_designacion { get; set; }
    }
    public class EntidadCoordinadorFilterRequest
    {
        public string? SerialKey { get; set; }
        public string? entidadkey { get; set; }
        public string? modalidadkey { get; set; }
        public string? profesionkey { get; set; }
        public string? filtro { get; set; }
        public bool? actual { get; set; }
    }
    public class EntidadCoordinadorResponse
    {
        public string? SerialKey { get; set; }
        public string? entidadkey { get; set; }
        public string? modalidadkey { get; set; }
        public string? profesionkey { get; set; }
        public string? nombres { get; set; }
        public string? apellidos { get; set; }
        public string? numero_celular { get; set; }
        public string? correo_institucional { get; set; }
        public DateTime? fecha_inicio { get; set; }
        public DateTime? fecha_fin { get; set; }
        public bool? actual { get; set; }
        public DocumentResponse? documento_designacion { get; set; }
        public ProfesionResponse? profesion { get; set; }
        public ModalidadContratoResponse? modalidadcontrato { get; set; }
    }
}
