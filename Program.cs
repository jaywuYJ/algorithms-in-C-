using System;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var unsorted = new int[] { 5, 56, 64, 83, 9, 1, 7, 99, 43, 88, 66, 97, 1, 2, 38, 42, 55, 28 };
            var search = new Sort(unsorted);
            // search.SelectSearch();
            // search.InsertionSort();
            // search.ShellSort();
            // search.RecursiveMergeSort();
            // search.NonRecursiveMergeSort();
            // search.MergeSort(unsorted,new int[unsorted.Length],0,unsorted.Length-1);
            var longest = new LongestPalindrome("my mum have a aabbaa cccbbabbcccd abba");
            longest.GetLongestPalindrome1();

            var pm = new PatternMatch("I have a dog".ToCharArray(), "dog".ToCharArray());

            Console.WriteLine(pm.BruteForceMatch2());

            Console.WriteLine("Hello World!");
        }




    }
}
