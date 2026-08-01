using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Data
{
    public class DapperContext
    {
        IConfiguration config;

        public DapperContext(IConfiguration config)
        {
            this.config = config;
        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(
                config.GetConnectionString("DefaultConnection"));
        }
    }
}
