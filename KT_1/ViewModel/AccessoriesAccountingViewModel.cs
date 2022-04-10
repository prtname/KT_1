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
    public class AccessoriesAccountingViewModel : BaseViewModel
    {
        public ObservableCollection<Accessory> Accessories => m_Accessories;

        public AccessoriesAccountingViewModel(AccessoryRepository accessoryRepository)
        {
            m_AccessoryRepository = accessoryRepository;
            m_Accessories = new ObservableCollection<Accessory>(m_AccessoryRepository.GetAllAccessories());
        }

        private AccessoryRepository m_AccessoryRepository;
        private ObservableCollection<Accessory> m_Accessories;
    }
}
