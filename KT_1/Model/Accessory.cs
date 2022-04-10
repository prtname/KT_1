using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT_1.Model
{
    public class Accessory
    {
        public Accessory()
        {
        }

        public Accessory(string articul, double weight ,string name, string type,
            double width, double height, Decimal price)
        {
            Articul = articul;
            Name = name;
            Type = type;
            Width = width;
            Height = height;
            Price = price;
            Weight = weight;
        }


        public string Articul { get; set; }

        public string Name {get; set; }
        public string Type {get; set; }

        public double Width {get; set; }
        public double Height {get; set; }
        public double Weight { get; set; }


        public Decimal Price {get; set; }
    }
}
