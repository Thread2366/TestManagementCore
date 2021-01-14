using System;
using System.Collections.Generic;
using System.Text;
using Dapper.Contrib.Extensions;

namespace TestManagementCore.Entities
{
    [Table("Permissions")]
    public class Permission
    {
        public int Id { get; set; }
        public string PermissionName { get; set; }
        public string Description { get; set; }
    }
}
