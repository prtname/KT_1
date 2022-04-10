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
        public double? Length
        {
            get { return m_Length; }
            set
            {
                m_Length = value;
                OnPropertyChanged("Length");
            }
        }
        public IEnumerable<Fabric> Fabrics => m_Fabrics;

        public Fabric SelectedFabric
        {
            get { return m_SelectedFabric; }
            set
            {
                m_SelectedFabric = value;
                OnPropertyChanged("SelectedFabric");
            }
        }


        public RelayCommand CreateCommand => m_CreateCommand;
        public RelayCommand CloseCommand => m_CloseCommand;

        public CreateFabricRollViewModel(FabricRepository fabricRepository, FabricRoll roll,
            DialogView<CreateFabricRollViewModel> view)
            : this(fabricRepository, view)
        {
            m_Roll = roll;

            Articul = roll.RollArticul;
            Length = roll.Length;
            SelectedFabric = roll.Fabric;
        }

        public CreateFabricRollViewModel(FabricRepository fabricRepository, DialogView<CreateFabricRollViewModel> view)
        {
            m_FabricRepository = fabricRepository;
            m_View = view;

            m_CreateCommand = new RelayCommand(CanCreate, Create);
            m_CloseCommand = new RelayCommand((param) => m_View.CloseDialog(false));

            m_Fabrics = m_FabricRepository.GetAllFabrics();
        }


        private void Create(object param)
        {
            var roll = new FabricRoll(Articul, (double)Length, SelectedFabric);
            if (m_Roll == null)
            {
                m_FabricRepository.Replace(m_Roll, roll);
            }
            else
            {
                m_FabricRepository.Add(roll);
            }
            m_View.CloseDialog(true);
        }

        private bool CanCreate(object param)
        {
            if (string.IsNullOrWhiteSpace(Articul) ||
                Length == null ||
                SelectedFabric == null)
            {
                return false;
            }
            return true;
        }


        private string m_Articul;
        private double? m_Length;
        private FabricRoll m_Roll;
        private Fabric m_SelectedFabric;

        private IEnumerable<Fabric> m_Fabrics;
        private FabricRepository m_FabricRepository;
        private DialogView<CreateFabricRollViewModel> m_View;
        private RelayCommand m_CreateCommand;
        private RelayCommand m_CloseCommand;
    }
}
