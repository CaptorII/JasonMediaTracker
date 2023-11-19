using System;
using System.Diagnostics;
using System.IO;
using SQLite;

namespace JasonMediaTracker.Models
{
    public static class Database
    {
        public static SQLiteAsyncConnection db;
        static string fileName = "MediaDatabase.sql";
        public static bool IsInitialized { get; private set; } = false;
        public static bool OperationCompleted { get; private set; } = false;

        public static async void InitialiseDatabase()
        {
            var localDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var fullFilePath = Path.Combine(localDataPath, fileName);
            Debug.WriteLine(fullFilePath); // Display the full path so we can find it on our drive
            db = new SQLiteAsyncConnection(fullFilePath);
            await db.CreateTableAsync<Book>();
            await db.CreateTableAsync<Movie>();
            await db.CreateTableAsync<TVShow>();
            IsInitialized = true;
        }

        public static async void UpdateTable(Media m)
        {
            OperationCompleted = false;
            if (m.GetType() == typeof(Book))
            {
                await db.UpdateAsync((Book)m);
            }
            else if (m.GetType() == typeof(Movie))
            {
                await db.UpdateAsync((Movie)m);
            }
            else if (m.GetType() == typeof(TVShow))
            {
                await db.UpdateAsync((TVShow)m);
            }
            OperationCompleted = true;
        }
    }
}
