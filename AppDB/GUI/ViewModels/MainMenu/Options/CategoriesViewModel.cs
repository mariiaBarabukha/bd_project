using Controller;
using Controller.DBObjects;
using GUI.Models;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace GUI.ViewModels.MainMenu.Options
{
    class CategoriesViewModel
    {
        public List<DBCategory> Categories { get; set; }
        public DBCategory Category 
        { 
            get => StateManager.CategoryToEdit;
            set => StateManager.CategoryToEdit = value;
        }
        public DelegateCommand Delete { get; }
        public DelegateCommand Add { get; }
        public DelegateCommand Edit { get; }

        private Action _reload;
        private Action _goToAdd;
        public CategoriesViewModel(Action reload, Action goToAdd)
        {
            _reload = reload;
            _goToAdd = goToAdd;
            Delete = new DelegateCommand(DeleteCategory);
            Add = new DelegateCommand(GoToAdd);
            Edit = new DelegateCommand(GoToEdit);
            Categories = new List<DBCategory>();
            var categories = Load();
            foreach (var category in categories)
            {
                Categories.Add((DBCategory)category);
            }
        }
        private void DeleteCategory()
        {
            Model.getInstance().db.DeleteCategory(Category.ID);
            _reload.Invoke();

        }
        private List<DBObject> Load()
        {
            return Model.getInstance().db.GetAllCategories();
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
    }
}
