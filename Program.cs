using System;
using Algorithms;

namespace algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var unsorted = new int[] {5,56,64,83,9,1,7,99,43};
            var search = new Search(unsorted);
            search.SelectSearch();

            Console.WriteLine("Hello World!");
        }




    }
}
