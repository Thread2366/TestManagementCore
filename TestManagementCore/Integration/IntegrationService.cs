using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagementCore.Entities;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace TestManagementCore.Integration
{
    public class IntegrationService : IIntegrationService
    {
        public IntegrationService(ServiceSettings settings)
        {
            Settings = settings;
        }

        public ServiceSettings Settings { get; }

        #region Tasks management

        public async Task<AuthResult> Auth(string login, string password)
        {
            using (var http = new HttpClient())
            {
                var content = new StringContent(
                    JsonConvert.SerializeObject(new { Login = login, Password = password }),
                    Encoding.UTF8,
                    "application/json");
                var response = await http.PostAsync(Settings.AuthEndpoint, content);
                var respBody = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == HttpStatusCode.Forbidden)
                    return AuthResult.Fail(respBody);
                else if (response.IsSuccessStatusCode)
                    return AuthResult.Success(respBody);
                else throw new IntegrationRequestException($"Code: {response.StatusCode}, Message: {respBody}");
            }
        }

        public Task<User> GetUserInfo(string login)
        {
            return HttpSend<string, User>(login, $"{Settings.UserEndpoint.TrimEnd('/')}/{login}");
        }

        public Task<Dictionary<Project, Role>> GetProjects(string login)
        {
            return HttpSend<string, Dictionary<Project, Role>>(
                login, $"{Settings.ProjectsEndpoint.TrimEnd('/')}?login={login}");
        }

        #endregion


        #region Requirements management

        public Task<IEnumerable<Specification>> GetSpecifications(int projectId)
        {
            return HttpSend<int, IEnumerable<Specification>>(
                projectId,
                $"{Settings.SpecificationsEndpoint.TrimEnd('/')}?project={projectId}");
        }
        
        public Task<IEnumerable<Requirement>> GetRequirements(int specificationId)
        {
            return HttpSend<int, IEnumerable<Requirement>>(
                specificationId, 
                $"{Settings.RequirementsEndpoint.TrimEnd('/')}?specification={specificationId}");
        }

        public Task<Requirement> GetRequirementById(int id)
        {
            return HttpSend<int, Requirement>(
                id, $"{Settings.RequirementsEndpoint.TrimEnd('/')}/{id}");
        }

        public Task<Specification> GetSpecificationById(int id)
        {
            return HttpSend<int, Specification>(
                id, $"{Settings.SpecificationsEndpoint.TrimEnd('/')}/{id}");
        }

        #endregion


        private async Task<TOut> HttpSend<TIn, TOut>(TIn obj, string endpoint)
        {
            using (var http = new HttpClient())
            {
                var response = await http.GetAsync(endpoint);
                var respBody = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<TOut>(respBody);
                else throw new IntegrationRequestException($"Code: {response.StatusCode}, Message: {respBody}");
            }
        }
    }
}
