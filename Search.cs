using System;
using System.Collections.Generic;

namespace Algorithms
{
    public abstract class SearchBase<K>
    {
        protected K[] _seq;
        private SearchBase()
        { }
        public SearchBase(K[] seq)
        {
            _seq = seq;
        }
        // private 

        public abstract int Search(K key, int low, int high);
 
    }

    public class BinarySearch<K> : SearchBase<K> where K : IComparable
    {
        public BinarySearch(K[] seq) : base(seq)
        {

        }

        public override int Search(K key, int low, int high)
        {
            if (low > high || low < 0 || high > _seq.Length)
                return -1;

            int mid = low + (high - low) / 2;
            int cmp = key.CompareTo(_seq[mid]);

            if (cmp > 0) //key larger than mid
                return Search(key, mid + 1, high);
            else if (cmp < 0)
                return Search(key, low, mid - 1);
            else
                return mid;
        }



    }
}