using System;
using ToDoListMobile.Models;

namespace ToDoListMobile.Services.User
{
    public class CurrentUser : ICurrentUser
    {
        public int IdUser { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Organization { get; set; }
        public string Role { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string AccessToken { get; set; }
        public bool IsAutorized { get; set; }
	}
}