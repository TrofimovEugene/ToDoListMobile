using System;
using System.Threading;
using System.Windows.Input;
using ToDoListMobile.Services;
using ToDoListMobile.Services.User;
using ToDoListMobile.Views;
using Xamarin.Forms;

namespace ToDoListMobile.ViewModels
{
    public class RegistryUserPageViewModel : BaseViewModel
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Organization { get; set; }
        public DateTime DateOfBirth { get; set; }
        
        public ICommand Registry { get; private set; }
        public INavigation Navigation { get; set; }
        
        public RegistryUserPageViewModel()
        {
            Registry = new Command(OnRegistryClickButton);
        }

        private async void OnRegistryClickButton()
        {
            var firstName = FirstName;
            var secondName = SecondName;
            var email = Email;
            var password = Password;
            var confirmPassword = ConfirmPassword;
            var organization = Organization;
            var dateOfBirth = DateOfBirth;
            
            var api = new ApiClient()
            {
                BaseUrl = @"http://todolist.somee.com/"
            };
            var userService = new UserService(api);
            if (password.Equals(confirmPassword))
                await userService.RegisterAsync(firstName,
                    secondName,
                    email,
                    password,
                    organization,
                    "user",
                    dateOfBirth,
                    CancellationToken.None);
            await Navigation.PushAsync(new MainPage());
        }
    }
}