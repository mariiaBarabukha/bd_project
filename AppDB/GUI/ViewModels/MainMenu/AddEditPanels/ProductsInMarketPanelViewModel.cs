using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace GUI.ViewModels.MainMenu.AddEditPanels
{
    class ProductsInMarketPanelViewModel
    {
        public DelegateCommand AddNew { get; set; }
        public DelegateCommand AddProm { get; set; }
        public DelegateCommand Edit { get; set; }
        public DelegateCommand Back { get; set; }

        public ProductsInMarketPanelViewModel(Action goToAddNew, Action goToAddProm,
            Action goToEdit, Action back)
        {
            Back = new DelegateCommand(back);
            AddNew = new DelegateCommand(goToAddNew);
            AddProm = new DelegateCommand(goToAddProm);
            Edit = new DelegateCommand(goToEdit);
        }
    }
}
