using System;
using SQLite;
using System.IO;
using Xamarin.Forms;
using XFPrismDemo.Services;
using XFPrismDemo.iOS.DataPersistence;

[assembly: Dependency(typeof(SQLiteDb))]
namespace XFPrismDemo.iOS.DataPersistence
{
    public class SQLiteDb : ISQLiteConnection
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, "WatchlistSQLite.db3");

            return new SQLiteAsyncConnection(path);
        }
    }
}