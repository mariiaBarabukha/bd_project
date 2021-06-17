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
    /// Interaction logic for Workers.xaml
    /// </summary>
    public partial class Workers : UserControl
    {
        WorkerEditViewModel _view;
        public Workers(Action back)
        {
            _view = new WorkerEditViewModel(back);
            InitializeComponent();
            DataContext = _view;
        }

        
    }
}
