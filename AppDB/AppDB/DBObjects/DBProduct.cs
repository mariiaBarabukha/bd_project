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
        public DBProduct(int id, string name, int category, DateTime ed, string charact)
        {
            //ID = Convert.ToInt32(Guid.NewGuid());  
            ID = id;
            Name = name;
        //    Price = price;
            IDCategory = category;
            Expiration_day = ed;
            Characteristics = charact;
            
        }
        public DBProduct(DBProduct p)
        {
            ID = p.ID;           
            Name = p.Name;
         //   Price = p.Price;
            Category = p.Category;
            Expiration_day = p.Expiration_day;
            Characteristics = p.Characteristics;
            IDCategory = p.IDCategory;

        }

        public int ID { get; set; }
        public string Name { get; set; }
       // public decimal Price { get; set; }
        public string Category { get; set; }       
        public DateTime Expiration_day { get; private set; }
        public string Characteristics { get; set; }
        public int IDCategory { get; set; }

        public DBObject makeObjectdFrom(OleDbDataReader reader)
        {
            ID = Convert.ToInt32(reader[0]);
            Name = reader[1].ToString();
          //  Price = Convert.ToDecimal(reader[2]);           
            Category = reader[2].ToString();
            Expiration_day = (DateTime)reader[3];
            IDCategory = Convert.ToInt32(reader[4]);
            Characteristics = reader[5].ToString();
            return new DBProduct(this);
        }
    }
}
