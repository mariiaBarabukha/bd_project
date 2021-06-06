using GUI.Models;
using GUI.ViewModels.MainMenu;
using GUI.ViewModels.MainMenu.Options;
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

namespace GUI.Views.MainMenu
{
    /// <summary>
    /// Interaction logic for SelectedOptionView.xaml
    /// </summary>
    public partial class SelectedOptionView : UserControl
    {
        SelectedOptionViewModel _view;
        public SelectedOptionView()
        {

            _view = new SelectedOptionViewModel();
            InitializeComponent();
            DataContext = _view;
            StateManager.GoToWorkers = GoToWorkers;
            StateManager.GoToProducts = GoToProducts;
            StateManager.GoToProductsInMarket = GoToProductsInMarket;
            StateManager.GoToCategories = GoToCategories;
            StateManager.GoToClients = GoToClientCards;
            StateManager.GoToOthers = GoToOthers;
            //StateManager.ctx = Content;
        }

        public void GoToWorkers()
        {
            Content = new WorkersView(GoToCashiers, GoToFindWorker);
        }
        public void GoToCashiers()
        {
            Content = new CashiersView(GoToWorkers);
        }

        public void GoToProducts()
        {
            Content = new ProductsView();
        }

        public void GoToProductsInMarket()
        {
            Content = new ProductsInMarketView();
        }

        public void GoToCategories()
        {
            Content = new CategoriesView();
        }

        public void GoToClientCards()
        {
            Content = new ClientCardsView();
        }
        public void GoToFindWorker()
        {
            Content = new FindWorkerView(GoToWorkers, GoToFindWorker);
        }

        public void GoToOthers()
        {
            Content = new OthersView();
        }

    }
}
