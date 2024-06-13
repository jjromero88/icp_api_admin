using Dapper;
using PCM.SIP.ICP.Aplicacion.Interface.Persistence;
using PCM.SIP.ICP.Domain.Entities;
using PCM.SIP.ICP.Persistence.Context;
using PCM.SIP.ICP.Transversal.Common;
using System.Data;

namespace PCM.SIP.ICP.Persistence.Repository
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly DapperContext _context;

        public PersonaRepository(DapperContext context)
        {
            _context = context;
        }

        public Response Insert(Persona entidad, out int id)
        {
            Response retorno = new Response();
            id = 0;

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var query = "dbo.USP_INS_PERSONA";

                    var parameters = new DynamicParameters();

                    parameters.Add("nombres", entidad.nombres);
                    parameters.Add("apellido_paterno", entidad.apellido_paterno);
                    parameters.Add("apellido_materno", entidad.apellido_materno);
                    parameters.Add("numdocumento", entidad.numdocumento);
                    parameters.Add("email", entidad.email);
                    parameters.Add("telefono_movil", entidad.telefono_movil);
                    parameters.Add("usuario_reg", entidad.usuario_reg);
                    parameters.Add("persona_id", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    parameters.Add("error", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                    parameters.Add("message", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);

                    var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);

                    retorno.Error = parameters.Get<bool?>("error") ?? false;
                    retorno.Message = parameters.Get<string>("message") ?? string.Empty;
                    id = parameters.Get<int?>("persona_id") ?? 0;
                }
            }
            catch (Exception ex)
            {
                retorno.Error = true;
                retorno.Message = ex.Message;
            }

            return retorno;
        }

        public Response Update(Persona entidad)
        {
            Response retorno = new Response();

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var query = "dbo.USP_UPD_PERSONA";

                    var parameters = new DynamicParameters();

                    parameters.Add("persona_id", entidad.persona_id);
                    parameters.Add("nombres", entidad.nombres);
                    parameters.Add("apellido_paterno", entidad.apellido_paterno);
                    parameters.Add("apellido_materno", entidad.apellido_materno);
                    parameters.Add("numdocumento", entidad.numdocumento);
                    parameters.Add("email", entidad.email);
                    parameters.Add("telefono_movil", entidad.telefono_movil);
                    parameters.Add("usuario_act", entidad.usuario_act);
                    parameters.Add("error", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                    parameters.Add("message", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);

                    var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);

                    retorno.Error = parameters.Get<bool?>("error") ?? false;
                    retorno.Message = parameters.Get<string>("message") ?? string.Empty;
                }
            }
            catch (Exception ex)
            {
                retorno.Error = true;
                retorno.Message = ex.Message;
            }

            return retorno;
        }

        public Response Delete(Persona entidad)
        {
            Response retorno = new Response();

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var query = "dbo.USP_DEL_PERSONA";

                    var parameters = new DynamicParameters();

                    parameters.Add("persona_id", entidad.persona_id);
                    parameters.Add("usuario_act", entidad.usuario_act);
                    parameters.Add("error", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                    parameters.Add("message", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);

                    var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);

                    retorno.Error = parameters.Get<bool?>("error") ?? false;
                    retorno.Message = parameters.Get<string>("message") ?? string.Empty;
                }
            }
            catch (Exception ex)
            {
                retorno.Error = true;
                retorno.Message = ex.Message;
            }

            return retorno;
        }

        public Response<dynamic> GetById(Persona entidad)
        {
            Response<dynamic> retorno = new Response<dynamic>();

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var query = "dbo.USP_GET_PERSONA";

                    var parameters = new DynamicParameters();

                    parameters.Add("persona_id", entidad.persona_id.Equals(0) ? (int?)null : entidad.persona_id);
                    parameters.Add("error", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                    parameters.Add("message", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);

                    var result = connection.QuerySingleOrDefault<dynamic>(query, param: parameters, commandType: CommandType.StoredProcedure);

                    retorno.Data = result ?? new EntidadGrupo();
                    retorno.Error = parameters.Get<bool?>("error") ?? false;
                    retorno.Message = parameters.Get<string>("message") ?? string.Empty;
                }
            }
            catch (Exception ex)
            {
                retorno.Error = true;
                retorno.Message = ex.Message;
            }

            return retorno;
        }

        public Response<List<dynamic>> GetList(Persona entidad)
        {
            Response<List<dynamic>> retorno = new Response<List<dynamic>>();

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var query = "dbo.USP_SEL_PERSONA";

                    var parameters = new DynamicParameters();

                    parameters.Add("persona_id", entidad.persona_id.Equals(0) ? (int?)null : entidad.persona_id);
                    parameters.Add("filtro", entidad.filtro);
                    parameters.Add("error", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                    parameters.Add("message", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);

                    IEnumerable<dynamic> result = connection.Query<dynamic>(query, param: parameters, commandType: CommandType.StoredProcedure);
                    List<dynamic> lista = result.ToList();

                    retorno.Data = lista;
                    retorno.Error = parameters.Get<bool?>("error") ?? false;
                    retorno.Message = parameters.Get<string>("message") ?? string.Empty;
                }
            }
            catch (Exception ex)
            {
                retorno.Error = true;
                retorno.Message = ex.Message;
            }

            return retorno;
        }
    }
}
