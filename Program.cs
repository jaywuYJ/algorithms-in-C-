using System;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var unsorted = new int[] {5,56,64,83,9,1,7,99,43};
            var search = new Sort(unsorted);
            // search.SelectSearch();
            search.InsertionSort();
            

            var pm = new PatternMatch("I have a dog".ToCharArray(),"dog".ToCharArray());
            
            Console.WriteLine(pm.BruteForceMatch2());

            Console.WriteLine("Hello World!");
        }




    }
}
