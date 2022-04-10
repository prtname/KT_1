using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT_1.Model
{
    public class AccessoryBatch
    {
        public string BatchArticul { get; set; }
        public int AccessoryNumber { get; set; }
        public Accessory Accessory { get; set; }

        public AccessoryBatch()
        {

        }
        public AccessoryBatch(string articul, int number, Accessory accessory)
        {
            BatchArticul = articul;
            AccessoryNumber = number;
            Accessory = accessory;
        }
    }
}
