using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KT_1.DataAccessLayer;
using KT_1.Helpers;
using KT_1.Model;

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

        public bool? DialogResult { get; private set; }

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


        public AuthorizationViewModel(DialogView<AuthorizationViewModel> view, DialogView<RegistrationViewModel> registrationView, UserRepository userRepository)
        {
            m_AuthCommand = new RelayCommand(CanAuth, Auth);
            m_View = view;
            m_UserRepository = userRepository;

            m_ShowRegistrationCommand = new RelayCommand(ShowRegistration);
            m_RegistrationView = registrationView;

            DialogResult = m_View.ShowDialog(this);
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
            m_View.CloseDialog(true);
        }

        private void ShowRegistration(object parameter)
        {
            RegistrationViewModel registration = new RegistrationViewModel(m_RegistrationView, m_UserRepository);
            if (registration.DialogResult != true) return;

            User = registration.User;
            m_View.CloseDialog(true);
        }



        private string m_Login;
        private string m_Password;
        private DialogView<AuthorizationViewModel> m_View;
        private UserRepository m_UserRepository;
        private string m_Error;

        private RelayCommand m_AuthCommand;
        private RelayCommand m_ShowRegistrationCommand;
        private DialogView<RegistrationViewModel> m_RegistrationView;
    }
}
