using Controller;
using Controller.DBObjects;
using GUI.Models;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace GUI.ViewModels.MainMenu.Options.Others
{
    class ProductsAmountViewModel
    {
        public List<DBProductSum> Products { get; set; }
        
        public DateTime FromDate
        {
            get => StateManager.FromDate;
            set => StateManager.FromDate = value;
        }
        public DateTime ToDate
        {
            get => StateManager.ToDate;
            set => StateManager.ToDate = value;
        }
        public string Cashier
        {
            get => StateManager.CashierForProductsSum;
            set => StateManager.CashierForProductsSum = value;
        }

        public DelegateCommand Find { get; }
        public ProductsAmountViewModel(Action reload)
        {
            //_reload = reload;
            Find = new DelegateCommand(reload);
            Products = new List<DBProductSum>();
            
            var products = Load();
            foreach (var product in products)
            {
                Products.Add((DBProductSum)product);
            }
        }

        public List<DBObject> Load()
        {
            return Model.getInstance().db.GetTotalAmountOfProducts(FromDate, ToDate);
        }
    }
}

