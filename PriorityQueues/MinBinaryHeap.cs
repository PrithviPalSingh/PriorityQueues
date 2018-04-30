using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueues
{
    class MinBinaryHeap
    {
        private string[] Items;

        private int N;

        public MinBinaryHeap(int n)
        {
            Items = new string[n];
        }

        public void Insert(string a)
        {
            Items[++N] = a;
            Swim(N);
        }

        private void Swim(int k)
        {
            while (k > 1 && greater(k / 2, k))
            {
                Exchange(k, k / 2);
                k = k / 2;
            }
        }

        private void Sink(int k)
        {
            while (2 * k <= N)
            {
                int j = 2 * k;
                if (j < N && greater(j, j + 1))
                {
                    j++;
                }

                if (greater(j, k))
                { break; }

                Exchange(k, j);
                k = j;
            }
        }

        public string DeleteMin()
        {
            string min = Items[1];
            Exchange(1, N--);
            Sink(1);
            Items[N + 1] = null;
            return min;
        }

        private bool greater(int i, int j)
        {
            return Items[i].CompareTo(Items[j]) > 0;
        }

        private void Exchange(int i, int j)
        {
            var swap = Items[i];
            Items[i] = Items[j];
            Items[j] = swap;
        }
    }
}
