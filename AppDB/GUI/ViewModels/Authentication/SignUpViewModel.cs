using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using Controller;
using GUI.Models;
using GUI.Views;
using Prism.Commands;


namespace GUI.ViewModels
{
    public class SignUpViewModel : INotifyPropertyChanged
        
    {
        private RegisteredUser _regUser = new RegisteredUser();
        private Action _gotoSignIn;
        private bool loginTaken = false;

        public string Login
        {
            get
            {
                return _regUser.Login;
            }
            set
            {
                if (_regUser.Login != value)
                {
                    _regUser.Login = value;
                    OnPropertyChanged();
                    SignUpCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string Password
        {
            get
            {
                return _regUser.Password;
            }
            set
            {
                if (_regUser.Password != value)
                {
                    _regUser.Password = value;
                    OnPropertyChanged();
                    SignUpCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string Email
        {
            get
            {
                return _regUser.Email;
            }
            set
            {
                if (_regUser.Email != value)
                {
                    _regUser.Email = value;
                    OnPropertyChanged();
                    SignUpCommand.RaiseCanExecuteChanged();
                }

            }
        }

        public string Name
        {
            get
            {
                return _regUser.Name;
            }
            set
            {
                if (_regUser.Name != value && Validity.checkValidity(value))
                {

                    _regUser.Name = value;
                    OnPropertyChanged();
                    SignUpCommand.RaiseCanExecuteChanged();
                }
                else
                {

                    MessageBox.Show("You are not allowed to use these symbols.");

                }
            }
        }
        public string Role
        {
            get
            {
                return _regUser.Role;
            }
            set
            {
                if (_regUser.Role != value)
                {
                    _regUser.Role = value;
                    OnPropertyChanged();
                    SignUpCommand.RaiseCanExecuteChanged();
                }

            }
        }

        public DateTime Birthday
        {
            get
            {
                return _regUser.Bitrhday;
            }
            set
            {
                if (_regUser.Bitrhday != value)
                {
                    _regUser.Bitrhday = value;
                    OnPropertyChanged();                    
                    SignUpCommand.RaiseCanExecuteChanged();
                }

            }
        }

        public string Address
        {
            get
            {
                return _regUser.Address;
            }
            set
            {
                if (_regUser.Address != value)
                {
                    _regUser.Address = value;
                    OnPropertyChanged();
                    SignUpCommand.RaiseCanExecuteChanged();
                }

            }
        }

        public string Phone
        {
            get
            {
                return _regUser.Phone;
            }
            set
            {
                if (_regUser.Phone != value)
                {
                    _regUser.Phone = value;
                    OnPropertyChanged();
                    SignUpCommand.RaiseCanExecuteChanged();
                }

            }
        }
        public DelegateCommand SignUpCommand { get; }


        public DelegateCommand SignInCommand { get; }
        public SignUpViewModel(Action gotoSignIn)
        {

            
            SignUpCommand = new DelegateCommand(SignUp, IsSignUpEnabled);
            _gotoSignIn = gotoSignIn;
            SignInCommand = new DelegateCommand(_gotoSignIn);

        }

        private bool IsSignUpEnabled()
        {
            return !String.IsNullOrWhiteSpace(Login) && !String.IsNullOrWhiteSpace(Password)
                && !String.IsNullOrWhiteSpace(Email)
                && !String.IsNullOrWhiteSpace(Name)
                && !String.IsNullOrWhiteSpace(Role)
                && !String.IsNullOrWhiteSpace(Address)
                && !String.IsNullOrWhiteSpace(Phone)                
                && !String.IsNullOrWhiteSpace(Name);
        }

        private async void SignUp()
        {
            if (!loginTaken && Validity.checkValidityEmail(Email))
            {
                if (!Validity.checkValidityBirthday(Birthday))
                {
                    MessageBox.Show("Incorrect date of birth. Please, check again");
                }

                if (!Validity.checkRole(Role))
                {
                    MessageBox.Show("You can enter only 'cashier' or 'manager' into position field");
                }
                var authService = new AuthenticationService();
                //User user = null;
                try
                {
            //        _regUser.Password = PasswordHandler.Code(_regUser.Password);
                    await authService.RegisterUser(_regUser);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Sign in failed: {ex.Message}");
                    return;
                }

                MessageBox.Show($"User successfully registered. Please sign in");

                _gotoSignIn.Invoke();
            }
            else
            {
                if (loginTaken) MessageBox.Show("Change your login");
                else MessageBox.Show("You should use a proper email");
            }

        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
