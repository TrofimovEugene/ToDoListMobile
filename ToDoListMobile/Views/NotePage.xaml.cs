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
	public partial class NotePage : ContentPage
	{
		public NoteViewModel ViewModel { get; private set; }
		public NotePage(NoteViewModel vm)
		{
			InitializeComponent();
			ViewModel = vm;
			PickerPriority.Items.Add("Высокий");
			PickerPriority.Items.Add("Средний");
			PickerPriority.Items.Add("Низкий");
			PickerPriority.Items.Add("Нет приоритета");
			this.BindingContext = ViewModel;
		}

		private void OnSelectedIndexChanged(object sender, EventArgs e)
		{
			ViewModel.PriorityText = PickerPriority.Items[PickerPriority.SelectedIndex];
		}
	}
}