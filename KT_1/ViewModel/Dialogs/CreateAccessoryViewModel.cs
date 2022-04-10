using KT_1.Helpers;
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


        public CreateAccessoryViewModel()
        {

        }


        public string m_Articul;
        public string m_Name;
        public string m_Type;
        public double m_Width;
        public double m_Height;
        public string m_Texture;
        public double m_Price;
    }
}
