using System.Collections.Generic;
using TestManagementCore.Entities;

namespace TestManagementCore.Security
{
    public interface ISecurityService
    {
        string ConnectionString { get; }

        long AllowAccess(int permId, int roleId);
        bool CheckAccess(int permId, int roleId);
        int DenyAccess(int permId, int roleId);
        IEnumerable<(Permission, Role)> GetAccessRules();
        IEnumerable<Permission> GetPermissions();
        IEnumerable<Role> GetRoles();
    }
}