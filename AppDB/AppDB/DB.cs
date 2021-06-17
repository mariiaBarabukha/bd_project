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
            dBObjects[7] = new DBCheckInfo();
            dBObjects[8] = new DBSale();
        }

        public void UpdateSale(int checkID2, int uPC, int amount)
        {
            OleDbConnection connection = new OleDbConnection(
                        connectionString);
            // string date1 = worker.Date_start.Date.ToString("d").Replace(".", "/");
            //  string date2 = worker.Birthday.Date.ToString("d").Replace(".", "/");
            var cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE Sale " +
                "Set amount = @amount " +

                " WHERE check_id = @check_id AND id_product = @id_product;";

            cmd.Parameters.AddWithValue("@amount", amount);
            cmd.Parameters.AddWithValue("@check_id", checkID2);
            cmd.Parameters.AddWithValue("@id_product", uPC);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
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
            
            string queryString = "SELECT * FROM Worker INNER JOIN" +
                " Worker W1 ON [W1].[id_worker] = [Worker].[id_manager] ";

            return getData(queryString, obj);
        }

        public DBWorker GetWorkerByID(int id)
        {
            obj.DBobject = dBObjects[0];

            string queryString = "SELECT * FROM Worker INNER JOIN" +
                " Worker W1 ON [W1].[id_worker] = [Worker].[id_manager] " +
                "WHERE [Worker].[id_worker] = "+id;

            return (DBWorker)(getData(queryString, obj)[0]);
        }

        public List<DBObject> GetWorkerBySurname(string surname)
        {
            obj.DBobject = dBObjects[0];

            string queryString = "SELECT * FROM Worker INNER JOIN Worker W1 " +
                "ON [W1].[id_worker] = [Worker].[id_manager] " +
                "WHERE [Worker].[full_name] LIKE '"+surname+"%'";

            return getData(queryString, obj);
        }

        public List<DBObject> GetCashiers()
        {
            obj.DBobject = dBObjects[0];

            string queryString = "SELECT * FROM Worker INNER JOIN Worker W1" +
                " ON [W1].[id_worker] = [Worker].[id_manager] " +
                "WHERE [Worker].[position] = 'cashier'"+
                "ORDER BY [Worker].[full_name]";

            return getData(queryString, obj);
        }

        public List<DBObject> GetManagers()
        {
            obj.DBobject = dBObjects[0];

            string queryString = "SELECT * FROM Worker INNER JOIN Worker W1" +
                " ON [W1].[id_worker] = [Worker].[id_manager] " +
                "WHERE [Worker].[position] = 'manager'" +
                "ORDER BY [Worker].[full_name]";

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
                "[name_category], [expiration_date], [category_id], [characteristics]"+
                " FROM [Product] INNER JOIN [Category] ON"+
                "[Product].[category_id] = [Category].[id_category]"+
                "ORDER BY [name_product]";

            return getData(queryString, obj);
        }

        public List<DBObject> GetProductsNotInMarket()
        {
            obj.DBobject = dBObjects[2];

            string queryString = "SELECT [id_product], [name_product], " +
                "[name_category], [expiration_date], [category_id], [characteristics]" +
                " FROM [Product] AS T INNER JOIN [Category] ON" +
                "[T].[category_id] = [Category].[id_category]  " +
                " WHERE NOT EXISTS(SELECT*" +
                " FROM Product_in_market INNER JOIN[Product] ON " +
                " [Product_in_market].[id_product] = [Product].[id_product]" +
                " WHERE T.id_product = Product.id_product)";


            return getData(queryString, obj);
        }

        public List<DBObject> GetProductsNotInMarketNotProm()
        {
            obj.DBobject = dBObjects[2];

            string queryString = "SELECT Product.[id_product], [name_product], " +
                " [name_category], [expiration_date], [category_id], [characteristics]" +
                " FROM ((Product INNER JOIN Category ON Product.[category_id] = [Category].[id_category]) " +
                " INNER JOIN Product_in_market ON Product.id_product = Product_in_market.id_product)" +
                " WHERE Product.id_product NOT IN (SELECT Product.id_product FROM ((Product  INNER JOIN Category ON Product.[category_id] = [Category].[id_category]) " +
                " INNER JOIN Product_in_market ON Product.id_product = Product_in_market.id_product) " +
                " Left Join Product_in_market AS T ON T.UPC_ordinary = Product_in_market.UPC_promotional" +
                " WHERE Product_in_market.isPromotional = 0 AND T.isPromotional = -1)";


            return getData(queryString, obj);
        }

        public List<DBObject> GetProductsWithCategory(string category)
        {
            obj.DBobject = dBObjects[2];

            string queryString = "SELECT [id_product], [name_product], " +
                "[name_category], [expiration_date], [category_id], [characteristics] " +
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
        public List<DBObject> GetProductsInMarketByProduct(string name)
        {
            obj.DBobject = dBObjects[3];

            string queryString = "SELECT *" +
                " FROM Product_in_market INNER JOIN" +
                " Product ON Product_in_market.id_product = Product.id_product"+
                " WHERE name_product = '"+name+"'";

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

        public List<DBObject> GetClientByName(string surname)
        {
            obj.DBobject = dBObjects[5];

            string queryString = "SELECT * FROM [Client_card] " +
                "WHERE [full_name_owner] LIKE '" + surname+" %'";
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

        public List<DBObject> GetTotalAmountOfProducts(DateTime From,
            DateTime To)
        {
            obj.DBobject = dBObjects[6];
            string date1 = From.Date.ToString("d").Replace(".", "/");
            string date2 = To.Date.ToString("d").Replace(".", "/");
            string queryString = "SELECT [name_product], COUNT([Sale].[amount]) AS total_amount "+
                " FROM(([Check] INNER JOIN [Sale] ON [Check].[id_check] = [Sale].[check_id]) " +
                " INNER JOIN [Product] ON [Sale].[id_product] = [Product].[id_product]) " +
                " INNER JOIN [Product_in_market] ON [Sale].[id_product] = [Product_in_market].[id_product] "+
                " WHERE [date_of_purchase] > #"+date1+"# AND [date_of_purchase] < #" +date2+"# "+
                " GROUP BY name_product";


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

        public List<DBObject> GetAllChecks()
        {
            obj.DBobject = dBObjects[7];

            string queryString = "SELECT * FROM [Check] INNER JOIN [Worker] "+
                "ON [Check].[cashier_id] = [Worker].[id_worker]";

            return getData(queryString, obj);
        }

        public List<DBObject> GetChecksByID(int id)
        {
            obj.DBobject = dBObjects[7];

            string queryString = "SELECT * FROM [Check] INNER JOIN [Worker] " +
                "ON [Check].[cashier_id] = [Worker].[id_worker]" +
                "WHERE [id_check] = " + id;

            return getData(queryString, obj);
        }

        public List<DBObject> GetChecksByCashier(string name)
        {
            obj.DBobject = dBObjects[7];

            string queryString = "SELECT * FROM [Check] INNER JOIN [Worker] " +
                "ON [Check].[cashier_id] = [Worker].[id_worker]"+
                "WHERE full_name = '"+name+"'";

            return getData(queryString, obj);
        }

        public List<DBObject> GetSalesByCheck(int id)
        {
            obj.DBobject = dBObjects[8];

            string queryString = "SELECT * FROM ([Sale] INNER JOIN [Product_in_market] " +
                "ON [Sale].[id_product] = [Product_in_market].[UPC_ordinary])" +
                " INNER JOIN Product ON Product_in_market.id_product = Product.id_product" +
                " WHERE [check_id] = "+id;

            return getData(queryString, obj);
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


        public void DeleteWorker(int id)
        {
            string queryString = "DELETE * FROM [Worker]" +
                "WHERE id_worker = " + id;
            Delete(queryString);
        }

        public void DeleteProduct(int id)
        {
            string queryString = "DELETE * FROM [Product]" +
                "WHERE id_product = " + id;
            Delete(queryString);
        }
        public void DeleteCategory(int id)
        {
            string queryString = "DELETE * FROM [Category]" +
                "WHERE id_category = " + id;
            Delete(queryString);
        }
        public void DeleteProductInMarket(int id)
        {
            string queryString = "DELETE * FROM [Product_in_market]" +
                "WHERE UPC_ordinary = " + id;
            Delete(queryString);
        }
        public void DeleteCheck(int id)
        {
            var sales = GetSalesByCheck(id);
            foreach (var sale in sales)
            {
                DeleteSale(id,((DBSale)sale).IDProduct);
            }
            string queryString = "DELETE * FROM [Check]" +
                "WHERE id_check = " + id;
            Delete(queryString);
        }
        public void DeleteSale(int check_id, int id_product)
        {
            obj.DBobject = dBObjects[8];
            string getQueryString = "SELECT * FROM [Sale] INNER JOIN [Product] " +
                "ON [Sale].[id_product] = [Product].[id_product] " +
                " WHERE check_id = " + check_id + " AND [Product].id_product = " + id_product;
            var t = getData(getQueryString, obj);
            if (t.Count == 0)
            {
                return;
            }

            var sale = (DBSale)(t[0]);

            int amount = sale.Amount;
            //int id_prod = sale.IDProduct;
            string queryString = "DELETE * FROM [Sale] " +
                " WHERE check_id = " + check_id + " AND id_product = "+ id_product;
            Delete(queryString);
            string updateQueryString = "UPDATE Product_in_market " +
                " SET amount_of_product = amount_of_product + " + amount+
                " WHERE id_product = " + id_product;
            OleDbConnection connection = new OleDbConnection(
                        connectionString);
            connection.Open();
            OleDbCommand updatecmd = new OleDbCommand();
            updatecmd.CommandText = updateQueryString;
            updatecmd.Connection = connection;
            updatecmd.ExecuteNonQuery();
            connection.Close();
        }
        public void DeleteClient(int id)
        {
            string queryString = "DELETE * FROM [Client_card]" +
                "WHERE card_id = " + id;
            Delete(queryString);
        }


        private void Delete(string queryString)
        {
            OleDbConnection connection = new OleDbConnection(
                        connectionString);
            connection.Open();
            OleDbCommand delcmd = new OleDbCommand();
            delcmd.CommandText = queryString;
            delcmd.Connection = connection;
            delcmd.ExecuteNonQuery();
            connection.Close();
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

            return;
        }


        public void AddProduct(DBProduct product)
        {
            //Random random = new Random();
            //var bytes = new byte[1];
            //random.NextBytes(bytes);
            OleDbConnection connection = new OleDbConnection(
                       connectionString);
            
            var cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO [Product]"
                + " VALUES (@id_product,@name_product,@category_id,"
                + "@exp_date, @characteristics)";
            cmd.Parameters.AddWithValue("@id_product", product.ID);
            cmd.Parameters.AddWithValue("@name_product", product.Name);
            cmd.Parameters.AddWithValue("@category_id", product.IDCategory);
            cmd.Parameters.AddWithValue("@exp_date", product.Expiration_day);
            cmd.Parameters.AddWithValue("@characteristics", product.Characteristics);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

            return;
        }

        public void AddNotPromProductInMarket(int id, decimal price, int amount)
        {
            //Random random = new Random();
            //var bytes = new byte[1];
            //random.NextBytes(bytes);
            OleDbConnection connection = new OleDbConnection(
                       connectionString);

            var cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO [Product_in_market]"
                + " VALUES (@upc,@upc_prom,@amount,"
                + "@price, @isProm, @id)";
            cmd.Parameters.AddWithValue("@upc", id-100);
            cmd.Parameters.AddWithValue("@upc_prom", id+100);
            cmd.Parameters.AddWithValue("@amount", amount);
            cmd.Parameters.AddWithValue("@price", (decimal)(price*78/50));
            cmd.Parameters.AddWithValue("@isProm", false);
            cmd.Parameters.AddWithValue("@id", id);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

            return;
        }

        public void AddPromProductInMarket(int id, decimal origin_price, int amount)
        {
            //Random random = new Random();
            //var bytes = new byte[1];
            //random.NextBytes(bytes);
            //decimal origin_price = 0;
            OleDbConnection connection = new OleDbConnection(
                       connectionString);

            var cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO [Product_in_market]"
                + " VALUES (@upc,@upc_prom,@amount,"
                + "@price, @isProm, @id)";
            cmd.Parameters.AddWithValue("@upc", id + 100);
            cmd.Parameters.AddWithValue("@upc_prom", id + 100);
            cmd.Parameters.AddWithValue("@amount", amount);
            var price = origin_price * 36 /25;
            cmd.Parameters.AddWithValue("@price", (decimal)price);
            cmd.Parameters.AddWithValue("@isProm", true);
            cmd.Parameters.AddWithValue("@id", id);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

            return;
        }
        public int AddCheck(int card_id, int cashier_id)
        {
            Random random = new Random();
            var bytes = new byte[1];
            random.NextBytes(bytes);
            OleDbConnection connection = new OleDbConnection(
                       connectionString);

            var cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO [Check]" +
                " (id_check, date_of_purchase, cashier_id) " +
                "VALUES (@id_check, Date(), @cashier_id)";
            cmd.Parameters.AddWithValue("@id_check", bytes[0]);
            //cmd.Parameters.AddWithValue("@client_id", clientCardId);
            cmd.Parameters.AddWithValue("@cashier_id", cashier_id);           

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

            return bytes[0];
        }

        public void AddClientCard(DBClientCard card)
        {
            //Random random = new Random();
            //var bytes = new byte[1];
            //random.NextBytes(bytes);
            OleDbConnection connection = new OleDbConnection(
                       connectionString);

            var cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO [Client_card]"
                + " VALUES (@card_id,@full_name,@phone,"
                + "@address, @discount)";
            cmd.Parameters.AddWithValue("@card_id", card.ID);
            cmd.Parameters.AddWithValue("@full_name", card.Name);
            cmd.Parameters.AddWithValue("@phone", card.Phone);
            cmd.Parameters.AddWithValue("@address", card.Address);
            cmd.Parameters.AddWithValue("@discount", card.Discount);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

            return;
        }
        public void AddCategory(DBCategory category)
        {
            
            OleDbConnection connection = new OleDbConnection(
                       connectionString);

            var cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO [Category]"
                + " VALUES (@id_category,@name_category)";
            cmd.Parameters.AddWithValue("@id_category", category.ID);
            cmd.Parameters.AddWithValue("@name_category", category.Name);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

            return;
        }

        public void AddSale(int id_check, int id_prod, int amount)
        {

            OleDbConnection connection = new OleDbConnection(
                       connectionString);
            var prod = GetProductsInMarketByUPC(id_prod);
            if (prod != null && id_check != 0)
            {
                decimal price = ((DBProductInMarket)prod[0]).Price;
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO [Sale]"
                    + " VALUES (@id_check,@id_prod,@amount,@price)";
                cmd.Parameters.AddWithValue("@id_check", id_check);
                cmd.Parameters.AddWithValue("@id_prod", id_prod);
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.Parameters.AddWithValue("@price", price);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();

                string updateQueryString = "UPDATE Product_in_market " +
                " SET amount_of_product = amount_of_product - " + amount +
                " WHERE UPC_ordinary = " + id_prod;
               
                connection.Open();
                OleDbCommand updatecmd = new OleDbCommand();
                updatecmd.CommandText = updateQueryString;
                updatecmd.Connection = connection;
                updatecmd.ExecuteNonQuery();
                connection.Close();
            }
            

            return;
        }

        public void UpdateProduct(DBProduct product)
        {
            OleDbConnection connection = new OleDbConnection(
                       connectionString);

            var cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE Product " +
                "Set name_product = @name_product," +
                "category_id = @category_id, expiration_date = @exp_date," +
                "Characteristics = @characteristics " +
                "WHERE id_product = @id_product; ";
            
            cmd.Parameters.AddWithValue("@name_product", product.Name);
            cmd.Parameters.AddWithValue("@category_id", product.IDCategory);
            cmd.Parameters.AddWithValue("@exp_date", product.Expiration_day);
            cmd.Parameters.AddWithValue("@characteristics", product.Characteristics);
            cmd.Parameters.AddWithValue("@id_product", product.ID);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void UpdateProductInMarket(int upc, decimal price, int amount)
        {
            OleDbConnection connection = new OleDbConnection(
                       connectionString);

            var cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE Product_in_market " +
                "Set price = @price," +
                "amount_of_product = @amount_of_product " +
                "WHERE UPC_ordinary = @UPC_ordinary; ";

            
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@amount_of_product", amount);
            cmd.Parameters.AddWithValue("@UPC_ordinary", upc);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void UpdateClientCard(DBClientCard card)
        {
            OleDbConnection connection = new OleDbConnection(
                       connectionString);

            var cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE Client_card " +
                "Set full_name_owner = @full_name," +
                "phone_number_owner = @phone_number_owner, address_owner = @address_owner," +
                "discount_percents = @discount_percents " +
                "WHERE card_id = @card_id; ";
           
           
            cmd.Parameters.AddWithValue("@full_name", card.Name);
            cmd.Parameters.AddWithValue("@phone_number_owner", card.Phone);
            cmd.Parameters.AddWithValue("@address_owner", card.Address);
            cmd.Parameters.AddWithValue("@discount_percents", card.Discount);
            cmd.Parameters.AddWithValue("@card_id", card.ID);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void UpdateCategory(DBCategory category)
        {
            OleDbConnection connection = new OleDbConnection(
                       connectionString);

            var cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE Category " +
                "Set name_category = @name_category " +
                "WHERE id_category = @id_category; ";

            cmd.Parameters.AddWithValue("@name_product", category.Name);
            cmd.Parameters.AddWithValue("@id_category", category.ID);
            

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void UpdateWorker(DBWorker worker)
        {
            OleDbConnection connection = new OleDbConnection(
                       connectionString);
           // string date1 = worker.Date_start.Date.ToString("d").Replace(".", "/");
          //  string date2 = worker.Birthday.Date.ToString("d").Replace(".", "/");
            var cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE Worker " +
                "Set full_name = @full_name, " +
                //"position = @position," +
                " salary = @salary, " +
                "date_start = @date_start," +
                " birthday = @birthday, " +
                "phone_number = @phone_number," +
                " address = @address," +
                " id_manager = @id_manager " +
                " WHERE id_worker = @id_worker;";

            cmd.Parameters.AddWithValue("@full_name", worker.Name);
           // cmd.Parameters.AddWithValue("@position", worker.Position);
            cmd.Parameters.AddWithValue("@salary", worker.Salary);
            cmd.Parameters.AddWithValue("@date_start", worker.Date_start);
            cmd.Parameters.AddWithValue("@birthday", worker.Birthday);            
            cmd.Parameters.AddWithValue("@phone_number", worker.Phone);
            cmd.Parameters.AddWithValue("@address", worker.Address);
            cmd.Parameters.AddWithValue("@id_manager", worker.IDManager);
            cmd.Parameters.AddWithValue("@id_worker", worker.ID);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void UpdateCheck(DBCheckInfo check, int cashier)
        {
            OleDbConnection connection = new OleDbConnection(
                       connectionString);
            // string date1 = worker.Date_start.Date.ToString("d").Replace(".", "/");
            //  string date2 = worker.Birthday.Date.ToString("d").Replace(".", "/");
            var cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE Check Set total_sum = @total_sum,client_card_id = @client_card_id " +
                " WHERE id_check = @id_check";

           // cmd.Parameters.AddWithValue("@date_of_purchase", check.PurchaseDate);           
            cmd.Parameters.AddWithValue("@total_sum", check.Total_sum);
            //cmd.Parameters.AddWithValue("@vat", Math.Round(check.VAT));
            cmd.Parameters.AddWithValue("@client_card_id", check.IDCard);
            cmd.Parameters.AddWithValue("@cashier_id", cashier);
            cmd.Parameters.AddWithValue("@id_check", check.ID);
           
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public decimal SumOfCheck(int id)
        {
            decimal res = 0;
            string queryString = "SELECT sum(price * amount)" +
                " FROM Sale" +
                " WHERE check_id = " + id;                

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
                    try
                    {
                        res = Convert.ToInt32(reader[0]);
                    }
                    catch(Exception e)
                    {
                        res = 0;
                    }
                    
                }
                reader.Close();

            }
            return res;
        }

        
    }

    
}

