using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT_1.Model
{
    public class FabricRoll
    {
        public string RollArticul { get; set; }
        public double Length { get; set; }
        public Fabric Fabric { get; set; }


        public FabricRoll(string articul, double length, Fabric fabric)
        {
            RollArticul = articul;
            Length = length;
            Fabric = fabric;
        }
    }
}
