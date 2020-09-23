using ToDoListMobile.Api.Methods;
using ToDoListMobile.Models;
using ToDoListMobile.Services.Note;

namespace ToDoListMobile.ViewModels.Note
{
    public static class NoteViewModelExtension
    {
        public static NoteViewModel ToViewModel(NoteModel noteModel, INoteService userService)
        {
            return new NoteViewModel(userService)
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