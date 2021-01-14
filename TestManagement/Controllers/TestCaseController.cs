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
    public class TestCaseController : ControllerBase
    {
        public TestCaseService _testCaseService;

        public TestCaseController(TestCaseService testCaseService)
        {
            _testCaseService = testCaseService;
        }

        [HttpGet("{id}")]
        public TestCase Get(int id)
        {
            return _testCaseService.GetById(id);
        }

        [HttpPut]
        public IActionResult Put([FromBody] TestCase testCase)
        {
            return _testCaseService.Edit(testCase) ? Ok() : BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return _testCaseService.Delete(id) > 0 ? Ok() : BadRequest();
        }

        [HttpPost]
        public IActionResult Post([FromBody] TestCase testCase)
        {
            return _testCaseService.Create(testCase) > 0 ? Ok() : BadRequest();
        }

        [HttpPost("[action]")]
        public IActionResult Exec(TestExecution execution)
        {
            return _testCaseService.RegisterExecution(execution) > 0 ? Ok() : BadRequest();
        }
    }
}
