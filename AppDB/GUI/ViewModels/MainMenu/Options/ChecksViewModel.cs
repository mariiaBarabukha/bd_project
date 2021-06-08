using Controller;
using Controller.DBObjects;
using GUI.Models;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace GUI.ViewModels.MainMenu.Options
{
    class ChecksViewModel
    {
        public List<DBCheckInfo> Checks { get; set; }
        public List<string> Cashiers { get; set; }
        public DBCheckInfo Selected 
        { 
            get => SelectedItemsManager.SelectedCheck; 
            set => SelectedItemsManager.SelectedCheck = value;
        }
        public DelegateCommand Find { get; }
        public DelegateCommand GoToDetails { get; }
        public string Cashier
        {
            get => StateManager.CashierForChecks;
            set => StateManager.CashierForChecks = value;
        }
        public ChecksViewModel(Action reload, Action details)
        {
            Cashiers = new List<string>();
            Find = new DelegateCommand(reload);
            GoToDetails = new DelegateCommand(details);
            var cashiers = Model.getInstance().db.GetCashiers();
            Cashiers.Add("All");
            foreach (var cashier in cashiers)
            {
                Cashiers.Add(((DBWorker)cashier).Name);
            }
            Checks = new List<DBCheckInfo>();
            var temp = Load();
            foreach (var t in temp)
            {
                Checks.Add((DBCheckInfo)t);
            }
        }

        private List<DBObject> Load()
        {
            if(StateManager.CashierForChecks == "All")
                return Model.getInstance().db.GetAllChecks();
            return Model.getInstance().db.GetChecksByCashier(Cashier);
        }
    }
}
