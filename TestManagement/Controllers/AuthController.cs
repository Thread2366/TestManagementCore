using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestManagement.Dto;
using TestManagementCore;
using TestManagementCore.AdminAuth;
using TestManagementCore.Integration;

namespace TestManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        public IAdminAuthService _adminAuthService;
        public IIntegrationService _integrationService;

        public AuthController(IAdminAuthService adminAuthService, IIntegrationService integrationService)
        {
            _adminAuthService = adminAuthService;
            _integrationService = integrationService;
        }

        [HttpPost("[action]")]
        public IActionResult Admin([FromBody]Creds creds)
        {
            if (_adminAuthService.GetPasswordHash(creds.Login).Equals(creds.Password))
                return Ok();
            else return Forbid();
        }

        [HttpPost]
        public async Task<IActionResult> Auth([FromBody]Creds creds)
        {
            var authResult = await _integrationService.Auth(creds.Login, creds.Password);
            if (authResult.IsSuccess) return Ok();
            else return Forbid();
        }
    }
}
