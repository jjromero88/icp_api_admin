using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using PCM.SIP.ICP.Transversal.Common.Constants;
using PCM.SIP.ICP.Aplicacion.Interface.Infraestructure;
using PCM.SIP.ICP.Transversal.Common.Generics;

namespace PCM.SIP.ICP.Api.Filters
{
    public class ValidateTokenRequestAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                string authorization = context.HttpContext.Request.Headers["Authorization"];

                // If no authorization header found, nothing to process further
                if (string.IsNullOrEmpty(authorization))
                {
                    throw new ArgumentException("El token no puede estar vacío");
                }

                string token;
                // If no content Bearer in Authorization Header
                if (!authorization.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                {
                    throw new Exception("El token no tiene el formato correcto");
                }
                else
                    token = authorization.Substring("Bearer ".Length).Trim();

                // If no token found, no further work possible
                if (string.IsNullOrEmpty(token))
                {
                    throw new Exception("El token no puede estar vacío");
                }

                // Obtener el servicio desde el proveedor de servicios
                var serviceProvider = context.HttpContext.RequestServices;
                var seguridadService = serviceProvider.GetRequiredService<ISecurityService>();

                // Llamar al método que valida el Token
                var validate = seguridadService.ValidateToken(token).Result;

                if (!validate)
                    throw new Exception("Sesión expirada!");

            }
            catch (Exception ex)
            {
                context.Result = new ObjectResult(new PcmResponse { Code = (int)HttpStatusCodeEnum.Unauthorized, error = true, Message = ex.Message })
                {
                    StatusCode = (int)HttpStatusCodeEnum.Unauthorized
                };

                return;
            }
        }

    }
}
