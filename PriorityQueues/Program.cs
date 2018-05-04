using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueues
{
    class Program
    {
        static void Main(string[] args)
        {
            TestMinIndexedPriorityQueue();
            Console.Read();
        }

        private static void MaxHeap()
        {
            UnOrderedPriorityQueue upq = new UnOrderedPriorityQueue(10);

            upq.Insert("P");
            upq.Insert("Q");
            upq.Insert("E");
            Console.WriteLine(upq.DeleteMax());
            upq.Insert("X");
            upq.Insert("A");
            upq.Insert("M");
            Console.WriteLine(upq.DeleteMax());
            upq.Insert("P");
            upq.Insert("L");
            upq.Insert("E");
            Console.WriteLine(upq.DeleteMax());
        }

        private static void MinHeap()
        {
            MinBinaryHeap upq = new MinBinaryHeap(10);
            upq.Insert("P");
            upq.Insert("Q");
            upq.Insert("Y");
            Console.WriteLine(upq.DeleteMin()); //E
            upq.Insert("X");
            upq.Insert("T");
            upq.Insert("M");
            Console.WriteLine(upq.DeleteMin()); //A
            upq.Insert("P");
            upq.Insert("L");
            upq.Insert("Z");
            Console.WriteLine(upq.DeleteMin()); //E
        }

        private static void TestMinIndexedPriorityQueue()
        {
            MinIndexedPriorityQueue<double> mipq = new MinIndexedPriorityQueue<double>(10);
            for (int i = 0; i < 10; i++)
                mipq.insert(i, 10 - i);

            Console.WriteLine($"{mipq.minKey()}, { mipq.size()}");
            mipq.deleteKey(8);
            Console.WriteLine($"{mipq.minKey()}, { mipq.size()}");
            mipq.deleteMin();
            Console.WriteLine($"{mipq.minKey()}, { mipq.size()}");
        }
    }
}
