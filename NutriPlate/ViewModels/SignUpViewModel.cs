using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NutriPlate.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        [ObservableProperty] private string _eyeIcon;

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
                }
            }
        }

        public ICommand SignInCommand { get; }
        #endregion

        public SignUpViewModel(INavigation navigation)
        {
            IsPassword = true;
            EyeIcon = FontHelper.CLOSED_EYE_ICON;

            //SignInCommand = new Command(OnSignInButtonClick, () =>
            //    !(string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(UserPassword)));
        }

        [RelayCommand]
        private void TogglePassordButton()
        {
            IsPassword = !IsPassword;
            if (IsPassword)
                EyeIcon = FontHelper.CLOSED_EYE_ICON;
            else
                EyeIcon = FontHelper.OPEN_EYE_ICON;

        }
    }
}
