using Controller;
using Controller.DBObjects;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GUI.ViewModels.MainMenu.Options
{
    class WorkersViewModel
    {
        //public ObservableCollection<WorkerViewModel> Workers { get; set; }
        public List<DBWorker> _Workers { get; set; }
        public DelegateCommand GetCashiers { get; }
        public DelegateCommand Find { get; }
        //Action goToCashiers;
        public WorkersViewModel(Action goToCashiers, Action goToFind)
        {
            // Workers = new ObservableCollection<WorkerViewModel>();
            GetCashiers = new DelegateCommand(goToCashiers);
            Find = new DelegateCommand(goToFind);
            _Workers = new List<DBWorker>();
            var temp = Load();
            foreach(var worker in temp)
            {
                //Workers.Add(new WorkerViewModel((DBWorker)worker));
                _Workers.Add((DBWorker)worker);
            }
        }

        private List<DBObject> Load()
        {
            return Model.getInstance().db.GetAllWorkers();
        }

        
    }
}
