using System;
using System.Collections.Generic;
using System.Text;
using Dapper.Contrib.Extensions;

namespace TestManagementCore.Entities
{
    [Table("TestCases")]
    public class TestCase : ITestEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Precondition { get; set; }
        public string Postcondition { get; set; }
        public string Action { get; set; }
        public string Expected { get; set; }
        public int ExecutionOrder { get; set; }
        public int ContainerId { get; set; }
        public string AuthorLogin { get; set; }
        public bool Tested { get; set; }
    }
}
