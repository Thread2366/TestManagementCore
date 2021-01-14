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
        public string ConnectionString { get; }

        public IEnumerable<Permission> GetPermissionsByName(string permissionName)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var perms = conn.Query<Permission>(
                    "SELECT * FROM Permissions WHERE PermissionName = @PermName", new { PermName = permissionName });
                return perms;
            }
        }

        public IEnumerable<Role> GetRolesByName(string roleName)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var roles = conn.Query<Role>(
                    "SELECT * FROM Roles WHERE RoleName = @RoleName", new { RoleName = roleName });
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

        public void AllowAccess(int permId, int roleId)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Insert(new AccessRule() { PermissionId = permId, RoleId = roleId });
                conn.Execute("INSERT INTO AccessRules (PermissionId, RoleId) VALUES (@PermId, @RoleId)",
                    new { PermId = permId, RoleId = roleId });
            }
        }

        public void DenyAccess(int permId, int roleId)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Execute("DELETE FROM AccessRules WHERE PermissionId = @PermId AND RoleId = @RoleId",
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
