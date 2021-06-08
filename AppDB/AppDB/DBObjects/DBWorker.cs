using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace Controller.DBObjects
{
    public class DBWorker : DBObject, IDBObject
    {


        public int ID { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public DateTime Date_start { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Name_manager { get;  set; }
        public DBWorker()
        {

        }
        public DBWorker(OleDbDataReader reader)
        {
            makeObjectdFrom(reader);
        }

        public DBObject makeObjectdFrom(OleDbDataReader reader)
        {
            ID = Convert.ToInt32(reader[0]);
            Name = reader[1].ToString();
            Position = reader[2].ToString();
            Salary = Convert.ToDecimal(reader[3]);
            Date_start = (DateTime)reader[4];
            Birthday = (DateTime)reader[5];
            Phone = reader[6].ToString();
            Address = reader[7].ToString();
            Name_manager = reader[10].ToString();
            return new DBWorker(this);

        }

        public DBWorker(DBWorker w)
        {
            ID = w.ID;
            Name = w.Name;
            Position = w.Position;
            Salary = w.Salary;
            Date_start = w.Date_start;
            Birthday = w.Birthday;
            Phone = w.Phone;
            Address = w.Address;
            Name_manager = w.Name_manager;
        }
    }
}
