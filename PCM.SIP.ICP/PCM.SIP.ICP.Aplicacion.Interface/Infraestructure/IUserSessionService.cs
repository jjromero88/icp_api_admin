using PCM.SIP.ICP.Domain.Entities;

namespace PCM.SIP.ICP.Aplicacion.Interface.Infraestructure
{
    public interface IUserService
    {
        void SetToken(string token);
        void SetUser(string entidad);
        UsuarioCache GetUser();
        string GetToken();
    }
}
