using Controller;
using Controller.DBObjects;
using GUI.Models;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace GUI.ViewModels.MainMenu.Options
{
    class ClientCardsViewModel : INotifyPropertyChanged
    {
        public double Discount
        {
            get => StateManager.PercentDiscount;
            set 
            {
                if (StateManager.PercentDiscount != Convert.ToDouble(value))
                {
                    StateManager.PercentDiscount = Convert.ToDouble(value);
                    OnPropertyChanged();
                    // SignInCommand.RaiseCanExecuteChanged();
                }
                
            }
           
        }
        public List<DBClientCard> ClientCards { get; set; }
        public DelegateCommand Find { get; }
        public DelegateCommand GetAll { get; }
        Action _reload;
        public ClientCardsViewModel(Action reload)
        {
            _reload = reload;
            Find = new DelegateCommand(reload);
            GetAll = new DelegateCommand(GetAllClients);
            ClientCards = new List<DBClientCard>();
            var cards = Load();
            foreach (var card in cards)
            {
                ClientCards.Add((DBClientCard)card);
            }

        }

        public void GetAllClients()
        {
            StateManager.PercentDiscount = 0;
            _reload.Invoke();

        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private List<DBObject> Load()
        {
            if(Discount == 0)
                return Model.getInstance().db.GetAllClientCards();
            return Model.getInstance().db.GetClientsWithDiscount(Discount);
        }
    }
}
