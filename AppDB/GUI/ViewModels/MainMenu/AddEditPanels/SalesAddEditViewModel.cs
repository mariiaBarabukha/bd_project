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
    class SalesAddEditViewModel
    {
       
        public int UPC { get; set; }
        public DelegateCommand Save { get; set; }
        public DelegateCommand Back { get; set; }

        public bool isEnabled { get; set; }
        public int Amount { get; set; }

        Action _back;
        public SalesAddEditViewModel(Action back)
        {
            _back = back;
            isEnabled = true;
            if (StateManager.ToEdit)
            {
                Amount = StateManager.SaleToEdit.Amount;
                UPC = StateManager.SaleToEdit.IDProduct;
                isEnabled = false;
            }
            Back = new DelegateCommand(back);          
           
            Save = new DelegateCommand(SaveProduct);

        }

        private void SaveProduct()
        {
            try{
                if (StateManager.ToEdit)
                {

                    Model.getInstance().db.UpdateSale(StateManager.CheckID2, UPC,
                        Amount);
                }
                else
                {
                    Model.getInstance().db.AddSale(StateManager.CheckID2, UPC,
                        Amount);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            _back.Invoke();
        }

        
    }
}
