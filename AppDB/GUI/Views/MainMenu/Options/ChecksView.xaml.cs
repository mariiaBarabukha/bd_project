using GUI.ViewModels.MainMenu.Options;
using GUI.Views.AddEditPanel;
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
    /// Interaction logic for ChecksView.xaml
    /// </summary>
    public partial class ChecksView : UserControl
    {
        ChecksViewModel _view;
        public ChecksView()
        {
            _view = new ChecksViewModel(Reload, GoToSales, GoToAdd);
            InitializeComponent();
            DataContext = _view;
        }

        public void Reload()
        {
            Content = new ChecksView();
        }

        public void GoToSales()
        {
            Content = new CheckDetailsView();
        }

        public void GoToAdd()
        {
            Content = new Checks();
        }
    }
}
