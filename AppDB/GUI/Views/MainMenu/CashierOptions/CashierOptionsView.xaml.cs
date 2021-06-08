using GUI.ViewModels.MainMenu.CashierOptions;
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

namespace GUI.Views.MainMenu.CashierOptions
{
    /// <summary>
    /// Interaction logic for CashierOptionsView.xaml
    /// </summary>
    public partial class CashierOptionsView : UserControl
    {
        CashierOptionsViewModel _view;
        public CashierOptionsView()
        {
            _view = new CashierOptionsViewModel();
            InitializeComponent();
            DataContext = _view;
        }
    }
}
