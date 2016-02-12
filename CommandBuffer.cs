using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash2016
{
    class CommandBuffer
    {
        private List<string> Commands;

        public CommandBuffer()
        {
            Commands = new List<string>(16 * 1024);
        }

        public void Load(Drone drone, Warehouse warehouse, int productID, int count)
        {
            Commands.Add(string.Format("{0} L {1} {2} {3}", drone.id, warehouse.id, productID, count));
        }

        public void Unload(Drone drone, Warehouse warehouse, int productID, int count)
        {
            Commands.Add(string.Format("{0} U {1} {2} {3}", drone.id, warehouse.id, productID, count));
        }

        public void Deliver(Drone drone, Order order, int productID, int count)
        {
            Commands.Add(string.Format("{0} D {1} {2} {3}", drone.id, order.ID, productID, count));
        }

        public void Wait(Drone drone, int turns)
        {
            Commands.Add(string.Format("{0} W {1}", drone.id, turns));
        }

        public void Write(string output)
        {
            using (var stream = new StreamWriter(output))
            {
                stream.WriteLine(Commands.Count);

                for (int i = 0; i < Commands.Count; i++)
                {
                    stream.WriteLine(Commands[i]);
                }
            }
        }

        public void Clear()
        {
            Commands.Clear();
        }
    }
}
