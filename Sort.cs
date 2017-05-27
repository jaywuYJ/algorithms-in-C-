using System;

namespace Algorithms
{
    public class Sort
    {
        private int[] _intArray;

        private Sort()
        {}
        public Sort(int[] unsorted)
        {
            _intArray = unsorted;
        }
        public void SelectionSort()
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

        public void InsertionSort()
        {
            //the outer loop visit all the elements in the array
            for(int i=0;i<_intArray.Length-1;i++)
            {
                //the inner loop compare the visiting element in the outer loop with the sorted array
                //and place the visiting element at the right position
                //sln#1
                // for(int j=i+1;j>0;j--)
                // {
                //     if(_intArray[j]<_intArray[j-1])
                //       Swap(j,j-1);
                //     else 
                //       break;
                // }

                //sln#2 use while loop and swap the visiting element only once with the right position
                int j=i+1; //visiting element is i+1
                int position = i; // target position to swap 
                while(j>0 && _intArray[j]<_intArray[j-1])
                {
                    position = j-1;
                    j--;
                }
                Swap(i+1,position);
            }
            PrintArray(_intArray);

        }

        public void ShellSort()
        {

        }
        


        #region utils
        protected void PrintArray(int[] sorted)
        {
            foreach(var n in sorted)
            {
                Console.Write(n.ToString()+",");
            }   
            Console.WriteLine();
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
