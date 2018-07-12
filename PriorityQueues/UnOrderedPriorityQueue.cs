using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueues
{
    /// <summary>
    /// Binary Heap
    /// 1. Keys in Nodes
    /// 2. Parent keys no smaller that children's keys
    /// 3. Array starts from index 1.
    /// 4. Largest key at Array[1].
    /// 5. Parent of node K is K/2
    /// 6. Children of node K are 2k and 2K+1
    /// </summary>
    class UnOrderedPriorityQueue<T> where T:IComparable<T>
    {
        T[] Items = null;
        int n = 0;

        public int N { get => n; set => n = value; }

        public UnOrderedPriorityQueue(int capacity)
        {
            Items = new T[capacity];
        }

        public void Insert(T item)
        {
            ////Normal implementation;
            //Items[N++] = item;

            //BH implementation
            Items[N++] = item;
            Swim(N - 1);
        }

        public T DeleteMax()
        {
            ////Normal Implementation
            //int MaxIndex = 0;
            //for (int i = 1; i < N; i++)
            //{
            //    if (Less(Items[MaxIndex], Items[i]))
            //    {
            //        MaxIndex = i;
            //    }
            //}

            //Exchange(MaxIndex, N - 1);
            //return Items[--N];

            ////BH Implementation
            T max = Items[0];
            Exchange(0, --N);
            Sink(0);
            Items[N] = default(T);
            return max;
        }

        public T Max()
        {
            //int MaxIndex = 0;
            //for (int i = 1; i < N; i++)
            //{
            //    if (Less(Items[MaxIndex], Items[i]))
            //    {
            //        MaxIndex = i;
            //    }
            //}

            return Items[0];
        }

        public bool IsEmpty()
        {
            return N == 0;
        }

        /// <summary>
        /// Children's key is larger than parent's key
        ///   - Exchange key in child with key in parent
        ///   - Repeat uptil heap order restored
        /// </summary>
        /// <param name="k"></param>
        private void Swim(int k)
        {
            while (k > 0 && Less(Items[k / 2], Items[k]))
            {
                Exchange(k, k / 2);
                k = k / 2;
            }
        }

        private bool Less(int i, int j)
        {
            return Items[i].CompareTo(Items[j]) < 0;
        }

        /// <summary>
        /// Parent's key become smaller than one or both children's key
        ///   - Exchange key in parent with key in larger child
        ///   - Repeat uptil heap order is restored
        /// </summary>
        /// <param name="k"></param>
        private void Sink(int k)
        {
            while (2 * k < N)
            {
                int j = 2 * k;

                if (j < N - 1 && Less(j, j + 1))
                    j++;

                if (!Less(k, j))
                    break;

                Exchange(k, j);
                k = j;
            }
        }

        private bool Less(T a, T b)
        {
            return a.CompareTo(b) < 0;
        }

        private void Exchange(int i, int j)
        {
            var swap = Items[i];
            Items[i] = Items[j];
            Items[j] = swap;
        }
    }
}
