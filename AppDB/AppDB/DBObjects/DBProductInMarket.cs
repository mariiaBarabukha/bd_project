using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace Controller.DBObjects
{
    public class DBProductInMarket : DBObject, IDBObject
    {
        public DBProductInMarket() { }

        public DBProductInMarket(OleDbDataReader reader)
        {
            makeObjectdFrom(reader);
        }
        public DBProductInMarket(int upc_o, string name, int upc_p, decimal price,
            int amount, bool isProm, string characteristic)
        {
            //ID = Convert.ToInt32(Guid.NewGuid());            
            UPC_ordinary = upc_o;
            Price = price;
            UPC_promotional = upc_p;
            Amount = amount;
            IsPromotional = isProm;
            Name = name;
            Characteristic = characteristic;
        }
        public DBProductInMarket(DBProductInMarket p)
        {
            UPC_ordinary = p.UPC_ordinary;
            Price = p.Price;
            UPC_promotional = p.UPC_promotional;
            Amount = p.Amount;
            IsPromotional = p.IsPromotional;
            Name = p.Name;
            Characteristic = p.Characteristic;
        }

        public int UPC_ordinary { get; set; }
        public int UPC_promotional { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public bool IsPromotional { get; set; }
        public string Name { get; set; }
        public string Characteristic { get; set; }

        public DBObject makeObjectdFrom(OleDbDataReader reader)
        {
            UPC_ordinary = Convert.ToInt32(reader[0]);
            UPC_promotional = Convert.ToInt32(reader[1]);
            Amount = Convert.ToInt32(reader[2]);
            Price = Convert.ToDecimal(reader[3]);
            IsPromotional = (bool)reader[4];
            Name = reader[7].ToString();
            Characteristic = reader[10].ToString();
            return new DBProductInMarket(this);
        }
    }
}
