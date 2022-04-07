using KT_1.DataAccessLayer;
using KT_1.Model;
using KT_1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT_1.View.Factories
{
    public class RegistrationViewFactory
    {
        public event EventHandler<User> DialogSuccess;
        public RegistrationViewFactory(UserRepository userRepository)
        {
            m_UserRepository = userRepository;
        }


        public void ShowDialog()
        {
            var viewmodel = new RegistrationViewModel(new RegistrationWindow(), m_UserRepository);
            if (viewmodel.DialogResult != null && viewmodel.DialogResult == true)
            {
                DialogSuccess(this, viewmodel.User);
            }
        }


        private UserRepository m_UserRepository;

    }
}
