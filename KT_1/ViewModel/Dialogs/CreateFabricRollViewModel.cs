using KT_1.Helpers;
using KT_1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT_1.ViewModel.Dialogs
{
    public class CreateFabricRollViewModel : BaseViewModel
    {
        public string Articul
        {
            get { return m_Articul; }
            set
            {
                m_Articul = value;
                OnPropertyChanged("Articul");
            }
        }
        public double Length
        {
            get { return m_Length; }
            set
            {
                m_Length = value;
                OnPropertyChanged("Length");
            }
        }
        public IEnumerable<Fabric> Fabrics => m_Fabrics;


        public RelayCommand AddCommand { get; set; }


        public CreateFabricRollViewModel()
        {

        }


        private string m_Articul;
        private double m_Length;
        private IEnumerable<Fabric> m_Fabrics;
    }
}
