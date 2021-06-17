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
    class CheckAddViewModel
    {
        public int Card { get; set; }
        public decimal Total { get=>CheckManager.Total; set =>CheckManager.Total = value; }
        public decimal VAT { get; set; }
        public bool istoAdd { get; set; }

        public DelegateCommand AddProduct { get; }
        public DelegateCommand EditProduct { get; }
        public DelegateCommand DeleteProduct { get; }
        public DelegateCommand Save { get; }
        public DelegateCommand Back { get; }
        public int id_check { get => StateManager.CheckID2; set=>StateManager.CheckID2 = value; }

        public DBSale Sale { get; set; }
        public List<DBSale> Sales { get; set; }

        Action _reload;
        Action _addEdit;
        Action _back;

        public CheckAddViewModel(Action goToAddEdit, Action goBack, Action reload)
        {
            
            _reload = reload;
            _addEdit = goToAddEdit;
            _back = goBack;
            DeleteProduct = new DelegateCommand(Delete);
            AddProduct = new DelegateCommand(AddClicked);
            EditProduct = new DelegateCommand(EditClicked);
            Back = new DelegateCommand(Cancel);
            Save = new DelegateCommand(SaveCheck);
           // int id_check = 0;
            try
            {
                if(id_check == 0)
                    id_check = Model.getInstance().db.AddCheck(9999, StateManager.Current_user.ID);
                
            }catch(Exception e)
            {

            }
            
            Sales = new List<DBSale>();
            var temp = Model.getInstance().db.GetSalesByCheck(id_check);
            foreach (var t in temp)
            {
                Sales.Add((DBSale)t);
            }
            Total = Model.getInstance().db.SumOfCheck(id_check);
            VAT = Total / 6;
        }

        private void Delete()
        {
            if (Sale != null)
            {
                Model.getInstance().db.DeleteSale(Sale.IDCheck, Sale.IDProduct);
                _reload.Invoke();
            }

        }

        private void AddClicked()
        {
            StateManager.ToEdit = false;
            _addEdit.Invoke();
        }

        private void EditClicked()
        {
            if(Sale != null)
            {
                StateManager.ToEdit = true;
                StateManager.SaleToEdit = Sale;
                _addEdit.Invoke();
            }
           
        }

        private void SaveCheck()
        {
            
            try
            {
                Model.getInstance().db.UpdateCheck(new DBCheckInfo(id_check, DateTime.Now, "", Card, Total, VAT),
                    StateManager.Current_user.ID);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void Cancel()
        {
            Model.getInstance().db.DeleteCheck(id_check);
            _back.Invoke();
        }
    }
}
