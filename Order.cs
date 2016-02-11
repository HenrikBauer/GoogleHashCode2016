using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash2016
{
    class Order
    {
        private List<Product> _products;
        private IntVector2 _destination;

        public List<Product> GetProducts()
        {
            return _products;
        }

        public IntVector2 GetDestination()
        {
            return _destination;
        }
    }
}
