using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash2016
{
    class Order
    {
        public int[] _products;
        private IntVector2 _destination;

        public IntVector2 GetDestination()
        {
            return _destination;
        }

        public Order(IntVector2 destination, int productsMax)
        {
            _destination = destination;
            _products = new int[productsMax];
        }
    }
}
