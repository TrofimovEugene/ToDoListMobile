using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ToDoListMobile.Api.Methods;
using ToDoListMobile.Models;
using ToDoListMobile.Services.User;

namespace ToDoListMobile.Services.Note
{
    public class NoteService : INoteService
    {
        private readonly GetNotesMethod _getNotesMethod;
        private readonly DeleteNoteMethod _deleteNoteMethod;
        private readonly CreateNoteMethod _createNoteMethod;
        private readonly ICurrentUser _currentUser;

        public NoteService(GetNotesMethod getNotesMethod,
                            ICurrentUser currentUser,
                            DeleteNoteMethod deleteNoteMethod,
                            CreateNoteMethod createNoteMethod)
        {
            _getNotesMethod = getNotesMethod;
            _currentUser = currentUser;
            _deleteNoteMethod = deleteNoteMethod;
            _createNoteMethod = createNoteMethod;
        }
        
        public async Task<List<NoteModel>> GetNoteListAsync(CancellationToken ct)
        {
            var response = await _getNotesMethod.ExecuteAsync(new GetNotesMethod.Request() {Id = _currentUser.IdUser}, ct).ConfigureAwait(false);
            return response?.Select(note => new NoteModel()
                {
                    Id = note.Id,
                    Header = note.Header,
                    DateAdded = note.DateAdded,
                    Text = note.Text,
                    UserId = note.UserId
                })
                .ToList();
        }

        public async Task DeleteNoteAsync(int id, CancellationToken ct)
        {
            await _deleteNoteMethod.ExecuteAsync(new DeleteNoteMethod.Request() {Id = id}, ct).ConfigureAwait(false);
        }

        public async Task CreateNoteAsync(NoteModel note, CancellationToken ct)
        {
            await _createNoteMethod.ExecuteAsync(new CreateNoteMethod.Request()
            {
                Header = note.Header,
                DateAdded = note.DateAdded,
                Text = note.Text,
                UserId = note.UserId
            }, ct).ConfigureAwait(false);
        }
    }
}