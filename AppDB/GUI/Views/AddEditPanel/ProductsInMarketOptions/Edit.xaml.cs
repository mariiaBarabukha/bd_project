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
    /// Interaction logic for Edit.xaml
    /// </summary>
    public partial class Edit : UserControl
    {
        EditViewModel _view;
        public Edit()
        {
            _view = new EditViewModel(Back, Reload);
            InitializeComponent();
            DataContext = _view;
        }

        public void Back()
        {
            Content = new ProductsInMarketPanel();
        }

        public void Reload()
        {
            Content = new Edit();
        }
    }
}
