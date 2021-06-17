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
        public DBSale(int iDCheck, int idprod, string name, decimal price, int amount)
        {
            //ID = Convert.ToInt32(Guid.NewGuid());            
            IDCheck = iDCheck;
            IDProduct = idprod;
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
            IDProduct = p.IDProduct;
        }

        public int IDCheck { get; set; }
        public int IDProduct { get; set; }
        public string NameProduct { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
       
        public DBObject makeObjectdFrom(OleDbDataReader reader)
        {
            IDCheck = Convert.ToInt32(reader[0]);
            IDProduct = Convert.ToInt32(reader[1]);
            NameProduct = reader[11].ToString();
            Amount = Convert.ToInt32(reader[2]);
            Price = Convert.ToDecimal(reader[3]);
            return new DBSale(this);
        }
    }
}
