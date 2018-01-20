using System;
using Xamarin.Forms;
using XFPrismDemo.LocalDBs;

namespace XFPrismDemo.Services
{
    public class DatabaseService : IDatabaseService
    {
        private TodoItemDatabase _todoItemDatabase;

        public TodoItemDatabase TodoItemDatabase
        {
            get
            {
                if (_todoItemDatabase == null)
                {
                    _todoItemDatabase = new TodoItemDatabase(DependencyService.Get<ISQLiteConnection>().GetConnection());
                }
                return _todoItemDatabase;
            }
        }
    }
}
