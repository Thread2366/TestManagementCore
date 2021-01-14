using System;
using System.Collections.Generic;
using System.Text;
using Dapper.Contrib.Extensions;

namespace TestManagementCore.Entities
{
    [Table("TestContainers_Requirements")]
    public class ContainerRequirementLink
    {
        public int Id { get; set; }
        public int ContainerId { get; set; }
        public int RequirementId { get; set; }
    }
}
