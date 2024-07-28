using HRManagement.ViewModel;

namespace HRManagement.Views;

public partial class InterViewList : ContentPage
{
	public InterViewList()
	{
		InitializeComponent();
		BindingContext = new InterviewListViewModel();
	}
}