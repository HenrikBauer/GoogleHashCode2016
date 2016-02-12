using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash2016
{
    class ProductsSet
    {
        public int Count;
        public int[] Items;

        public ProductsSet()
        {
            Items = new int[Simulation.ProductsCount];
        }

        public void Add(int id)
        {
            Items[id]++;
            Count++;
        }

        public void Add(int id, int count)
        {
            Items[id] += count;
            Count += count;
        }

        public void Remove(int id)
        {
            Items[id]--;
            Count--;
        }

        public void Remove(int id, int count)
        {
            Items[id] -= count;
            Count -= count;
        }

        public int Weight()
        {
            int result = 0;

            for (int i = 0; i < Simulation.ProductsCount; i++)
            {
                result += Items[i] * Simulation.ProductsWeights[i];
            }
            return result;
        }

        public bool HaveSthSimilar(ProductsSet other)
        {
            for (int i = 0; i < Simulation.ProductsCount; i++)
            {
                if (Items[i] > 0 && other.Items[i] > 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
