using KT_1.DataAccessLayer;
using KT_1.Helpers;
using KT_1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT_1.ViewModel
{
    public class RegistrationViewModel : BaseViewModel
    {
        public string Name
        {
            get { return m_Name; }
            set
            {
                m_Name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Login
        {
            get { return m_Login; }
            set
            {
                m_Login = value;
                OnPropertyChanged("Login");
            }
        }

        public string Password { 
            get { return m_Password;}
            set 
            {
                m_Password = value;
                OnPropertyChanged("Password");
            }
        }

        public string PasswordConfirmation
        {  
            get { return m_PasswordConfirmation;}
            set 
            {
                m_PasswordConfirmation = value;
                OnPropertyChanged("PasswordConfirmation");
            }
        }

        public RelayCommand CreateAccountCommand
        {
            get { return m_CreateAccountCommand; }
            set { m_CreateAccountCommand = value; }
        }

        public string LoginError {
            get { return m_LoginError; }
            private set
            {
                m_LoginError = value;
                OnPropertyChanged("LoginError");
            }
        }
        public string PasswordError 
        { 
            get { return m_PasswordError; }
            private set
            {
                m_PasswordError = value;
                OnPropertyChanged("PasswordError");
            }
        }

        public bool? DialogResult { get; private set; }

        public User User { get; private set; }


        public RegistrationViewModel(DialogView<RegistrationViewModel> view, UserRepository userRepository)
        {
            m_CreateAccountCommand = new RelayCommand(CanCreateUser, CreateUser);

            m_View = view;
            m_UserRepository = userRepository;

            DialogResult = m_View.ShowDialog(this);
        }

        public void CreateUser(object parameter)
        {
            if (m_UserRepository.HasUserWithLogin(Login))
            {
                LoginError = "Такой логин уже существует";
                return;
            }
            if (Password != PasswordConfirmation)
            {
                PasswordError = "Пароли не совпадают";
                return;
            }

            this.User = new User(Login, Password, Name, "Customer");
            m_View.CloseDialog(true);
        }

        public bool CanCreateUser(object parameter)
        {
            return !String.IsNullOrEmpty(Login) && !String.IsNullOrEmpty(Password) && !String.IsNullOrEmpty(PasswordConfirmation)
                && Password == PasswordConfirmation;
        }

        private string m_Name;
        private string m_Login;
        private string m_Password;
        private string m_PasswordConfirmation;

        private string m_LoginError;
        private string m_PasswordError;

        private DialogView<RegistrationViewModel> m_View;
        private UserRepository m_UserRepository;

        private RelayCommand m_CreateAccountCommand;
    }
}
