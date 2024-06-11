using PCM.SIP.ICP.Domain.Entities;
using PCM.SIP.ICP.Transversal.Common.Generics;

namespace PCM.SIP.ICP.Aplicacion.Interface.Infraestructure
{
    public interface ISecurityService
    {
        Task<UsuarioCache> GetSessionDataAsync(string token);
        Task<bool> ValidateToken(string token);
    }
}
