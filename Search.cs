using System;

namespace Algorithms
{
    public class Search
    {
        int[] _seq;
        private Search()
        {}
        public Search(int[] seq)
        {
            _seq = seq;
        }
        // private 
    }

    public class BinarySearch : Search
    {
        public BinarySearch (int[] seq) : base(seq)
        {}

    }
}