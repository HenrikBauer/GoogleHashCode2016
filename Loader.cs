using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash2016
{
    static class Loader
    {
        public static int ReadUint(this Stream fs)
        {
            int result = 0;

            char c = '0';
            do
            {
                result = result * 10 + (int)(c - '0');

                c = (char)fs.ReadByte();

            } while (fs.CanRead && c != '\n' && c != ' ');

            return result;
        }

        public static void Load(string path)
        {
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                // Parameters of the simulation
                int rows = stream.ReadUint();
                int columns = stream.ReadUint();
                int drones = stream.ReadUint();
                int deadline = stream.ReadUint();
                int droneMaxLoad = stream.ReadUint();

                Simulation.Rows = rows;
                Simulation.Columns = columns;
                Simulation.Deadline = deadline;
                Simulation.DroneMaxLoad = droneMaxLoad;

                // Spawn drones
                for (uint i = 0; i < drones; i++)
                {
                    // TODO: creae empty drone at [0;0]
                }

                // Products weights
                int productTypesCount = stream.ReadUint();
                Simulation.ProductsWeights = new int[productTypesCount];
                for (int i = 0; i < productTypesCount; i++)
                {
                    Simulation.ProductsWeights[i] = stream.ReadUint();
                }

                // Warehouses
                int wareHousesCount = stream.ReadUint();
                for (uint i = 0; i < wareHousesCount; i++)
                {
                    int wRow = stream.ReadUint();
                    int wColumn = stream.ReadUint();

                    Warehouse w = new Warehouse((int)wRow, (int)wColumn, (int)productTypesCount);

                    int[] wItemsCount = new int[productTypesCount];
                    for (uint j = 0; j < productTypesCount; j++)
                    {
                        int count = stream.ReadUint();
                        if (count > 0)
                        {
                            // TODO: add to the warehouse product with id=j and amount=count, weight take from productTypesWeights[j]
                        }
                    }

                    Simulation.Warehouses.Add(w);
                }

                // Customers Orders
                int ordersCount = stream.ReadUint();
                for (uint i = 0; i < ordersCount; i++)
                {
                    int deliveryRow = stream.ReadUint();
                    int deliveryColumn = stream.ReadUint();

                    Order order = new Order(new IntVector2(deliveryRow, deliveryColumn), productTypesCount);

                    int orderedProductsCount = stream.ReadUint();
                    for (int j = 0; j < orderedProductsCount; j++)
                    {
                        int productID = stream.ReadUint();
                        order._products[productID]++;
                    }

                    Simulation.Orders.Add(order);
                }
            }
        }
    }
}
