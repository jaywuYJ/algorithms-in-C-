using System;

namespace Algorithms
{
    public class Sort
    {
        private int[] _intArray;

        private Sort()
        { }
        public Sort(int[] unsorted)
        {
            _intArray = unsorted;
        }

        public int[] CurrentSequence { get { return _intArray; } }

        public void SelectionSort()
        {
            for (int i = 0; i < _intArray.Length; i++)
            {
                int min = i;
                for (int j = i + 1; j < _intArray.Length; j++)
                {
                    if (_intArray[j] < _intArray[min])
                        min = j;
                }
                Swap(i, min);
            }

            PrintArray(_intArray);

        }

        public void InsertionSort()
        {
            //the outer loop visit all the elements in the array
            for (int i = 0; i < _intArray.Length - 1; i++)
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
                int j = i + 1; //visiting element is i+1
                int position = i; // target position to swap 
                while (j > 0 && _intArray[j] < _intArray[j - 1])
                {
                    position = j - 1;
                    j--;
                }
                Swap(i + 1, position);
            }
            PrintArray(_intArray);

        }

        public void ShellSort()
        {
            int h = 0;
            //use h = 3*h+1 as the increment subsequence
            while (h <= _intArray.Length / 3)
            {
                h = 3 * h + 1;
            }

            //start shell sort
            while (h > 0)
            {
                //outter loops index increase from group number 1 to ...
                for (int group = 0; group < h; group++)
                {
                    //insertion sort
                    Console.WriteLine(@"group number{0}, current h is {1}", group, h);
                    for (int i = h; i < _intArray.Length; i += h)
                    {
                        int j = i;
                        while (j >= h && _intArray[j] < _intArray[j - h])
                        {
                            Swap(j, j - h);
                            PrintArray(_intArray);
                            j -= h;
                        }
                    }

                }
                h = h / 3;
            }

        }

        public void ShellSort2()
        {
            int h = 0;
            //use h = 3*h+1 as the increment subsequence
            while (h <= _intArray.Length / 3)
            {
                h = 3 * h + 1;
            }

            //start shell sort
            while (h >= 1)
            {
                //outter loops index increase from h until the last number
                for (int i = h; i < _intArray.Length; i++)
                {

                    int j = h;
                    while (j >= h && _intArray[j] < _intArray[j - h])
                    {
                        Swap(j, j - h);
                    }

                }
                h = h / 3;
            }

        }

        public void RecursiveMergeSort()
        {
            int low = 0;
            int high = _intArray.Length - 1; //important, shoud be the larget index rather than the total number

            int[] temp = new int[_intArray.Length];
            sort(temp, low, high);

            Console.WriteLine();
            PrintArray(_intArray);
        }

        //used by MergeSort
        private void sort(int[] temp, int low, int high)
        {
            if (low < high)
            {
                int mid = low + (high - low) / 2;
                sort(temp, low, mid);
                sort(temp, mid + 1, high);
                merge(temp, low, mid, high);
            }
            // else
            // {

            // }
        }

        //used by MergeSort
        private void merge(int[] temp, int low, int mid, int high)
        {
            //merge two sorted sub sequence, by comparing and putting the smaller ones in to the temp array.
            int i = low;
            int j = mid + 1;
            int tempIndex = low;
            int tempLength = high - low + 1;
            while (i <= mid && j <= high) // <= is important, make sure each element is visited
            {
                if (_intArray[i] < _intArray[j])
                    temp[tempIndex++] = _intArray[i++]; // #1 use latest _intArray data
                else
                    temp[tempIndex++] = _intArray[j++]; // #2 use latest _intArray data
            }

            //exhaust the left part
            while (i <= mid)
            {
                temp[tempIndex++] = _intArray[i++]; // #3 use latest _intArray data
            }

            //exhaust the right part
            while (j <= high)
            {
                temp[tempIndex++] = _intArray[j++]; // #4 use latest _intArray data
            }


            //交换数据 must exchange!!!
            //otherwise the new data will not be reflected on _intArray which is used in #1,2,3,4 in another method call
            for (int k = 0; k < tempLength; k++)
            {
                // _intArray[high] = temp[high];
                // high--;
                _intArray[low] = temp[low];
                low++;
            }

            PrintArray(temp);

        }

        public void NonRecursiveMergeSort()
        {
            int[] tempArray = new int[_intArray.Length];
            for (int groupSize = 1; groupSize < _intArray.Length; groupSize *= 2)
            {
                for (int j = 0; j < _intArray.Length - groupSize; j += 2 * groupSize)
                {
                    //use Math.Min because the j+2*groupSize-1 may goes out of index
                    merge(tempArray, j, j + groupSize - 1, Math.Min(j + 2 * groupSize - 1, _intArray.Length - 1));

                }
            }
            Console.WriteLine();
            PrintArray(_intArray);

        }

