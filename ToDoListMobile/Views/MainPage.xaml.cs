using System;
using System.ComponentModel;
using System.Windows.Input;
using ToDoListMobile.ViewModels;
using Xamarin.Forms;

namespace ToDoListMobile.Views
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class MainPage : ContentPage
	{
		public  ICommand ClickCommand { get; private set; }

		public MainPage()
		{
			InitializeComponent();
		}
	}
}
