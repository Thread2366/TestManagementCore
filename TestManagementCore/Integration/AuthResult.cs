using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestManagementCore.Integration
{
    public class AuthResult
    {
        public bool IsSuccess { get; }
        public string Error { get; }
        public string Cookie { get; }

        private AuthResult(bool isSuccess, string cookie, string error)
        {
            IsSuccess = isSuccess;
            Cookie = cookie;
            Error = error;
        }

        public static AuthResult Success(string cookie)
        {
            return new AuthResult(true, cookie, null);
        }

        public static AuthResult Fail(string error)
        {
            return new AuthResult(false, null, error);
        }
    }
}
