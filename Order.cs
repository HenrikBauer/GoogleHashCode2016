using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash2016
{
    class Order : IComparer<Order>, IComparable
    {
        public int ID;
        public ProductsSet Set;

        private IntVector2 _destination;

        public IntVector2 GetDestination()
        {
            return _destination;
        }

        public Order(int id, IntVector2 destination)
        {
            ID = id;
            _destination = destination;
            Set = new ProductsSet();
        }
        
        public int Compare(Order x, Order y)
        {
            return x.Set.Count.CompareTo(y.Set.Count);
        }

        public int CompareTo(object obj)
        {
            Order o = obj as Order;
            if (o == null)
                return 1;
            return Set.Count.CompareTo(o.Set.Count);
        }
    }
}
