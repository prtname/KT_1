using KT_1.DataAccessLayer;
using KT_1.Helpers;
using KT_1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT_1.ViewModel.Dialogs
{
    public class CreateOrderViewModel : BaseViewModel
    {
        public Product SelectedProduct
        {
            get { return m_SelectedProduct; }
            set
            {
                m_SelectedProduct = value;
                CalcPrice();
                OnPropertyChanged("SelectedProduct");
            }
        }
        public IEnumerable<Product> Products => m_Products;
        public int? Number
        {
            get { return m_Number; }
            set
            {
                m_Number = value;
                CalcPrice();
                OnPropertyChanged("Number");
            }
        }
        public IEnumerable<User> Managers => m_Managers;
        public User SelectedManager
        {
            get { return m_SelectedManager; }
            set
            {
                m_SelectedManager = value;
                OnPropertyChanged("SelectedManager");
            }
        }
        public Decimal Price
        {
            get { return m_Price; }
            private set
            {
                m_Price = value;
                OnPropertyChanged("Price");
            }
        }

        public RelayCommand CreateCommand => m_CreateCommand;
        public RelayCommand CloseCommand => m_CloseCommand;

        public CreateOrderViewModel(OrderRepository orderRepository,
                                    ProductRepository productRepository,
                                    UserRepository userRepository,
                                    User currentUser,
                                    Order order,
                                    DialogView<CreateOrderViewModel> view)
            : this(orderRepository, productRepository, userRepository, currentUser, view)
        {
            m_Order = order;

            SelectedProduct = order.Product;
            Number = order.NumberOfProducts;
            SelectedManager = order.Manager;
            Price = order.Price;
        }

        public CreateOrderViewModel(OrderRepository orderRepository,
                                    ProductRepository productRepository,
                                    UserRepository userRepository,
                                    User currentUser,
                                    DialogView<CreateOrderViewModel> view)
        {
            m_OrderRepository = orderRepository;
            m_View = view;
            m_User = currentUser;

            m_Products = productRepository.GetAllProducts();
            m_Managers = userRepository.GetAllUsersWithRole("Manager");

            m_CreateCommand = new RelayCommand(CanCreate, Create);
            m_CloseCommand = new RelayCommand((param) => m_View.CloseDialog(false));
        }

        private void CalcPrice()
        {
            if (SelectedProduct == null || Number == null) return;

            Decimal accessoriesPrice = 0;
            foreach (var accessory in SelectedProduct.Accessories)
            {
                accessoriesPrice += accessory.Accessory.Price;
            }
            Decimal fabricsPrice = 0;
            foreach (var fabric in SelectedProduct.Fabrics)
            {
                fabricsPrice += fabric.Price;
            }

            Price = (accessoriesPrice + fabricsPrice) * (int)Number;
        }

        private void Create(object obj)
        {
            int id = m_OrderRepository.GetNewId();
            var order = new Order(id, SelectedProduct, (int)Number, DateTime.Now, "not ready", m_User, SelectedManager, Price);
            if (m_Order != null)
            {
                m_OrderRepository.Replace(m_Order, order);
            }
            else
            {
                m_OrderRepository.AddOrder(order);
            }
            m_View.CloseDialog(true);
        }

        private bool CanCreate(object obj)
        {
            if (SelectedProduct == null ||
                SelectedManager == null ||
                Number == null) return false;
            return true;
        }

        private Decimal m_Price;
        private int? m_Number;
        public IEnumerable<Product> m_Products;
        public IEnumerable<User> m_Managers;
        private RelayCommand m_CreateCommand;
        private RelayCommand m_CloseCommand;
        private DialogView<CreateOrderViewModel> m_View;
        private User m_User;
        private OrderRepository m_OrderRepository;
        private User m_SelectedManager;
        private Product m_SelectedProduct;
        private Order m_Order;
    }
}
