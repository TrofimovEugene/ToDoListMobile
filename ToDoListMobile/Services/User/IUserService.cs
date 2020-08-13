using System;
using System.Threading;
using System.Threading.Tasks;

namespace ToDoListMobile.Services.User
{
    public interface IUserService
    {
        Task LoginAsync(string username, string password, CancellationToken ct);
        
        Task RegisterAsync(string firstName, string secondName, string email,
            string password, string organization, string role, DateTime dateOfBirth, CancellationToken ct);
    }
}