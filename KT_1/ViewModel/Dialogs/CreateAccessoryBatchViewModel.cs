using KT_1.Helpers;
using KT_1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT_1.ViewModel.Dialogs
{
    public class CreateAccessoryBatchViewModel : BaseViewModel
    {
        public IEnumerable<Accessory> Accessories { get; }
        public int AccessoriesNumber { get; set; }
        public string Articul { get; set; }

        public RelayCommand Add { get; set; }


        public CreateAccessoryBatchViewModel()
        {

        }


        private IEnumerable<Accessory> m_Accessories;
        private int m_AccessoriesNumber;
        private string m_Articul;
    }
}
