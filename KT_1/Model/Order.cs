using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT_1.Model
{
    public class Order
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int NumberOfProducts { get; set; }
        public DateTime Date { get; set; }
        public string ProcessStatus { get; set; }
        public User Customer { get; set; }
        public User Manager { get; set; }
        public double Price { get; set; }


        public Order(int id, Product product, int numberOfProducts, DateTime date, 
            string processStatus, User customer, User manager, double price)
        {
            Id = id;
            Product = product;
            NumberOfProducts = numberOfProducts;
            Date = date;
            ProcessStatus = processStatus;
            Customer = customer;
            Manager = manager;
            Price = price;
        }
    }
}
