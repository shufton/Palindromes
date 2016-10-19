using System;

namespace Palindromes
{
    // Palindromes may have different rulles in different languages
    // So extract an interface to allow alternative implementations
    // of the finding algorithm to be used.
    public interface IPalindromeFinder
    {
        bool IsPalindrome(string inputString);
    }

    internal class PalindromeFinder : IPalindromeFinder
    {
        public bool IsPalindrome(string inputString)
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
