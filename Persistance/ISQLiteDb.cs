using System;
using SQLite;

namespace SalesApp.Persistance
{
    public interface ISQLiteDb
    {
        SQLiteConnection GetConnection();
    }
}
