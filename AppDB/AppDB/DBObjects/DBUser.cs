using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace Controller.DBObjects
{
    public class DBUser : DBObject, IDBObject
    {
        public DBUser() { }
        
        public DBUser(OleDbDataReader reader)
        {
            makeObjectdFrom(reader);
        }
        public DBUser(string name, string email, string login, string password,
            string role, DateTime bd, string address, string phone, decimal salary,
            DateTime start)
        {
            //ID = Convert.ToInt32(Guid.NewGuid());            
            Name = name;
            Email = email;
            Login = login;
            Password = password;
            Role = role;
            Birthday = bd;
            Address = address;
            Phone = phone;
            Salary = salary;
            DateStart = start;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime DateStart { get; private set; }

        public DBObject makeObjectdFrom(OleDbDataReader reader)
        {
            ID = Convert.ToInt32(reader[0]);
            Login = reader[1].ToString();
            Email = reader[2].ToString();
            Password = reader[3].ToString();
            Name = reader[5].ToString();               
            Role = reader[6].ToString();
            Salary = Convert.ToDecimal(reader[7]);
            DateStart = (DateTime)reader[8];
            Birthday = (DateTime)reader[9];
            Phone = reader[10].ToString(); 
            Address = reader[11].ToString();
            return this;
        }
    }
}
