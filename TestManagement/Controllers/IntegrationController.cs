using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestManagementCore.Entities;
using TestManagementCore.Integration;

namespace TestManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IntegrationController : ControllerBase
    {
        public IIntegrationService _integrationService;

        public IntegrationController(IIntegrationService integrationService)
        {
            _integrationService = integrationService;
        }

        [HttpGet("[action]/{login}")]
        public async Task<Dictionary<Project, Role>> Projects(string login)
        {
            return await _integrationService.GetProjects(login);
        }

        [HttpGet("[action]/{login}")]
        public async Task<User> UserInfo(string login)
        {
            return await _integrationService.GetUserInfo(login);
        }

        [HttpGet("[action]/{projectId}")]
        public async Task<IEnumerable<Specification>> Specifications(int projectId)
        {
            return await _integrationService.GetSpecifications(projectId);
        }

        [HttpGet("[action]/{specId}")]
        public async Task<Specification> Specification(int specId)
        {
            return await _integrationService.GetSpecificationById(specId);
        }

        [HttpGet("[action]/{specId}")]
        public async Task<IEnumerable<Requirement>> Requirements(int specId)
        {
            return await _integrationService.GetRequirements(specId);
        }

        [HttpGet("[action]/{specId}")]
        public async Task<Requirement> Requirement(int reqId)
        {
            return await _integrationService.GetRequirementById(reqId);
        }
    }
}
