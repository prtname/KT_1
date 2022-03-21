using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT_1.Model
{
    public struct Position
    {
        public double m_X;
        public double m_Y;

        public Position(double x, double y)
        {
            m_X = x;
            m_Y = y;
        }
    }

    internal class ProductAccessory
    {
        public Product Product { get; set; }
        public Accessory Accessory { get; set; }
        public Position Position { get; set; }

        public double Rotation { get; set; }


        public ProductAccessory(Accessory accessory, Product product, Position position, double rotation)
        {
            Product = product;
            Accessory = accessory;
            Position = position;
            Rotation = rotation;
        }
    }
}
