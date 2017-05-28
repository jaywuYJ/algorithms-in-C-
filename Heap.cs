using System;

namespace Algorithms
{
    public struct Heap
    {
        int[] _queue;
        int _currentLen;
        public Heap(int max)
        {
            _queue = new int[max + 1];
            _currentLen = 0;
        }

        public int[] GetHeap()
        {
            return _queue;
        }
        public int DelMax()
        {
            int max = _queue[1];
            _queue[1] = _queue[_currentLen--];
            Sink(1);
            return max;
        }

        public void Insert(int element)
        {
            _queue[++_currentLen] = element;
            Swim(_currentLen);
        }

        public bool IsEmpty()
        {
            return _currentLen == 0;
        }

        private void Swim(int n)
        {
            int k = n / 2; //k is the father node, given any node k(k>=2), its father node is k/2
            while (k >= 1 && _queue[k] < _queue[n]) //if father is valid && father is smaller than the new element
            {
                Swap(k, n);
                n = k; //update the value
                k = k / 2;
            }
        }

        //v is not the index, but the previous last element 
        private void Sink(int k)
        {
            while (2 * k <= _currentLen)
            {
                //Given any node k, its left son is 2k, and right son is 2k+1
                int i = 2 * k;
                if (i < _currentLen && _queue[i] < _queue[i + 1]) // Key point: compare which child is bigger
                    i++; //if the right child is bigger, then i = right child index

                //compare with its bigger son
                if (_queue[k] < _queue[i])
                {
                    Swap(k, i);
                    k = i; //very important!!!
                }
                else
                {
                    break;
                }



                //original implementation which is not so correct
                // if (2 * k <= _currentLen && _queue[k] < _queue[2 * k])
                // {
                //     Swap(k, 2 * k);
                //     k = 2 * k;
                // }
                // else if ((2 * k + 1) <= _currentLen && _queue[k] < _queue[2 * k + 1])
                // {
                //     Swap(k, 2 * k + 1);
                //     k = 2 * k + 1;
                // }
                // break;


            }
        }

        private void Swap(int first, int second)
        {
            if (first <= _currentLen && second <= _currentLen)
            {
                int tmp = _queue[first];
                _queue[first] = _queue[second];
                _queue[second] = tmp;
            }
        }

    }
}