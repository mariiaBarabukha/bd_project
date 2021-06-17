using Controller;
using Controller.DBObjects;
using GUI.Models;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace GUI.ViewModels.MainMenu.AddEditPanels
{
    class ProductsEditViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public DateTime Exp_date { get; set; }
        public string Characteristics { get; set; }
        public string Command { get; set; }

        public List<string> Categories { get; set; }

        public DelegateCommand ActionOnClick { get; }
        public bool isEnabled { get; set; }


        public DelegateCommand Back { get; }
        private List<DBCategory> _categories;
        Action _back;
        public ProductsEditViewModel(Action back)
        {
            _back = back;
            
            var cat = Model.getInstance().db.GetAllCategories();
            Categories = new List<string>();
            _categories = new List<DBCategory>();
            foreach (var c in cat)
            {
                Categories.Add(((DBCategory)c).Name);
                _categories.Add((DBCategory)c);
            }
            Back = new DelegateCommand(back);
            if (StateManager.ToEdit)
            {
                isEnabled = false;
                Command = "Save changes";
                ID = StateManager.ProductToEdit.ID;
                Name = StateManager.ProductToEdit.Name;
                Category = StateManager.ProductToEdit.Category;
                Exp_date = StateManager.ProductToEdit.Expiration_day;
                Characteristics = StateManager.ProductToEdit.Characteristics;
                ActionOnClick = new DelegateCommand(Update);
            }
            else
            {
                isEnabled = true;
                Command = "Add";
                ActionOnClick = new DelegateCommand(Add);
            }
        }

        private void Add()
        {
            try{
                Model.getInstance().db.AddProduct(new DBProduct(ID, Name,
                    _categories[Categories.IndexOf(Category)].ID, Exp_date, Characteristics));
                _back.Invoke();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void Update()
        {
            try
            {
                Model.getInstance().db.UpdateProduct(new DBProduct(ID, Name,
                    _categories[Categories.IndexOf(Category)].ID, Exp_date, Characteristics));
                _back.Invoke();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
}
