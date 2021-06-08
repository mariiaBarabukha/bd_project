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
    /// Interaction logic for ClientByName.xaml
    /// </summary>
    public partial class ClientByName : UserControl
    {
        ClientByNameViewModel _view;
        public ClientByName()
        {
            _view = new ClientByNameViewModel(Reload);
            InitializeComponent();
            DataContext = _view;
        }

        public void Reload()
        {
            Content = new ClientByName();
        }
    }
}
