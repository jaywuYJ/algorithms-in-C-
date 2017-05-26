using System;

namespace Algorithms
{
    public class Search
    {
        private int[] _intArray;

        private Search()
        {}
        public Search(int[] unsorted)
        {
            _intArray = unsorted;
        }
        public void SelectSearch()
        {
            for(int i=0;i<_intArray.Length;i++)
            {
                int min = i;
                for(int j=i+1;j<_intArray.Length;j++)
                {
                    if(_intArray[j]<_intArray[min])
                    min = j;
                }
                Swap(i,min);
            }

            PrintArray(_intArray);

        }

        #region utils
        protected void PrintArray(int[] sorted)
        {
            foreach(var n in sorted)
            {
                Console.Write(n.ToString()+",");
            }   
        }

        protected void Swap(int first, int second)
        {
            if(first != second)
            {
                int tmp = _intArray[first];
                _intArray[first] = _intArray[second];
                _intArray[second] = tmp;
            }
        }
        #endregion

    }
    
}
