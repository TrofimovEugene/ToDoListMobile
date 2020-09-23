using System.Threading;
using System.Windows.Input;
using Autofac;
using ToDoListMobile.Api.Services;
using ToDoListMobile.Services;
using ToDoListMobile.Services.Navigation;
using ToDoListMobile.Services.Presenter;
using ToDoListMobile.Services.User;
using ToDoListMobile.ViewModels.Note;
using ToDoListMobile.Views;
using Xamarin.Forms;

namespace ToDoListMobile.ViewModels
{
	public class MainPageViewModel : BaseViewModel
	{
		private IUserService _userService;
		private IViewModelPresenter _viewModelPresenter;
		public ICommand LoginCommand { get; private set; }
		public ICommand RegistryCommand { get; private set; }
		public string Email { get; set; }
		public string Password { get; set; }

		public MainPageViewModel()
		{
			RegistryCommand = new Command(OnRegistryButtonClick);
			LoginCommand = new Command(OnLoginButtonClick);
			
		}

		private async void OnLoginButtonClick()
		{
			var email = Email;
			var password = Password;

			_userService = IoC.IoC.Container.Resolve<IUserService>();
			await _userService.LoginAsync(email, password, CancellationToken.None);
			_viewModelPresenter = IoC.IoC.Container.Resolve<IViewModelPresenter>();
			await _viewModelPresenter.OpenViewModelAsync(typeof(NotesListPageViewModel), CancellationToken.None, null);
		}
		
		private async void OnRegistryButtonClick()
		{
			_viewModelPresenter = IoC.IoC.Container.Resolve<IViewModelPresenter>();
			await _viewModelPresenter.OpenViewModelAsync(typeof(RegistryUserPageViewModel), CancellationToken.None, null);
		}
	}
}
