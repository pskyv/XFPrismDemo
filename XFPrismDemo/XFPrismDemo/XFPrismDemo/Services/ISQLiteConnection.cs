using SQLite;

namespace XFPrismDemo.Services
{
    public interface ISQLiteConnection
    {
        SQLiteAsyncConnection GetConnection();
    }
}
