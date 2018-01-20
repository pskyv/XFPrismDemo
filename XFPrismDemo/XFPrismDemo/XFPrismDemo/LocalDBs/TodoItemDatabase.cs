using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using XFPrismDemo.Models;

namespace XFPrismDemo.LocalDBs
{
    public class TodoItemDatabase
    {
        private readonly SQLiteAsyncConnection _connection;

        public TodoItemDatabase(SQLiteAsyncConnection connection)
        {
            _connection = connection;
            _connection.CreateTableAsync<TodoItem>().Wait();
        }

        public async Task<IEnumerable<TodoItem>> GetItemsAsync()
        {
            return await _connection.Table<TodoItem>().ToListAsync();
        }

        public Task<List<TodoItem>> GetItemsNotDoneAsync()
        {
            return _connection.Table<TodoItem>().Where(x => x.IsDone == false).ToListAsync();
        }

        public Task<TodoItem> GetItemAsync(int id)
        {
            return _connection.Table<TodoItem>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(TodoItem item)
        {
            return _connection.InsertAsync(item);
        }

        public Task<int> DeleteItemAsync(TodoItem item)
        {
            return _connection.DeleteAsync(item);
        }
    }
}
