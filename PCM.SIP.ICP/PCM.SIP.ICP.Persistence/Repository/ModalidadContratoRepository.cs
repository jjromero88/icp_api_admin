using Dapper;
using PCM.SIP.ICP.Aplicacion.Interface.Persistence;
using PCM.SIP.ICP.Domain.Entities;
using PCM.SIP.ICP.Persistence.Context;
using PCM.SIP.ICP.Transversal.Common;
using System.Data;

namespace PCM.SIP.ICP.Persistence.Repository
{
    public class ModalidadContratoRepository : IModalidadContratoRepository
    {
        private readonly DapperContext _context;

        public ModalidadContratoRepository(DapperContext context)
        {
            _context = context;
        }
        public Response Insert(ModalidadContrato entidad)
        {
            throw new NotImplementedException();
        }

        public Response Update(ModalidadContrato entidad)
        {
            throw new NotImplementedException();
        }

        public Response Delete(ModalidadContrato entidad)
        {
            throw new NotImplementedException();
        }

        public Response<dynamic> GetById(ModalidadContrato entidad)
        {
            throw new NotImplementedException();
        }

        public Response<List<dynamic>> GetList(ModalidadContrato entidad)
        {
            Response<List<dynamic>> retorno = new Response<List<dynamic>>();

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var query = "dbo.USP_SEL_MODALIDAD";

                    var parameters = new DynamicParameters();

                    parameters.Add("modalidad_id", entidad.modalidad_id.Equals(0) ? (int?)null : entidad.modalidad_id);
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
