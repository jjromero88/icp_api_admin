using PCM.SIP.ICP.Aplicacion.Interface.Infraestructure;
using PCM.SIP.ICP.Domain.Entities;
using System.Text.Json;

namespace PCM.SIP.ICP.Infraestructure.Services
{
    public class UserService : IUserService
    {
        private UsuarioCache _usuarioCache;

        public UsuarioCache GetUser()
        {
            return _usuarioCache;
        }

        public void SetUser(string entidad)
        {
            try
            {
                var result = JsonSerializer.Deserialize<UsuarioCache>(entidad);

                if (result == null)
                    throw new Exception($"Error al deserializar el usuario de sesion");

                _usuarioCache = result;
            }
            catch
            (Exception ex)
            {
                throw new Exception($"Error al obtener datos del usuario: {ex.Message}", ex);
            }
        }
    }
}
