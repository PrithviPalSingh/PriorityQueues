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

            Console.Read();
        }
    }
}
