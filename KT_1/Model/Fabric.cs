using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT_1.Model
{
    public class Fabric
    {
        public string Articul { get; set; }

        public string Name { get; set; }

        public string Color { get; set; }

        public string Texture { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public Decimal Price { get; set; }

        public IEnumerable<string> Composition
        {
            get { return m_Composition; }
            set { m_Composition = value.ToList(); }
        }

        public Fabric()
        {
            m_Composition = new List<string>();
        }

        public Fabric(string articul, string name, double width, double height, 
            Decimal price, IEnumerable<string> composition)
        {
            Articul = articul;
            Name = name;
            Height = height;
            Width = width;
            Price = price;
            m_Composition = composition.ToList();
        }

        public void AddComposition(string composition)
        {
            m_Composition.Add(composition);
        }

        public void DeleteComposition(string composition)
        {
            m_Composition.Remove(composition);
        }


        private List<string> m_Composition;
    }
}
