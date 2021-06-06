using Controller.DBObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Windows;

namespace Controller
{
    public class DB
    {

        decimal minSalary = 7000;
        
        //int usercounter = 0;
        IDBObject[] dBObjects;
        DBObject obj = new DBObject();
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\study\\2_year_of_study\\bd_1\\АІС\\supermarket.accdb;Persist Security Info=False;";

        public decimal MinSalary { get => minSalary; }

        public DB()
        {
            dBObjects = new IDBObject[10];
            dBObjects[0] = new DBWorker();
            dBObjects[1] = new DBUser();
            dBObjects[2] = new DBProduct();
            dBObjects[3] = new DBProductInMarket();
            dBObjects[4] = new DBCategory();
            dBObjects[5] = new DBClientCard();
            dBObjects[6] = new DBProductSum();
        }

        private List<DBObject> getData(string queryString, DBObject obj)
        {
            //obj = (str)obj;
            var dataList = new List<DBObject>();
           
            using (OleDbConnection connection = new OleDbConnection(
                       connectionString))
            using (var command = connection.CreateCommand())
            {
                command.CommandText = queryString;
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    dataList.Add(obj.makeObjectFrom(reader));
                }
                reader.Close();

            }

            return dataList;
        }

        //public List<DBObject> GetData1()
        //{
        //    obj.DBobject = dBObjects[0];
        //    obj = new DBPerson();
        //    //var users = new List<DBObject>();
        //    string queryString = "SELECT [card_id], [full_name_owner]" +
        //       " FROM [Client_card] WHERE [card_id] NOT IN " +
        //       "(SELECT [client_card_id] " +
        //       "FROM [Check] INNER JOIN [Sale] ON [Check].[id_check] = [Sale].[check_id]" +
        //       " WHERE [id_product] IN (SELECT [id_product]" +
        //       " FROM [Product] INNER JOIN [Category] ON [Product].[category_id] = [Category].[id_category]" +
        //       " WHERE [name_category] = 'Побутова хімія'))";
        //    return getData(queryString, obj);
            
        //}
        public List<DBObject> GetData4()
        {
            obj.DBobject = dBObjects[0];
            //obj = new DBPerson();
            string queryString = "SELECT [card_id], [full_name_owner] FROM [Client_card]"+
                "WHERE [card_id] IN(SELECT [card_id] FROM [Check]"+
                " WHERE NOT EXISTS (SELECT * FROM [Help4]"+
                "WHERE [id_category] NOT IN (SELECT [id_category] "+
                "FROM [Help4] WHERE [card_id] = [Check].[client_card_id])))";
            return getData(queryString, obj);
        }

        public List<DBObject> GetUserByLogin(string login)
        {
            obj.DBobject = dBObjects[1];
            string queryString = "SELECT * FROM [User] "+
                "INNER JOIN Worker ON [User].[user_id] = [Worker].[id_worker]" +
                "WHERE [login] = '"+login+"'";
            //Console.WriteLine(login);
            return getData(queryString, obj);
        }

        public List<DBObject> GetAllWorkers()
        {
            obj.DBobject = dBObjects[0];
            
            string queryString = "SELECT * FROM [Worker] ";

            return getData(queryString, obj);
        }

        public List<DBObject> GetWorkerBySurname(string surname)
        {
            obj.DBobject = dBObjects[0];

            string queryString = "SELECT * FROM [Worker] " +
                "WHERE [full_name] LIKE '"+surname+"%'";

            return getData(queryString, obj);
        }

        public List<DBObject> GetCashiers()
        {
            obj.DBobject = dBObjects[0];

            string queryString = "SELECT * FROM [Worker] "+
                "WHERE [position] = 'cashier'"+
                "ORDER BY [full_name]";

            return getData(queryString, obj);
        }
        public List<DBObject> GetAllCategories()
        {
            obj.DBobject = dBObjects[4];

            string queryString = "SELECT * FROM [Category] " +
                "ORDER BY [name_category]";

            return getData(queryString, obj);
        }

