using Controller.DBObjects;
using GUI.ViewModels.MainMenu;
using GUI.ViewModels.MainMenu.Options;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace GUI.Models
{
    class StateManager
    {
        private StateManager() { }

       // private const string V = "Workers";
        public static User Current_user;
        private static string curr_opt;

        public static Action GoToWorkers;
        public static Action GoToProducts;
        public static Action GoToProductsInMarket;
        public static Action GoToCategories;
        public static Action GoToChecks;
        public static Action GoToClients;
        public static Action GoToOthers;
        public static Action LogOut;

        public static string CategoryOfProducts = "All";
        public static string SurnameOfWorker = "";
        public static double PercentDiscount = 0;
        public static string CashierForProductsSum = "All";
        public static DateTime ToDate = DateTime.Now.Date;
        public static DateTime FromDate = DateTime.Now.AddYears(-3).Date;
        public static int VarOfProm = 0;
        public static string ProductsSortBy = "[name_product]";
        public static int UPC = 0;
        public static string CashierForChecks = "All";
        public static string NameForProducts = "All";

        public static bool ToEdit;
        public static DBProduct ProductToEdit;
        public static DBWorker WorkerToEdit;
        public static DBCategory CategoryToEdit;
        public static DBClientCard CardToEdit;
        public static DBSale SaleToEdit;
        public static DBProductInMarket productInMarketToEdit;

        public static int CheckID = 0;
        public static int CheckID2 = 0;
        public static string Current_option
        {
            get => curr_opt;
            set
            {
                if(value != curr_opt)
                {
                    curr_opt = value;
                    switch (curr_opt)
                    {
                        case "Workers":
                            GoToWorkers.Invoke();
                            break;
                        case "Products":
                            GoToProducts.Invoke();
                            break;
                        case "Products_market":
                            GoToProductsInMarket.Invoke();
                            break;
                        case "Checks":
                            GoToChecks.Invoke();
                            break;
                        case "Clients_cards":
                            GoToClients.Invoke();
                            break;
                        case "Other":
                            GoToOthers.Invoke();
                            break;
                        case "Categories":
                            GoToCategories.Invoke();
                            break;

                    }
                }
            }
        }

        

        
    }
}
