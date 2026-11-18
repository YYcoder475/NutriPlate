namespace NutriPlate.Views;
using NutriPlate.ViewModels;

public partial class SignUpPage : ContentPage
{
	public SignUpPage()
	{
        InitializeComponent();
        BindingContext = new SignUpViewModel(this.Navigation);
    }
}