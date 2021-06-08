using GUI.Models;
using GUI.Views.MainMenu.CashierOptions;
using GUI.Views.MainMenu.Options;
using System.Windows.Controls;


namespace GUI.Views.MainMenu
{
    /// <summary>
    /// Interaction logic for SelectedCashierView.xaml
    /// </summary>
    public partial class SelectedCashierView : UserControl
    {
        public SelectedCashierView()
        {
            InitializeComponent();
            CashiersOptionsManager.GoToChecks = GoToChecks;
            CashiersOptionsManager.GoToClients = GoToClients;
            CashiersOptionsManager.GoToProducts = GoToProducts;
            CashiersOptionsManager.GoToProfile = GoToProfile;
        }

        public void GoToChecks()
        {
            Content = new CashierOptions.CashierChecksPanelView();
        }

        public void GoToClients()
        {
            Content = new CashierOptions.CashierClientPanelView();
        }

        public void GoToProducts()
        {
            Content = new ProductsInMarketView();
        }

        public void GoToProfile()
        {
            Content = new ProfileView();
        }
    }
}
