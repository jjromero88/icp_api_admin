using Dapper;
using PCM.SIP.ICP.Aplicacion.Interface.Persistence;
using PCM.SIP.ICP.Domain.Entities;
using PCM.SIP.ICP.Persistence.Context;
using PCM.SIP.ICP.Transversal.Common;
using PCM.SIP.ICP.Transversal.Common.Data;
using System.Data;

namespace PCM.SIP.ICP.Persistence.Repository
{
    public class PreguntaRepository : IPreguntaRepository
    {
        private readonly DapperContext _context;

        public PreguntaRepository(DapperContext context)
        {
            _context = context;
        }

        public Response Insert(Pregunta entidad)
        {
            Response retorno = new Response();

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var query = "dbo.USP_INS_PREGUNTA";

                    var parameters = new DynamicParameters();

                    parameters.Add("componente_id", entidad.componente_id);
                    parameters.Add("numero", entidad.numero);
                    parameters.Add("descripcion", entidad.descripcion);
                    parameters.Add("calculo_icp", entidad.calculo_icp);
                    parameters.Add("habilitado", entidad.habilitado);
                    parameters.Add("usuario_reg", entidad.usuario_reg);
                    parameters.Add("error", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                    parameters.Add("message", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);

                    var alternativasTable = DataTableHelper.ConvertToDataTable(entidad.alternativas ?? new List<TypeAlternativa>());
                    parameters.Add("ALTERNATIVAS", alternativasTable.AsTableValuedParameter("UDT_ALTERNATIVA"));

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

        public Response Update(Pregunta entidad)
        {
            Response retorno = new Response();

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var query = "dbo.USP_UPD_PREGUNTA";

                    var parameters = new DynamicParameters();

                    parameters.Add("pregunta_id", entidad.pregunta_id);
                    parameters.Add("componente_id", entidad.componente_id);
                    parameters.Add("numero", entidad.numero);
                    parameters.Add("descripcion", entidad.descripcion);
                    parameters.Add("calculo_icp", entidad.calculo_icp);
                    parameters.Add("habilitado", entidad.habilitado);
                    parameters.Add("usuario_act", entidad.usuario_act);
                    parameters.Add("error", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                    parameters.Add("message", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);

                    var dtAlternativas = DataTableHelper.ConvertToDataTable(entidad.alternativas ?? new List<TypeAlternativa>());
                    parameters.Add("ALTERNATIVAS", dtAlternativas.AsTableValuedParameter("UDT_ALTERNATIVA"));

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

        public Response Delete(Pregunta entidad)
        {
            Response retorno = new Response();

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var query = "dbo.USP_DEL_PREGUNTA";

                    var parameters = new DynamicParameters();

                    parameters.Add("pregunta_id", entidad.pregunta_id);
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

        public Response<dynamic> GetById(Pregunta entidad)
        {
            Response<dynamic> retorno = new Response<dynamic>();

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var query = "dbo.USP_GET_PREGUNTA";

                    var parameters = new DynamicParameters();

                    parameters.Add("pregunta_id", entidad.pregunta_id.Equals(0) ? (int?)null : entidad.pregunta_id);
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

        public Response<List<dynamic>> GetList(Pregunta entidad)
        {
            Response<List<dynamic>> retorno = new Response<List<dynamic>>();

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var query = "dbo.USP_SEL_PREGUNTA";

                    var parameters = new DynamicParameters();

                    parameters.Add("pregunta_id", entidad.pregunta_id.Equals(0) ? (int?)null : entidad.pregunta_id);
                    parameters.Add("componente_id", entidad.componente_id);
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
