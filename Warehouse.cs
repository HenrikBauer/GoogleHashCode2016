using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash2016
{
    class Warehouse
    {
        public int[] Products;
        int x, y;
        int size, n;

        public Warehouse(int Xloc, int Yloc, int numOfProducts)
        {
            x = Xloc;
            y = Yloc;
            Products = new int[numOfProducts];
            size = numOfProducts;
            n = 0;
        }

        public void PrepareToDelivery()
        {
            //products = products.Sort()
        }

        public int GetProduct(int typeID)
        {
            int temp = Products[size - (n + 1)];
            n--;
            return temp;
        }
    }
}
