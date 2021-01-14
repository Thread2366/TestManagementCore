using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestManagement.Dto
{
    public class RequirementBinding
    {
        public int ContainerId { get; set; }
        public IEnumerable<int> RequirementIds { get; set; }
    }
}
