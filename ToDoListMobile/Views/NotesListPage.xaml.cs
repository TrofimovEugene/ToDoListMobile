using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ToDoListMobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoListMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotesListPage
    {
        public NotesListPage()
        {
            var container = IoC.IoC.Container;

            // Resolve view model.
            //var viewModel = (BaseViewModel) container.Resolve(typeof(MainMenuViewModel));

            // Resolve view for view model.
            var view = container.ResolveKeyed<Element>(typeof(MainMenuViewModel));
            //view.BindingContext = viewModel;
            Master = (Page) view;
            InitializeComponent();
        }
    }
}