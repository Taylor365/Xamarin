using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsAppSQLite.PCL
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
