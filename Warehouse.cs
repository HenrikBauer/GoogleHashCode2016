using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash2016
{
    class Warehouse
    {
        int []products;
        int x, y;
        

        public Warehouse(int Xloc, int Yloc, int numOfProducts)
        {
            x = Xloc;
            y = Yloc;
            products = new int[numOfProducts];
           // zmiana 
        }

        public void AddProduct(int typeId, int q)
        {
            products[typeId].quanity = q;
        }
        public void PrepareToDelivery()
        {
            //products = products.Sort()
        }
        public bool GetProductOfType(int typeId)
        {
            if (products[typeId].quanity <= 0)
                return false;
            products[typeId].quanity--;
            return true;
        }
    }
}
