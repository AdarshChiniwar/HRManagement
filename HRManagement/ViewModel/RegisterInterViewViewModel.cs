using HRManagement.Helper;
using HRManagement.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HRManagement.ViewModel
{
    public class RegisterInterViewViewModel : BaseViewModel
    {

        #region Global Variables
        private SQLiteConnection sqliteConnection;
        #endregion

        #region Properties
        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; OnPropertyChanged(nameof(FirstName)); }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; OnPropertyChanged(nameof(LastName)); }
        }

        private string emailId;
        public string EmailId
        {
            get { return emailId; }
            set { emailId = value; OnPropertyChanged(nameof(EmailId)); }
        }


        private string phoneNumber;

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; OnPropertyChanged(nameof(PhoneNumber)); }
        }

        private string age;
        public string Age
        {
            get { return age; }
            set { age = value; OnPropertyChanged(nameof(Age)); }
        }


        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; OnPropertyChanged(nameof(Address)); }
        }

        private string role;

        public string Role
        {
            get { return role; }
            set { role = value; OnPropertyChanged(nameof(Role)); }
        }


        private string expectedSalary;

        public string ExpectedSalary
        {
            get { return expectedSalary; }
            set { expectedSalary = value; OnPropertyChanged(nameof(ExpectedSalary)); }
        }

       

        public ICommand RegisterCmd { get; set; }
        #endregion

        #region Constructor
        public RegisterInterViewViewModel()
        {
            sqliteConnection = SqliteHelper.GetConnection();
            RegisterCmd = new Command(RegisterInterview);
        }
        #endregion

        #region Functions
        private async void RegisterInterview()
        {
            if (string.IsNullOrEmpty(FirstName) ||
              string.IsNullOrEmpty(LastName) ||
               string.IsNullOrEmpty(EmailId) ||
               string.IsNullOrEmpty(PhoneNumber) ||
                   string.IsNullOrEmpty(Address) ||
                                string.IsNullOrEmpty(ExpectedSalary) ||
                                string.IsNullOrEmpty(Age) ||
                string.IsNullOrEmpty(Role)

               )
            {
                await Application.Current.MainPage.DisplayAlert("Incomplete input", "Fields cannot be empty", "Ok");
            }
            else
            {
                InterViewDetails interViewDetails = new InterViewDetails()
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    EmailId = EmailId,
                    PhoneNumber = PhoneNumber,
                    ExpectedSalary = Convert.ToInt32(ExpectedSalary),
                    Address = Address,
                    Role = Role,
                    Age = Convert.ToInt32(Age)
                };
                try
                {

                    int result = sqliteConnection.Insert(interViewDetails);
                    if (result == 1)
                    {
                        FirstName = string.Empty;
                        LastName = string.Empty;
                        EmailId = string.Empty;
                        PhoneNumber = string.Empty;
                        ExpectedSalary = string.Empty;
                        Address = string.Empty;
                        Role = string.Empty;
                        Age = string.Empty;
                        await Application.Current.MainPage.DisplayAlert("Info", "Congratulations , Interview details registered Successfully", "OK");

                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Registration Failed!!!", "Please try again", "ERROR");
                    }
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                }
            }
        }
        #endregion

    }
}
