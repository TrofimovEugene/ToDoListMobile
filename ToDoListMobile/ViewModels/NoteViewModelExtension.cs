using ToDoListMobile.Api.Shared;

namespace ToDoListMobile.ViewModels
{
    public static class NoteViewModelExtension
    {
        public static NoteViewModel ToViewModel(NoteModel noteModel)
        {
            return new NoteViewModel()
            {
                Id = noteModel.Id,
                Header = noteModel.Header,
                DateAdded = noteModel.DateAdded,
                Text = noteModel.Text,
                UserId = noteModel.UserId
            };
        }
        
        public static NoteModel FromViewModel(NoteViewModel noteModel)
        {
            return new NoteModel()
            {
                Id = noteModel.Id,
                Header = noteModel.Header,
                DateAdded = noteModel.DateAdded,
                Text = noteModel.Text,
                UserId = noteModel.UserId
            };
        }
    }
}