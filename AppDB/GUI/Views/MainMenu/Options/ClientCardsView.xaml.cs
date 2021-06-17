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
    /// Interaction logic for ClientCardView.xaml
    /// </summary>
    public partial class ClientCardsView : UserControl
    {
        ClientCardsViewModel _view;
        public ClientCardsView()
        {
            _view = new ClientCardsViewModel(Reload, GoToAddEdit);
            InitializeComponent();
            DataContext = _view;
        }

        public void Reload()
        {
            Content = new ClientCardsView();
        }
        public void GoToAddEdit()
        {
            Content = new Clients();
        }
    }
}
