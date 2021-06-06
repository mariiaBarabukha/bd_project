using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace Controller
{
    public class Model
    {
        private static Model instance;

        public DB db = new DB();

        private Model(){}

        public static Model getInstance()
        {
            if (instance == null)
                instance = new Model();
            return instance;
        }




    }
}
