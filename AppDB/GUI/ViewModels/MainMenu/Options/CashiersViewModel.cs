using Controller;
using Controller.DBObjects;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace GUI.ViewModels.MainMenu.Options
{
    class CashiersViewModel
    {
        public List<DBWorker> Cashiers { get; set; }

        public DelegateCommand GetAll { get; }
        public CashiersViewModel(Action action)
        {
            GetAll = new DelegateCommand(action);
            Cashiers = new List<DBWorker>();
            var cashiers = Load();
            foreach (var cashier in cashiers)
            {
                Cashiers.Add((DBWorker)cashier);
            }
        }
        private List<DBObject> Load()
        {
            return Model.getInstance().db.GetCashiers();
        }
    }
}
