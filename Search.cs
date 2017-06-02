using System;
using System.Collections.Generic;
using System.Numerics;


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

    public class Node<K, T> where T : struct where K : IComparable<K>
    {
        public K Key { get; set; }
        public T Value { get; set; }
        public Node<K, T> Left, Right;
        public int N;

        public Node(K key, T value, int N)
        {
            Key = key;
            Value = value;
            this.N = N;
        }

    }


    //different with Heap(binary tree), in a binary search tree, each node has one or two childs, 
    //and the node is bigger than its left child, smaller than its right child.
    public class BinarySearchTree<K, T> where T : struct where K : IComparable<K>
    {
        // private SearchBase<K> SearchBehavour;
        Node<K, T> Root { get; set; }
        public int Size()
        {
            return Size(Root);
        }

        public int Size(Node<K, T> node)
        {
            if (node == null)
            {
                return 0;
            }
            return node.N;
        }
        public T? GetValue(K key)
        {
            return GetValue(Root, key);
        }

        private T? GetValue(Node<K, T> root, K key)
        {
            if (root == null)
                return null;

            int cmp = key.CompareTo(root.Key);

            if (cmp < 0) // root's left is smaller than root 
            {
                return GetValue(root.Left, key);
            }
            else if (cmp > 0)
            {
                return GetValue(root.Right, key);
            }
            else
            {
                return root.Value;
            }
        }

        public void PutValue(K key, T value)
        {
            PutValue(Root, key, value);
        }

        private Node<K, T> PutValue(Node<K, T> root, K key, T value)
        {
            if (root == null)
                return new Node<K, T>(key, value, 1);

            int cmp = key.CompareTo(root.Key);
            if (cmp > 0)
            {
                return PutValue(root.Right, key, value);
            }
            else if (cmp < 0)
            {
                return PutValue(root.Left, key, value);
            }
            else
            {
                root.Value = value;
                return root;
            }

        }

        //
        public void DeleteMin()
        {
            if (this.Root.Left == null && this.Root.Right == null)
                this.Root = null;
            else
                DeleteMin(this.Root);
        }

        //the returned node is the original node in the parameter or the one the replaced the original parameter
        private Node<K, T> DeleteMin(Node<K, T> node)
        {
            throw new NotImplementedException();
            // if (node == null)
            //     return null;
            // if (node.Left == null)
            //     return node.Right;

            // Node<K,T> returnNode = DeleteMin(node.Left);
            // returnNode.N = Size
            

        }
        public void DeleteNode(K key)
        {

        }





    }

    public class Helper
    {
        public int StringComparer(string first, string second)
        {
            if (String.IsNullOrEmpty(first) || String.IsNullOrEmpty(second))
                throw new ArgumentException();
                
            char[] firstArray = first.ToCharArray();
            char[] secondArray = second.ToCharArray();
            int firstLength = firstArray.Length;
            int secondLength = second.Length;
            int shorter = (firstLength < secondLength) ? firstLength : secondLength;

            for (int i = 0; i < shorter; i++)
            {
                int cmp = first[i].CompareTo(second[i]);
                if (cmp != 0)
                {
                    return cmp;
                }

            }
            return firstLength - secondLength;
        }
    }

}