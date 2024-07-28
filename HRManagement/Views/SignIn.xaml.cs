using HRManagement.ViewModel;

namespace HRManagement.Views;

public partial class SignIn : ContentPage
{
	public SignIn()
	{
		InitializeComponent();
		BindingContext = new SingInViewModel();
	}
}