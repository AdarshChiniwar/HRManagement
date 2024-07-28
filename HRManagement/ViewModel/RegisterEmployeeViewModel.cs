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
    public class RegisterEmployeeViewModel : BaseViewModel
    {
        #region Global Variables
        private SQLiteConnection sqliteConnection;
        #endregion

        #region Properties

        private string id;
        public string Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged(nameof(Id)); }
        }

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

        private string salary;
        public string Salary
        {
            get { return salary; }
            set { salary = value; OnPropertyChanged(nameof(Salary)); }
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

        private DateTime dOJ = DateTime.Now;
        public DateTime DOJ
        {
            get { return dOJ; }
            set { dOJ = value; OnPropertyChanged(nameof(DOJ)); }
        }


        public ICommand RegisterCmd { get; set; }
        public ICommand EditCmd { get; set; }
        Employee Employee;
        #endregion

        #region Constructor
        public RegisterEmployeeViewModel()
        {
            RegisterCmd = new Command(RegisterEmployee);
            sqliteConnection = SqliteHelper.GetConnection();
            EditCmd = new Command(EditRecord);
        }


        #endregion

        #region Functions
        public void SendEmployeeModel(Employee employee)
        {
            Employee = employee;
        }
        private async void EditRecord()
        {
            try
            {
                if (Employee != null)
                {
                    sqliteConnection.Update(Employee);
                    await Application.Current.MainPage.DisplayAlert("Indo", "Update Successfull!", "OK");
                    await Shell.Current.GoToAsync("..");
                }
                   
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
        private async void RegisterEmployee(object obj)
        {
            if (string.IsNullOrEmpty(FirstName) ||
                string.IsNullOrEmpty(LastName) ||
                 string.IsNullOrEmpty(EmailId) ||
                 string.IsNullOrEmpty(PhoneNumber) ||
                     string.IsNullOrEmpty(Address) ||
                      string.IsNullOrEmpty(Id) ||
                                  string.IsNullOrEmpty(Salary) ||
                                  string.IsNullOrEmpty(Age) ||
                  string.IsNullOrEmpty(Role)

                 )
            {
                await Application.Current.MainPage.DisplayAlert("Incomplete input", "Fields cannot be empty", "Ok");
            }
            else
            {
                Employee user = new Employee()
                {
                    Id = Convert.ToInt32(Id),
                    FirstName = FirstName,
                    LastName = LastName,
                    EmailId = EmailId,
                    PhoneNumber = PhoneNumber,
                    Salary = Convert.ToInt32(Salary),
                    Age = Convert.ToInt32(Age),
                    Address = Address,
                    Role = Role,
                    DOJ = DOJ
                };
                try
                {

                    int result = sqliteConnection.Insert(user);
                    if (result == 1)
                    {
                        Id = string.Empty;
                        FirstName = string.Empty;
                        LastName = string.Empty;
                        EmailId = string.Empty;
                        PhoneNumber = string.Empty;
                        Salary = string.Empty;
                        Age = string.Empty;
                        Address = string.Empty;
                        Role = string.Empty;

                        await Application.Current.MainPage.DisplayAlert("Info", "Congratulations , Employee registered Successfully", "OK");

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
