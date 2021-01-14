using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagementCore.Entities;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Data.SqlClient;

namespace TestManagementCore.Api
{
    public class ApiService
    {
        public string ConnectionString { get; }

        public ApiService(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public bool CheckIfRequirementIsTested(Requirement requirement)
        {
            var testCaseIds = new List<int>();
            using var conn = new SqlConnection(ConnectionString);
            var containers = conn.Query<ContainerRequirementLink>(
                "SELECT * FROM TestContainers_Requirements WHERE RequirementId = @RequirementId",
                new { RequirementId = requirement.Id }).Select(x => x.ContainerId);
            while (containers.Any())
            {
                var inClause = string.Join(',', containers);
                testCaseIds.AddRange(
                    conn.Query<TestCase>($"SELECT * FROM TestCases WHERE ContainerId IN ({inClause})")
                    .Select(x => x.Id));
                containers = conn.Query<TestContainer>($"SELECT * FROM TestContainers WHERE ParentId IN ({inClause})").Select(x => x.Id);
            }

            if (testCaseIds.Count == 0) return false;

            using var reader = conn.ExecuteReader($"SELECT * FROM TestExecutions " +
                $"WHERE TestCaseId IN ({string.Join(',', testCaseIds)}) " +
                $"ORDER BY ExecutionDate DESC");

            var parser = reader.GetRowParser<TestExecution>();
            var idsHashSet = new HashSet<int>(testCaseIds);
            while (reader.Read())
            {
                var exec = parser(reader);
                if (idsHashSet.Contains(exec.TestCaseId) && exec.Success)
                {
                    if (exec.Success) idsHashSet.Remove(exec.TestCaseId);
                    else return false;
                }
                if (idsHashSet.Count == 0) break;
            }
            if (idsHashSet.Count != 0) return false;
            return true;
        }

        public IEnumerable<int> GetTestedRequirements(Specification specification)
        {
            throw new NotImplementedException();
        }
    }
}
