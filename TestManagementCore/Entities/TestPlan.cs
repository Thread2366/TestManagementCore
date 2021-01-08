using System;
using System.Collections.Generic;
using System.Text;

namespace TestManagementCore.Entities
{
    public class TestPlan
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int SpecificationId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
    }
}
