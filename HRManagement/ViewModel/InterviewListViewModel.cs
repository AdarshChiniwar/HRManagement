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
    public class InterviewListViewModel : BaseViewModel
    {
        #region Global Variables
        private SQLiteConnection sqliteConnection;
        #endregion


        #region Properties
        private ObservableCollection<InterViewDetails> interviewList;
        public ObservableCollection<InterViewDetails> InterviewList
        {
            get { return interviewList; }
            set { interviewList = value; OnPropertyChanged(nameof(InterviewList)); }
        }
        public ICommand DeleteCmd { get; set; }

        #endregion

        #region Constructor
        public InterviewListViewModel()
        {
            InterviewList = new ObservableCollection<InterViewDetails>();
            sqliteConnection = SqliteHelper.GetConnection();
            DeleteCmd = new Command<InterViewDetails>(DeleteEmployee);
            LoadUI();
        }

        private async void DeleteEmployee(InterViewDetails inter)
        {
            try
            {
                bool result = await Application.Current.MainPage.DisplayAlert("Info", "Are you sure you want to delete the record?", "OK", "Cancel");
                if (result)
                {
                    sqliteConnection.Delete<InterViewDetails>(inter.Id);
                    LoadUI();
                }

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async void LoadUI()
        {
            try
            {
                InterviewList.Clear();
                var details = (from x in sqliteConnection.Table<InterViewDetails>() select x).ToList();
                foreach (var item in details)
                {
                    InterviewList.Add(item);
                }
                if (InterviewList.Count == 0)
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
