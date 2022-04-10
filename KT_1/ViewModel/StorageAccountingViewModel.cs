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
    public class StorageAccountingViewModel : BaseViewModel
    {
        public ObservableCollection<FabricRoll> FabricRolls => m_FabricRolls;
        public ObservableCollection<AccessoryBatch> AccessoryBatches => m_AccessoryBatches;

        public StorageAccountingViewModel(FabricRepository fabricRepository, AccessoryRepository accessoryRepository)
        {
            m_FabricRepository = fabricRepository;
            m_AccessoryRepository = accessoryRepository;

            m_FabricRolls = new ObservableCollection<FabricRoll>(m_FabricRepository.GetAllRolls());
            m_AccessoryBatches = new ObservableCollection<AccessoryBatch>(m_AccessoryRepository.GetAllBatches());
        }


        private ObservableCollection<FabricRoll> m_FabricRolls;
        private ObservableCollection<AccessoryBatch> m_AccessoryBatches;

        private FabricRepository m_FabricRepository;
        private AccessoryRepository m_AccessoryRepository;
    }
}
