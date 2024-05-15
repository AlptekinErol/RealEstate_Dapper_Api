using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace RealEstate_Dapper_Api.Models.DapperContext
{
    public class Context
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public Context(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("connection"); // buradaki connection parametresi bizim appsetting.json da sql connection string içeren key değerimiz
        }
        public DbConnection CreateConnection() => new SqlConnection(_connectionString); // Dapper için gerekli olan Create connection methodu eklendi
    }
}
