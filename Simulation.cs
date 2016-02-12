using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shell;

namespace Hash2016
{
    static class Simulation
    {
         public static int Rows;
        public static int Columns;
        public static int Deadline;
        public static int DroneMaxLoad;
        public static int ProductsCount;
        public static int[] ProductsWeights;
        public static List<Drone> drones = new List<Drone>(1024);
        public static List<Warehouse> Warehouses = new List<Warehouse>(1024);
        public static List<Order> Orders = new List<Order>(1024);
        public static CommandBuffer Commands = new CommandBuffer();

        public static void Run(string input)
        {
            // Clear previous data
            Clear();

            // Load data
            Loader.Load(input);

            // Pre simulation works do be done:
            Orders.Sort();
            divideDrones();

            // Simulation
            Deadline = 10;
            List<Warehouse> www = new List<Warehouse>(Warehouses.Count);
            for (int i = 0; i < Deadline; i++)
            {
                int dronesInUse = 0;
                while (dronesInUse < drones.Count - 1)
                {
                    Order o = Orders[0];
                    Orders.RemoveAt(0);

                    www.AddRange(Warehouses);
                    while (o.Set.Count > 0)
                    {
                        Warehouse closeW = findCLosestWarehouse(www, o.GetDestination(), o.Set);

                        Drone d = drones[dronesInUse++];

                        int productID;
                        int count;
                        for (int a = 0; a < ProductsCount; a++)
                        {
                            if (closeW.Set.Items[a] > 0 && o.Set.Items[a] > 0)
                            {
                                productID = a;
                                count = Math.Min(closeW.Set.Items[a], o.Set.Items[a]);

                              

                                closeW.Set.Remove(productID, count);
                                o.Set.Remove(productID, count);

                                Commands.Load(d, closeW, productID, count);
                                Commands.Deliver(d, o, productID, count);
                            }
                        }

                        if (dronesInUse == drones.Count)
                            break;
                    }

                    JumpItem:

                    www.Clear();

                }

                if (Orders.Count == 0)
                    break;
            }

            // Write commands
            Commands.Write(input + ".out");
        }

        public static void divideDrones()
        {
            int allProducts= 0;
            foreach (Warehouse wh in Warehouses)
	        {
		          allProducts+= wh.Set.Count;
	        }

            int dronesUsed=0;
            foreach (Warehouse wh in Warehouses)
            {
                wh.numberOfDrones = (wh.Set.Count / allProducts) * drones.Count;
                dronesUsed += wh.numberOfDrones;
            }

            if (drones.Count - dronesUsed > 0)//rozdanie wolnych dronów
            {
               Warehouse w = Warehouses.ElementAt(0);
               w.numberOfDrones += drones.Count - dronesUsed;
            }
        }

        public static Warehouse findCLosestWarehouse(List<Warehouse> ww, IntVector2 v, ProductsSet set)
        {
            int minDst = int.MaxValue;
            Warehouse reslt = null;
            for (int i = 0; i < Warehouses.Count; i++)
            {
                if (ww[i].Set.HaveSthSimilar(set))
                {
                    int dst = (int)Math.Ceiling(ww[i].Pos.Distance(v));
                    if (dst < minDst)
                    {
                        reslt = Warehouses[i];
                        minDst = dst;
                    }
                }
            }
            return reslt;
        }

        public static void Clear()
        {
            Warehouses.Clear();
            Orders.Clear();
            drones.Clear();
            Commands.Clear();
            ProductsWeights = null;
            
            GC.Collect();
        }
    }
}
