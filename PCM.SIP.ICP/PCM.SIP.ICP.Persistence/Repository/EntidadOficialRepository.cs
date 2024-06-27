using Dapper;
using PCM.SIP.ICP.Aplicacion.Interface.Persistence;
using PCM.SIP.ICP.Domain.Entities;
using PCM.SIP.ICP.Persistence.Context;
using PCM.SIP.ICP.Transversal.Common;
using System.Data;

namespace PCM.SIP.ICP.Persistence.Repository
{
    public class EntidadOficialRepository : IEntidadOficialRepository
    {
        private readonly DapperContext _context;

        public EntidadOficialRepository(DapperContext context)
        {
            _context = context;
        }

        public Response Insert(EntidadOficial entidad)
        {
            Response retorno = new Response();

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var query = "dbo.USP_INS_ENTIDADOFICIAL";

                    var parameters = new DynamicParameters();

                    parameters.Add("entidad_id", entidad.entidad_id);
                    parameters.Add("modalidad_id", entidad.modalidad_id);
                    parameters.Add("profesion_id", entidad.profesion_id);
                    parameters.Add("nombres", entidad.nombres);
                    parameters.Add("apellidos", entidad.apellidos);
                    parameters.Add("numero_celular", entidad.numero_celular);
                    parameters.Add("correo_institucional", entidad.correo_institucional);
                    parameters.Add("fecha_inicio", entidad.fecha_inicio);
                    parameters.Add("fecha_fin", entidad.fecha_fin);
                    parameters.Add("designacion_doc", entidad.designacion_doc);
                    parameters.Add("actual", entidad.actual);
                    parameters.Add("usuario_reg", entidad.usuario_reg);
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
        public Response Update(EntidadOficial entidad)
        {
            Response retorno = new Response();

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var query = "dbo.USP_UPD_ENTIDADOFICIAL";

                    var parameters = new DynamicParameters();

                    parameters.Add("entidadoficial_id", entidad.entidadoficial_id);
                    parameters.Add("entidad_id", entidad.entidad_id);
                    parameters.Add("modalidad_id", entidad.modalidad_id);
                    parameters.Add("profesion_id", entidad.profesion_id);
                    parameters.Add("nombres", entidad.nombres);
                    parameters.Add("apellidos", entidad.apellidos);
                    parameters.Add("numero_celular", entidad.numero_celular);
                    parameters.Add("correo_institucional", entidad.correo_institucional);
                    parameters.Add("fecha_inicio", entidad.fecha_inicio);
                    parameters.Add("fecha_fin", entidad.fecha_fin);
                    parameters.Add("designacion_doc", entidad.designacion_doc);
                    parameters.Add("actual", entidad.actual);
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
        public Response Delete(EntidadOficial entidad)
        {
            Response retorno = new Response();

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var query = "dbo.USP_DEL_ENTIDADOFICIAL";

                    var parameters = new DynamicParameters();

                    parameters.Add("entidadoficial_id", entidad.entidadoficial_id);
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
        public Response<dynamic> GetById(EntidadOficial entidad)
        {
            Response<dynamic> retorno = new Response<dynamic>();

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var query = "dbo.USP_GET_ENTIDADOFICIAL";

                    var parameters = new DynamicParameters();

                    parameters.Add("entidadoficial_id", entidad.entidadoficial_id.Equals(0) ? (int?)null : entidad.entidadoficial_id);
                    parameters.Add("error", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                    parameters.Add("message", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);

                    var result = connection.QuerySingleOrDefault<dynamic>(query, param: parameters, commandType: CommandType.StoredProcedure);

                    retorno.Data = result ?? new EntidadOficial();
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
        public Response<List<dynamic>> GetList(EntidadOficial entidad)
        {
            Response<List<dynamic>> retorno = new Response<List<dynamic>>();

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var query = "dbo.USP_SEL_ENTIDADOFICIAL";

                    var parameters = new DynamicParameters();

                    parameters.Add("entidadoficial_id", entidad.entidadoficial_id.Equals(0) ? (int?)null : entidad.entidadoficial_id);
                    parameters.Add("entidad_id", entidad.entidad_id);
                    parameters.Add("modalidad_id", entidad.modalidad_id);
                    parameters.Add("profesion_id", entidad.profesion_id);
                    parameters.Add("actual", entidad.actual);
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
