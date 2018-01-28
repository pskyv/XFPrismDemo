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

        public async Task<List<TodoItem>> GetItemsNotDoneAsync()
        {
            return await _connection.Table<TodoItem>().Where(x => x.IsDone == false).ToListAsync();
        }

        public async Task<TodoItem> GetItemAsync(int id)
        {
            return await _connection.Table<TodoItem>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveItemAsync(TodoItem item)
        {
            return await _connection.InsertAsync(item);
        }

        public async Task<int> UpdateItemAsync(TodoItem item)
        {
            return await _connection.UpdateAsync(item);
        }

        public async Task<int> DeleteItemAsync(TodoItem item)
        {
            return await _connection.DeleteAsync(item);
        }
    }
}
