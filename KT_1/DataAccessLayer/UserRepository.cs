using KT_1.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT_1.DataAccessLayer
{
    public class UserRepository
    {
        public UserRepository(SqlConnection connection)
        {
            m_Connection = connection;
        }

        public User GetUserWithLoginPassword(string login, string password)
        {
            string queryString = "SELECT * FROM Users WHERE ULogin = @Login and UPassword = @Password;";

            var loginParameter = new SqlParameter("@Login", SqlDbType.NChar);
            loginParameter.Value = login;

            var passwordParameter = new SqlParameter("@Password", SqlDbType.NChar);
            passwordParameter.Value = password;

            var cmd = new SqlCommand(queryString, m_Connection);
            cmd.Parameters.Add(loginParameter);
            cmd.Parameters.Add(passwordParameter);

            var reader = cmd.ExecuteReader();
            reader.Read();
            var user = UserFromSqlDataReader(reader);
            reader.Close();
            return user;
        }

        public bool HasUserWithLoginPassword(string login, string password)
        {
            string queryString = "SELECT * FROM Users WHERE ULogin = @Login and UPassword = @Password;";

            var loginParameter = new SqlParameter("@Login", SqlDbType.NChar);
            loginParameter.Value = login;

            var passwordParameter = new SqlParameter("@Password", SqlDbType.NChar);
            passwordParameter.Value = password;

            var cmd = new SqlCommand(queryString, m_Connection);
            cmd.Parameters.Add(loginParameter);
            cmd.Parameters.Add(passwordParameter);

            var reader = cmd.ExecuteReader();
            bool hasRows = reader.HasRows;
            reader.Close();
            return hasRows;
        }

        public bool HasUserWithLogin(string login)
        {
            string queryString = "SELECT * FROM Users WHERE ULogin = @Login;";

            var loginParameter = new SqlParameter("@Login", SqlDbType.NChar);
            loginParameter.Value = login;

            var cmd = new SqlCommand(queryString, m_Connection);
            cmd.Parameters.Add(loginParameter);

            var reader = cmd.ExecuteReader();
            bool hasRows = reader.HasRows;
            reader.Close();
            return hasRows;
        }

        public void AddUser(User user)
        {
            string queryString = "INSERT INTO Users VALUES (@Login, @Password, @Name, @Role);";

            var loginParameter = new SqlParameter("@Login", SqlDbType.NChar);
            loginParameter.Value = user.Login;

            var passwordParameter = new SqlParameter("@Password", SqlDbType.NChar);
            passwordParameter.Value = user.Password;

            var nameParameter = new SqlParameter("@Name", SqlDbType.NChar);
            nameParameter.Value = user.Name;

            var roleParameter = new SqlParameter("@Role", SqlDbType.NChar);
            roleParameter.Value = user.Role;

            var cmd = new SqlCommand(queryString, m_Connection);
            cmd.Parameters.Add(loginParameter);
            cmd.Parameters.Add(passwordParameter);
            cmd.Parameters.Add(nameParameter);
            cmd.Parameters.Add(roleParameter);

            cmd.ExecuteNonQuery();
        }

        public IEnumerable<User> GetAllUsersWithRole(string role)
        {
            string queryString = "SELECT * FROM Users WHERE URole = @Role;";

            var roleParameter = new SqlParameter("@Role", SqlDbType.NChar);
            roleParameter.Value = role;

            var cmd = new SqlCommand(queryString, m_Connection);
            cmd.Parameters.Add(roleParameter);

            var reader = cmd.ExecuteReader();
            var list = new List<User>();
            while (reader.Read())
            {
                list.Add(UserFromSqlDataReader(reader));
            }

            return list;
        }

        private User UserFromSqlDataReader(SqlDataReader reader)
        {
            return new User((string)reader[0], (string)reader[1], (string)reader[3], (string)reader[2]);
        }

        private SqlConnection m_Connection;
    }
}
