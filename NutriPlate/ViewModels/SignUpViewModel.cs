using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NutriPlate.Helpers;
using System.Windows.Input;

namespace NutriPlate.ViewModels
{
    public partial class SignUpViewModel : ObservableObject
    {
        #region Data Members
        private string? _userName;
        private string? _firstName;
        private string? _lastName;
        private string? _email;
        private string? _userPassword;
        private string? _mobile;
        [ObservableProperty] private bool _isPassword;
        [ObservableProperty] public string _eyeIcon;

        private readonly INavigation? _navigationPage;
        #endregion

        #region Properties

        public string UserName
        {
            get => _userName;
            set
            {
                if (_userName != value)
                {
                    _userName = value;
                    OnPropertyChanged();
                    (SignUpCommand as Command).ChangeCanExecute();
                }
            }
        }
        public string FirstName
        {
            get => _firstName;
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged();
                    (SignUpCommand as Command).ChangeCanExecute();
                }
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged();
                    (SignUpCommand as Command).ChangeCanExecute();
                }
            }
        }
        public string Email
        {
            get => _email;
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged();
                    (SignUpCommand as Command).ChangeCanExecute();
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
                    (SignUpCommand as Command).ChangeCanExecute();
                }
            }
        }
        public string Mobile
        {
            get => _mobile;
            set
            {
                if (_mobile != value)
                {
                    _mobile = value;
                    OnPropertyChanged();
                    (SignUpCommand as Command).ChangeCanExecute();
                }
            }
        }

        public ICommand SignUpCommand { get; }
        public ICommand NavigateToSignInCommand { get; }
        #endregion

        public SignUpViewModel(INavigation? navigationPage)
        {
            IsPassword = true;
            EyeIcon = FontHelper.OPEN_EYE_ICON;

            SignUpCommand = new Command(SignUp, Validate);

            NavigateToSignInCommand = new Command(async () =>
            {
                if (navigationPage != null)
                {
                    await navigationPage.PushAsync(new Views.SignInPage());
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

        private async void SignUp()
        {
            //Register user into DB
            //Save User to Current User
            //Go to Main Page
            await Toast.Make($"SignUp new user", ToastDuration.Short, 14).Show();
        }

        private bool Validate()
        {
            var unameOK = !string.IsNullOrEmpty(UserName);
            var fnameOK = !string.IsNullOrEmpty(FirstName);
            var lnameOK = !string.IsNullOrEmpty(LastName);
            var emailOK = !string.IsNullOrEmpty(Email);
            var passOK = string.IsNullOrEmpty(UserPassword) ? false :
            UserPassword.Length > 5;
            var mobileOK = string.IsNullOrEmpty(Mobile) ? false :
            Mobile.Length == 10;
            return unameOK && fnameOK && lnameOK && emailOK && passOK && mobileOK;
        }
    }
}
