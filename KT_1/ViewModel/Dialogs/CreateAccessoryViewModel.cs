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
    public class CreateAccessoryViewModel : BaseViewModel
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
        public string Type
        {
            get { return m_Type; }
            set
            {
                m_Type = value;
                OnPropertyChanged("Type");
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
        public double? Price
        {
            get { return m_Price; }
            set
            {
                m_Price = value;
                OnPropertyChanged("Price");
            }
        }


        public RelayCommand CreateCommand => m_CreateCommand;
        public RelayCommand CloseCommand => m_CloseCommand;

        public CreateAccessoryViewModel(AccessoryRepository accessoryRepository, Accessory accessory,
            DialogView<CreateAccessoryViewModel> view)
            : this(accessoryRepository, view)
        {
            m_Accessory = accessory;

            m_Articul = accessory.Articul;
            m_Name = accessory.Name;
            m_Type = accessory.Type;
            m_Width = accessory.Width;
            m_Height = accessory.Height;
            m_Texture = accessory.Texture;
            m_Price = accessory.Price;
        }

        public CreateAccessoryViewModel(AccessoryRepository accessoryRepository, DialogView<CreateAccessoryViewModel> view)
        {
            m_AccessoryRepository = accessoryRepository;

            m_CreateCommand = new RelayCommand(CanCreate, Create);
            m_CloseCommand = new RelayCommand((param) => m_View.CloseDialog(false));
        }

        private bool CanCreate(object param)
        {
            if (string.IsNullOrWhiteSpace(Articul) || 
                string.IsNullOrWhiteSpace(Name) ||
                string.IsNullOrWhiteSpace(Type) ||
                string.IsNullOrWhiteSpace(Texture) ||
                Width == null ||
                Height == null ||
                Price == null)
            {
                return false;
            }
            return true;
        }
        private void Create(object param)
        {
            var accessory = new Accessory(Articul, Name, Type, (double)Width, (double)Height, Texture, (double)Price);
            if (m_Accessory != null)
            {
                m_AccessoryRepository.Replace(m_Accessory, accessory);
            }
            else
            {
                m_AccessoryRepository.Add(accessory);
            }
        }


        private string m_Articul;
        private string m_Name;
        private string m_Type;
        private double? m_Width;
        private double? m_Height;
        private string m_Texture;
        private double? m_Price;

        private RelayCommand m_CreateCommand;
        private RelayCommand m_CloseCommand;

        private AccessoryRepository m_AccessoryRepository;
        private Accessory m_Accessory;

        private DialogView<CreateAccessoryViewModel> m_View;
    }
}
