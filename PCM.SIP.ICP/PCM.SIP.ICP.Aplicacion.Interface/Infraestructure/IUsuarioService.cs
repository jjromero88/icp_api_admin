using PCM.SIP.ICP.Transversal.Common;
using PCM.SIP.ICP.Transversal.Contracts.Seguridad.Request;
using PCM.SIP.ICP.Transversal.Contracts.Seguridad.Response;

namespace PCM.SIP.ICP.Aplicacion.Interface.Infraestructure
{
    public interface IUsuarioService
    {
        Task<SeguridadResponse> InsertUsuario(InsertUsuarioRequest request, string? token);
        Task<SeguridadResponse> UpdateUsuario(UpdateUsuarioRequest request, string? token);
        Task<List<UsuarioResponse>> ListUsuario(UsuarioFilterRequest request, string? token);
    }
}
