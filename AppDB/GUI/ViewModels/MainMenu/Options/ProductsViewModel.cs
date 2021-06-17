using Controller;
using Controller.DBObjects;
using GUI.Models;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace GUI.ViewModels.MainMenu.Options
{

    class ProductsViewModel
    {
        public List<DBProduct> Products { get; set; }
        public DBProduct Product 
        { 
            get => StateManager.ProductToEdit;
            set => StateManager.ProductToEdit = value;
        }
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
        public DelegateCommand Delete { get; }
        public DelegateCommand Add { get; }
        public DelegateCommand Edit { get; }
        Action _goToAdd;
        //private Action _reload;
        public ProductsViewModel(Action action, Action goToAdd)
        {
            _goToAdd = goToAdd;
            Delete = new DelegateCommand(DeleteProduct);
            Add = new DelegateCommand(GoToAdd);
            Edit = new DelegateCommand(GoToEdit);
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

        private void GoToAdd()
        {
            StateManager.ToEdit = false;
            _goToAdd.Invoke();
        }
        private void GoToEdit()
        {
            StateManager.ToEdit = true;
            _goToAdd.Invoke();
        }
        private void DeleteProduct()
        {
            Model.getInstance().db.DeleteProduct(Product.ID);
            reload.Invoke();

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
