using KT_1.Helpers;
using KT_1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT_1.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel(User currentUser)
        {
            m_CurrentUser = currentUser;
        }


        private User m_CurrentUser;

    }
}
