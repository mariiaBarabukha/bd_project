using Controller;
using Controller.DBObjects;
using GUI.Models;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;

namespace GUI.ViewModels.MainMenu.AddEditPanels.ProductsInMarketOptions
{
    class EditViewModel : INotifyPropertyChanged
    {
        public int UPC { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }

        public DelegateCommand Save { get; set; }
        public DelegateCommand Cancel { get; set; }
        public DelegateCommand Find { get; set; }
        Action _back;
        Action _reload;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public DBProductInMarket ProductInMarket { get => StateManager.productInMarketToEdit;
            set => StateManager.productInMarketToEdit = value; }
        public List<int> UPCs { get; set; }
        public EditViewModel(Action back, Action reload)
        {
            
            _back = back;
            _reload = reload;
            Cancel = new DelegateCommand(Back);
            Save = new DelegateCommand(Edit);
            var temp = Model.getInstance().db.GetAllProductsInMarket("[upc_ordinary]");
            UPCs = new List<int>();
            foreach (var t in temp)
            {
                UPCs.Add(((DBProductInMarket)t).UPC_ordinary);
            }
            Find = new DelegateCommand(FindByUPC);
            if (ProductInMarket != null)
            {
                UPC = ProductInMarket.UPC_ordinary;
                Name = ProductInMarket.Name;
                Price = ProductInMarket.Price;
                Amount = ProductInMarket.Amount;
            }
        }

        public void Back()
        {
            ProductInMarket = null;
            _back.Invoke();
        }
        public void Edit()
        {
            if (Price > 0 && Amount > 0)
            {
                Model.getInstance().db.UpdateProductInMarket(UPC, Price, Amount);
            }
            ProductInMarket = null;
            _back.Invoke();
        }

        public void FindByUPC()
        {
            try
            {
                ProductInMarket = (DBProductInMarket)(Model.getInstance().db.GetProductsInMarketByUPC(UPC)[0]);
                _reload.Invoke();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
           
            
        }
    }
}
