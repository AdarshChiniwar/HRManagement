using HRManagement.Views;

namespace HRManagement
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("EmployeeList", typeof(EmployeeList));
            Routing.RegisterRoute("RegisterInterview", typeof(RegisterInterView));
            Routing.RegisterRoute("InterviewList", typeof(InterViewList));
            //Routing.RegisterRoute("RegisterEmployee", typeof(RegisterEmployee));
        }

        private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            Shell.Current.FlyoutIsPresented = false;
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            Shell.Current.FlyoutIsPresented = false;
            MenuItem menuItem = sender as MenuItem;
            if (menuItem.CommandParameter.ToString() == "RegisterInterview")
            {
                
                await Shell.Current.GoToAsync("RegisterInterview");
            }
            if (menuItem.CommandParameter.ToString() == "EmployeeList")
            {
                await Shell.Current.GoToAsync("EmployeeList");
            }
            if (menuItem.CommandParameter.ToString() == "InterviewList")
            {
                await Shell.Current.GoToAsync("InterviewList");
            }
            if (menuItem.CommandParameter.ToString() == "Logout")
            {
                Preferences.Set("user", string.Empty);
                Application.Current.MainPage = new NavigationPage(new SignIn());
            }
        }
    }
}
