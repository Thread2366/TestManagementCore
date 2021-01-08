using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestManagementCore
{
    public class TestManagementSettings
    {
        public string ConnectionString { get; }
        public string SpecificationsEndpoint { get; }
        public string RequirementsEndpoint { get; }
        public string AuthEndpoint { get; }
        public string ProjectsEndpoint { get; }
    }
}
