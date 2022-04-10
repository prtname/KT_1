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
            var f = new Fabric(123, "имя", 200, 100, 300, new List<string>());
            f.AddComposition("Хлопок");
            f.AddComposition("Полиэстер");
            m_Fabrics.Add(f);
        }

        private List<Fabric> m_Fabrics = new List<Fabric>();
        private List<FabricRoll> m_Rolls = new List<FabricRoll>();
    }
}
