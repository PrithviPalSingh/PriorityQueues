using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueues
{
    public class Median
    {
        #region - with indexed priority queue
        //private MinIndexedPriorityQueue<int> biggerHeap;

        //private MaxIndexedPriorityQueue<int> lowerHeap;

        //public Median(int max)
        //{
        //    biggerHeap = new MinIndexedPriorityQueue<int>(max);
        //    lowerHeap = new MaxIndexedPriorityQueue<int>(max);
        //}

        //public void Push(int val)
        //{
        //    //Add number to the property queue

        //    //If number is greater than the least maxPQ number, it is an maxPQ number
        //    if (val >= lowerHeap.maxKey())
        //        lowerHeap.insert(val, val);
        //    else //Otherwise it is a lower number
        //        biggerHeap.insert(val, val);

        //    //Rebalance
        //    //If the queues sizes differ by 2, they need to be rebalanced so that they
        //    //differ by 1.
        //    if (lowerHeap.size() - biggerHeap.size() == 2)
        //    { //maxPQ queue is larger
        //        biggerHeap.insert(lowerHeap.maxKey(), lowerHeap.maxKey());        //Move value from maxPQ to minPQ
        //        lowerHeap.deleteMax();                    //Remove same value from maxPQ
        //    }
        //    else if (biggerHeap.size() - lowerHeap.size() == 2)
        //    { //minPQ queue is larger
        //        lowerHeap.insert(biggerHeap.minKey(), biggerHeap.minKey());               //Move value from minPQ to maxPQ
        //        biggerHeap.deleteMin();                           //Remove same value
        //    }
        //}

        //public int GetMedian()
        //{
        //    if (lowerHeap.size() == biggerHeap.size())               //Upper and lower are same size
        //        return (lowerHeap.maxKey() + biggerHeap.minKey()) / 2;  //so median is average of least upper and greatest lower
        //    else if (lowerHeap.size() > biggerHeap.size())           //Upper size greater
        //        return lowerHeap.maxKey();
        //    else                                         //Lower size greater
        //        return biggerHeap.minKey();
        //}
        #endregion

        #region - with priority queue

        private MinBinaryHeap<int> upperHeap;

        private UnOrderedPriorityQueue<int> lowerHeap;

        public Median(int max)
        {
            upperHeap = new MinBinaryHeap<int>(max);
            lowerHeap = new UnOrderedPriorityQueue<int>(max);
        }

        public double FindMedian(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                AddNumber(arr[i]);
                Rebalance();
            }

            return GetMedian();
        }

        private void AddNumber(int number)
        {
            if (lowerHeap.IsEmpty() || number < Convert.ToInt32(lowerHeap.Max()))
            {
                lowerHeap.Insert(number);
            }
            else
            {
                upperHeap.Insert(number);
            }
        }

        private void Rebalance()
        {
            if (lowerHeap.N - upperHeap.N >= 2)
            {
                upperHeap.Insert(lowerHeap.DeleteMax());
            }
            else if (upperHeap.N - lowerHeap.N >= 2)
            {
                lowerHeap.Insert(upperHeap.DeleteMin());
            }
        }

        private double GetMedian()
        {
            if (lowerHeap.N == upperHeap.N)
            {
                return (Convert.ToDouble(lowerHeap.Max()) + Convert.ToDouble(upperHeap.Min())) / 2;
            }
            else if (lowerHeap.N > upperHeap.N)
            {
                return Convert.ToDouble(lowerHeap.Max());
            }
            else
            {
                return Convert.ToDouble(upperHeap.Min());
            }
        }
        #endregion
    }
}