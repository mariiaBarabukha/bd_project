using System;
using System.Collections.Generic;
using System.Text;

namespace GUI.Models
{
    class PasswordHandler
    {
        private static int key = 10;

        private static string doConvert(string pw, int p = 1)
        {
            char[] ch = pw.ToCharArray();
            for (int i = 0; i < ch.Length; i++)
            {
                int a = ch[i];
                a += (p * key);
                if (a > 127)
                {
                    a = a % 127;
                }
                ch[i] = (char)a;
            }
            return new string(ch);
        }
        public static string Code(string pw)
        {
            return doConvert(pw);
        }
        public static string Decode(string pw)
        {
            return doConvert(pw, -1);
        }

    }
}
