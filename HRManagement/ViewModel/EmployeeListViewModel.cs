using HRManagement.Helper;
using HRManagement.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HRManagement.ViewModel
{
    public class EmployeeListViewModel : BaseViewModel
    {

        #region Global Variables
        private SQLiteConnection sqliteConnection;
        #endregion


        #region Properties
        private ObservableCollection<Employee> employeeList;
        public ObservableCollection<Employee> EmployeeList
        {
            get { return employeeList; }
            set { employeeList = value; OnPropertyChanged(nameof(EmployeeList)); }
        }
        public ICommand EditCmd { get; set; }
        public ICommand DeleteCmd { get; set; }

        #endregion

        #region Constructor
        public EmployeeListViewModel()
        {
            EmployeeList = new ObservableCollection<Employee>();
            sqliteConnection = SqliteHelper.GetConnection();
            EditCmd = new Command<Employee>(EditEmployee);
            DeleteCmd = new Command<Employee>(DeleteEmployee);
            LoadUI();
        }




        #endregion

        #region Function
        private async void DeleteEmployee(Employee employee)
        {
            try
            {
                bool result = await Application.Current.MainPage.DisplayAlert("Info", "Are you sure you want to delete the record?", "OK", "Cancel");
                if (result)
                {
                    sqliteConnection.Delete<Employee>(employee.Id);
                    LoadUI();
                }

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
        private async void EditEmployee(Employee employee)
        {
            var navigationParameters = new Dictionary<string, object>
                {
                { "mode", employee },
                };
            await Shell.Current.GoToAsync("///RegisterEmployee", navigationParameters);
        }
        private async void LoadUI()
        {
            try
            {
                EmployeeList.Clear();
                var details = (from x in sqliteConnection.Table<Employee>() select x).ToList();
                foreach (var item in details)
                {
                    EmployeeList.Add(item);
                }
                if (EmployeeList.Count == 0)
                {
                    await Application.Current.MainPage.DisplayAlert("Info", "No records available!", "OK");
                }

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
        #endregion
    }
}
