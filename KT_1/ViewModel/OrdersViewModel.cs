using KT_1.DataAccessLayer;
using KT_1.Helpers;
using KT_1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT_1.ViewModel
{
    public class OrdersViewModel : BaseViewModel
    {
        public ObservableCollection<Order> Orders => m_Orders;

        public OrdersViewModel(OrderRepository orderRepository, User userOrders)
        {
            m_OrderRepository = orderRepository;
            m_UserOrders = userOrders;

            m_Orders = new ObservableCollection<Order>(m_OrderRepository.GetOrdersForUser(m_UserOrders));
        }

        public OrdersViewModel(OrderRepository orderRepository)
        {
            m_OrderRepository = orderRepository;
            m_Orders = new ObservableCollection<Order>(m_OrderRepository.GetAllOrders());
        }

        private OrderRepository m_OrderRepository;
        private ObservableCollection<Order> m_Orders;

        private User m_UserOrders;

    }
}
