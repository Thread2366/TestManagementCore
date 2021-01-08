using System;
using System.Collections.Generic;
using System.Text;

namespace TestManagementCore.Entities
{
    public class ContainerPlanLink
    {
        public int Id { get; set; }
        public int TestContainerId { get; set; }
        public int TestPlanId { get; set; }
    }
}
