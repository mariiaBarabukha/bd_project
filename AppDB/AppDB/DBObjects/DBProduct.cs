using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace Controller.DBObjects
{
    public class DBProduct : DBObject, IDBObject
    {
        public DBProduct() { }

        public DBProduct(OleDbDataReader reader)
        {
            makeObjectdFrom(reader);
        }
        public DBProduct(string name, decimal price,
            string category, DateTime ed)
        {
            //ID = Convert.ToInt32(Guid.NewGuid());            
            Name = name;
        //    Price = price;
            Category = category;
            Expiration_day = ed;
            
        }
        public DBProduct(DBProduct p)
        {
            ID = p.ID;           
            Name = p.Name;
         //   Price = p.Price;
            Category = p.Category;
            Expiration_day = p.Expiration_day;

        }

        public int ID { get; set; }
        public string Name { get; set; }
       // public decimal Price { get; set; }
        public string Category { get; set; }       
        public DateTime Expiration_day { get; private set; }

        public DBObject makeObjectdFrom(OleDbDataReader reader)
        {
            ID = Convert.ToInt32(reader[0]);
            Name = reader[1].ToString();
          //  Price = Convert.ToDecimal(reader[2]);           
            Category = reader[2].ToString();
            Expiration_day = (DateTime)reader[3];
            return new DBProduct(this);
        }
    }
}
