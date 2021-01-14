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
    public class TestPlanController : ControllerBase
    {
        public TestPlanService _testPlanService;

        public TestPlanController(TestPlanService testPlanService)
        {
            _testPlanService = testPlanService;
        }

        [HttpGet("{id}")]
        public TestPlan Get(int id)
        {
            return _testPlanService.GetById(id);
        }

        [HttpPut]
        public IActionResult Put([FromBody] TestPlan testPlan)
        {
            return _testPlanService.Edit(testPlan) ? Ok() : BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return _testPlanService.Delete(id) > 0 ? Ok() : BadRequest();
        }

        [HttpPost]
        public IActionResult Post([FromBody] TestPlan testPlan)
        {
            return _testPlanService.Create(testPlan) > 0 ? Ok() : BadRequest();
        }
    }
}
