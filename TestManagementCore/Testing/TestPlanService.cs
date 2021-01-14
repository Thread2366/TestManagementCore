using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagementCore.Entities;

namespace TestManagementCore.Testing
{
    public class TestPlanService : TestServiceBase<TestPlan>
    {
        public TestPlanService(ServiceSettings settings) : base(settings)
        {
        }
    }
}
