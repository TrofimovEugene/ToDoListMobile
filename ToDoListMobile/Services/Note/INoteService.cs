using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ToDoListMobile.Models;

namespace ToDoListMobile.Services.Note
{
    public interface INoteService
    {
        Task<List<NoteModel>> GetNoteListAsync(CancellationToken ct);

        Task DeleteNoteAsync(int id, CancellationToken ct);

        Task CreateNoteAsync(NoteModel note, CancellationToken ct);
    }
}