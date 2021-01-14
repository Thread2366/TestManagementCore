using System.Collections.Generic;
using TestManagementCore.Entities;

namespace TestManagementCore.Api
{
    public interface IApiService
    {
        ServiceSettings Settings { get; }

        bool CheckIfRequirementIsTested(int id);
        IEnumerable<int> GetTestedRequirements(int id);
    }
}