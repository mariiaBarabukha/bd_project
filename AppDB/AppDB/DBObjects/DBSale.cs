using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace Controller.DBObjects
{
    public class DBSale : DBObject, IDBObject
    {
        public DBSale() { }

        public DBSale(OleDbDataReader reader)
        {
            makeObjectdFrom(reader);
        }
        public DBSale(int iDCheck, string name, int upc_p, decimal price,
            int amount, bool isProm, string characteristic)
        {
            //ID = Convert.ToInt32(Guid.NewGuid());            
            IDCheck = iDCheck;
            Price = price;
            Amount = amount;
            NameProduct = name;
        }
        public DBSale(DBSale p)
        {
            IDCheck = p.IDCheck;
            Price = p.Price;
            Amount = p.Amount;
            NameProduct = p.NameProduct;
        }

        public int IDCheck { get; set; }
        public string NameProduct { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
       
        public DBObject makeObjectdFrom(OleDbDataReader reader)
        {
            IDCheck = Convert.ToInt32(reader[0]);
            NameProduct = reader[5].ToString();
            Amount = Convert.ToInt32(reader[2]);
            Price = Convert.ToDecimal(reader[3]);
            return new DBSale(this);
        }
    }
}
