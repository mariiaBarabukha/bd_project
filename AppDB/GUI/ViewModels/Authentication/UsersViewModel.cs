using Controller;
using Controller.DBObjects;
using GUI.Models;
using GUI.Views;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

namespace GUI.ViewModels
{
    class UsersViewModel : BindableBase
    {
        public ObservableCollection<UserViewModel> Users { get; set;}
       
        public UsersViewModel()
        {
            
            var users = Load();
            Users = new ObservableCollection<UserViewModel>();
            //foreach (var user in users)
            //{
            //    Users.Add(new UserViewModel((DBPerson)user));
            //}
        }

        public List<DBObject> Load()
        {
            return Model.getInstance().db.GetData4();
        }
    }
}
