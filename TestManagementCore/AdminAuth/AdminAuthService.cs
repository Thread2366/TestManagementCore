using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using TestManagementCore.Entities;

namespace TestManagementCore.AdminAuth
{
    public class AdminAuthService : IAdminAuthService
    {
        public ServiceSettings Settings { get; }

        public AdminAuthService(ServiceSettings settings)
        {
            Settings = settings;
        }

        public string GetPasswordHash(string login)
        {
            using (var conn = new SqlConnection(Settings.ConnectionString))
            {
                var adm = conn.QueryFirstOrDefault<Administrator>(
                    "SELECT * FROM Administrators WHERE Login = @Login", new { Login = login });
                return adm?.PasswordHash;
            }
        }

        public void RegisterAdmin(string login, string passwordHash)
        {
            using (var conn = new SqlConnection(Settings.ConnectionString))
            {
                conn.Execute("INSERT INTO Administrators (Login, PasswordHash) VALUES (@Login, @Password)",
                    new { Login = login, Password = passwordHash });
            }
        }
    }
}
