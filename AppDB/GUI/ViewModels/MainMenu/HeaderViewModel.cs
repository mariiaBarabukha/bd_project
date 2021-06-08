using GUI.Models;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace GUI.ViewModels.MainMenu
{
    class HeaderViewModel
    {
        public string Name { get; private set; }

        public string Position { get; private set; }

        public DelegateCommand LogOut { get; }
        public HeaderViewModel(Action logOut)
        {
            LogOut = new DelegateCommand(logOut);
            Name = StateManager.Current_user.Name;
            Position = StateManager.Current_user.Position;
        }
    }
}
