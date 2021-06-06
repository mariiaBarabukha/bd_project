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
    /// Interaction logic for ProductsInMarketView.xaml
    /// </summary>
    public partial class ProductsInMarketView : UserControl
    {
        ProductsInMarketViewModel _view;
        public ProductsInMarketView()
        {
            _view = new ProductsInMarketViewModel(Reload);
            InitializeComponent();
            DataContext = _view;
        }

        public void Reload()
        {
            Content = new ProductsInMarketView();
        }
    }
}
