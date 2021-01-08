using System;
using System.Collections.Generic;
using System.Text;

namespace TestManagementCore.Entities
{
    public class AccessRule
    {
        public int Id { get; set; }
        public int PermissionId { get; set; }
        public int RoleId { get; set; }
    }
}
