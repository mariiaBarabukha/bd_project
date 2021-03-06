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
    /// Interaction logic for CategoriesView.xaml
    /// </summary>
    public partial class CategoriesView : UserControl
    {
        CategoriesViewModel _view;
        public CategoriesView()
        {
            _view = new CategoriesViewModel(Reload, GoToAddEdit);
            InitializeComponent();
            DataContext = _view;
        }

        public void Reload()
        {
            Content = new CategoriesView();
        }
        public void GoToAddEdit()
        {
            Content = new Categories();
        }
    }
}
