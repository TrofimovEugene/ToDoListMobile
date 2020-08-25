using System;
using System.Threading;
using System.Threading.Tasks;
using ToDoListMobile.Api.Methods;
using ToDoListMobile.Api.Services;

namespace ToDoListMobile.Services.User
{
    public class UserService : IUserService
    {
        private readonly IHttpClientBase _httpClient;
        private readonly ICurrentUser _currentUser;
        
        public UserService(IHttpClientBase httpClient,
                            ICurrentUser currentUser)
        {
            _httpClient = httpClient;
            _currentUser = currentUser;
        }
        
        public async Task LoginAsync(string username, string password, CancellationToken ct)
        {
            var response = await new AuthenticateUserMethod(_httpClient).ExecuteAsync(
                new AuthenticateUserMethod.Request(){ Email = username, Password = password}, ct).ConfigureAwait(false);
            _httpClient.Token = response.AccessToken;
            _currentUser.IdUser = response.IdUser;
            _currentUser.FirstName = response.FirstName;
            _currentUser.SecondName = response.SecondName;
            _currentUser.Email = response.Email;
            _currentUser.Password = response.Password;
            _currentUser.Organization = response.Organization;
            _currentUser.DateOfBirth = response.DateOfBirth;
            _currentUser.AccessToken = response.AccessToken;
        }

        public async Task RegisterAsync(string firstName, string secondName, string email, string password, string organization, string role, DateTime dateOfBirth,
            CancellationToken ct)
        {
            var response = await new RegistryUserMethod(_httpClient).ExecuteAsync(
                new RegistryUserMethod.Request()
                {
                    FirstName = firstName,
                    SecondName = secondName,
                    Email = email,
                    Password = password,
                    Organization = organization,
                    Role = role,
                    DateOfBirth = dateOfBirth
                }, CancellationToken.None).ConfigureAwait(false);
        }
    }
}