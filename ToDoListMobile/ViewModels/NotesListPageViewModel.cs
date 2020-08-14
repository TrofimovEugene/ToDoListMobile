using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace ToDoListMobile.ViewModels
{
    public class NotesListPageViewModel : BaseViewModel
    {
        public ICommand Sports { get; set; }

        public NotesListPageViewModel()
        {
            Sports = new Command(OnButtonSportsClicked);
        }

        private void OnButtonSportsClicked()
        {
            Debug.WriteLine("SPORTS");
        }
    }
}