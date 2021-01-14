using System;
using Dapper.Contrib.Extensions;

namespace TestManagementCore.Entities
{
    [Table("Roles")]
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
    }
}
