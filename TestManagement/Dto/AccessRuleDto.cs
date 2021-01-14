using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestManagementCore.Entities;

namespace TestManagement.Dto
{
    public class AccessRuleDto
    {
        public Role Role { get; set; }
        public Permission Permission { get; set; }
    }
}
