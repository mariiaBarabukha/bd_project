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
    class ClientEditAddViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public double Discount { get; set; }

        public string Command { get; set; }

       
        public DelegateCommand ActionOnClick { get; }
        public bool isEnabled { get; set; }


        public DelegateCommand Back { get; }
      
        Action _back;
        public ClientEditAddViewModel(Action back)
        {
            _back = back;

            var cat = Model.getInstance().db.GetAllCategories();
           
            Back = new DelegateCommand(back);
            if (StateManager.ToEdit)
            {
                isEnabled = false;
                Command = "Save changes";
                ID = StateManager.CardToEdit.ID;
                Name = StateManager.CardToEdit.Name;
                Phone = StateManager.CardToEdit.Phone;
                Address = StateManager.CardToEdit.Address;
                Discount = StateManager.CardToEdit.Discount;
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
                Model.getInstance().db.AddClientCard(new DBClientCard(ID, Name,Phone,Address,Discount));
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
                Model.getInstance().db.UpdateClientCard(new DBClientCard(ID, Name,Phone, Address,Discount));
                _back.Invoke();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
}
