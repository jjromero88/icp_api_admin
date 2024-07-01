using Dapper;
using PCM.SIP.ICP.Aplicacion.Interface.Persistence;
using PCM.SIP.ICP.Domain.Entities;
using PCM.SIP.ICP.Persistence.Context;
using PCM.SIP.ICP.Transversal.Common;
using System.Data;

namespace PCM.SIP.ICP.Persistence.Repository
{
    public class EtapaRepository : IEtapaRepository
    {
        private readonly DapperContext _context;

        public EtapaRepository(DapperContext context)
        {
            _context = context;
        }

        public Response Insert(Etapa entidad)
        {
            throw new NotImplementedException();
        }

        public Response Update(Etapa entidad)
        {
            throw new NotImplementedException();
        }

        public Response Delete(Etapa entidad)
        {
            throw new NotImplementedException();
        }

        public Response<dynamic> GetById(Etapa entidad)
        {
            throw new NotImplementedException();
        }

        public Response<List<dynamic>> GetList(Etapa entidad)
        {
            Response<List<dynamic>> retorno = new Response<List<dynamic>>();

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var query = "dbo.USP_SEL_ETAPA";

                    var parameters = new DynamicParameters();

                    parameters.Add("etapa_id", entidad.etapa_id.Equals(0) ? (int?)null : entidad.etapa_id);
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
