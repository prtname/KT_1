using KT_1.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT_1.DataAccessLayer
{
    public class AccessoryRepository
    {
        public IEnumerable<Accessory> GetAllAccessories()
        {
            string queryString = "SELECT * FROM Accessory";
            var cmd = new SqlCommand(queryString, m_Connection);

            var reader = cmd.ExecuteReader();
            var list = new List<Accessory>();
            while (reader.Read())
            {
                list.Add(ReaderToAccessory(reader));
            }
            return list;
        }

        public IEnumerable<AccessoryBatch> GetAllBatches()
        {
            string queryString = "SELECT * FROM AccessoryStorage";
            var cmd = new SqlCommand(queryString, m_Connection);

            var reader = cmd.ExecuteReader();
            var list = new List<AccessoryBatch>();
            while (reader.Read())
            {
                var accessory = new AccessoryBatch
                {
                    BatchArticul = reader[0] as string,
                    Accessory = GetAccessoryWithArticul(reader[1] as string),
                    AccessoryNumber = (int)reader[2]
                };
                list.Add(accessory);
            }
            return list;
        }

        private Accessory ReaderToAccessory(SqlDataReader reader)
        {
            var accessory = new Accessory();
            accessory.Articul = reader[0] as string;
            accessory.Name = reader[1] as string;
            accessory.Type = reader[2] as string;
            accessory.Width = (double)reader[3];
            accessory.Height = (double)reader[4];
            accessory.Weight = (double)reader[5];
            accessory.Price = (Decimal)reader[6];
            return accessory;
        }

        public Accessory GetAccessoryWithArticul(string articul)
        {
            string queryString = "SELECT * FROM Accessory WHERE Articul = N'" + articul + "';";
            var cmd = new SqlCommand(queryString, m_Connection);

            var reader = cmd.ExecuteReader();

            reader.Read();
            return ReaderToAccessory(reader);
        }

        public IEnumerable<Accessory> GetAccessoryForProduct(Product product)
        {
            string queryString = "SELECT * FROM Accessory" +
                                "JOIN ProductAccessory ON Accessory.Articul = ProductAccessory.AccessoryArticul" +
                                "JOIN Product ON ProductAccessory.ProductArticul = Product.Articul " +
                                "WHERE Product.Articul = @Articul;";
            var articul = new SqlParameter("@Articul", SqlDbType.NChar);
            articul.Value = product.Articul;

            var cmd = new SqlCommand(queryString, m_Connection);
            cmd.Parameters.Add(articul);

            var reader = cmd.ExecuteReader();

            var list = new List<Accessory>();
            while (reader.Read())
            {
                list.Add(ReaderToAccessory(reader));
            }
            return list;
        }

        public AccessoryRepository(SqlConnection connection)
        {
            m_Connection = connection;
        }

        private SqlConnection m_Connection;

        public void Replace(AccessoryBatch m_AccessoryBatch, AccessoryBatch batch)
        {
            throw new NotImplementedException();
        }

        public void Add(AccessoryBatch batch)
        {
            throw new NotImplementedException();
        }

        public void Replace(Accessory oldAccessory, Accessory newAccessory)
        {
        }

        public void Add(Accessory accessory)
        {
            throw new NotImplementedException();
        }


    }
}
