using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using DAL.DataContext.Contract;

namespace DAL.DataContext
{
    public class DapperHelper : IDapperHelper
    {

        private readonly IConfiguration _configuration;
        public string ConnectionString { get; set; }
        public string ProviderName { get; set; }

        public DapperHelper(IConfiguration configuration) {
            _configuration = configuration;

            ConnectionString = _configuration.GetConnectionString("DBConnection");
            ProviderName = "MySql.Data.MySqlClient";
        }

        public IDbConnection GetDapperHelper() {
            return new MySqlConnection(ConnectionString);
        }

    }
}
