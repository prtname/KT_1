using KT_1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT_1.DataAccessLayer
{
    public class AccessoryRepository
    {
        public IEnumerable<Accessory> GetAllAccessories()
        {
            return m_Accessories;
        }

        public IEnumerable<AccessoryBatch> GetAllBatches()
        {
            return m_Batches;
        }

        public IEnumerable<Accessory> GetAccessoryForProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public AccessoryRepository()
        {
            m_Accessories.Add(new Accessory(1337, "Да", "тип", 12, 15, "текст", 300));
        }

        private List<Accessory> m_Accessories = new List<Accessory>();
        private List<AccessoryBatch> m_Batches = new List<AccessoryBatch>();

        public void Replace(AccessoryBatch m_AccessoryBatch, AccessoryBatch batch)
        {
            throw new NotImplementedException();
        }

        public void Add(AccessoryBatch batch)
        {
            throw new NotImplementedException();
        }

        public void Replace(Accessory m_Accessory, Accessory accessory)
        {
            throw new NotImplementedException();
        }

        public void Add(Accessory accessory)
        {
            throw new NotImplementedException();
        }
    }
}
