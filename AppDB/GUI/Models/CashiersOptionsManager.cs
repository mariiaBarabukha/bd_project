using System;
using System.Collections.Generic;
using System.Text;

namespace GUI.Models
{
    class CashiersOptionsManager
    {
        public static Action GoToChecks;
        public static Action GoToClients;
        public static Action GoToProducts;
        public static Action GoToProfile;
        private static string curr_opt;

        public static string ClientSurname = "";
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
                        
                        case "Products":
                            GoToProducts.Invoke();
                            break;
                        
                        case "Checks":
                            GoToChecks.Invoke();
                            break;
                        case "Clients_cards":
                            GoToClients.Invoke();
                            break;
                        case "MyProfile":
                            GoToProfile.Invoke();
                            break;
                        

                    }
                }
            }
        }

        
    }
}
