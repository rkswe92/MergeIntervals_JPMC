using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MergeIntervals_JPMC
{
    public class MergeIntervals
    {
        class sortHelper : IComparer
        {
            int IComparer.Compare(object a, object b)
            {
                Interval first = (Interval)a;
                Interval second = (Interval)b;
                if (first.first == second.first)
                {
                    return first.last - second.last;
                }
                return first.first - second.first;
            }
        }

        public void MergeIntervalsTogather(Interval[] arr) { 
            //Always sort array in ascending order to make the comparisions easy
            if(arr.Length>0)
            {
                Array.Sort(arr, new sortHelper());
            }
            //pickup the top of the array
            var top = arr[0];
            Stack stk = new Stack();
            stk.Push(top);

            //Now for each element in the arr compare the top last to arr[i].first to see if arr.first can be ignored if it overlaps
            // we will now it by checking if top.last < arr[i].first if so that means it overlaps

            for(int i=1;i<arr.Length;i++){

                top = (Interval)stk.Peek();
                if(top.last<arr[i].first)
                {
                    stk.Push(arr[i]);
                }
                //This condition merges two intervals by checking the last values if the top.last < arr[i].last then update the last of top with the 
                // arr[i].last and pop the earlier added interval and update the top back to the stack.
                else if(top.last < arr[i].last )
                {
                    top.last = arr[i].last;
                    stk.Pop();
                    stk.Push(top);
                }
            }
            // Print contents of stack
            Console.Write("The Merged Intervals are: ");
            while (stk.Count != 0)
            {
                Interval t = (Interval)stk.Pop();
                Console.Write("[" + t.first + "," + t.last + "] ");
            }

        }
    }
    public class Interval {
       public int first { get; set; }
       public int last { get; set; }
        public  Interval(int a, int b)
        {
            this.first = a;
            this.last = b;
        }
    }
}
