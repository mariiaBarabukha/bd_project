using System;
using System.Data.OleDb;
using System.IO;

namespace AppDB
{
    class Program
    {
        static void Main(string[] args)
        {

            //string queryString = "SELECT [card_id], [full_name_owner] FROM Client_card WHERE card_id NOT IN (SELECT client_card_id FROM Check INNER JOIN Sale ON Check.id_check = Sale.check_id WHERE id_product IN (SELECT id_product FROM Product INNER JOIN Category ON Product.category_id = Category.id_category WHERE name_category = 'Побутова хімія'))";

            string queryString = "SELECT [card_id], [full_name_owner]"+
                " FROM [Client_card] WHERE [card_id] NOT IN "+
                "(SELECT [client_card_id] "+
                "FROM [Check] INNER JOIN [Sale] ON [Check].[id_check] = [Sale].[check_id]"+
                " WHERE [id_product] IN (SELECT [id_product]"+
                " FROM [Product] INNER JOIN [Category] ON [Product].[category_id] = [Category].[id_category]"+
                " WHERE [name_category] = 'Побутова хімія'))";

            string connectionString = @"Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\supermarket.accdb;Persist Security Info=False;";
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
                    Console.WriteLine(reader[0]+" "+reader[1]);
                }
                reader.Close();
                
            }
        }
    }
}
