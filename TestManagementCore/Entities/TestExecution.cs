using System;
using System.Collections.Generic;
using System.Text;

namespace TestManagementCore.Entities
{
    public class TestExecution
    {
        public int Id { get; set; }
        public bool Success { get; set; }
        public string Result { get; set; }
        public string Comment { get; set; }
        public DateTime ExecutionDate { get; set; }
        public int TestCaseId { get; set; }
        public int ExecutorId { get; set; }
    }
}
