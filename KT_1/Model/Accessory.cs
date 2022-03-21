using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT_1.Model
{
    internal class Accessory
    {
        public Accessory()
        {
        }

        public Accessory(int articul, string name, string type,
            double width, double height, string texture,
            double price)
        {
            Articul = articul;
            Name = name;
            Type = type;
            Width = width;
            Height = height;
            Price = price;
            Texture = texture;
        }


        public int Articul { get; set; }

        public string Name {get; set; }
        public string Type {get; set; }

        public double Width {get; set; }
        public double Height {get; set; }

        public string Texture {get; set; }

        public double Price {get; set; }
    }
}
