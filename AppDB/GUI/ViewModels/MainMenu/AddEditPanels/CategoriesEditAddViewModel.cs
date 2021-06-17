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
    class CategoriesEditAddViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

       
        public DelegateCommand ActionOnClick { get; }
        public bool isEnabled { get; set; }

        public string Command { get; set; }
        public DelegateCommand Back { get; }
       
        Action _back;
        public CategoriesEditAddViewModel(Action back)
        {
            _back = back;

            var cat = Model.getInstance().db.GetAllCategories();
           
            Back = new DelegateCommand(back);
            if (StateManager.ToEdit)
            {
                isEnabled = false;
                Command = "Save changes";
                ID = StateManager.CategoryToEdit.ID;
                Name = StateManager.CategoryToEdit.Name;               
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
            try
            {
                Model.getInstance().db.AddCategory(new DBCategory(ID, Name));
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
                Model.getInstance().db.UpdateCategory(new DBCategory(ID, Name));
                _back.Invoke();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
}

