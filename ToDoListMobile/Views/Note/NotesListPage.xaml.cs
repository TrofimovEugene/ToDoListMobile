using Autofac;
using ToDoListMobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoListMobile.Views.Note
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotesListPage: ContentPage
    {
        public NotesListPage()
        {
            InitializeComponent();
        }
    }
}