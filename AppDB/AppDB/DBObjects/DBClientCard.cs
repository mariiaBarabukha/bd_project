using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace Controller.DBObjects
{
    public class DBClientCard : DBObject, IDBObject
    {


        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public double Discount { get; set; }
        public DBClientCard()
        {

        }
        public DBClientCard(OleDbDataReader reader)
        {
            makeObjectdFrom(reader);
        }

        public DBObject makeObjectdFrom(OleDbDataReader reader)
        {
            ID = Convert.ToInt32(reader[0]);
            Name = reader[1].ToString();
            Phone = reader[2].ToString();
            Address = reader[3].ToString();
            Discount = Convert.ToDouble(reader[4]);
            return new DBClientCard(this);

        }

        public DBClientCard(DBClientCard w)
        {
            ID = w.ID;
            Name = w.Name;
            Phone = w.Phone;
            Address = w.Address;
            Discount = w.Discount;
        }

        public DBClientCard(int id, string name, string phone, string address, double discout)
        {
            ID = id;
            Name = name;
            Phone = phone;
            Address = address;
            Discount = discout;
        }
    }
}
