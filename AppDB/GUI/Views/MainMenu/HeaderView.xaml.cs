using GUI.ViewModels.MainMenu;
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

namespace GUI.Views.MainMenu
{
    /// <summary>
    /// Interaction logic for HeaderView.xaml
    /// </summary>
    public partial class HeaderView : UserControl
    {
        private HeaderViewModel _viewModel;
        public HeaderView()
        {
            _viewModel = new HeaderViewModel();
            InitializeComponent();
            DataContext = _viewModel;
        }
    }
}
