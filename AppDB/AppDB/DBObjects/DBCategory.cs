using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace Controller.DBObjects
{
    public class DBCategory : DBObject, IDBObject
    {
        public DBCategory() { }

        public DBCategory(OleDbDataReader reader)
        {
            makeObjectdFrom(reader);
        }
        public DBCategory(string name)
        {
            //ID = Convert.ToInt32(Guid.NewGuid());            
            Name = name;          

        }
        public DBCategory(DBCategory p)
        {
            ID = p.ID;
            Name = p.Name;
        }

        public int ID { get; set; }
        public string Name { get; set; }
      

        public DBObject makeObjectdFrom(OleDbDataReader reader)
        {
            ID = Convert.ToInt32(reader[0]);
            Name = reader[1].ToString();           
            return new DBCategory(this);
        }
    }
}
