using HRManagement.Contracts;
using HRManagement.Platforms.Android;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: Dependency(typeof(SQliteDroid))]
namespace HRManagement.Platforms.Android
{
    public class SQliteDroid : Isqlite
    {
        public static string FullPath;
        public static string DbDirectoryPath;
        public SQLiteConnection GetConnection()
        {
            var dbase = "library.sql";
            DbDirectoryPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
            FullPath = Path.Combine(DbDirectoryPath, dbase);
            var connection = new SQLiteConnection(FullPath);
            return connection;
        }
    }
}
