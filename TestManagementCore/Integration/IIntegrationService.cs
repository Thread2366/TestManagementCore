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
        ServiceSettings Settings { get; }


        #region Tasks management

        Task<AuthResult> Auth(string login, string password);
        Task<User> GetUserInfo(string login);
        Task<Dictionary<Project, Role>> GetProjects(string login);

        #endregion


        #region Requirements management

        Task<IEnumerable<Specification>> GetSpecifications(int projectId);
        Task<IEnumerable<Requirement>> GetRequirements(int specificationId);
        Task<Specification> GetSpecificationById(int id);
        Task<Requirement> GetRequirementById(int id);

        #endregion
    }
}
