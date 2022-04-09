using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using KT_1.DataAccessLayer;
using KT_1.Helpers;
using KT_1.Model;
using KT_1.View;

namespace KT_1.ViewModel
{
    public class AuthorizationViewModel : BaseViewModel
    {
        public string Login
        {
            get { return m_Login; }
            set
            {
                m_Login = value;
                OnPropertyChanged("Login");
            }
        }

        public string Password
        {
            get { return m_Password; }
            set
            {
                m_Password = value;
                OnPropertyChanged("Password");
            }
        }

        public Visibility WindowVisibility
        {
            get { return m_WindowVisibility; }
            set
            {
                m_WindowVisibility = value;
                OnPropertyChanged("WindowVisibility");
            }
        }

        public RelayCommand AuthCommand
        {
            get { return m_AuthCommand; }
            set { m_AuthCommand = value; }
        }

        public RelayCommand ShowRegistrationCommand
        {
            get { return m_ShowRegistrationCommand; }
            set { m_ShowRegistrationCommand = value; }
        }

        public User User { get; private set; }

        public string Error
        {
            get { return m_Error; }
            private set
            {
                m_Error = value;
                OnPropertyChanged("Error");
            }
        }


        public AuthorizationViewModel(UserRepository userRepository)
        {
            if (userRepository == null) throw new ArgumentNullException(nameof(userRepository));

            m_AuthCommand = new RelayCommand(CanAuth, Auth);
            m_UserRepository = userRepository;

            m_ShowRegistrationCommand = new RelayCommand(ShowRegistration);
        }

        private bool CanAuth(object parameter)
        {
            return !String.IsNullOrEmpty(Login) && !String.IsNullOrEmpty(Password);
        }

        private void Auth(object parameter)
        {
            if (!m_UserRepository.HasUserWithLoginPassword(Login, Password))
            {
                Error = "Неверный логин или пароль";
                return;
            }

            this.User = m_UserRepository.GetUserWithLoginPassword(Login, Password);

            AuthCompleted();
        }

        private void AuthCompleted()
        {
            var viewModel = new MainViewModel(User);
            var view = new MainWindow(viewModel);

            view.Closed += (sender, e) => App.Current.Shutdown();

            WindowVisibility = Visibility.Hidden;
            view.Show();
        }

        private void ShowRegistration(object parameter)
        {
            var viewModel = new RegistrationViewModel(new RegistrationWindow(), m_UserRepository);
            if (viewModel.DialogResult != null && viewModel.DialogResult == true)
            {
                User = viewModel.User;
                AuthCompleted();
            }
        }

        private string m_Login;
        private string m_Password;
        private UserRepository m_UserRepository;
        private string m_Error;

        private RelayCommand m_AuthCommand;
        private RelayCommand m_ShowRegistrationCommand;

        private Visibility m_WindowVisibility;
    }
}
