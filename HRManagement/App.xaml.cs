using HRManagement.Contracts;
using HRManagement.Helper;
using HRManagement.Models;
using HRManagement.Views;
using SQLite;

namespace HRManagement
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            UserAppTheme = AppTheme.Light;
            string user = Preferences.Get("user", string.Empty);
            if (string.IsNullOrEmpty(user))
            {
                MainPage = new NavigationPage(new SignIn());
            }
            else
            {
                MainPage = new AppShell();
            }
        }

        protected override void OnStart()
        {
            base.OnStart();
            CerateTables();

        }

        private void CerateTables()
        {

            //SQLiteConnection sqliteConnection = DependencyService.Get<Isqlite>().GetConnection();
            //sqliteConnection.CreateTable<User>();
            SQLiteConnection sqliteConnection = SqliteHelper.GetConnection();
            sqliteConnection.CreateTable<User>();
            sqliteConnection.CreateTable<Employee>();
            sqliteConnection.CreateTable<InterViewDetails>();

        }
    }
}
