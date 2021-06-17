using Controller;
using Controller.DBObjects;
using GUI.Models;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace GUI.ViewModels.MainMenu.Options
{
    class CheckDetailsViewModel
    {
        public List<DBSale> Sales { get; set; }
        public DBSale Sale { get;
            set; }
        public DelegateCommand Back { get; }
        public DelegateCommand Delete { get; }
        private Action _reload;
        public bool delButtonVisibility { get; set; }
        public CheckDetailsViewModel(Action back, Action reload)
        {
            _reload = reload;
            delButtonVisibility = false;
            if (StateManager.Current_user.Position.ToUpper() == "MANAGER")
            {
                delButtonVisibility = true;
            }
            Delete = new DelegateCommand(DeleteSale);
            Back = new DelegateCommand(back);
            var selected = SelectedItemsManager.SelectedCheck;
            if (selected == null)
                return;
            var sales = Model.getInstance().db.GetSalesByCheck(selected.ID);
            Sales = new List<DBSale>();
            foreach (var sale in sales)
            {
                Sales.Add((DBSale)sale);
            }
        }

        private void DeleteSale()
        {
            Model.getInstance().db.DeleteSale(Sale.IDCheck, Sale.IDProduct);
            _reload.Invoke();

        }
    }
}
