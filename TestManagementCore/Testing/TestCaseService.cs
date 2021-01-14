using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Dapper;
using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations.Schema;
using TestManagementCore.Entities;

namespace TestManagementCore.Testing
{
    public class TestCaseService : TestServiceBase<TestCase>
    {
        public TestCaseService(string connectionString) : base(connectionString)
        {
        }

        public long RegisterExecution(TestExecution execution)
        {
            execution.ExecutionDate = DateTime.Now;
            using (var conn = new SqlConnection(ConnectionString))
            {
                return conn.Insert(execution);
            }
        }
    }
}
