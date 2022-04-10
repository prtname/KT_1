using KT_1.DataAccessLayer;
using KT_1.Helpers;
using KT_1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT_1.ViewModel
{
    public class FabricAccountingViewModel : BaseViewModel
    {
        public ObservableCollection<Fabric> Fabrics 
        {
            get { return m_Fabrics; } 
            private set
            {
                m_Fabrics = value;
                OnPropertyChanged("Fabrics");
            }
        }

        public FabricAccountingViewModel(FabricRepository fabricRepository)
        {
            m_FabricRepository = fabricRepository;
            m_Fabrics = new ObservableCollection<Fabric>(m_FabricRepository.GetAllFabrics());
        }

        private void OnFabricsChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    m_FabricRepository.AddRange((IEnumerable<Fabric>)e.NewItems);
                    break;
            }
        }

        private FabricRepository m_FabricRepository;
        private ObservableCollection<Fabric> m_Fabrics;
    }
}
