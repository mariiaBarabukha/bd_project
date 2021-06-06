using GUI.ViewModels.MainMenu.Options;
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

namespace GUI.Views.MainMenu.Options
{
    /// <summary>
    /// Interaction logic for CashiersView.xaml
    /// </summary>
    public partial class CashiersView : UserControl
    {
        CashiersViewModel _view;
        public CashiersView(Action action)
        {
            _view = new CashiersViewModel(action);
            InitializeComponent();
            DataContext = _view;
        }
    }
}
