using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT_1.Model
{
    public class User
    {
        public string Login { get; private set; }
        public string Password { get; private set; }
        public string Name { get; private set; }
        public string Role { get; private set; }

        
        public User(string login, string password, string name, string role)
        {
            Login = login;
            Password = password;
            Name = name;
            Role = role;
        }
    }
}
