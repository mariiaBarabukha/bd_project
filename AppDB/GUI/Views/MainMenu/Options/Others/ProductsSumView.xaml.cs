using GUI.ViewModels.MainMenu.Options.Others;
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

namespace GUI.Views.MainMenu.Options.Others
{
    /// <summary>
    /// Interaction logic for ProductsSumView.xaml
    /// </summary>
    public partial class ProductsSumView : UserControl
    {
        ProductsSumViewModel _view;
        public ProductsSumView()
        {
            _view = new ProductsSumViewModel(Reload);
            InitializeComponent();
            DataContext = _view;
        }

        public void Reload()
        {
            Content = new ProductsSumView();
        }
    }
}
