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
    /// Interaction logic for FindWorkerView.xaml
    /// </summary>
    public partial class FindWorkerView : UserControl
    {
        FindWorkerViewModel _view;
        public FindWorkerView(Action goBack, Action reload)
        {
            _view = new FindWorkerViewModel(goBack, reload);
            InitializeComponent();
            DataContext = _view;
        }
        
    }
}
