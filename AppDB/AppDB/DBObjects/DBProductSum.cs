using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace Controller.DBObjects
{
    public class DBProductSum : DBObject, IDBObject
    {
        public DBProductSum() { }

        public DBProductSum(OleDbDataReader reader)
        {
            makeObjectdFrom(reader);
        }
        public DBProductSum(string name, decimal price,
            string category, DateTime ed)
        {
            //ID = Convert.ToInt32(Guid.NewGuid());            
            Name = name;
            Sum = price;
           

        }
        public DBProductSum(DBProductSum p)
        {
            Sum = p.Sum;
            Name = p.Name;
        }

        
        public string Name { get; set; }
        public decimal Sum { get; set; }
        

        public DBObject makeObjectdFrom(OleDbDataReader reader)
        {
           
            Name = reader[0].ToString();
            Sum = Convert.ToDecimal(reader[1]);           
            return new DBProductSum(this);
        }
    }
}
