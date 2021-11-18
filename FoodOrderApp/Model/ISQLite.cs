using System;
using SQLite;

namespace FoodOrderApp.Model
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
