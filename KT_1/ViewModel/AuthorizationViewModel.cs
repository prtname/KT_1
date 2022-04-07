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
using KT_1.View.Factories;

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

        public Visibility WindowVisibility { get; private set; }

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


        public AuthorizationViewModel(UserRepository userRepository, RegistrationViewFactory registrationViewFactory)
        {
            if (userRepository == null) throw new ArgumentNullException(nameof(userRepository));
            if (registrationViewFactory == null) throw new ArgumentNullException(nameof(registrationViewFactory));

            m_AuthCommand = new RelayCommand(CanAuth, Auth);
            m_UserRepository = userRepository;

            m_ShowRegistrationCommand = new RelayCommand(ShowRegistration);
            m_RegistrationViewFactory = registrationViewFactory;
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
        }

        private void ShowRegistration(object parameter)
        {
            m_RegistrationViewFactory.DialogSuccess += OnRegistrationCompleted;
            m_RegistrationViewFactory.ShowDialog();
        }

        private void OnRegistrationCompleted(object sender, User user)
        {
            User = user;
        }

        private string m_Login;
        private string m_Password;
        private UserRepository m_UserRepository;
        private string m_Error;
        private RegistrationViewFactory m_RegistrationViewFactory;

        private RelayCommand m_AuthCommand;
        private RelayCommand m_ShowRegistrationCommand;
    }
}
