using GUI.ViewModels.MainMenu.AddEditPanels;
using GUI.Views.MainMenu.Options;
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

namespace GUI.Views.AddEditPanel
{
    /// <summary>
    /// Interaction logic for Clients.xaml
    /// </summary>
    public partial class Clients : UserControl
    {
        ClientEditAddViewModel _view;
        public Clients()
        {
            _view = new ClientEditAddViewModel(Back);
            InitializeComponent();
            DataContext = _view;
        }

        public void Back()
        {
            Content = new ClientCardsView();
        }
    }
}
