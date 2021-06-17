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
        public DBClientCard Card 
        { 
            get => StateManager.CardToEdit; 
            set => StateManager.CardToEdit = value;
        }
        public DelegateCommand Find { get; }
        public DelegateCommand Delete { get; }
        public DelegateCommand Add { get; }
        public DelegateCommand Edit { get; }

        private Action _goToAdd;
        public DelegateCommand GetAll { get; }
        Action _reload;
        public bool delButtonVisibility { get; set; }
        public ClientCardsViewModel(Action reload, Action goToAdd)
        {
            _reload = reload;
            _goToAdd = goToAdd;
            Add = new DelegateCommand(GoToAdd);
            Edit = new DelegateCommand(GoToEdit);
            delButtonVisibility = false;
            if (StateManager.Current_user.Position.ToUpper() == "MANAGER")
            {
                delButtonVisibility = true;
            }
            Find = new DelegateCommand(reload);
            Delete = new DelegateCommand(DeleteCard);
            GetAll = new DelegateCommand(GetAllClients);
            ClientCards = new List<DBClientCard>();
            var cards = Load();
            foreach (var card in cards)
            {
                ClientCards.Add((DBClientCard)card);
            }

        }

        private void GoToAdd()
        {
            StateManager.ToEdit = false;
            _goToAdd.Invoke();
        }
        private void GoToEdit()
        {
            StateManager.ToEdit = true;
            _goToAdd.Invoke();
        }
        private void DeleteCard()
        {
            Model.getInstance().db.DeleteClient(Card.ID);
            _reload.Invoke();

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
