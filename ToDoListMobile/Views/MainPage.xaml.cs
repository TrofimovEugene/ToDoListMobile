using System;
using System.ComponentModel;
using Autofac;
using ToDoListMobile.Services.User;
using ToDoListMobile.ViewModels;
using ToDoListMobile.Views.Note;
using Xamarin.Forms;

namespace ToDoListMobile.Views
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
			this.BindingContext = new MainPageViewModel();
		}

		public static implicit operator MainPage(NotesListPage v)
		{
			throw new NotImplementedException();
		}
	}
}
