using System;
using System.Collections.Generic;
using System.Text;

namespace TestManagementCore.Entities
{
    public class ContainerRequirementLink
    {
        public int Id { get; set; }
        public int ContainerId { get; set; }
        public int RequirementId { get; set; }
    }
}
