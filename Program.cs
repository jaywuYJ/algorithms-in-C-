using System;
using System.Collections.Generic;
using ProblemSolving;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var unsorted = new int[] { 5, 56, 64, 83, 9, 1, 7, 99, 43, 88, 66, 97, 1, 2, 38, 42, 55, 28 };
            var sort = new Sort(unsorted);
            // sort.SelectionSort();
            // sort.InsertionSort();
            // sort.ShellSort();
            // sort.RecursiveMergeSort();
            // sort.NonRecursiveMergeSort();
            // sort.MergeSort(unsorted,new int[unsorted.Length],0,unsorted.Length-1);
            // sort.HeapSort();

            // var dict = new string[]{"a","b","how","to","solve","this","puzzle","?"};

            // sort.QuickSort(0, unsorted.Length - 1);
            // var binSearch = new BinarySearch<int>(sort.CurrentSequence);
            // int result = binSearch.Search(2, 0, sort.CurrentSequence.Length - 1);
            // Console.WriteLine(result.ToString());

            // var linkedList = new LinkedListSolution();
            // var list1 = new ListNode(3);
            // list1.next = new ListNode(1);
            // list1.next.next = new ListNode(5);
            // var list2 = new ListNode(5);
            // list2.next = new ListNode(9);
            // list2.next.next = new ListNode(2);

            // var sum = linkedList.addLists(list1,list2);

            // var stringHelper = new StringHelper();
            // var result = stringHelper.ReverseWords("lak.kb c!gfbb' cgyxxrph!ai paim,izbj.tnkugjx.f!uhs!xgv vsx.ncydmsgeaenstgthzd'fv qssjheigf!xca!d ,tsvj!yni'csdnphtt cej.ngxy egnh oaxzxugnehorkqkt,");
            // Console.WriteLine(result);

            // var tmp = "         ";
            // var a = tmp.Trim();
            // Console.WriteLine(a);

            var btn = new BinaryTreeNode(1);
            btn.Left = new BinaryTreeNode(2);
            btn.Right = new BinaryTreeNode(3);
            btn.Left.Left = new BinaryTreeNode(4);
            btn.Left.Right = new BinaryTreeNode(5);
            btn.Left.Right.Left = new BinaryTreeNode(6);
            btn.Left.Right.Right = new BinaryTreeNode(7);
            var binaryTree = new BinaryTree(btn);
            binaryTree.MirrorTree();

            // var longest = new LongestPalindrome("my mum have a aabbaa cccbbabbcccd abba");
            // longest.GetLongestPalindrome1();

            // var pm = new PatternMatch("I have a dog".ToCharArray(), "dog".ToCharArray());

            // Console.WriteLine(pm.BruteForceMatch2());

            // Console.WriteLine("Hello World!");
        }




    }
}
