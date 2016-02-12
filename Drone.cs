using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash2016
{

    class Drone
    {
        public ProductsSet Set;
        public int id;


        public Drone(int ide)
        {
            Set = new ProductsSet();
            id = ide;
        }

        public void PickOrder()
        {
        }
    }
}
