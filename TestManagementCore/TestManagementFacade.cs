using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestManagementCore
{
    public class TestManagementFacade
    {
        private readonly TestManagementSettings _settings;

        public TestManagementFacade(TestManagementSettings settings)
        {
            _settings = settings;
        }

        public AuthManager GetAuthManager()
        {

        }
    }
}
