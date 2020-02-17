using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Repositories.Connection
{
    public class Connection : IConnection
    {
        private readonly IConfiguration _configuration;
        public static string connectionString = "";
        public Connection(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("Dapper");
        }
        public IDbConnection GetConnection
        {
            get
            {
                IDbConnection conn = new SqlConnection(connectionString);
                return conn;
            }
        }

        public string SetConnection()
        {
            return connectionString;
        }
    }
}
