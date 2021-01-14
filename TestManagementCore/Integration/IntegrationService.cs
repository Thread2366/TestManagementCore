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
        public IntegrationService(string connectionString, IntegrationEndpoints endpoints)
        {
            ConnectionString = connectionString;
            Endpoints = endpoints;
        }

        public string ConnectionString { get; }
        public IntegrationEndpoints Endpoints { get; }

        #region Tasks management

        public async Task<AuthResult> Auth(string login, string password)
        {
            using (var http = new HttpClient())
            {
                var content = new StringContent(
                    JsonConvert.SerializeObject(new { Login = login, Password = password }),
                    Encoding.UTF8,
                    "application/json");
                var response = await http.PostAsync(Endpoints.AuthEndpoint, content);
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
            return HttpSend<string, User>(login, $"{Endpoints.UserEndpoint.TrimEnd('/')}/{login}");
        }

        public Task<Dictionary<Project, Role>> GetProjects(User user)
        {
            return HttpSend<User, Dictionary<Project, Role>>(
                user, $"{Endpoints.ProjectsEndpoint.TrimEnd('/')}?login={user.Login}");
        }

        #endregion


        #region Requirements management

        public Task<IEnumerable<Specification>> GetSpecifications(Project project)
        {
            return HttpSend<Project, IEnumerable<Specification>>(
                project,
                $"{Endpoints.SpecificationsEndpoint.TrimEnd('/')}?project={project.Id}");
        }
        
        public Task<IEnumerable<Requirement>> GetRequirements(Specification specification)
        {
            return HttpSend<Specification, IEnumerable<Requirement>>(
                specification, 
                $"{Endpoints.RequirementsEndpoint.TrimEnd('/')}?specification={specification.Id}");
        }

        public Task<Requirement> GetRequirementById(int id)
        {
            return HttpSend<int, Requirement>(
                id, $"{Endpoints.RequirementsEndpoint.TrimEnd('/')}/{id}");
        }

        public Task<Specification> GetSpecificationById(int id)
        {
            return HttpSend<int, Specification>(
                id, $"{Endpoints.SpecificationsEndpoint.TrimEnd('/')}/{id}");
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
