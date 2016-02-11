using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash2016
{
    class Warehouse
    {
        public ProductsSet Set;
        int x, y;
        public int numberOfDrones;
        public int id;
        

        public Warehouse(int Xloc, int Yloc, int numOfProducts, int ide)
        {
            x = Xloc;
            y = Yloc;
            id = ide;
        }

        public void AddProduct(int typeId, int q)
        {
            Set.Items[typeId] = q;
        }
      
        public bool GetProductOfType(int typeId)
        {
            if (Set.Items[typeId] <= 0)
                return false;
            Set.Items[typeId]--;
            return true;
        }
    }
}
