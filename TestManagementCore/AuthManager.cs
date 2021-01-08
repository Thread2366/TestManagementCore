using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace TestManagementCore
{
    public class AuthManager
    {
        public string ConnectionString { get; }

        public AuthManager(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public Task<bool> AdminAuth(string login, SecureString password)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                var command = conn.CreateCommand();
            }
        }
    }
}
