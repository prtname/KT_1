using KT_1.Helpers;
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
        public double Width
        {
            get { return m_Width; }
            set
            {
                m_Width = value;
                OnPropertyChanged("Width");
            }
        }
        public double Height
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
        public double Price
        {
            get { return m_Price; }
            set
            {
                m_Price = value;
                OnPropertyChanged("Price");
            }
        }
        public ObservableCollection<string> Composition;

        public RelayCommand AddCommand { get; set; }

        public CreateFabricViewModel()
        {

        }


        private string m_Color;
        private double m_Width;
        private double m_Height;
        private string m_Texture;
        private double m_Price;
    }
}
