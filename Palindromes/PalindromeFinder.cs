using System;

namespace Palindromes
{
    internal class PalindromeFinder
    {
        internal bool IsPalindrome(string inputString)
        {
            if(String.IsNullOrEmpty(inputString))
                throw new ArgumentException("A valid string must be passed to IsPalindrome.",nameof(inputString));

            int fwPos = 0, revPos = inputString.Length - 1;

            while (fwPos < revPos)
            {
                if (inputString[fwPos] != inputString[revPos])
                    return false;
                ++fwPos;
                --revPos;
            }
            return true;
        }
    }
}
