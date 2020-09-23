using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDoListMobile.Api.Methods;
using ToDoListMobile.Services.Navigation;
using ToDoListMobile.Services.Note;
using ToDoListMobile.Services.User;
using Xamarin.Forms;

namespace ToDoListMobile.ViewModels.Note
{
    public class NotesListPageViewModel : BaseViewModel
    {
        private IViewModelPresenter _viewModelPresenter;

        private DeleteNoteMethod _deleteNoteMethod;

        private INoteService _noteService;
        //private IUserService _userService;

        public NotesListPageViewModel(IViewModelPresenter viewModelPresenter,
                                      DeleteNoteMethod deleteNoteMethod,
                                      INoteService noteService)
        {
            Sports = new Command(OnButtonSportsClicked);
			NewNoteCommand = new Command(async () => await NewNoteCreateAsync(CancellationToken.None));
            RefreshCommand = new Command(async () => await RefreshAsync());
            _viewModelPresenter = viewModelPresenter;
            _deleteNoteMethod = deleteNoteMethod;
            _noteService = noteService;
            //_userService = userService;
        }
        
        public ICommand RefreshCommand { get; set; }

        private async Task RefreshAsync()
        {
            IsRefreshing = true;
            var notes = await _noteService.GetNoteListAsync(CancellationToken.None).ConfigureAwait(false);
            if (notes == null)
            {
                IsRefreshing = false;
                return;
            }

            Notes.Clear();
            foreach (var note in notes)
            {
                Notes.Add(NoteViewModelExtension.ToViewModel(note, _noteService));
            }

            IsRefreshing = false;
        }

        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set
            {
                _isRefreshing = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<NoteViewModel> _notes;
        public ObservableCollection<NoteViewModel> Notes
        {
            get => _notes;
            set
            {
                _notes = value;
                OnPropertyChanged();
            } 
        }
        public override Task InitializeAsync(CancellationToken ct)
        {
            var notes = _noteService.GetNoteListAsync(CancellationToken.None).Result;
            if (notes == null)
                return base.InitializeAsync(ct);
            Notes = new ObservableCollection<NoteViewModel>();
            foreach (var note in notes)
            {
                Notes.Add(NoteViewModelExtension.ToViewModel(note, _noteService));
            }
            return base.InitializeAsync(ct);
        }
        
        

        private async Task NewNoteCreateAsync(CancellationToken ct)
        {
            await _viewModelPresenter.OpenViewModelAsync(typeof(NoteViewModel), ct, null);
        }
        public ICommand NewNoteCommand { get; set; }
        public ICommand Sports { get; set; }

        private void OnButtonSportsClicked()
        {
            Debug.WriteLine("SPORTS");
        }
    }
}