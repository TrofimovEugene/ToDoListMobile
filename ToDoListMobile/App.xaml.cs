﻿using System;
using System.Collections.Generic;
using Autofac;
using Autofac.Extras.CommonServiceLocator;
using Microsoft.Practices.ServiceLocation;
using Rg.Plugins.Popup.Contracts;
using Rg.Plugins.Popup.Services;
using ToDoListMobile.Api.Services;
using ToDoListMobile.IoC;
using ToDoListMobile.Models;
using ToDoListMobile.Services;
using ToDoListMobile.Services.Navigation;
using ToDoListMobile.Services.Presenter;
using ToDoListMobile.Services.User;
using ToDoListMobile.ViewModels;
using Xamarin.Forms;
using ToDoListMobile.Views;

namespace ToDoListMobile
{
	public partial class App : Application
	{
		public Page RootPage { get; set; }
		public App(ContainerBuilder builder)
		{
			InitializeComponent();
			builder.Register(ctx => new ApiClient()
			{
				BaseUrl = @"http://todolist.somee.com/" 
			}).As<IHttpClientBase>().SingleInstance();
			builder.RegisterType<UserService>().As<IUserService>().SingleInstance();
			
			builder.RegisterType<RegistryUserPage>().Keyed<Element>(typeof(RegistryUserPageViewModel));
			builder.RegisterType<RegistryUserPageViewModel>().AsSelf();
			builder.RegisterType<NotesListPage>().Keyed<Element>(typeof(RegistryUserPageViewModel));
			builder.RegisterType<NotesListPageViewModel>().AsSelf();
			
			RootPage = new NavigationPage(new MainPage());
			
			var navigation = RootPage.Navigation;
			builder.RegisterInstance(navigation).As<INavigation>().SingleInstance();

			var popupNavigation = PopupNavigation.Instance;
			builder.RegisterInstance(popupNavigation).As<IPopupNavigation>().SingleInstance();
			
			var viewPresenter = new ViewPresenter(navigation, popupNavigation, new Dictionary<Type, PresentationType>
			{
				{typeof(RegistryUserPage), PresentationType.Modal},
				{typeof(NotesListPage), PresentationType.Modal}
			});
			
			var viewModelPresenter = new ViewModelPresenter(viewPresenter);
			builder.RegisterInstance(viewModelPresenter).As<IViewModelPresenter>().SingleInstance();
			
			MainPage = RootPage;
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
