using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NutriPlate.Helpers;
using NutriPlate.Service;
using System.Windows.Input;

namespace NutriPlate.ViewModels
{
    public partial class SignInViewModel : ObservableObject
    {

        private DBMokup _db;
        private string? _userName;
        private string? _userPassword;

        private readonly INavigation? _navigationPage;

        #region Properties    
        [ObservableProperty] private string _loginMessage;
        [ObservableProperty] private bool _signInMessageVisible;
        [ObservableProperty] private Color _signInMessageColor;
        [ObservableProperty] private bool _isPassword;
        [ObservableProperty] private string _eyeIcon;

        public string UserName
        {
            get => _userName;
            set
            {
                if (_userName != value)
                {
                    _userName = value;
                    OnPropertyChanged();
                    (SignInCommand as Command).ChangeCanExecute();
                }
            }

        }
        public string UserPassword
        {
            get => _userPassword;
            set
            {
                if (_userPassword != value)
                {
                    _userPassword = value;
                    OnPropertyChanged();
                    (SignInCommand as Command).ChangeCanExecute();
                }
            }
        }

        public ICommand SignInCommand { get; }
        public ICommand NavigateToSignUpCommand { get; }
        #endregion

        public SignInViewModel(INavigation? navigationPage)
        {
            IsPassword = true;
            EyeIcon = FontHelper.OPEN_EYE_ICON;
            SignInMessageVisible = false;
            LoginMessage = String.Empty;
            _db = new DBMokup();

            SignInCommand = new Command(SignIn, () => 
                !(string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(UserPassword)));

            NavigateToSignUpCommand = new Command(async () =>
            {
                if (navigationPage != null)
                {
                    await navigationPage.PushAsync(new Views.SignUpPage());
                }
            });
            _navigationPage = navigationPage;
        }

        [RelayCommand]
        private void ShowPassword()
        {
            if (IsPassword)
                EyeIcon = FontHelper.CLOSED_EYE_ICON;
            else
                EyeIcon = FontHelper.OPEN_EYE_ICON;

            IsPassword = !IsPassword;
        }

        private void SignIn()
        {
            SignInMessageVisible = true;
            if (_db.IsExist(UserName, UserPassword))
            {
                LoginMessage = AppMessages.loginMessage;
                SignInMessageColor = Colors.Green;
                //Navigate to MainPage
            }
            else
            {
                LoginMessage = AppMessages.loginErrorMessage;
                SignInMessageColor = Colors.Red;
            }
        }

    }
}
