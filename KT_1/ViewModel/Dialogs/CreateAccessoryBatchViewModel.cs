using KT_1.DataAccessLayer;
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
        public IEnumerable<Accessory> Accessories => m_Accessories;
        public Accessory SelectedAccessory
        {
            get { return m_SelectedAccessory; }
            set
            {
                m_SelectedAccessory = value;
                OnPropertyChanged("SelectedAccessory");
            }
        }

        public int? AccessoriesNumber
        {
            get { return m_AccessoriesNumber; }
            set
            {
                m_AccessoriesNumber = value;
                OnPropertyChanged("AccessoriesNumber");
            }
        }

        public string Articul
        {
            get { return m_Articul; }
            set
            {
                m_Articul = value;
                OnPropertyChanged("Articul");
            }
        }

        public RelayCommand AddCommand => m_CreateCommand;
        public RelayCommand CloseCommand => m_CloseCommand;


        public CreateAccessoryBatchViewModel(AccessoryRepository accessoryRepository, AccessoryBatch batch, DialogView<CreateAccessoryBatchViewModel> view)
            : this(accessoryRepository, view)
        {
            m_AccessoryBatch = batch;
            m_AccessoriesNumber = batch.AccessoryNumber;
            m_SelectedAccessory = batch.Accessory;
        }

        public CreateAccessoryBatchViewModel(AccessoryRepository accessoryRepository, DialogView<CreateAccessoryBatchViewModel> view)
        {
            m_AccessoryRepository = accessoryRepository;
            m_Accessories = accessoryRepository.GetAllAccessories();
            m_View = view;

            m_CreateCommand = new RelayCommand(CanCreate, CreateBatch);
            m_CloseCommand = new RelayCommand((param) => m_View.CloseDialog(false));

            m_View.ShowDialog(this);
        }

        private bool CanCreate(object param)
        {
            if (string.IsNullOrWhiteSpace(Articul) || AccessoriesNumber == null) return false;
            return true;
        }
        private void CreateBatch(object param)
        {
            var batch = new AccessoryBatch(Articul, (int)AccessoriesNumber, SelectedAccessory);
            if (m_AccessoryBatch != null)
            {
                m_AccessoryRepository.Replace(m_AccessoryBatch, batch);
            }
            else
            {
                m_AccessoryRepository.Add(batch);
            }

            m_View.CloseDialog(true);
        }


        private AccessoryRepository m_AccessoryRepository;
        private IEnumerable<Accessory> m_Accessories;
        private int? m_AccessoriesNumber;
        private string m_Articul;
        private Accessory m_SelectedAccessory;
        private AccessoryBatch m_AccessoryBatch;

        private DialogView<CreateAccessoryBatchViewModel> m_View;
        private RelayCommand m_CreateCommand;
        private RelayCommand m_CloseCommand;
    }
}
