using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace ToDoListMobile.ViewModels
{
    public class MainMenuViewModel
    {
        public MainMenuViewModel()
		{
            Sports = new Command(OnButtonSportsClicked);
        }

        public ICommand Sports { get; set; }

        private void OnButtonSportsClicked()
        {
            Debug.WriteLine("SPORTS");
        }
    }
}