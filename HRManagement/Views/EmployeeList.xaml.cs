using HRManagement.ViewModel;

namespace HRManagement.Views;

public partial class EmployeeList : ContentPage
{
	public EmployeeList()
	{
		InitializeComponent();
		BindingContext = new EmployeeListViewModel();

    }
}