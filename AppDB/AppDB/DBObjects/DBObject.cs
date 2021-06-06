using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace Controller.DBObjects
{
    public class DBObject
    {
        private IDBObject _dBObject;

        public DBObject()
        { }
        public DBObject(IDBObject dBObject)
        {
            _dBObject = dBObject;
        }

        public IDBObject DBobject { get => _dBObject; set => _dBObject = value; }

        public DBObject makeObjectFrom(OleDbDataReader reader)
        {
           return _dBObject.makeObjectdFrom(reader);
        }
        

    }

    public interface IDBObject
    {
        DBObject makeObjectdFrom(OleDbDataReader reader);
    }
}
