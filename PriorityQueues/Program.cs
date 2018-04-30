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
            MinHeap();

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
    }
}
