using Controller;
using Controller.DBObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace GUI.ViewModels.MainMenu.Options
{
    class CategoriesViewModel
    {
        public List<DBCategory> Categories { get; set; }

        public CategoriesViewModel()
        {
            Categories = new List<DBCategory>();
            var categories = Load();
            foreach (var category in categories)
            {
                Categories.Add((DBCategory)category);
            }
        }

        private List<DBObject> Load()
        {
            return Model.getInstance().db.GetAllCategories();
        }
    }
}
