using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestManagementCore
{
    public class ServiceSettings
    {
        public string ConnectionString { get; set; }
        public string SpecificationsEndpoint { get; set; }
        public string RequirementsEndpoint { get; set; }
        public string AuthEndpoint { get; set; }
        public string UserEndpoint { get; set; }
        public string ProjectsEndpoint { get; set; }
    }
}
