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

namespace GUI.Views.MainMenu.AddEditPanels
{
    /// <summary>
    /// Interaction logic for Products.xaml
    /// </summary>
    public partial class Products : UserControl
    {
        ProductsEditViewModel _view;
        public Products()
        {
            _view = new ProductsEditViewModel(Back);
            InitializeComponent();
            DataContext = _view;
        }

        public void Back()
        {
            Content = new ProductsView();
        }
    }
}
