using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestManagement.Dto;
using TestManagementCore.AdminAuth;
using TestManagementCore.Api;
using TestManagementCore.Entities;
using TestManagementCore.Integration;
using TestManagementCore.Testing;

namespace TestManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestContainerController : ControllerBase
    {
        public TestContainerService _testContainerService;

        public TestContainerController(TestContainerService testContainerService)
        {
            _testContainerService = testContainerService;
        }

        [HttpGet("{id}")]
        public TestContainer Get(int id)
        {
            return _testContainerService.GetById(id);
        }

        [HttpPut]
        public IActionResult Put([FromBody] TestContainer testContainer)
        {
            return _testContainerService.Edit(testContainer) ? Ok() : BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return _testContainerService.Delete(id) > 0 ? Ok() : BadRequest();
        }

        [HttpPost]
        public IActionResult Post([FromBody] TestContainer testContainer)
        {
            return _testContainerService.Create(testContainer) > 0 ? Ok() : BadRequest();
        }

        [HttpPost("[action]")]
        public IActionResult Bind([FromBody] RequirementBinding binding)
        {
            return _testContainerService.BindRequirements(binding.ContainerId, binding.RequirementIds) > 0 ?
                Ok() : BadRequest();
        }
    }
}
