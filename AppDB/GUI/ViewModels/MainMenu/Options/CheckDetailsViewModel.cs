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
        public DelegateCommand Back { get; }
        public CheckDetailsViewModel(Action back)
        {
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
    }
}
