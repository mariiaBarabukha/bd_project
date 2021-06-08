using Controller;
using Controller.DBObjects;
using GUI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GUI.ViewModels.MainMenu.Options.Others
{
    class FindProductByNameViewModel
    {
        public List<DBProductInMarket> Products { get; set; }
        public List<string> Names { get; set; }
        Action reload;
        //public string sel_cat;
        public string SelectedName
        {
            get => StateManager.NameForProducts;
            set
            {
                StateManager.NameForProducts = value;
                reload.Invoke();
            }
        }

        public FindProductByNameViewModel(Action action)
        {
            reload = action;
            var products = Load();
            Names = new List<string>();
            Names.Add("All");
            var temp = Model.getInstance().db.GetAllProducts();
            foreach (var t in temp)
            {
                Names.Add(((DBProduct)t).Name);
            }

            Products = new List<DBProductInMarket>();
            foreach (var product in products)
            {
                Products.Add((DBProductInMarket)product);
            }
        }

        private List<DBObject> Load()
        {
            if (StateManager.NameForProducts == "All")
            {
                return Model.getInstance().db.GetAllProductsInMarket("[name_product]");
            }
            return Model.getInstance().db
                .GetProductsInMarketByProduct(SelectedName);

        }
    }
}

