using System;
using System.Collections.Generic;
using System.Text;
using Dapper.Contrib.Extensions;

namespace TestManagementCore.Entities
{
    [Table("TestPlans")]
    public class TestPlan : ITestEntity
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int SpecificationId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AuthorLogin { get; set; }
    }
}
