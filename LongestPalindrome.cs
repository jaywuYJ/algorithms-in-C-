using System;

namespace Algorithms
{
    public class LongestPalindrome
    {
        private char[] _content;

        private LongestPalindrome()
        {}
        public LongestPalindrome(string content)
        {
            _content = content.ToCharArray();
        }

        //the most straight forward way
        public void GetLongestPalindrome1()
        {
            //the output
            int left = 0, longest = 1; //left : longest starting indext, longest: the longest length

            for (int i = 0; i < _content.Length; i++)
            {
                int j, k;
                int currentLongest = 1;
                int currentLeft = i;

                //find the odd palindrome
                k = i - 1;
                j = i + 1;

                while (k >= 0 && j < _content.Length && _content[k] == _content[j])
                {

                    currentLongest += 2;
                    currentLeft = k;
                    if (currentLongest > longest)
                    {
                        longest = currentLongest;
                        left = currentLeft;
                    }
                    k--;
                    j++;

                }

                if (currentLongest > 1)
                {
                    Console.WriteLine("current longest palindrome is:");
                    for (int n = currentLeft; n < currentLeft + currentLongest; n++)
                    {
                        Console.Write(_content[n]);
                    }
                    Console.WriteLine();
                }

                //find the even palindrome
                k = i;
                j = i + 1;
                currentLongest = 0;
                currentLeft = i;

                while (k >= 0 && j < _content.Length && _content[k] == _content[j])
                {
                    currentLongest += 2;
                    currentLeft = k;
                    if (currentLongest > longest)
                    {
                        longest = currentLongest;
                        left = currentLeft;
                    }
                    k--;
                    j++;

                }

                if (currentLongest > 0)
                {
                    Console.WriteLine("current longest palindrome is:");
                    for (int n = currentLeft; n < currentLeft + currentLongest; n++)
                    {
                        Console.Write(_content[n]);
                    }
                    Console.WriteLine();
                }
            }

            for (int i = left; i < left + longest; i++)
            {
                Console.Write(_content[i]);
            }
            Console.WriteLine();
        }
    }
}