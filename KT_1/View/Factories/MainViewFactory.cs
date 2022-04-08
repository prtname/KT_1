using KT_1.Model;
using KT_1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT_1.View.Factories
{
    public class MainViewFactory
    {
        public event EventHandler Closed;

        public MainViewFactory(User currentUser)
        {
            m_CurrentUser = currentUser;
        }

        public void Show()
        {
            var viewModel = new MainViewModel(m_CurrentUser);
            var view = new MainWindow(viewModel);

            view.Closed += Closed;

            view.Show();
        }


        private User m_CurrentUser;
    }
}
