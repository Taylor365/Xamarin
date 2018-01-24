using SQLite;

namespace SQLite
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}

