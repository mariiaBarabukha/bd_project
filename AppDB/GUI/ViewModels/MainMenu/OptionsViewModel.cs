using GUI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace GUI.ViewModels.MainMenu
{
    class OptionsViewModel
    {
        private TextBlock _sel_op;
        public TextBlock SelectedOption 
        {
            get => _sel_op;
            set 
            {
                _sel_op = value;
                StateManager.Current_option = _sel_op.Name;
                
            }
        }

        

    }
}
