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
    /// Interaction logic for ChechByIDView.xaml
    /// </summary>
    public partial class CheckByIDView : UserControl
    {
        CheckByIDViewModel _view;
        public CheckByIDView()
        {
            _view = new CheckByIDViewModel(Reload);
            InitializeComponent();
            DataContext = _view;
        }

        public void Reload()
        {
            Content = new CheckByIDView();
        }
    }
}
