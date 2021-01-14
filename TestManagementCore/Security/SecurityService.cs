using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagementCore.Entities;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Data;

namespace TestManagementCore.Security
{
    public class SecurityService : ISecurityService
    {
        public SecurityService(ServiceSettings settings)
        {
            ConnectionString = settings.ConnectionString;
        }

        public string ConnectionString { get; }

        public IEnumerable<Permission> GetPermissions()
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var perms = conn.Query<Permission>("SELECT * FROM Permissions");
                return perms;
            }
        }

        public IEnumerable<Role> GetRoles()
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var roles = conn.Query<Role>("SELECT * FROM Roles");
                return roles;
            }
        }

        public IEnumerable<(Permission, Role)> GetAccessRules()
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var perms = conn.Query<Permission>("SELECT * FROM Permissions").ToDictionary(perm => perm.Id);
                var roles = conn.Query<Role>("SELECT * FROM Roles").ToDictionary(role => role.Id);
                return conn.Query<AccessRule>("SELECT * FROM AccessRules")
                    .Select(rule => (perms[rule.PermissionId], roles[rule.RoleId]));
            }
        }

        public long AllowAccess(int permId, int roleId)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                return conn.Insert(new AccessRule() { PermissionId = permId, RoleId = roleId });
            }
        }

        public int DenyAccess(int permId, int roleId)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                return conn.Execute("DELETE FROM AccessRules WHERE PermissionId = @PermId AND RoleId = @RoleId",
                    new { PermId = permId, RoleId = roleId });
            }
        }

        public bool CheckAccess(int permId, int roleId)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var rule = conn.QueryFirstOrDefault<AccessRule>(
                    "SELECT * FROM AccessRules WHERE PermissionId = @PermId AND RoleId = @RoleId",
                    new { PermId = permId, RoleId = roleId });
                return rule != null;
            }
        }
    }
}
