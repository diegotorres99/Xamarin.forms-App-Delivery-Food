using System;
using System.IO;
using FoodOrderApp.Model;
using SQLite;
using Xamarin.Forms;

[assembly:Dependency(typeof(FoodOrderApp.iOS.SQLite_iOS))]
namespace FoodOrderApp.iOS
{
    public class SQLite_iOS : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var sqliteFileName = "MyDatabase.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, sqliteFileName);
            var cn = new SQLiteConnection(path);
            return cn;
        }
    }
}
