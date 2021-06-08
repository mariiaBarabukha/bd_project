using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace Controller.DBObjects
{
    public class DBCheckInfo : DBObject, IDBObject
    {
        public DBCheckInfo() { }

        public DBCheckInfo(OleDbDataReader reader)
        {
            makeObjectdFrom(reader);
        }
        public DBCheckInfo(string name, decimal total_sum,
            decimal vat, DateTime pd, List<DBSale> sales)
        {
            CashierName = name;
            Total_sum = total_sum;
            VAT = vat;
            PurchaseDate = pd;
            Sales = sales;
        }
        public DBCheckInfo(DBCheckInfo p)
        {
            ID = p.ID;
            CashierName = p.CashierName;
            Total_sum = p.Total_sum;
            VAT = p.VAT;
            PurchaseDate = p.PurchaseDate;
           // Sales = new List<DBSale>(p.Sales);
        }

        public int ID { get; set; }
        public string CashierName { get; set; }
        public decimal Total_sum { get; set; }
        public decimal VAT { get; set; }
        public DateTime PurchaseDate { get; set; }

        public List<DBSale> Sales { get; set; }

        public DBObject makeObjectdFrom(OleDbDataReader reader)
        {
            var t1 = reader[0];
            var t2 = reader[1];
            ID = Convert.ToInt32(reader[0]);
            PurchaseDate = (DateTime)reader[1];
            Total_sum = Convert.ToDecimal(reader[2]);
            VAT = Total_sum / 6;
            CashierName = reader[7].ToString();
            //var temp = Model.getInstance().db.GetSalesByCheck(ID);
            //Sales = new List<DBSale>();
            //foreach (var t in temp)
            //{
            //    Sales.Add((DBSale)t);
            //}
            return new DBCheckInfo(this);
        }
    }
}
