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
        public static int[] ProductsWeights;
        public static List<Warehouse> Warehouses = new List<Warehouse>(1024);
        public static List<Order> Orders = new List<Order>(1024);

        public static void Run(string input)
        {
            // Clear previous data
            Clear();

            // Load data
            Loader.Load(input);
            

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
