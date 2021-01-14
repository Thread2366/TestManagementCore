using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagementCore.Entities;

namespace TestManagementCore.Integration
{
    public interface IIntegrationService
    {
        string ConnectionString { get; }
        IntegrationEndpoints Endpoints { get; }


        #region Tasks management

        Task<AuthResult> Auth(string login, string password);
        Task<User> GetUserInfo(string login);
        Task<Dictionary<Project, Role>> GetProjects(User user);

        #endregion


        #region Requirements management

        Task<IEnumerable<Specification>> GetSpecifications(Project project);
        Task<IEnumerable<Requirement>> GetRequirements(Specification specification);
        Task<Specification> GetSpecificationById(int id);
        Task<Requirement> GetRequirementById(int id);

        #endregion
    }
}
