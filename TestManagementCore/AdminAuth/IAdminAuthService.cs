using System.Threading.Tasks;

namespace TestManagementCore.AdminAuth
{
    public interface IAdminAuthService
    {
        string GetPasswordHash(string login);
        void RegisterAdmin(string login, string passwordHash);
    }
}