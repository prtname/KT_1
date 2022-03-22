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

        public bool? DialogResult { get; private set; }

        public User User { get; private set; }


        public AuthorizationViewModel(DialogView<AuthorizationViewModel> view, UserRepository userRepository)
        {
            m_AuthCommand = new RelayCommand(Auth);
            m_View = view;
            m_UserRepository = userRepository;

            DialogResult = m_View.ShowDialog(this);
        }

        private void Auth(object parameter)
        {
            this.User = m_UserRepository.GetUserWithLoginPassword(Login, Password);

            m_View.CloseDialog(true);
        }


        private string m_Login;
        private string m_Password;
        private DialogView<AuthorizationViewModel> m_View;
        private UserRepository m_UserRepository;

        private RelayCommand m_AuthCommand;
    }
}
