using PCM.SIP.ICP.Aplicacion.Interface.Infraestructure;
using PCM.SIP.ICP.Domain.Entities;
using PCM.SIP.ICP.Domain.Entities.Security;
using System.Text.Json;

namespace PCM.SIP.ICP.Infraestructure.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly HttpClient _httpClient;

        public SecurityService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
       
        public async Task<UsuarioCache> GetSessionDataAsync(string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var httpResponse = await _httpClient.GetAsync("api/security/GetSessionData");

                if (httpResponse.IsSuccessStatusCode)
                {    
                    var responseContent = await httpResponse.Content.ReadAsStringAsync();

                    var result = JsonSerializer.Deserialize<ResponseSecurityService>(responseContent);

                    if (result == null || result.Payload == null)
                        throw new HttpRequestException($"Error al obtener los datos de sesión:");

                    return result.Payload;
                }
                else
                {
                    throw new HttpRequestException($"Error al obtener los datos de sesión:");
                }
            }
            catch (Exception ex)
            {
                throw new HttpRequestException($"HttpRequestException: {ex.Message}", ex);
            }
        }
    }
}
