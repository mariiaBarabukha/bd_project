using GUI.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace GUI.ViewModels
{
    class MainViewModel : BindableBase
    {
        public DelegateCommand ShowRes { get; }
        List<UserViewModel> users = new List<UserViewModel>();

        public MainViewModel()
        {
            
        }

        
    }
}
