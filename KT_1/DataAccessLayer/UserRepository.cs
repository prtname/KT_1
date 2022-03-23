using KT_1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT_1.DataAccessLayer
{
    public class UserRepository
    {
        public UserRepository()
        {
            m_Users.Add(new LoginPassword("Lubi4", "123321"), new User("Lubi4", "123321", "Lubi4", "Customer"));
        }

        public User GetUserWithLoginPassword(string login, string password)
        {
            return m_Users[new LoginPassword(login, password)];
        }

        public bool HasUserWithLoginPassword(string login, string password)
        {
            return m_Users.ContainsKey(new LoginPassword(login,password));
        }

        public bool HasUserWithLogin(string login)
        {
            foreach (var user in m_Users)
            {
                if (user.Value.Login == login) return true;
            }
            return false;
        }

        public void CreateUser(User user)
        {
            m_Users.Add(new LoginPassword(user.Login, user.Password), user);
        }

        private struct LoginPassword
        {
            public LoginPassword(string login, string password)
            {
                m_login = login;
                m_password = password;
            }

            public override int GetHashCode()
            {
                return m_login.GetHashCode() ^ m_password.GetHashCode();
            }

            private string m_login;
            private string m_password;
        }

        private Dictionary<LoginPassword, User> m_Users = new Dictionary<LoginPassword, User>() { };
    }
}
