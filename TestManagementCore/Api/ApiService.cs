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
    public class ApiService : IApiService
    {
        public ServiceSettings Settings { get; }

        public ApiService(ServiceSettings settings)
        {
            Settings = settings;
        }

        public bool CheckIfRequirementIsTested(int id)
        {
            var testCaseIds = new List<int>();
            using var conn = new SqlConnection(Settings.ConnectionString);
            var containers = conn.Query<ContainerRequirementLink>(
                "SELECT * FROM TestContainers_Requirements WHERE RequirementId = @RequirementId",
                new { RequirementId = id }).Select(x => x.ContainerId);
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

        public IEnumerable<int> GetTestedRequirements(int id)
        {
            return Enumerable.Empty<int>();
        }
    }
}
