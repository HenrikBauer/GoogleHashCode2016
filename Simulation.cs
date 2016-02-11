using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static List<Drone> drones;
        public static List<Warehouse> Warehouses = new List<Warehouse>(1024);
        public static List<Order> Orders = new List<Order>(1024);

        public static void Run(string input)
        {
            // Clear previous data
            Clear();

            // Load data
            Loader.Load(input);
            
            // Pre simulation works do be done:
            // - sort orders
            // - assign drones to the local warehouses
            Orders.Sort();

            // Simulation
        }

        public void divideDrones()
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
        
        public static void Clear()
        {
            Warehouses.Clear();
            Orders.Clear();
            ProductsWeights = null;

            GC.Collect();
        }
    }
}
