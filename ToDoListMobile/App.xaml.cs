using System;
using System.Collections.Generic;
using Autofac;
using Rg.Plugins.Popup.Contracts;
using Rg.Plugins.Popup.Services;
using ToDoListMobile.Api.Methods;
using ToDoListMobile.Api.Services;
using ToDoListMobile.Models;
using ToDoListMobile.Services;
using ToDoListMobile.Services.Navigation;
using ToDoListMobile.Services.Note;
using ToDoListMobile.Services.Presenter;
using ToDoListMobile.Services.User;
using ToDoListMobile.ViewModels;
using ToDoListMobile.ViewModels.Note;
using Xamarin.Forms;
using ToDoListMobile.Views;
using ToDoListMobile.Views.Note;

namespace ToDoListMobile
{
	public partial class App : Application
	{
		private NotesListPage NotesListPage { get; set; }
		private MainMenu MainMenu { get; set; }
		private NavigationPage RootPage { get; set; }
		public App(ContainerBuilder builder)
		{
			InitializeComponent();
			builder.Register(ctx => new ApiClient()
			{
				BaseUrl = @"http://todolist.somee.com/" 
			}).As<IHttpClientBase>().SingleInstance();
			builder.RegisterType<UserService>().As<IUserService>().SingleInstance();
			builder.RegisterType<NoteService>().As<INoteService>().SingleInstance();

			builder.RegisterType<CurrentUser>().As<ICurrentUser>().SingleInstance();

			builder.RegisterType<CreateNoteMethod>().SingleInstance();
			builder.RegisterType<GetNotesMethod>().SingleInstance();
			builder.RegisterType<DeleteNoteMethod>().SingleInstance();
			builder.RegisterType<RegistryUserMethod>().SingleInstance();
			builder.RegisterType<AuthenticateUserMethod>().SingleInstance();


			builder.RegisterType<RegistryUserPage>().Keyed<Element>(typeof(RegistryUserPageViewModel));
			builder.RegisterType<RegistryUserPageViewModel>().AsSelf();
			builder.RegisterType<MainMenu>().Keyed<Element>(typeof(MainMenuViewModel));
			builder.RegisterType<MainMenuViewModel>().AsSelf();
			builder.RegisterType<NoteView>().Keyed<Element>(typeof(NoteViewModel));
			builder.RegisterType<NoteViewModel>().AsSelf();
			builder.RegisterType<LoginPage>().Keyed<Element>(typeof(LoginPageViewModel));
			builder.RegisterType<LoginPageViewModel>().AsSelf();

			MainMenu = new MainMenu();
			builder.RegisterInstance(MainMenu).Keyed<Element>(typeof(MainMenuViewModel)).SingleInstance();
			builder.RegisterType<MainMenuViewModel>().AsSelf().SingleInstance();

			NotesListPage = new NotesListPage();
			builder.RegisterInstance(NotesListPage).Keyed<Element>(typeof(NotesListPageViewModel));
			builder.RegisterType<NotesListPageViewModel>().AsSelf();


			RootPage = new NavigationPage(NotesListPage);
			
			var navigation = RootPage.Navigation;
			builder.RegisterInstance(navigation).As<INavigation>().SingleInstance();

			var popupNavigation = PopupNavigation.Instance;
			builder.RegisterInstance(popupNavigation).As<IPopupNavigation>().SingleInstance();
			
			var viewPresenter = new ViewPresenter(navigation, popupNavigation, new Dictionary<Type, PresentationType>
			{
				{typeof(RegistryUserPage), PresentationType.Default},
				{typeof(NotesListPage), PresentationType.Default},
				{typeof(NoteView), PresentationType.Default },
				{typeof(LoginPage), PresentationType.Modal }
			});
			
			var viewModelPresenter = new ViewModelPresenter(viewPresenter);
			builder.RegisterInstance(viewModelPresenter).As<IViewModelPresenter>().SingleInstance();

			MainPage = new MainPage
			{
				Master = MainMenu,
				Detail = RootPage
			};
		}
		
		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
