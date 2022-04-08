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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KT_1.View.UserControls
{
    /// <summary>
    /// Логика взаимодействия для NavigationBar.xaml
    /// </summary>
    public partial class NavigationBar : UserControl
    {
        public static readonly DependencyProperty ItemsDependencyProperty = DependencyProperty.Register(nameof(Items), typeof(IEnumerable<MenuItemData>), typeof(NavigationBar));

        public IEnumerable<MenuItemData> Items
        {
            get => (IEnumerable<MenuItemData>)GetValue(ItemsDependencyProperty);
            set => SetValue(ItemsDependencyProperty, value);
        }
        public NavigationBar()
        {
            InitializeComponent();
        }
    }
}
