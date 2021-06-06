using Controller;
using Controller.DBObjects;
using GUI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GUI.ViewModels.MainMenu.Options
{

    class ProductsViewModel
    {
        public List<DBProduct> Products { get; set; }
        public List<string> Categories { get; set; }
        Action reload;
        //public string sel_cat;
        public string SelectedCategory 
        { 
            get => StateManager.CategoryOfProducts;
            set
            {
                StateManager.CategoryOfProducts = value;
                reload.Invoke();
            }
        }

        public ProductsViewModel(Action action)
        {
            reload = action;
            var products = Load();
            Categories = new List<string>();
            Categories.Add("All");
            var temp = Model.getInstance().db.GetAllCategories();
            foreach (var t in temp)
            {
                Categories.Add(((DBCategory)t).Name);
            }
            
            Products = new List<DBProduct>();
            foreach (var product in products)
            {
                Products.Add((DBProduct)product);
            }
        }

        private List<DBObject> Load()
        {
            if(StateManager.CategoryOfProducts == "All")
            {
                return Model.getInstance().db.GetAllProducts();
            }
            return Model.getInstance().db
                .GetProductsWithCategory(StateManager.CategoryOfProducts);
            
        }
    }
}
