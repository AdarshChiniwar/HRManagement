using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Helper
{
    public class SqliteHelper
    {
        public static SQLiteConnection SQLiteConnection;
        private SqliteHelper()
        {
        }
        public static string FullPath;
        public static string DbDirectoryPath;
        public static SQLiteConnection GetConnection()
        {
            if (SQLiteConnection != null)
                return SQLiteConnection;
            var dbase = "HrManagement.sql";
            DbDirectoryPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
            FullPath = Path.Combine(DbDirectoryPath, dbase);
            SQLiteConnection = new SQLiteConnection(FullPath);
            return SQLiteConnection;
        }
    }
}
