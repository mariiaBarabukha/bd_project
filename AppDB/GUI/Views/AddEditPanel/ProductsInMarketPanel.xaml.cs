using GUI.ViewModels.MainMenu.AddEditPanels;
using GUI.Views.AddEditPanel.ProductsInMarketOptions;
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
    /// Interaction logic for ProductsInMarket.xaml
    /// </summary>
    public partial class ProductsInMarketPanel : UserControl
    {
        ProductsInMarketPanelViewModel _view;
        public ProductsInMarketPanel()
        {
            _view = new ProductsInMarketPanelViewModel(AddNew, AddProm, Edit, Back);
            InitializeComponent();
            DataContext = _view;
        }

        public void AddNew()
        {
            Content = new Add();
        }

        public void AddProm()
        {
            Content = new AddNorProm();
        }

        public void Edit()
        {
            Content = new Add();
        }

        public void Back()
        {
            Content = new Add();
        }
    }
}
