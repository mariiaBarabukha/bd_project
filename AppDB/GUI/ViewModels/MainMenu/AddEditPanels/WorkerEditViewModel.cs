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
    class WorkerEditViewModel
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
        public int IDManager { get; set; }

        public List<string> Names_managers { get; set; }
        public List<string> Roles { get; set; }
        private Action _back;
        public DelegateCommand Save { get; }
        public DelegateCommand Back { get; }

        private List<DBWorker> _workers;
        public WorkerEditViewModel(Action back)
        {
            Roles = new List<string>();
            Roles.Add("manager");
            Roles.Add("cashier");

            ID = StateManager.WorkerToEdit.ID;
            Name = StateManager.WorkerToEdit.Name;
            Position = StateManager.WorkerToEdit.Position;
            Salary = StateManager.WorkerToEdit.Salary;
            Date_start = StateManager.WorkerToEdit.Date_start;
            Birthday = StateManager.WorkerToEdit.Birthday;
            Phone = StateManager.WorkerToEdit.Phone;
            Address = StateManager.WorkerToEdit.Address;
            Name_manager = StateManager.WorkerToEdit.Name_manager;

            _back = back;
            Back = new DelegateCommand(back);
            Save = new DelegateCommand(Update);

            _workers = new List<DBWorker>();

            Names_managers = new List<string>();
            var temp = Model.getInstance().db.GetManagers();
            foreach (var t in temp)
            {
                Names_managers.Add(((DBWorker)t).Name);
                _workers.Add((DBWorker)t);
            }

        }

        private void Update()
        {
            try
            {
                Model.getInstance().db.UpdateWorker(new DBWorker(ID, Name, Position, Salary, Birthday,
                    Date_start, Phone, Address, Name_manager, _workers[Names_managers.IndexOf(Name_manager)].ID));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            _back.Invoke();
        }
    }
}
