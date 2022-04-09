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
    public class ProductAccountingViewModel : BaseViewModel
    {
        public ObservableCollection<Product> Products
        {
            get { return m_Products; }
        }

        public ProductAccountingViewModel(ProductRepository productRepository)
        {
            m_ProductRepository = productRepository;
            m_Products = new ObservableCollection<Product>(m_ProductRepository.GetAllProducts());
        }

        private ObservableCollection<Product> m_Products;
        private ProductRepository m_ProductRepository;
    }
}
