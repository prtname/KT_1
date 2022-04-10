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
        public IEnumerable<Product> Products { get; set; }
        public int Number
        {
            get { return m_Number; }
            set
            {
                m_Number = value;
                OnPropertyChanged("Number");
            }
        }
        public IEnumerable<User> Managers { get; set; }
        public double Price
        {
            get { return m_Price; }
            private set
            {
                m_Price = value;
                OnPropertyChanged("Price");
            }
        }

        public RelayCommand AddCommand { get; set; }


        public CreateOrderViewModel()
        {

        }


        private double m_Price;
        private int m_Number;
    }
}
