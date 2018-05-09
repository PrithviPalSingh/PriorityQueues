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
            //TestMinIndexedPriorityQueue();
            //TestMaxIndexedPriorityQueue();
            TestMedianIndexedPriorityQueue();
            //MinHeap();
            Console.Read();
        }

        private static void MaxHeap()
        {
            UnOrderedPriorityQueue<string> upq = new UnOrderedPriorityQueue<string>(10);

            upq.Insert("P");
            upq.Insert("Q");
            upq.Insert("E");
            Console.WriteLine(upq.DeleteMax()); //Q
            upq.Insert("X");
            upq.Insert("A");
            upq.Insert("M");
            Console.WriteLine(upq.DeleteMax());//X
            upq.Insert("P");
            upq.Insert("L");
            upq.Insert("E");
            Console.WriteLine(upq.DeleteMax());//P
        }

        private static void MinHeap()
        {
            MinBinaryHeap<string> upq = new MinBinaryHeap<string>(20);
            upq.Insert("P");
            upq.Insert("Q");
            upq.Insert("Y");
            upq.Insert("E");
            Console.WriteLine(upq.DeleteMin()); //E
            upq.Insert("X");
            upq.Insert("T");
            upq.Insert("M");
            upq.Insert("A");
            Console.WriteLine(upq.DeleteMin()); //A
            upq.Insert("P");
            upq.Insert("L");
            upq.Insert("Z");
            upq.Insert("E");
            Console.WriteLine(upq.DeleteMin()); //E
            Console.WriteLine(upq.Min());//L
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

        private static void TestMaxIndexedPriorityQueue()
        {
            MaxIndexedPriorityQueue<double> mapq = new MaxIndexedPriorityQueue<double>(10);
            for (int i = 0; i < 10; i++)
                mapq.insert(i, 10 - i);

            Console.WriteLine($"{mapq.maxKey()}, { mapq.size()}");
            mapq.deleteKey(8);
            Console.WriteLine($"{mapq.maxKey()}, { mapq.size()}");
            mapq.deleteMax();
            Console.WriteLine($"{mapq.maxKey()}, { mapq.size()}");
        }

        private static void TestMedianIndexedPriorityQueue()
        {
            Median med = new Median(7);
            int[] arr = { 1, 2, 3, 4, 5 };// { 6, 5, 3, 4, 1, 2, 10 };            
            var me = med.FindMedian(arr);
            Console.WriteLine(me);
            arr = arr.Reverse().ToArray<int>();
            me = med.FindMedian(arr);
            Console.WriteLine(me);
            //Console.WriteLine($"{mapq.maxKey()}, { mapq.size()}");
            //mapq.deleteKey(8);
            //Console.WriteLine($"{mapq.maxKey()}, { mapq.size()}");
            //mapq.deleteMax();
            //Console.WriteLine($"{mapq.maxKey()}, { mapq.size()}");
        }
    }
}
