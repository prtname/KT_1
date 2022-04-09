using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
            var userRepository = new UserRepository();

            var authViewModel = new AuthorizationViewModel(userRepository);
            var authView = new AuthorizationWindow(authViewModel);
            authView.Show();
        }
    }
}
