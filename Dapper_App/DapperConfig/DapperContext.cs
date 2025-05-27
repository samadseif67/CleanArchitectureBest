using Microsoft.Data.SqlClient;
using System.Data;

namespace Dapper_App.DapperConfig
{
    public class DapperContext
    {

        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DapperShopConnection");
        }

        public IDbConnection CreateConnection()
        {
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            return dbConnection;
        }
    }
}