        public List<DBObject> GetAllProducts()
        {
            obj.DBobject = dBObjects[2];

            string queryString = "SELECT [id_product], [name_product], "+
                "[price], [name_category], [expiration_date]"+
                " FROM [Product] INNER JOIN [Category] ON"+
                "[Product].[category_id] = [Category].[id_category]"+
                "ORDER BY [name_product]";

            return getData(queryString, obj);
        }



        public List<DBObject> GetProductsWithCategory(string category)
        {
            obj.DBobject = dBObjects[2];

            string queryString = "SELECT [id_product], [name_product], " +
                "[price], [name_category], [expiration_date]" +
                " FROM ([Product] INNER JOIN [Category] ON" +
                "[Product].[category_id] = [Category].[id_category])" +
                "WHERE [name_category] = '"+category+"'"+
                "ORDER BY [name_product]";

            return getData(queryString, obj);
        }

        public List<DBObject> GetAllProductsInMarket(string order)
        {
            obj.DBobject = dBObjects[3];

            string queryString = "SELECT * FROM [Product_in_market] INNER JOIN"+
                " [Product] ON [Product_in_market].[id_product] = [Product].[id_product]" +
                " ORDER BY "+ order;

            return getData(queryString, obj);
        }

        public List<DBObject> GetAllPromProductsInMarket(string order)
        {
            obj.DBobject = dBObjects[3];

            string queryString = "SELECT * FROM [Product_in_market] INNER JOIN" +
                " [Product] ON [Product_in_market].[id_product] = [Product].[id_product]" +
                 "WHERE isPromotional = -1 "+
                "ORDER BY " + order;

            return getData(queryString, obj);
        }

        public List<DBObject> GetProductsInMarketByUPC(int upc)
        {
            obj.DBobject = dBObjects[3];

            string queryString = "SELECT * FROM [Product_in_market] INNER JOIN" +
                " [Product] ON [Product_in_market].[id_product] = [Product].[id_product]" +
                 "WHERE UPC_ordinary = " +upc+" OR UPC_promotional = "+upc;

            return getData(queryString, obj);
        }

        public List<DBObject> GetAllNotPromProductsInMarket(string order)
        {
            obj.DBobject = dBObjects[3];


            string queryString = "SELECT * FROM [Product_in_market] INNER JOIN" +
                " [Product] ON [Product_in_market].[id_product] = [Product].[id_product]" +
                " WHERE isPromotional = 0 "+
                " ORDER BY " + order;

            return getData(queryString, obj);
        }

        public List<DBObject> GetAllClientCards()
        {
            obj.DBobject = dBObjects[5];

            string queryString = "SELECT * FROM [Client_card] ";

            return getData(queryString, obj);
        }

        public List<DBObject> GetClientsWithDiscount(double discount)
        {
            obj.DBobject = dBObjects[5];

            string queryString = "SELECT * FROM [Client_card] "+
                "WHERE [discount_percents] = "+discount;

            return getData(queryString, obj);
        }

