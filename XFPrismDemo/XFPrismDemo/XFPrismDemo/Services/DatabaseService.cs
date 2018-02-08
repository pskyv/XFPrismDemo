using System;
using Xamarin.Forms;
using XFPrismDemo.LocalDBs;

namespace XFPrismDemo.Services
{
    public class DatabaseService : IDatabaseService
    {
        private TodoItemDatabase _todoItemDatabase;
        private NoteDatabase _noteDatabase;

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

        public NoteDatabase NoteDatabase
        {
            get
            {
                if (_noteDatabase == null)
                {
                    _noteDatabase = new NoteDatabase(DependencyService.Get<ISQLiteConnection>().GetConnection());
                }
                return _noteDatabase;
            }
        }
    }
}
