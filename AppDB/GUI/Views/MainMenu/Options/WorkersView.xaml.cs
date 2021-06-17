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
    /// Interaction logic for WorkersView.xaml
    /// </summary>
    public partial class WorkersView : UserControl
    {
        WorkersViewModel _view;
        public WorkersView(Action goToCashiers, Action goToFind, Action reload, Action goToEdit)
        {
            _view = new WorkersViewModel(goToCashiers, goToFind, reload, goToEdit);
            InitializeComponent();
            DataContext = _view;
        }
    }
}
