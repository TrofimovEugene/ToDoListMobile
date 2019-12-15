using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListMobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoListMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NotesListView : ContentPage
	{
		public NotesListView()
		{
			InitializeComponent();
			BindingContext = new NotesListViewModel() {Navigation = this.Navigation};
			
		}
	}
}