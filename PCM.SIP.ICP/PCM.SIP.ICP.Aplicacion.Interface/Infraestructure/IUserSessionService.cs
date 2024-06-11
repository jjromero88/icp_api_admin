using PCM.SIP.ICP.Domain.Entities;

namespace PCM.SIP.ICP.Aplicacion.Interface.Infraestructure
{
    public interface IUserService
    {
        void SetUser(string entidad);
        UsuarioCache GetUser();
    }
}
