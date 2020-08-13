using ToDoListMobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoListMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistryUserPage : ContentPage
    {
        public RegistryUserPage()
        {
            InitializeComponent();
            this.BindingContext = new RegistryUserPageViewModel() { Navigation = this.Navigation };
        }
    }
}