        public void MergeSort(int[] array, int[] temparray, int left, int right)
        {
            if (left < right)
            {
                //取分割位置
                int middle = (left + right) / 2;

                //递归划分数组左序列
                MergeSort(array, temparray, left, middle);

                //递归划分数组右序列
                MergeSort(array, temparray, middle + 1, right);

                //数组合并操作
                Merge(array, temparray, left, middle + 1, right);
            }

            PrintArray(array);
        }

        private void Merge(int[] array, int[] temparray, int left, int middle, int right)
        {
            //左指针尾
            int leftEnd = middle - 1;

            //右指针头
            int rightStart = middle;

            //临时数组的下标
            int tempIndex = left;

            //数组合并后的length长度
            int tempLength = right - left + 1;

            //先循环两个区间段都没有结束的情况
            while ((left <= leftEnd) && (rightStart <= right))
            {
                //如果发现有序列大，则将此数放入临时数组
                if (array[left] < array[rightStart])
                    temparray[tempIndex++] = array[left++];
                else
                    temparray[tempIndex++] = array[rightStart++];
            }

            //判断左序列是否结束
            while (left <= leftEnd)
                temparray[tempIndex++] = array[left++];

            //判断右序列是否结束
            while (rightStart <= right)
                temparray[tempIndex++] = array[rightStart++];

            //交换数据
            for (int i = 0; i < tempLength; i++)
            {
                array[right] = temparray[right];
                right--;
            }
        }


        public void QuickSort(int low, int high)
        {
            if (low < high) //when low = high no need to partition and sort so don't use <=
            {
                int position = partition(low, high);
                QuickSort(low, position - 1); //keypoint: do not include position into sub sequence
                QuickSort(position + 1, high);
            }
        }

        public void QuickSortSplitThree(int low, int high)
        {
            if (low < high)
            {
                //need 3 pointers
                int lt = low, i = low + 1, gt = high; //i always points to the element right to the comparables.
                int comparable = _intArray[low];
                //partition i such that a[lt..i-1] are equal to v and a[i..gt] are not yet examined
                while (i <= gt)
                {
                    int cmp = _intArray[i].CompareTo(comparable);
                    //the difference with QuickSort is that lt(gt) swap with i rather than gt(lt)
                    //
                    if (cmp > 0) //array[i] is less than comparable
                    {
                        Swap(i++, lt++); //swap and move on
                    }
                    else if (cmp < 0)
                    {
                        Swap(i, gt--); //i doesn't move because it needs to compare with comparable in the next round
                    }
                    else
                    {
                        i++; // i move on until array[i] doesn't equal with comparable
                    }
                }
                //after partition, sort recursively
                QuickSortSplitThree(low, lt - 1); //  lt such that a[lo..lt-1] is less than v
                QuickSortSplitThree(gt + 1, high); // gt such that a[gt+1, hi] is greater than v

            }

        }

        private int partition(int low, int high)
        {
            int pivot = _intArray[low];
            int i = low, j = high + 1;
            while (i < j)
            {
                //use i < high to avoid index out of bounds of the array
                while (i < high && _intArray[++i] < pivot) //use ++i to ensure that current i is the one that need to be swap
                    if (i == j)
                        break;

                while (j > low && _intArray[--j] > pivot)
                    if (i == j)
                        break;

                if (i < j)
                {
                    Swap(i, j);
                }
                else
                {
                    break;
                }
            }
            //when i==j, swap the pivot with array[j]
            if (_intArray[low] < _intArray[j])
            {
                j = j - 1;
            }
            Swap(low, j);

            PrintArray(_intArray);

            // for(int i=low+1;i<high-low+1;i++)
            // {
            //     for(int j=high;j>low;j--)
            //     {
            //         if (i!=j)
            //         {
            //             if(_intArray[i]<_intArray[low])
            //             {
            //                 i++;
            //             }
            //         }
            //         else
            //         {
            //             pivot = j;
            //         }
            //     }

            // }
            return j;
        }


        public void HeapSort()
        {
            var heap = new Heap(_intArray.Length);
            //build up the heap
            for (int i = 0; i < _intArray.Length; i++)
            {
                heap.Insert(_intArray[i]);
            }

            PrintArray(heap.GetHeap());


            int[] sorted = new int[_intArray.Length];
            int j = sorted.Length - 1;
            //get a sorted sequence
            while (!heap.IsEmpty())
            {
                sorted[j--] = heap.DelMax();
            }

            PrintArray(sorted);
        }


        #region utils



        protected void PrintArray(int[] sorted)
        {
            foreach (var n in sorted)
            {
                Console.Write(n.ToString() + ",");
            }
            Console.WriteLine();
        }

        protected void Swap(int first, int second)
        {
            if (first != second)
            {
                int tmp = _intArray[first];
                _intArray[first] = _intArray[second];
                _intArray[second] = tmp;
            }
        }
        #endregion

    }

}
