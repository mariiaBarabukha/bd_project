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
    /// Interaction logic for MianView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();
            Content = new SignInView(GotoSignUp, GoToMain);
        }
        public void GotoSignUp()
        {
            Content = new SignUpView(GotoSignIn);
        }
        public void GoToMain()
        {
            Content = new RepresentationView();
        }
        public void GotoSignIn()
        {
            Content = new SignInView(GotoSignUp, GoToMain);
        }
    }
}
