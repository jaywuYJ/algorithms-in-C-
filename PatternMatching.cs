using System;

namespace Algorithms
{
    public class PatternMatch
    {
        private char[] _original;
        private char[] _pattern;
        private PatternMatch()
        {}

        public PatternMatch(char[] original, char[] pattern)
        {
            _original = original;
            _pattern = pattern;
        }

        public int BruteForceMatch()
        {
            if (_original.Length>=_pattern.Length)
            {
                for(int i=0;i<_original.Length;i++)
                {
                    int j=0;
                    for(;j<_pattern.Length;j++)
                    {
                        if (_original[i]==_pattern[j])
                        {
                            i++;
                        }
                        else
                            break;
                    }
                    if (j==_pattern.Length)
                        return i-j+1;
                }
            }
            
            return -1;
        }

        public int BruteForceMatch2()
        {
            if (_original.Length>=_pattern.Length)
            {
                int i=0,j=0;
                while(i<_original.Length && j<_pattern.Length)
                {
                    if (_original[i]==_pattern[j])
                    {
                        //move on
                        i++;
                        j++;
                    }
                    else
                    {
                        //reset, i move to next
                        i = i-j+1;
                        j = 0;
                    }
                }
                if (j == _pattern.Length)
                return i-j+1;
            }
            
            return -1;
        }

        public int KmpMatch()
        {
            
            return -1;
        }
    }
}