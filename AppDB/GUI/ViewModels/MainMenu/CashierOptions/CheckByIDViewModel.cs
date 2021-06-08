using Controller;
using Controller.DBObjects;
using GUI.Models;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace GUI.ViewModels.MainMenu.CashierOptions
{
    class CheckByIDViewModel
    {
        public List<DBCheckInfo> Checks { get; set; }
        public int ID 
        { 
            get => StateManager.CheckID; 
            set => StateManager.CheckID = value; 
        }
        public DelegateCommand Find { get; }

        public CheckByIDViewModel(Action reload)
        {
            Find = new DelegateCommand(reload);
            Checks = new List<DBCheckInfo>();
            var temp = Load();
            foreach (var t in temp)
            {
                Checks.Add((DBCheckInfo)t);
            }
        }

        public List<DBObject> Load()
        {
            if (ID != 0)
            {
                return Model.getInstance().db.GetChecksByID(ID);
            }
            return Model.getInstance().db.GetAllChecks();
        }
    }
}