        public List<DBObject> GetTotalSumOfProducts(DateTime From,
            DateTime To)
        {
            obj.DBobject = dBObjects[6];
            string date1 = From.Date.ToString("d").Replace(".", "/");
            string date2 = To.Date.ToString("d").Replace(".", "/");
            string queryString = "SELECT [name_product],"+
                " SUM([Sale].[price]) AS total_sum "+
                "FROM ([Sale] INNER JOIN [Product] ON"+
                " [Sale].[id_product] = [Product].[id_product]) "+
                "INNER JOIN [Check] ON [Sale].[check_id] = [Check].[id_check]" +
                "WHERE [date_of_purchase] > #" + date1+
                "# AND [date_of_purchase] < #" + date2 + "#"+
                "GROUP BY [name_product]";

            return getData(queryString, obj);
        }
        public List<DBObject> GetTotalSumOfProductsByCashier(string name, 
            DateTime From, DateTime To)
        {
            obj.DBobject = dBObjects[6];
            string date1 = From.Date.ToString("d").Replace(".", "/");
            string date2 = To.Date.ToString("d").Replace(".", "/");
            string queryString = "SELECT [name_product]," +
                " SUM([Sale].[price]) AS total_sum " +
                "FROM ([Sale] INNER JOIN [Product] ON" +
                " [Sale].[id_product] = [Product].[id_product]) " +
                "INNER JOIN [Check] ON [Sale].[check_id] = [Check].[id_check]"+
                "WHERE [cashier_id] IN (SELECT [id_worker] AND " +
                "[date_of_purchase] > #" + date1+
                "# AND [date_of_purchase] < #" + date2 + "#" +
                "FROM [Worker] " +
                "WHERE [full_name] = '"+name+"') " +
                "GROUP BY [name_product]";
               

            return getData(queryString, obj);
        }


        public void AddUser(DBUser regUser)
        {
            Random random = new Random();
            var bytes = new byte[1];
            random.NextBytes(bytes);
            OleDbConnection connection = new OleDbConnection(
                       connectionString);
            //ADD TO USER
            var cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO [User]"
                + " VALUES (@user_id,@login,@email,"
                +"@password)";
            cmd.Parameters.AddWithValue("@user_id", bytes[0]);
            cmd.Parameters.AddWithValue("@login", regUser.Login);
            cmd.Parameters.AddWithValue("@email", regUser.Email);
            cmd.Parameters.AddWithValue("@password", regUser.Password);
           
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

            //ADD TO WORKER
            cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO [Worker]"
                + " VALUES (@id_worker,@fullnme,@position,"
                + "@salary, Date(), @birthday, @phone_number, @address, @id_manager)";
            cmd.Parameters.AddWithValue("@user_id", bytes[0]);
            cmd.Parameters.AddWithValue("@full_name", regUser.Name);
            cmd.Parameters.AddWithValue("@position", regUser.Role);
            cmd.Parameters.AddWithValue("@salary", regUser.Salary);
           //cmd.Parameters.AddWithValue("@date_start", regUser.DateStart);
            cmd.Parameters.AddWithValue("@birthday", regUser.Birthday);
            cmd.Parameters.AddWithValue("@phone_number", regUser.Phone);
            cmd.Parameters.AddWithValue("@address", regUser.Address);
            cmd.Parameters.AddWithValue("@id_manger", 3);
            //cmd.Connection = connectionString;
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            //Random random = new Random();
            //var bytes = new byte[1];
            //random.NextBytes(bytes);
            //OleDbDataAdapter adapter = new OleDbDataAdapter();
            //OleDbCommand command;
            //OleDbConnection connection = new OleDbConnection(
            //            connectionString);


            //command = new OleDbCommand(
            //    "INSERT INTO User " +
            //    "VALUES ("+ bytes[0] + ", ?, ?, ?, ?, ?)", connection);

            //command.Parameters.Add(
            //    "user_id", OleDbType.Integer).Value = bytes[0];
            //command.Parameters.Add(
            //    "full_name", OleDbType.VarChar).Value = regUser.Name;
            //command.Parameters.Add(
            //    "login", OleDbType.VarChar).Value = regUser.Login;
            //command.Parameters.Add(
            //    "email", OleDbType.VarChar).Value = regUser.Email;
            //command.Parameters.Add(
            //    "password", OleDbType.VarChar).Value = regUser.Password;
            //command.Parameters.Add(
            //    "role", OleDbType.VarChar).Value = regUser.Role;

            //"INSERT INTO User " +
            //    "VALUES (" + regUser.Name + ", " + regUser.Login +
            //    ", " + regUser.Email + ", " + regUser.Password + ", " + regUser.Role
            //    + ")", connection);

            //adapter.InsertCommand = command;

            return;
        }

       

    }
}
