using KT_1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT_1.DataAccessLayer
{
    public class FabricRepository
    {
        public IEnumerable<Fabric> GetAllFabrics()
        {
            return m_Fabrics;
        }
        
        public IEnumerable<FabricRoll> GetAllRolls()
        {
            return m_Rolls;
        }

        public void AddRange(IEnumerable<Fabric> fabrics)
        {
            m_Fabrics.AddRange(fabrics);
        }

        public FabricRepository()
        {
        }

        private List<Fabric> m_Fabrics = new List<Fabric>();
        private List<FabricRoll> m_Rolls = new List<FabricRoll>();

        internal void Replace(FabricRoll m_Roll, FabricRoll roll)
        {
            throw new NotImplementedException();
        }

        internal void Add(FabricRoll roll)
        {
            throw new NotImplementedException();
        }

        internal void Replace(Fabric m_Fabric, Fabric fabric)
        {
            throw new NotImplementedException();
        }

        internal void Add(Fabric fabric)
        {
            throw new NotImplementedException();
        }
    }
}
