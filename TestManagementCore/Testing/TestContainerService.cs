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
        public TestContainerService(ServiceSettings settings) : base(settings)
        {
        }

        public int BindRequirements(int containerId, IEnumerable<int> reqIds)
        {
            using var conn = new SqlConnection(Settings.ConnectionString);
            return conn.Execute("INSERT INTO TestContainers_Requirements (ContainerId, RequirementId) VALUES " +
                $"{string.Join(',', reqIds.Select(reqId => $"({containerId}, {reqId})"))}");
        }
    }
}
