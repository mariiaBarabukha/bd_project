using GUI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace GUI.ViewModels.MainMenu.CashierOptions
{
    class CashierOptionsViewModel
    {
        private TextBlock _sel_op;
        public TextBlock SelectedOption
        {
            get => _sel_op;
            set
            {
                _sel_op = value;
                CashiersOptionsManager.Current_option = _sel_op.Name;

            }
        }
    }
}
