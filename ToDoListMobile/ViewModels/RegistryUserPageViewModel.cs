using System;
using System.Threading;
using System.Windows.Input;
using ToDoListMobile.Services;
using ToDoListMobile.Services.Navigation;
using ToDoListMobile.Services.User;
using ToDoListMobile.Views;
using Xamarin.Forms;

namespace ToDoListMobile.ViewModels
{
    public class RegistryUserPageViewModel : BaseViewModel
    {
        private IViewModelPresenter _viewModelPresenter;
        private IUserService _userService;
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Organization { get; set; }
        public DateTime DateOfBirth { get; set; }
        
        public ICommand Registry { get; private set; }

        public RegistryUserPageViewModel(IViewModelPresenter viewModelPresenter,
                                            IUserService userService)
        {
            Registry = new Command(OnRegistryClickButton);
            _viewModelPresenter = viewModelPresenter;
            _userService = userService;
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

            if (password.Equals(confirmPassword))
                await _userService.RegisterAsync(firstName,
                    secondName,
                    email,
                    password,
                    organization,
                    "user",
                    dateOfBirth,
                    CancellationToken.None);
            await _viewModelPresenter.OpenViewModelAsync(typeof(LoginPageViewModel), CancellationToken.None, null);
        }
    }
}