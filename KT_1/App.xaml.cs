using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using KT_1.DataAccessLayer;
using KT_1.View;
using KT_1.ViewModel;

namespace KT_1
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            String connectionString = "Data Source=(local);Initial Catalog=KT_1;Integrated Security=True;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            var userRepository = new UserRepository(connection);

            var authViewModel = new AuthorizationViewModel(userRepository);
            var authView = new AuthorizationWindow(authViewModel);
            authView.Show();
        }
    }
}
