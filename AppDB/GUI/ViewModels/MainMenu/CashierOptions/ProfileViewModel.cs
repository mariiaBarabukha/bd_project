using Controller;
using GUI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GUI.ViewModels.MainMenu.CashierOptions
{
    class ProfileViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public DateTime Date_start { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Name_manager { get; set; }

        public ProfileViewModel()
        {
            var w = Model.getInstance().db.GetWorkerByID(StateManager.Current_user.ID);
            ID = w.ID;
            Name = w.Name;
            Position = w.Position;
            Salary = w.Salary;
            Date_start = w.Date_start;
            Birthday = w.Birthday;
            Phone = w.Phone;
            Address = w.Address;
            Name_manager = w.Name_manager;
        }


    }
}
