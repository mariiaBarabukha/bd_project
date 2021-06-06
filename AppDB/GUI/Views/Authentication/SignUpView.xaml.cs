using GUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI.Views
{
    /// <summary>
    /// Interaction logic for SignUpView.xaml
    /// </summary>
   
    public partial class SignUpView : UserControl
    {
        private SignUpViewModel _viewModel;
        public SignUpView(Action GoToSignIn)
        {
            InitializeComponent();
            _viewModel = new SignUpViewModel(GoToSignIn);
            DataContext = _viewModel;
        }
        private void PasswordInput_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            _viewModel.Password = PasswordInput.Password;
        }
    }
}
