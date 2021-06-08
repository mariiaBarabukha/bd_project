using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Controller;
using Controller.DBObjects;

namespace GUI.Models
{
    class AuthenticationService
    {
        private static List<DBUser> _users = new List<DBUser>();
        public async Task<User> Authenticate(AuthenticationUser authUser)
        {

            if (String.IsNullOrWhiteSpace(authUser.Login) || String.IsNullOrWhiteSpace(authUser.Password))
                throw new ArgumentException("Login or password is empty");
            var users = Model.getInstance().db.GetUserByLogin(authUser.Login);
            DBUser dbUser = null;
            DBUser temp = null;
            if (users.Count > 0)
            {
                temp = (DBUser)users[0];
            }
            else
            {
                throw new Exception("Incorrect login!");
            }
            if (temp != null && authUser.Password == PasswordHandler.Decode(temp.Password))
            {
                
                dbUser = (DBUser)users[0];
            }
            //MessageBox.Show(PasswordHandler.Decode(authUser.Password));
            if (dbUser == null)
            {
                throw new Exception("Incorrect password!");
            }
            return new User(dbUser.ID, dbUser.Name, dbUser.Email, dbUser.Login, dbUser.Role);
        }

        public async Task<bool> RegisterUser(RegisteredUser regUser)
        {
            var dbUser = new DBUser(regUser.Name, regUser.Email,
                regUser.Login, PasswordHandler.Code(regUser.Password), regUser.Role, regUser.Bitrhday, regUser.Address,
                regUser.Phone, Model.getInstance().db.MinSalary, DateTime.UtcNow);
            Model.getInstance().db.AddUser(dbUser);
           
            return true;

        }
    }
}

