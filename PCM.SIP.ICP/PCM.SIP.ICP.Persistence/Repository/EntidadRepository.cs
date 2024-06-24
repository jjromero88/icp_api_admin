using Dapper;
using PCM.SIP.ICP.Aplicacion.Interface.Persistence;
using PCM.SIP.ICP.Domain.Entities;
using PCM.SIP.ICP.Persistence.Context;
using PCM.SIP.ICP.Transversal.Common;
using System.Data;

namespace PCM.SIP.ICP.Persistence.Repository
{
    public class EntidadRepository : IEntidadRepository
    {
        private readonly DapperContext _context;

        public EntidadRepository(DapperContext context)
        {
            _context = context;
        }

        public Response Insert(Entidad entidad)
        {
            Response retorno = new Response();

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var query = "dbo.USP_INS_ENTIDAD";

                    var parameters = new DynamicParameters();

                    parameters.Add("entidadgrupo_id", entidad.entidadgrupo_id);
                    parameters.Add("entidadsector_id", entidad.entidadsector_id);
                    parameters.Add("numero_ruc", entidad.numero_ruc);
                    parameters.Add("acronimo", entidad.acronimo);
                    parameters.Add("nombre", entidad.nombre);
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

        public Response Update(Entidad entidad)
        {
            Response retorno = new Response();

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var query = "dbo.USP_UPD_ENTIDAD";

                    var parameters = new DynamicParameters();

                    parameters.Add("entidad_id", entidad.entidad_id);
                    parameters.Add("entidadgrupo_id", entidad.entidadgrupo_id);
                    parameters.Add("entidadsector_id", entidad.entidadsector_id);
                    parameters.Add("numero_ruc", entidad.numero_ruc);
                    parameters.Add("acronimo", entidad.acronimo);
                    parameters.Add("nombre", entidad.nombre);
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

        public Response Delete(Entidad entidad)
        {
            Response retorno = new Response();

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var query = "dbo.USP_DEL_ENTIDAD";

                    var parameters = new DynamicParameters();

                    parameters.Add("entidad_id", entidad.entidad_id);
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

        public Response<dynamic> GetById(Entidad entidad)
        {
            Response<dynamic> retorno = new Response<dynamic>();

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var query = "dbo.USP_GET_ENTIDAD";

                    var parameters = new DynamicParameters();

                    parameters.Add("entidad_id", entidad.entidad_id.Equals(0) ? (int?)null : entidad.entidad_id);
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

        public Response<List<dynamic>> GetList(Entidad entidad)
        {
            Response<List<dynamic>> retorno = new Response<List<dynamic>>();

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var query = "dbo.USP_SEL_ENTIDAD";

                    var parameters = new DynamicParameters();

                    parameters.Add("entidad_id", entidad.entidad_id.Equals(0) ? (int?)null : entidad.entidad_id);
                    parameters.Add("entidadgrupo_id", entidad.entidadgrupo_id);
                    parameters.Add("entidadsector_id", entidad.entidadsector_id);
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

        public Response UpdateGeneralidades(Entidad entidad)
        {
            Response retorno = new Response();

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var query = "dbo.USP_UPD_ENTIDAD_GENERALIDADES";

                    var parameters = new DynamicParameters();

                    parameters.Add("entidad_id", entidad.entidad_id);
                    parameters.Add("ubigeo_id", entidad.ubigeo_id);
                    parameters.Add("documentoestructura_id", entidad.documentoestructura_id);
                    parameters.Add("modalidadintegridad_id", entidad.modalidadintegridad_id);
                    parameters.Add("documentoestructura_doc", entidad.documentoestructura_doc);
                    parameters.Add("modalidadintegridad_doc", entidad.modalidadintegridad_doc);
                    parameters.Add("modalidadintegridad_anterior", entidad.modalidadintegridad_anterior);
                    parameters.Add("documentointegridad_desc", entidad.documentointegridad_desc);
                    parameters.Add("documentointegridad_doc", entidad.documentointegridad_doc);
                    parameters.Add("num_servidores", entidad.num_servidores);
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

        public Response<List<dynamic>> GetListGeneralidades(Entidad entidad)
        {
            Response<List<dynamic>> retorno = new Response<List<dynamic>>();

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var query = "dbo.USP_SEL_ENTIDAD_GENERALIDADES";

                    var parameters = new DynamicParameters();

                    parameters.Add("entidad_id", entidad.entidad_id.Equals(0) ? (int?)null : entidad.entidad_id);
                    parameters.Add("entidadgrupo_id", entidad.entidadgrupo_id);
                    parameters.Add("entidadsector_id", entidad.entidadsector_id);
                    parameters.Add("ubigeo_id", entidad.ubigeo_id);
                    parameters.Add("documentoestructura_id", entidad.documentoestructura_id);
                    parameters.Add("modalidadintegridad_id", entidad.modalidadintegridad_id);
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
