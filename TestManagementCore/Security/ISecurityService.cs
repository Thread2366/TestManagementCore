using System.Collections.Generic;
using TestManagementCore.Entities;

namespace TestManagementCore.Security
{
    public interface ISecurityService
    {
        string ConnectionString { get; }

        void AllowAccess(int permId, int roleId);
        bool CheckAccess(int permId, int roleId);
        void DenyAccess(int permId, int roleId);
        IEnumerable<(Permission, Role)> GetAccessRules();
        IEnumerable<Permission> GetPermissionsByName(string permissionName);
        IEnumerable<Role> GetRolesByName(string roleName);
    }
}