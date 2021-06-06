using System;
using System.Collections.Generic;
using System.Text;

namespace GUI.Models
{
    public class RegisteredUser
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }
        public string Role { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime Bitrhday { get; set; }
    }
}
