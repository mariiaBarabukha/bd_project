using System;


namespace Controller
{
    public class Validity
    {
        public static bool checkValidity(string input)
        {
            char[] badSymbols = {'@', '-', '_', '!', '?', '+', '=', ')',
                '(', '*', '^', '$', '#', '"', '`', '~', '/', '\\', '.', ',', '|', '№', ';', '₴', '%', '&',
            '1', '2', '3', '4', '5', '6', '7', '8', '9', '0'};
            if (input.IndexOfAny(badSymbols, 0) == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool checkValidityEmail(string input)
        {

            if ((input.IndexOf('@', 0) != -1 && input.IndexOf('.', 0) != -1))
            {

                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool checkValidityBirthday(DateTime bd)
        {
            return bd.Year < DateTime.Now.Year - 18 && bd.Year > 1900;
        }      

        public static bool checkRole(string role)
        {
            return role.ToUpper() == "CASHIER" || role.ToUpper() == "MANAGER";
        }

    }
}
