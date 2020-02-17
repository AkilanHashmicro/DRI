using System;
using SalesApp.Persistance;
using SQLite;
using Xamarin.Forms;
using static SalesApp.models.CRMModel;

namespace SalesApp
{
    public class DatabaseHelper
    {
        static SQLiteConnection sqliteconnection;   
        public const string DbFileName = "MBTrussco.db";   
   
        public DatabaseHelper() {   
            sqliteconnection = DependencyService.Get<ISQLiteDb>().GetConnection();   
            sqliteconnection.CreateTable<ProductsList>();   
        }   
   
    }
}
