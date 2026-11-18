using NutriPlate.Helpers;
using NutriPlate.Service;
using NutriPlate.ViewModels;

namespace NutriPlate.Views;

public partial class SignInPage : ContentPage
{
    public SignInPage()
	{
		InitializeComponent();
        BindingContext = new SignInViewModel(this.Navigation);
    }
}