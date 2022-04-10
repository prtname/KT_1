using KT_1.DataAccessLayer;
using KT_1.Helpers;
using KT_1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT_1.ViewModel.Dialogs
{
    public class CreateFabricViewModel : BaseViewModel
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
        public string Name
        {
            get { return m_Name; }
            set
            {
                m_Name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Color
        {
            get { return m_Color; }
            set
            {
                m_Color = value;
                OnPropertyChanged("Color");
            }
        }
        public double? Width
        {
            get { return m_Width; }
            set
            {
                m_Width = value;
                OnPropertyChanged("Width");
            }
        }
        public double? Height
        {
            get { return m_Height; }
            set
            {
                m_Height = value;
                OnPropertyChanged("Height");
            }
        }
        public string Texture
        {
            get { return m_Texture; }
            set
            {
                m_Texture = value;
                OnPropertyChanged("Texture");
            }
        }
        public Decimal? Price
        {
            get { return m_Price; }
            set
            {
                m_Price = value;
                OnPropertyChanged("Price");
            }
        }
        public ObservableCollection<string> Composition => m_Composition;

        public RelayCommand CreateCommand { get; set; }
        public RelayCommand CloseCommand { get; set; }

        public CreateFabricViewModel(FabricRepository fabricRepository, Fabric fabric,
            DialogView<CreateFabricViewModel> view)
            : this(fabricRepository, view)
        {
            m_Fabric = fabric;

            Articul = fabric.Articul;
            Name = fabric.Name;
            Color = fabric.Color;
            Width = fabric.Width;
            Height = fabric.Height;
            Texture = fabric.Texture;
            Price = fabric.Price;
            m_Composition = new ObservableCollection<string>(fabric.Composition);
        }

        public CreateFabricViewModel(FabricRepository fabricRepository, DialogView<CreateFabricViewModel> view)
        {
            m_FabricRepository = fabricRepository;
            m_View = view;

            m_CreateCommand = new RelayCommand(CanCreate, Create);
            m_CloseCommand = new RelayCommand((param) => m_View.CloseDialog(false));
        }

        private void Create(object obj)
        {
            var fabric = new Fabric(Articul, Name, (double)Width, (double)Height, (Decimal)Price, Composition);
            if (m_Fabric != null)
            {
                m_FabricRepository.Replace(m_Fabric, fabric);
            }
            else
            {
                m_FabricRepository.Add(fabric);
            }
            m_View.CloseDialog(true);
        }

        private bool CanCreate(object obj)
        {
            if (string.IsNullOrWhiteSpace(Articul) ||
                string.IsNullOrWhiteSpace(Name) ||
                string.IsNullOrWhiteSpace(Color) ||
                string.IsNullOrWhiteSpace(Texture) ||
                Width == null ||
                Height == null ||
                Price == null ||
                Composition.Count == 0)
            {
                return false;
            }
            return true;
        }

        private string m_Color;
        private double? m_Width;
        private double? m_Height;
        private string m_Texture;
        private Decimal? m_Price;
        private string m_Articul;
        private string m_Name;
        private ObservableCollection<string> m_Composition;

        private FabricRepository m_FabricRepository;
        private DialogView<CreateFabricViewModel> m_View;
        private RelayCommand m_CreateCommand;
        private RelayCommand m_CloseCommand;
        private Fabric m_Fabric;
    }
}
