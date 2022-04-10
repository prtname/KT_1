using KT_1.DataAccessLayer;
using KT_1.Helpers;
using KT_1.Model;
using KT_1.View;
using KT_1.View.Pages;
using KT_1.View.UserControls;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            var items = new Dictionary<string, IEnumerable<MenuItemData>>();
            items.Add("Customer", new List<MenuItemData>()
            {
                new MenuItemData("Ваши заказы", new Uri("/View/Pages/OrdersAccounting.xaml", UriKind.Relative))
            });

            items.Add("Manager", new List<MenuItemData>()
            {
                new MenuItemData("Заказы", new Uri("/View/Pages/OrdersAccounting.xaml", UriKind.RelativeOrAbsolute)),
                new MenuItemData("Изделия", new Uri("/View/Pages/ProductsAccounting.xaml", UriKind.RelativeOrAbsolute)),
            });

            items.Add("Storekeeper", new List<MenuItemData>() 
            {
                new MenuItemData("Ткани", new Uri("/View/Pages/FabricsAccounting.xaml", UriKind.RelativeOrAbsolute)),
                new MenuItemData("Аксессуары", new Uri("/View/Pages/AccessoriesAccounting.xaml", UriKind.RelativeOrAbsolute)),
                new MenuItemData("Склад", new Uri("/View/Pages/StorageAccounting.xaml", UriKind.RelativeOrAbsolute)),
            });

            items.Add("Director", new List<MenuItemData>()
            {
                new MenuItemData("Заказы", new Uri("/View/Pages/OrdersAccounting.xaml", UriKind.RelativeOrAbsolute)),
                new MenuItemData("Изделия", new Uri("/View/Pages/ProductsAccounting.xaml", UriKind.RelativeOrAbsolute)),
                new MenuItemData("Склад", new Uri("/View/Pages/StorageAccounting.xaml", UriKind.RelativeOrAbsolute)),
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
            {
                page.DataContext = new FabricAccountingViewModel(new FabricRepository());
            }
            else if (page is ProductsAccounting)
            {
                page.DataContext = new ProductAccountingViewModel(new ProductRepository());
            }    
            else if (page is AccessoriesAccounting)
            {
                //page.DataContext = new AccessoriesAccountingViewModel(new AccessoryRepository(connection));
            }
            else if (page is OrdersAccounting)
            {
                if (m_CurrentUser.Role == "Customer")
                    page.DataContext = new OrdersViewModel(new OrderRepository(), m_CurrentUser);
                else
                    page.DataContext = new OrdersViewModel(new OrderRepository());
            }
            else if (page is StorageAccounting)
            {
                page.DataContext = new StorageAccounting();
            }

        }

        private User m_CurrentUser;
        private IEnumerable<MenuItemData> m_MenuItems;

    }
}
