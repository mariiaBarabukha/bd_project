using Controller;
using Controller.DBObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Prism.Commands;
using GUI.Models;

namespace GUI.ViewModels.MainMenu.Options.FindProduct
{
    class SimpleResultViewModel
    {
        public List<DBProductInMarket> Products { get; set; }
        public DelegateCommand Find { get; }
        public int UPC 
        {
            get => StateManager.UPC;
            set => StateManager.UPC = value;
        }

        public SimpleResultViewModel(Action reload)
        {
            Find = new DelegateCommand(reload);
            Products = new List<DBProductInMarket>();
            var temp = Load();
            foreach(var t in temp)
            {
                Products.Add((DBProductInMarket)t);
            }
        }

        private List<DBObject> Load()
        {
            return Model.getInstance().db.GetProductsInMarketByUPC(UPC);
        }
    }
}
