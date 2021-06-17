using Controller;
using Controller.DBObjects;
using GUI.Models;
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
        public DelegateCommand Delete { get; }
        public DBWorker Worker 
        { 
            get => StateManager.WorkerToEdit;
            set => StateManager.WorkerToEdit = value; 
        }
        public DelegateCommand Edit { get; }
        private Action _goToEdit;
        private Action _reload;
        //Action goToCashiers;
        public WorkersViewModel(Action goToCashiers, Action goToFind, Action reload, Action goToEdit)
        {
            // Workers = new ObservableCollection<WorkerViewModel>();
            GetCashiers = new DelegateCommand(goToCashiers);
            Find = new DelegateCommand(goToFind);
            _reload = reload;
            Delete = new DelegateCommand(DeleteWorker);
            _goToEdit = goToEdit;
            Edit = new DelegateCommand(UpDate);
            _Workers = new List<DBWorker>();
            var temp = Load();
            foreach(var worker in temp)
            {
                //Workers.Add(new WorkerViewModel((DBWorker)worker));
                _Workers.Add((DBWorker)worker);
            }
        }

        private void DeleteWorker()
        {
            Model.getInstance().db.DeleteWorker(Worker.ID);
            _reload.Invoke();

        }
        private List<DBObject> Load()
        {
            return Model.getInstance().db.GetAllWorkers();
        }

        private void UpDate()
        {
            if (StateManager.WorkerToEdit != null)
                _goToEdit.Invoke();
        }

        
    }
}
