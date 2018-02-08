using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using XFPrismDemo.Models;

namespace XFPrismDemo.LocalDBs
{
    public class NoteDatabase
    {
        private readonly SQLiteAsyncConnection _connection;

        public NoteDatabase(SQLiteAsyncConnection connection)
        {
            _connection = connection;
            _connection.CreateTableAsync<Note>().Wait();
        }

        public async Task<IEnumerable<Note>> GetNotesAsync()
        {
            return await _connection.Table<Note>().ToListAsync();
        }

        public async Task<int> SaveNoteAsync(Note note)
        {
            return await _connection.InsertAsync(note);
        }

        public async Task<int> UpdateNoteAsync(Note note)
        {
            return await _connection.UpdateAsync(note);
        }

        public async Task<int> DeleteNoteAsync(Note note)
        {
            return await _connection.DeleteAsync(note);
        }
    }
}
