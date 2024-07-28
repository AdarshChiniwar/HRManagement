using HRManagement.Models;
using HRManagement.ViewModel;

namespace HRManagement.Views;
[QueryProperty(nameof(Mode), "mode")]
public partial class RegisterEmployee : ContentPage, IQueryAttributable
{
    RegisterEmployeeViewModel registerEmployeeViewModel { get; set; }
    public string Mode { get; set; }
    public RegisterEmployee()
	{
		InitializeComponent();
        registerEmployeeViewModel = new RegisterEmployeeViewModel();
        BindingContext = registerEmployeeViewModel;
        register.IsVisible = true;
        edit.IsVisible = false;

    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query != null)
        {
            Employee mode = query.ContainsKey("mode") ? query["mode"] as Employee: null;
            if(mode != null)
            {
                registerEmployeeViewModel.SendEmployeeModel(mode);
                register.IsVisible = false;
                edit.IsVisible = true;
            }
            else
            {
                register.IsVisible = true;
                edit.IsVisible = false;
            }


        }
        else
        {
            register.IsVisible = true;
            edit.IsVisible = false;
        }
    }
}