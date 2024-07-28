using HRManagement.Contracts;
using HRManagement.Helper;
using HRManagement.Models;
using HRManagement.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HRManagement.ViewModel
{
    public class SingInViewModel : BaseViewModel
    {
        #region Global Variables
        private SQLiteConnection sqliteConnection;
        #endregion

        #region Properties
        private string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; OnPropertyChanged(nameof(UserName)); }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged(nameof(Password)); }
        }

        public ICommand SigninCmd { get; set; }
        public ICommand SignUpCmd { get; set; }
        #endregion

        #region Constructer
        public SingInViewModel()
        {
            SigninCmd = new Command(SignIn);
            SignUpCmd = new Command(SignUp);
            sqliteConnection = SqliteHelper.GetConnection();
        }




        #endregion

        #region Private Functions
        private async void SignUp()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new SignUp());
        }
        private async void SignIn()
        {
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
            {
                await Application.Current.MainPage.DisplayAlert("Incomplete input", "Fields cannot be empty", "Ok");
            }
            else
            {
                bool val = ValidateCreds();
                if (val)
                {
                    Preferences.Set("user", UserName);
                    Application.Current.MainPage = new AppShell();
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Incorrect username or password", "Ok");
                }
            }
        }
        private bool ValidateCreds()
        {
            bool status = false;
            User user = sqliteConnection.Table<User>().FirstOrDefault(elm => elm.Name == UserName);
            if (user != null && user.Password == Password)
            {
                status = true;
            }
            return status;
            //Check sqlite table
        }
        #endregion

    }
}
