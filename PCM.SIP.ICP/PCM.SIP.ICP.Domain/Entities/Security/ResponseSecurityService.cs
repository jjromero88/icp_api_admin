using System.Text.Json.Serialization;

namespace PCM.SIP.ICP.Domain.Entities.Security
{
    public class ResponseSecurityService
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("error")]
        public bool Error { get; set; }

        [JsonPropertyName("payload")]
        public UsuarioCache? Payload { get; set; }
    }
}
