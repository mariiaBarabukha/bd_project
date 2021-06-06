using Controller;
using Controller.DBObjects;
using GUI.Models;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace GUI.ViewModels.MainMenu.Options.Others
{
    class ProductsSumViewModel
    {
        //Action _reload;
        public List<DBProductSum> Products { get; set; }
        public List<string> Cashiers { get; set; }
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
        public ProductsSumViewModel(Action reload)
        {
            //_reload = reload;
            Find = new DelegateCommand(reload);
            Products = new List<DBProductSum>();
            Cashiers = new List<string>();
            Cashiers.Add("All");
            var temp = Model.getInstance().db.GetCashiers();
            foreach (var t in temp)
            {
                Cashiers.Add(((DBWorker)t).Name);
            }
            var products = Load();
            foreach (var product in products)
            {
                Products.Add((DBProductSum)product);
            }
        }

        public List<DBObject> Load()
        {
            if (Cashier == "All")
            {
                return Model.getInstance().db.GetTotalSumOfProducts(FromDate, ToDate);
            }
            return Model.getInstance().db.GetTotalSumOfProductsByCashier(Cashier, FromDate, ToDate);
        }
    }
}
