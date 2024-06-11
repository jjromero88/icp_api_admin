using PCM.SIP.ICP.Aplicacion.Interface.Infraestructure;
using PCM.SIP.ICP.Transversal.Common.Generics;
using System.Net.Http.Json;

namespace PCM.SIP.ICP.Infraestructure.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly HttpClient _httpClient;

        public SecurityService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PcmResponse> GetSessionDataAsync(string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var response = await _httpClient.GetAsync("api/security/GetSessionData");

                if (response.IsSuccessStatusCode)
                {
                    var sessionData = await response.Content.ReadFromJsonAsync<PcmResponse>();
                    return sessionData;
                }
                else
                {
                    throw new HttpRequestException($"Error al obtener los datos de sesión: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                throw new HttpRequestException($"HttpRequestException: {ex.Message}", ex);
            }
        }
    }
}
