using GUI.ViewModels.MainMenu.AddEditPanels.ProductsInMarketOptions;
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

namespace GUI.Views.AddEditPanel.ProductsInMarketOptions
{
    /// <summary>
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class Add : UserControl
    {
        AddViewModel _view;
        public Add()
        {
            _view = new AddViewModel(Back);
            InitializeComponent();
            DataContext = _view;
        }

        public void Back()
        {
            Content = new ProductsInMarketPanel();
        }
    }
}
