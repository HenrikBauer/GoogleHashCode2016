using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash2016
{
    class Warehouse
    {
        Product []products;
        int x, y;
        int size, n;

        public Warehouse(int Xloc, int Yloc, int numOfProducts)
        {
            x = Xloc;
            y = Yloc;
            products = new Product[numOfProducts];
            size = numOfProducts;
            n = 0;
        }

        public void AddProduct(Product p)
        {
            products[n++] = p;
        }
        public void PrepareToDelivery()
        {
            //products = products.Sort()
        }
        public Product GetProduct()
        {
            
            Product temp = products[size-(n+1)];
            n--;
            return temp;

        }
    }
}
