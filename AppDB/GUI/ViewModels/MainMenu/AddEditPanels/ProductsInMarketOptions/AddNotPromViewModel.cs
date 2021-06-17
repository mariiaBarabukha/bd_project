using Controller;
using Controller.DBObjects;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace GUI.ViewModels.MainMenu.AddEditPanels.ProductsInMarketOptions
{
    class AddNotPromViewModel
    {
        public List<string> Names { get; set; }
        List<DBProduct> _dBProducts;
        public string Product { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }
        public DelegateCommand Save { get; set; }
        public DelegateCommand Cancel { get; set; }

        Action _back;
        public AddNotPromViewModel(Action back)
        {
            _back = back;
            Cancel = new DelegateCommand(back);
            Save = new DelegateCommand(Add);
            Names = new List<string>();
            _dBProducts = new List<DBProduct>();
            var temp = Model.getInstance().db.GetProductsNotInMarketNotProm();
            foreach (var t in temp)
            {
                var prod = (DBProduct)t;
                Names.Add(prod.Name);
                _dBProducts.Add(prod);
            }
        }

        private void Add()
        {
            try
            {
                Model.getInstance().db.AddPromProductInMarket(_dBProducts[Names.IndexOf(Product)].ID,
                    Price, Amount);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            _back.Invoke();
        }
    }
}
