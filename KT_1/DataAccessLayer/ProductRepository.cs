using KT_1.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT_1.DataAccessLayer
{
    internal class ProductRepository
    {
        public IEnumerable<Product> GetAllProducts()
        {
            return new List<Product>(m_Products);
        }

        public void AddProduct(Product product)
        {
            m_Products.Add(product);
        }

        public void AddRangeProducts(IEnumerable<Product> products)
        {
            m_Products.AddRange(products);
        }


        private List<Product> m_Products = new List<Product>();
    }
}
