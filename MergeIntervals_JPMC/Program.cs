using System;

namespace MergeIntervals_JPMC
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Interval Merge Program");
            MergeIntervals obj = new MergeIntervals();
            Interval[] arr = new Interval[5];
            arr[0] = new Interval(1, 3);
            arr[1] = new Interval(1, 7);
            arr[2] = new Interval(2, 3);
            arr[3] = new Interval(2, 4);
            arr[4] = new Interval(2, 5);
            obj.MergeIntervalsTogather(arr);
            Console.ReadKey();
        }
    }
}
