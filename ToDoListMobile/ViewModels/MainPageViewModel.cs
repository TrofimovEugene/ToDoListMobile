using System.Threading;
using System.Windows.Input;
using ToDoListMobile.Services;
using ToDoListMobile.Services.User;
using ToDoListMobile.Views;
using Xamarin.Forms;

namespace ToDoListMobile.ViewModels
{
	public class MainPageViewModel : BaseViewModel
	{
		public ICommand LoginCommand { get; private set; }
		public ICommand RegistryCommand { get; private set; }
		public string Email { get; set; }
		public string Password { get; set; }
		
		public INavigation Navigation { get; set; }

		public MainPageViewModel()
		{
			RegistryCommand = new Command(OnRegistryButtonClick);
			LoginCommand = new Command(OnLoginButtonClick);
		}

		private async void OnLoginButtonClick()
		{
			var email = Email;
			var password = Password;

			var api = new ApiClient()
			{
				BaseUrl = @"http://todolist.somee.com/" 
			};
			var userService = new UserService(api);
			await userService.LoginAsync(email, password, CancellationToken.None);
			await Navigation.PushAsync(page: new NotesListPage());
		}
		
		private async void OnRegistryButtonClick()
		{
			await Navigation.PushAsync(new RegistryUserPage());
		}
	}
}
