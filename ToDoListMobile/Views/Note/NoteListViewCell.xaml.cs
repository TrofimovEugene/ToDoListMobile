using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListMobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoListMobile.Views.Note
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoteListViewCell : ViewCell
    {
        public NoteListViewCell()
        {
            InitializeComponent();
        }
    }
}