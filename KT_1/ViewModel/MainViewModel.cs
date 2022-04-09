using KT_1.Helpers;
using KT_1.Model;
using KT_1.View;
using KT_1.View.UserControls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace KT_1.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        static private IReadOnlyDictionary<string, IEnumerable<MenuItemData>> ms_MenuItems;
        static MainViewModel()
        {
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            var pagesViewDir = Path.Combine(baseDir, "View/Pages/");

            var items = new Dictionary<string, IEnumerable<MenuItemData>>();
            items.Add("Customer", new List<MenuItemData>()
            {
                new MenuItemData("Ваши заказы", new Uri(Path.Combine(pagesViewDir, "CustomerOrders.xaml"), UriKind.RelativeOrAbsolute)),
            });

            items.Add("Manager", new List<MenuItemData>()
            {
                new MenuItemData("Заказы", new Uri(Path.Combine(pagesViewDir, "Orders.xaml"), UriKind.RelativeOrAbsolute)),
                new MenuItemData("Изделия", new Uri(Path.Combine(pagesViewDir, "ProductsAccounting.xaml"), UriKind.RelativeOrAbsolute)),
            });

            items.Add("Storekeeper", new List<MenuItemData>() 
            {
                new MenuItemData("Ткани", new Uri(Path.Combine(pagesViewDir, "FabricsAccounting.xaml"), UriKind.RelativeOrAbsolute)),
                new MenuItemData("Аксессуары", new Uri(Path.Combine(pagesViewDir, "AccessoriesAccounting.xaml"), UriKind.RelativeOrAbsolute)),
                new MenuItemData("Склад", new Uri(Path.Combine(pagesViewDir, "StorageAccounting.xaml"), UriKind.RelativeOrAbsolute)),
            });

            items.Add("Director", new List<MenuItemData>()
            {
                new MenuItemData("Заказы", new Uri(Path.Combine(pagesViewDir, "ProductsAccounting.xaml"), UriKind.RelativeOrAbsolute)),
                new MenuItemData("Изделия", new Uri(Path.Combine(pagesViewDir, "ProductsAccounting.xaml"), UriKind.RelativeOrAbsolute)),
                new MenuItemData("Склад", new Uri(Path.Combine(pagesViewDir, "StorageAccounting.xaml"), UriKind.RelativeOrAbsolute)),
            });

            ms_MenuItems = items;
        }

        private void Logout(object param)
        {

        }

        public IEnumerable<MenuItemData> MenuItems => m_MenuItems;

        public MainViewModel(User currentUser)
        {
            m_CurrentUser = currentUser;

            if (!ms_MenuItems.TryGetValue(currentUser.Role, out m_MenuItems))
            {
                MessageBox.Show("Пользователь не имеет роли!", null, MessageBoxButton.OK, MessageBoxImage.Error);
                Logout(null);
            }

            var items = m_MenuItems.ToList();
            items.Add(new MenuItemData("Выйти", new RelayCommand(Logout)));
            m_MenuItems = items;
        }

        public void Page_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            var page = e.Content as Page;
            if (page == null) return;

            if (page is FabricsAccounting)
                page.DataContext = new FabricAccountingViewModel(new DataAccessLayer.FabricRepository());
            else if (page is ProductsAccounting)
                page.DataContext = new ProductAccountingViewModel();
        }

        private User m_CurrentUser;
        private IEnumerable<MenuItemData> m_MenuItems;

    }
}
