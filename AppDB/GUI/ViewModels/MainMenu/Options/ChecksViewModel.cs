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
        public DelegateCommand Delete { get; }
        public DelegateCommand Add { get; }
        public DelegateCommand GoToDetails { get; }
        public string Cashier
        {
            get => StateManager.CashierForChecks;
            set => StateManager.CashierForChecks = value;
        }
        private Action _reload;
        private Action _add;
        public bool delButtonVisibility { get; set; }
        public bool addButtonVisibility { get; set; }
        public ChecksViewModel(Action reload, Action details, Action goToAdd)
        {
            delButtonVisibility = false;
            addButtonVisibility = true;
            _add = goToAdd;
            if (StateManager.Current_user.Position.ToUpper() == "MANAGER")
            {
                delButtonVisibility = true;
                addButtonVisibility = false;
            }
            _reload = reload;
            Delete = new DelegateCommand(DeleteCheck);
            Add = new DelegateCommand(GoAdd);
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
        private void DeleteCheck()
        {
            Model.getInstance().db.DeleteCheck(Selected.ID);
            _reload.Invoke();

        }
        private List<DBObject> Load()
        {
            if(StateManager.CashierForChecks == "All")
                return Model.getInstance().db.GetAllChecks();
            return Model.getInstance().db.GetChecksByCashier(Cashier);
        }

        private void GoAdd()
        {
            StateManager.CheckID2 = 0;
            _add.Invoke();
        }
    }
}
