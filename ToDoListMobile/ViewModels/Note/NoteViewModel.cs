using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Input;
using ToDoListMobile.Api.Methods;
using ToDoListMobile.Services.Note;
using Xamarin.Forms;

namespace ToDoListMobile.ViewModels.Note
{
    public class NoteViewModel : BaseViewModel
    {
        private INoteService _noteService;
        public NoteViewModel(INoteService noteService)
        {
            _noteService = noteService;
            
            Delete = new Command(() => OnDeleteNote(CancellationToken.None));
            Edit = new Command(OnEditNote);
            Create = new Command(() => OnCreateNote(CancellationToken.None));
        }

		#region Properties

		private int _id;
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        private string _header;
        public string Header
        {
            get => _header;
            set
            {
                _header = value;
                OnPropertyChanged();
            }
        }

        private DateTime _dateAdded;
        public DateTime DateAdded
        {
            get => _dateAdded;
            set
            {
                _dateAdded = value;
                OnPropertyChanged();
            }
        }

        private string _text;
        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged();
            }
        }

        private int _userId;
        public int UserId
        {
            get => _userId;
            set
            {
                _userId = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Command
        
        public ICommand Edit { get; set; }

        public ICommand Delete { get; set; }

        public ICommand Create { get; set; }

        private async void OnDeleteNote(CancellationToken ct)
        {
            await _noteService.DeleteNoteAsync(Id, ct);
        }

        private void OnEditNote()
        {
            Debug.WriteLine("Типа отредактировано!");
        }

        private async void OnCreateNote(CancellationToken ct)
		{
            await _noteService.CreateNoteAsync(new Models.NoteModel()
            {
                DateAdded = DateTime.Now,
                Header = this.Header,
                Text = this.Text,
                UserId = 2
            }, ct);
		}
        #endregion
    }
    
}