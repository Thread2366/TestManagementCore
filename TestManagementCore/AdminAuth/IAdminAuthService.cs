using System.Threading.Tasks;

namespace TestManagementCore.AdminAuth
{
    public interface IAdminAuthService
    {
        public ServiceSettings Settings { get; }

        string GetPasswordHash(string login);
        void RegisterAdmin(string login, string passwordHash);
    }
}