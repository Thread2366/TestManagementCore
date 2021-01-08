using System;
using System.Collections.Generic;
using System.Text;

namespace TestManagementCore.Entities
{
    public class TestContainer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ExecutionOrder { get; set; }
        public string ParentId { get; set; }
        public string AuthorId { get; set; }
    }
}
