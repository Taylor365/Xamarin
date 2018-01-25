using ContactsAppSQLite.PCL;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ContactsAppSQLite.API
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, "MySQLite.db4");

            return new SQLiteAsyncConnection(path);
        }
    }
}
