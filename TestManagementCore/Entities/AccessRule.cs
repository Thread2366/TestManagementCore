using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Dapper.Contrib.Extensions;

namespace TestManagementCore.Entities
{
    [Table("AccessRules")]
    public class AccessRule
    {
        public int Id { get; set; }
        public int PermissionId { get; set; }
        public int RoleId { get; set; }
    }
}
