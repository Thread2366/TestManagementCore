using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestManagementCore.Integration
{

    [Serializable]
    public class IntegrationRequestException : Exception
    {
        public IntegrationRequestException() { }
        public IntegrationRequestException(string message) : base(message) { }
        public IntegrationRequestException(string message, Exception inner) : base(message, inner) { }
        protected IntegrationRequestException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
