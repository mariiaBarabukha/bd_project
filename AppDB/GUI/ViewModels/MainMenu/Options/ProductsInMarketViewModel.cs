using Controller;
using Controller.DBObjects;
using GUI.Models;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace GUI.ViewModels.MainMenu.Options
{
    class ProductsInMarketViewModel
    {
        Action _reload;
        public List<DBProductInMarket> ProductsMarket { get; set; }
        public DelegateCommand GetAll { get; }
        public DelegateCommand GetPromotional { get; }
        public DelegateCommand GetNotPromotional { get; }

        public DelegateCommand SortByAmount { get; }
        public DelegateCommand SortByName { get; }
        public ProductsInMarketViewModel(Action reload)
        {
            _reload = reload;
            GetAll = new DelegateCommand(GetAllProd);
            GetPromotional = new DelegateCommand(GetAllPromProd);
            GetNotPromotional = new DelegateCommand(GetAllNotPromProd);
            SortByAmount = new DelegateCommand(sortByAmount);
            SortByName = new DelegateCommand(sortByName);
            ProductsMarket = new List<DBProductInMarket>();
            var products = Load();
            foreach (var product in products)
            {
                ProductsMarket.Add((DBProductInMarket)product);
            }
        }

        private void GetAllProd()
        {
            StateManager.VarOfProm = 0;
            _reload.Invoke();
        }

        private void GetAllPromProd()
        {
            StateManager.VarOfProm = 1;
            _reload.Invoke();
        }

        private void GetAllNotPromProd()
        {
            StateManager.VarOfProm = 2;
            _reload.Invoke();
        }

        private void sortByName()
        {
            StateManager.ProductsSortBy = "[name_product]";
            _reload.Invoke();
        }

        private void sortByAmount()
        {
            StateManager.ProductsSortBy = "[amount_of_product]";
            _reload.Invoke();
        }

        private List<DBObject> Load()
        {
            if (StateManager.VarOfProm == 1)
                return Model.getInstance().db.GetAllPromProductsInMarket(StateManager.ProductsSortBy);
            if (StateManager.VarOfProm == 2)
                return Model.getInstance().db.GetAllNotPromProductsInMarket(StateManager.ProductsSortBy);
            return Model.getInstance().db.GetAllProductsInMarket(StateManager.ProductsSortBy);
        }
    }
}
