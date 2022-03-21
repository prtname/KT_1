using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT_1.Model
{
    internal class Product
    {
        public int Articul { get; set; }

        public string Name {get; set; }

        public double Width {get; set; }

        public double Height {get; set; }

        public string Texture {get; set; }

        public IEnumerable<Fabric> Fabrics
        {
            get { return m_Fabrics;  }
            set { m_Fabrics = value.ToList(); }
        }

        public IEnumerable<Accessory> Accessories
        {
            get { return m_Accessories; }
            set { m_Accessories = value.ToList(); }
        }

        public IEnumerable<string> Composition
        {
            get { return m_Composition; }
            set { m_Composition = value.ToList(); }
        }

        public string LaundryCare {get; set; }

        public string Description {get; set; }


        public Product()
        {
            m_Composition = new List<string>();
            m_Fabrics = new List<Fabric>();
            m_Accessories = new List<Accessory>();
        }

        public Product(int articul, string name, double width, double height, string texture, 
            IEnumerable<string> composition, string laundryCare, IEnumerable<Fabric> fabrics,
            IEnumerable<Accessory> accessories)
        {
            Articul = articul;
            Name = name;
            Width = width;
            Height = height;
            Texture = texture;
            m_Composition = composition.ToList();
            LaundryCare = laundryCare;
            m_Fabrics = fabrics.ToList();
            m_Accessories = accessories.ToList();
        }

        public void AddComposition(string composition)
        {
            m_Composition.Add(composition);
        }

        public void RemoveComposition(string composition)
        {
            m_Composition.Remove(composition);
        }


        private List<Fabric> m_Fabrics;
        private List<Accessory> m_Accessories;

        private List<string> m_Composition;
    }
}
