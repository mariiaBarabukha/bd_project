using Controller;
using Controller.DBObjects;
using GUI.Models;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace GUI.ViewModels.MainMenu.CashierOptions
{
    class ClientByNameViewModel
    {
        public string Surname 
        { 
            get => CashiersOptionsManager.ClientSurname;
            set => CashiersOptionsManager.ClientSurname = value;
        }
        public List<DBClientCard> ClientCards { get; set; }
        public DelegateCommand Find { get; }

        public ClientByNameViewModel(Action reload)
        {
            Find = new DelegateCommand(reload);
            ClientCards = new List<DBClientCard>();
            var temp = Load();
            foreach (var t in temp)
            {
                ClientCards.Add((DBClientCard)t);
            }
        }

        public List<DBObject> Load()
        {
            if(Surname == "")
            {
                Model.getInstance().db.GetAllClientCards();
            }
            return Model.getInstance().db.GetClientByName(Surname);
        }
    }
}
