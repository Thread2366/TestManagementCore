using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestManagement.Dto;
using TestManagementCore.AdminAuth;
using TestManagementCore.Api;
using TestManagementCore.Entities;
using TestManagementCore.Integration;

namespace TestManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        public IApiService _apiService;

        public ApiController(IApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet("check-tested/[action]")]
        public bool Requirement(int id)
        {
            return _apiService.CheckIfRequirementIsTested(id);
        }

        [HttpGet("check-tested/[action]")]
        public IEnumerable<int> Specification(int id)
        {
            return _apiService.GetTestedRequirements(id);
        }
    }
}
