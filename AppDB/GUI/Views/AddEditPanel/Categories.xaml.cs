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
    /// Interaction logic for Categories.xaml
    /// </summary>
    public partial class Categories : UserControl
    {
        CategoriesEditAddViewModel _view;
        public Categories()
        {
            _view = new CategoriesEditAddViewModel(Back);
            InitializeComponent();
            DataContext = _view;
        }

        public void Back()
        {
            Content = new CategoriesView();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
