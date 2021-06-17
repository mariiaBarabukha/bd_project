using Controller;
using Controller.DBObjects;
using GUI.Models;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace GUI.ViewModels.MainMenu.AddEditPanels.ProductsInMarketOptions
{
    class EditViewModel
    {
        public int UPC 
        { 
            get => StateManager.productInMarketToEdit.UPC_ordinary;
            set => StateManager.productInMarketToEdit.UPC_ordinary = value; 
        }
        public string Name
        {
            get => StateManager.productInMarketToEdit.Name;
            set => StateManager.productInMarketToEdit.Name = value;
        }
        public decimal Price
        {
            get => StateManager.productInMarketToEdit.Price;
            set => StateManager.productInMarketToEdit.Price = value;
        }
        public int Amount
        {
            get => StateManager.productInMarketToEdit.Amount;
            set => StateManager.productInMarketToEdit.Amount = value;
        }

        public DelegateCommand Save { get; set; }
        public DelegateCommand Cancel { get; set; }
        public DelegateCommand Find { get; set; }
        Action _back;

        public List<int> UPCs { get; set; }
        public EditViewModel(Action back)
        {
            _back = back;
            Cancel = new DelegateCommand(back);
            Save = new DelegateCommand(Edit);
            var temp = Model.getInstance().db.GetAllProductsInMarket("[upc_ordinary]");
            UPCs = new List<int>();
            foreach (var t in temp)
            {
                UPCs.Add(((DBProductInMarket)t).UPC_ordinary);
            }
        }

        public void Edit()
        {
            if (Price > 0 && Amount > 0)
            {

            }
        }
    }
}
