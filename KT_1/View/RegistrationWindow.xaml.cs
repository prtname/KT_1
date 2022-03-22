using KT_1.DataAccessLayer;
using KT_1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KT_1.View
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window, DialogView<RegistrationViewModel>
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        public bool? ShowDialog(RegistrationViewModel viewModel)
        {
            this.DataContext = viewModel;
            return this.ShowDialog();
        }

        public void CloseDialog(bool dialogResult)
        {
            DialogResult = dialogResult;
        }
    }
}
