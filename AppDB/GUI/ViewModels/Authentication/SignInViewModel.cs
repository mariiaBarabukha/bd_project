using GUI.Models;
using Prism.Commands;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;

namespace GUI.ViewModels
{
    class SignInViewModel : INotifyPropertyChanged
    {
        private AuthenticationUser _authUser = new AuthenticationUser();
        private Action _gotoSignUp;
        private Action _goToMain;
        private bool _isEnabled = true;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Login
        {
            get => _authUser.Login;
            set
            {
                if (_authUser.Login != value)
                {
                    _authUser.Login = value;
                    OnPropertyChanged();
                    SignInCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string Password
        {
            get => _authUser.Password;
            set
            {
                if (_authUser.Password != value)
                {
                    _authUser.Password = value;
                    OnPropertyChanged();
                    SignInCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public DelegateCommand SignInCommand { get; }

        public DelegateCommand SignUpCommand { get; }
        public bool IsEnabled { get => _isEnabled; set => _isEnabled = value; }

        public SignInViewModel(Action gotoSignUp, Action goToMain)
        {
            //2
            SignInCommand = new DelegateCommand(SignIn, IsSignInEnabled);
            _gotoSignUp = gotoSignUp;
            SignUpCommand = new DelegateCommand(_gotoSignUp);
            _goToMain = goToMain;

        }

        private bool IsSignInEnabled()
        {
            return !String.IsNullOrWhiteSpace(Login) && !String.IsNullOrWhiteSpace(Password);
        }

        private async void SignIn()
        {
            if (String.IsNullOrWhiteSpace(Login) || String.IsNullOrWhiteSpace(Password))
                MessageBox.Show("Login or password is empty");
            else
            {
                var authService = new AuthenticationService();
                User user = null;
                try
                {
                    IsEnabled = false;
                    //_authUser.Password = _authUser.Password;
                    // _authUser.Password = PasswordHandler.Code(_authUser.Password);
                    user = await authService.Authenticate(_authUser);
                    StateManager.Current_user = user;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Sign in failed: {ex.Message}");
                    return;
                }
                //MessageBox.Show($"Sign in was successful for user {user.FirstName} {user.LastName}");
                //CurrentInfo.Customer = new lab.Customer(user.FirstName, user.LastName, user.Email);
                //Load();
                _goToMain.Invoke();

            }
        }

        
    }
}
