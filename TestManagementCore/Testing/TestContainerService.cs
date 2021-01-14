using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagementCore.Entities;
using Dapper;
using Dapper.Contrib.Extensions;

namespace TestManagementCore.Testing
{
    public class TestContainerService : TestServiceBase<TestContainer>
    {
        public TestContainerService(string connectionString) : base(connectionString)
        {
        }
    }
}
