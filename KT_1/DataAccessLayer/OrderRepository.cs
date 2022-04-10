using KT_1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT_1.DataAccessLayer
{
    public class OrderRepository
    {
        public IEnumerable<Order> GetAllOrders()
        {
            return m_Orders;
        }

        public IEnumerable<Order> GetOrdersForUser(User user)
        {
            return m_Orders;
        }

        public void AddOrder(Order order)
        {
            m_Orders.Add(order);
        }

        // что-то еще тут
        public OrderRepository()
        {

        }

        private List<Order> m_Orders = new List<Order>();
    }
}
