using GUI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GUI.ViewModels.MainMenu
{
    class HeaderViewModel
    {
        public string Name { get; private set; }

        public string Position { get; private set; }
        public HeaderViewModel()
        {
            Name = StateManager.Current_user.Name;
            Position = StateManager.Current_user.Position;
        }
    }
}
