using System;

namespace ToDoListMobile.Services.User
{
    public interface ICurrentUser
    {
        int IdUser { get; set; }
        string FirstName { get; set; }
        string SecondName { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        string Organization { get; set; }
        string Role { get; set; }
        DateTime DateOfBirth { get; set; }
        string AccessToken { get; set; }
    }
}