using Dapper;
using System.Data;
using PCM.SIP.ICP.Aplicacion.Interface.Persistence;
using PCM.SIP.ICP.Domain.Entities;
using PCM.SIP.ICP.Persistence.Context;
using PCM.SIP.ICP.Transversal.Common;

namespace PCM.SIP.ICP.Persistence.Repository
{
    internal class DocumentoEstructuraRepository : IDocumentoEstructuraRepository
    {
        private readonly DapperContext _context;

        public DocumentoEstructuraRepository(DapperContext context)
        {
            _context = context;
        }

        public Response Insert(DocumentoEstructura entidad)
        {
            throw new NotImplementedException();
        }

        public Response Update(DocumentoEstructura entidad)
        {
            throw new NotImplementedException();
        }
        public Response Delete(DocumentoEstructura entidad)
        {
            throw new NotImplementedException();
        }

        public Response<dynamic> GetById(DocumentoEstructura entidad)
        {
            throw new NotImplementedException();
        }

        public Response<List<dynamic>> GetList(DocumentoEstructura entidad)
        {
            Response<List<dynamic>> retorno = new Response<List<dynamic>>();

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var query = "dbo.USP_SEL_DOCUMENTOESTRUCTURA";

                    var parameters = new DynamicParameters();

                    parameters.Add("documentoestructura_id", entidad.documentoestructura_id.Equals(0) ? (int?)null : entidad.documentoestructura_id);
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
