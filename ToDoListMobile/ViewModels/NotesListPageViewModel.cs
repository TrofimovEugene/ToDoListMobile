using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDoListMobile.Api.Methods;
using ToDoListMobile.Api.Shared;
using ToDoListMobile.Services.Navigation;
using ToDoListMobile.Services.User;
using ToDoListMobile.Views;
using Xamarin.Forms;

namespace ToDoListMobile.ViewModels
{
    public class NotesListPageViewModel : BaseViewModel
    {
        private IViewModelPresenter _viewModelPresenter;
        private ICurrentUser _currentUser;
        //private IUserService _userService;
        private GetNotesMethod _createNoteMethod;
        
        public NotesListPageViewModel(IViewModelPresenter viewModelPresenter,
                                      ICurrentUser currentUser,
                                      GetNotesMethod createNoteMethod)
        {
            Sports = new Command(OnButtonSportsClicked);
            NewNoteCommand = new Command(NewNoteCreate);
            _viewModelPresenter = viewModelPresenter;
            _currentUser = currentUser;
            _createNoteMethod = createNoteMethod;
            //_userService = userService;
        }

        private List<NoteViewModel> _notes = new List<NoteViewModel>();
        public List<NoteViewModel> Notes
        {
            get => _notes;
            set
            {
                _notes = value;
                OnPropertyChanged();
            } }
        public override Task InitializeAsync(CancellationToken ct)
        {
            var response = _createNoteMethod.ExecuteAsync(new GetNotesMethod.Request() {Id = _currentUser.IdUser}, ct).Result;
            if (response == null) 
                return base.InitializeAsync(ct);
            foreach (var note in response)
            {
                Notes.Add(NoteViewModelExtension.ToViewModel(note));
            }
            return base.InitializeAsync(ct);
        }

        private void NewNoteCreate()
        {
            Debug.WriteLine("New Note!");
        }
        public ICommand NewNoteCommand { get; set; }
        public ICommand Sports { get; set; }

        private void OnButtonSportsClicked()
        {
            Debug.WriteLine("SPORTS");
        }
    }
}