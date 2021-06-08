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
    /// Interaction logic for FindProductByNameView.xaml
    /// </summary>
    public partial class FindProductByNameView : UserControl
    {
        FindProductByNameViewModel _view;
        public FindProductByNameView()
        {
            _view = new FindProductByNameViewModel(Reload);
            InitializeComponent();
            DataContext = _view;
        }

        public void Reload()
        {
            Content = new FindProductByNameView();
        }
    }
}
