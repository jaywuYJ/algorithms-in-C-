using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    //a max heap is a binary tree that each node has two childs, and both childs are smaller than the parent.
    public class Heap
    {
        protected int[] _queue;
        protected int _currentLen;
        public Heap(int max)
        {
            //the binary tree is stored in an array that starts with array[1].
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

        protected void Swap(int first, int second)
        {
            if (first <= _currentLen && second <= _currentLen)
            {
                int tmp = _queue[first];
                _queue[first] = _queue[second];
                _queue[second] = tmp;
            }
        }

        public void PrintHeap()
        {

        }

        public void MirrorHeap()
        {

        }

    }

    public class PriorQueue<T> : Heap
    {
        public PriorQueue(int max) : base(max)
        {
        }


        private void Swim(int n)
        {
            int k = n / 2; //k is the father node, given any node k(k>=2), its father node is k/2
            while (k >= 1 && _queue[k].CompareTo(_queue[n]) < 0) //if father is valid && father is smaller than the new element
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
                if (i < _currentLen && _queue[i].CompareTo(_queue[i + 1]) < 0) // Key point: compare which child is bigger
                    i++; //if the right child is bigger, then i = right child index

                //compare with its bigger son
                if (_queue[k].CompareTo(_queue[i]) < 0)
                {
                    Swap(k, i);
                    k = i; //very important!!!
                }
                else
                {
                    break;
                }

            }
        }

    }

    public class Node : IComparable<Node>
    {
        public int Value { get; set; }
        public int CompareTo(Node target)
        {
            int result = 0;
            if (this.Value > target.Value)
            {
                result = 1;
            }
            else if (this.Value == target.Value)
            {
                result = 0;
            }
            else
            {
                result = -1;
            }

            return result;
        }
    }


    public class BinaryTreeNode : Node
    {
        public BinaryTreeNode Left { get; set; }
        public BinaryTreeNode Right { get; set; }

        public BinaryTreeNode(int val)
        { this.Value = val; }

    }

    public class BinaryTree
    {
        BinaryTreeNode Root { get; set; }
        public BinaryTree(BinaryTreeNode root)
        {
            this.Root = root;
        }

        //non-recursive mirror binary tree
        public void MirrorTree()
        {
            Stack<BinaryTreeNode> s = new Stack<BinaryTreeNode>();
            var currentNode = this.Root;
            while (currentNode != null || s.Count != 0) // must have the '||' operator
            {
                while (currentNode != null)
                {
                    s.Push(currentNode);
                    currentNode = currentNode.Left;
                    PrintStack(s);
                }
                if (s.Count != 0)
                {
                    currentNode = s.Pop();
                    
                    var tmpNode = currentNode.Left;
                    currentNode.Left = currentNode.Right;
                    currentNode.Right = tmpNode;

                    currentNode = currentNode.Left; //original right
                    PrintStack(s);
                }
            }
        }

        private void PrintStack(Stack<BinaryTreeNode> s)
        {
            StringBuilder sbd = new StringBuilder();
            foreach(var item in s)
            {
                sbd.Append(item.Value.ToString()+",");
            }
            Console.WriteLine(sbd.ToString());
        }

    }

    
}