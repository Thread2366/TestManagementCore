using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestManagement.Dto;
using TestManagementCore.AdminAuth;
using TestManagementCore.Api;
using TestManagementCore.Entities;
using TestManagementCore.Integration;
using TestManagementCore.Security;

namespace TestManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SecurityController : ControllerBase
    {
        public ISecurityService _securityService;

        public SecurityController(ISecurityService securityService)
        {
            _securityService = securityService;
        }

        [HttpGet("[action]")]
        public IEnumerable<Role> Roles()
        {
            return _securityService.GetRoles();
        }

        [HttpGet("[action]")]
        public IEnumerable<Permission> Permissions()
        {
            return _securityService.GetPermissions();
        }

        [HttpGet("[action]")]
        public IEnumerable<AccessRuleDto> GetAccessRules()
        {
            return _securityService.GetAccessRules().Select(tpl => new AccessRuleDto()
            {
                Permission = tpl.Item1,
                Role = tpl.Item2
            });
        }

        [HttpPost("[action]")]
        public IActionResult Allow([FromBody] PermRoleIdsPair permRolePair)
        {
            return _securityService.AllowAccess(permRolePair.PermId, permRolePair.RoleId) > 0 ? Ok() : BadRequest();
        }

        [HttpPost("[action]")]
        public IActionResult Deny([FromBody] PermRoleIdsPair permRolePair)
        {
            return _securityService.DenyAccess(permRolePair.PermId, permRolePair.RoleId) > 0 ? Ok() : BadRequest();
        }

        [HttpGet("[action]")]
        public bool Check(int permId, int roleId)
        {
            return _securityService.CheckAccess(permId, roleId);
        }
    }
}
