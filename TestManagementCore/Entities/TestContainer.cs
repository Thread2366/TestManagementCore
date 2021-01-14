using System;
using System.Collections.Generic;
using System.Text;
using Dapper.Contrib.Extensions;

namespace TestManagementCore.Entities
{
    [Table("TestContainers")]
    public class TestContainer : ITestEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ExecutionOrder { get; set; }
        public string ParentId { get; set; }
        public int TestPlanId { get; set; }
        public bool Tested { get; set; }
    }
}
