using System.ComponentModel;
using Autofac;
using ToDoListMobile.Services.User;
using ToDoListMobile.ViewModels;
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
	}
}
