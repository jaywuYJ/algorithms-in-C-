using System;

namespace ProblemSolving
{


    #region Reverse Words in a String
    public class StringHelper
    {
        public string ReverseWords(string origin)
        {
            /* there are several ways to solve the problem, i just pick one from my instinct
            The algorithem behave like the partition process in QuickSort
            1. start scaning from both low and high, 
            2. find the first word, and the last word, then stop, and swap them
            3. until firstEnd pointer == secondStart pointer
            4. use test cases(consider extreme situation, empty string, many spaces between the word, etc) to check the code */
            if (String.IsNullOrEmpty(origin))
                return origin;

            char[] o = origin.ToCharArray();
            int fs = 0, fe = 0, ss = o.Length - 1, se = o.Length - 1;
            while (fe < ss)
            {
                while (fs < o.Length && o[fs] == ' ') fs++;
                fe = fs;
                while ((fe < o.Length) && o[fe] != ' ') fe++;
                while ((0 <= se) && o[se] == ' ') se--;
                ss = se;
                while ((0 <= ss) && o[ss] != ' ') ss--;
                o = SwapWords(o, fs, fe - 1, ss + 1, se);
                int fl = fe - fs;
                int sl = se - ss;
                fs = fs + sl - 1; //Key point: fs = "new fe"
                se = se - fl - 1; // key key point! se = "new ss"
            }
            return new string(o);
        }

        private char[] SwapWords(char[] o, int firstStart, int firstEnd, int secondStart, int secondEnd)
        {
            if (firstStart == secondStart)
                return o;

            char[] newArray = new char[o.Length];
            int current = 0;
            for (int i = 0; i < firstStart; i++)
            {
                newArray[i] = o[i];
                current = i;
            }

            for (int i = secondStart; i <= secondEnd; i++)
            {
                newArray[current++] = o[i];
            }

            for (int i = firstEnd + 1; i < secondStart; i++)
            {
                newArray[current++] = o[i];
            }

            for (int i = firstStart; i <= firstEnd; i++)
            {
                newArray[current++] = o[i];
            }

            while (current < o.Length)
            {
                newArray[current] = ' ';
                current++;
            }
            return newArray;
        }
    }



    #endregion

    #region LinkedList Sum
    //Definition for singly-linked list.
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x)
        {
            val = x;
            next = null;
        }
    }

    public class LinkedListSolution
    {
        /**
         * @param l1: the first list
         * @param l2: the second list
         * @return: the sum list of l1 and l2 
         */
        public ListNode addLists(ListNode l1, ListNode l2)
        {
            // write your code here
            ListNode merge = null;
            ListNode current = null;
            int residual = 0;
            int overflow = 0;
            while (l1 != null && l2 != null)
            {
                int sum = l1.val + l2.val + overflow;
                overflow = (int)sum / 10;
                residual = (int)sum % 10;

                if (merge == null)
                {
                    merge = new ListNode(residual);
                    current = merge;
                }
                else
                {
                    ListNode newNode = new ListNode(residual);
                    current.next = newNode;
                    current = current.next;
                }
                l1 = l1.next;
                l2 = l2.next;
            }
            int extraVal = 0;
            while (l1 != null)
            {
                extraVal = l1.val;
                extraVal += overflow;
                overflow = 0;
                ListNode newNode = new ListNode((int)extraVal % 10);
                current.next = newNode;
                current = current.next;
                if (extraVal >= 10)
                {
                    newNode = new ListNode((int)extraVal / 10);
                    current.next = newNode;
                    current = current.next;
                }
                l1 = l1.next;
            }
            while (l2 != null)
            {
                extraVal = l2.val;
                extraVal += overflow;
                overflow = 0;
                ListNode newNode = new ListNode((int)extraVal % 10);
                current.next = newNode;
                current = current.next;
                if (extraVal >= 10)
                {
                    newNode = new ListNode((int)extraVal / 10);
                    current.next = newNode;
                    current = current.next;
                }
                l2 = l2.next;
            }
            // 1->1->1->1->null    9->8->8->8->null
            if (overflow != 0)
            {
                ListNode newNode = new ListNode(overflow);
                current.next = newNode;
                current = current.next;
            }


            return merge;
        }
    }
    #endregion
}