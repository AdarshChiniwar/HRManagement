using HRManagement.ViewModel;

namespace HRManagement.Views;

public partial class RegisterInterView : ContentPage
{
	public RegisterInterView()
	{
		InitializeComponent();
		BindingContext = new RegisterInterViewViewModel();

    }
}