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
    class FindWorkerViewModel : INotifyPropertyChanged
    {
        public List<DBWorker> Workers { get; set; }
        public string Surname
        {
            get => StateManager.SurnameOfWorker;
            set
            {
                if (StateManager.SurnameOfWorker != value)
                {
                    StateManager.SurnameOfWorker = value;
                    OnPropertyChanged();
                   // SignInCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public DelegateCommand GoBack { get; }
        public DelegateCommand Find { get; }
        //Action goToCashiers;
        public FindWorkerViewModel(Action goToWorkers, Action find)
        {
            // Workers = new ObservableCollection<WorkerViewModel>();
            GoBack = new DelegateCommand(goToWorkers);
            Find = new DelegateCommand(find);
            Workers = new List<DBWorker>();
            var temp = Load();
            foreach (var worker in temp)
            {
                //Workers.Add(new WorkerViewModel((DBWorker)worker));
                Workers.Add((DBWorker)worker);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private List<DBObject> Load()
        {
            return Model.getInstance().db.GetWorkerBySurname(Surname);
        }
    }
}
