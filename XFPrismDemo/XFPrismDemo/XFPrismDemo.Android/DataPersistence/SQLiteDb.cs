using SQLite;
using System;
using System.IO;
using Xamarin.Forms;
using XFPrismDemo.Android.DataPersistence;
using XFPrismDemo.Services;

[assembly: Dependency(typeof(SQLiteDb))]
namespace XFPrismDemo.Android.DataPersistence
{
    public class SQLiteDb : ISQLiteConnection
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, "MyDemo.db3");

            return new SQLiteAsyncConnection(path);
        }
    }
}