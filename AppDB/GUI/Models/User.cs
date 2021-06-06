using System;
using System.Collections.Generic;
using System.Text;

namespace GUI.Models
{
    class User
    {
        public User(int id, string name, string email, string login, string role)
        {
            ID = id;
            Name = name;           
            Email = email;
            Login = login;
            Position = role;
        }


        public int ID { get; }
        public string Name { get; }        
        public string Email { get; }
        public string Login { get; }

        public string Position { get; }
    }
}
