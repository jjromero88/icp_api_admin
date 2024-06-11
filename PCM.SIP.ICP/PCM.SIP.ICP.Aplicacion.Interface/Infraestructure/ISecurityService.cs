using PCM.SIP.ICP.Transversal.Common.Generics;

namespace PCM.SIP.ICP.Aplicacion.Interface.Infraestructure
{
    public interface ISecurityService
    {
        Task<PcmResponse> GetSessionDataAsync(string token);
    }
}
