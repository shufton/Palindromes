using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromes
{
    internal class PalindromeSearcher
    {
        private IPalindromeFinder _finder;

        public PalindromeSearcher(IPalindromeFinder finder)
        {
            _finder = finder;
        }

        public int FindPossibleSubstring(string inputString, int startPos, int endPos)
        {
            if (String.IsNullOrEmpty(inputString))
                throw new ArgumentException("A valid string must be passed to FindPalindromes.", nameof(inputString));

            if (startPos < 0 || inputString.Length <= startPos)
                throw new ArgumentException("The start position for the search must refer to a location within the string.", nameof(startPos));

            if (endPos <= startPos)
                throw new ArgumentException("The stendart position for the search must be after the start pos .", nameof(endPos));

            while (endPos > startPos)
            {
                if (inputString[startPos] == inputString[endPos])
                    return endPos;
                --endPos;
            }

            return -1;
        }

        public List<PalindromeResult> FindPalindromes(String inputString)
        {
            if (String.IsNullOrEmpty(inputString))
                throw new ArgumentException("A valid string must be passed to FindPalindromes.", nameof(inputString));

            var results = new List<PalindromeResult>();

            var inputLength = inputString.Length - 1;
            for (var startPos = 0; startPos < inputLength; ++startPos)
            {
                var endPos = FindPossibleSubstring(inputString, startPos, inputLength);
                if (ScanSubstring(inputString, endPos, startPos, results))
                    startPos = endPos;
            }

            results.Sort();
            return results;
        }

        internal bool ScanSubstring(string inputString, int endPos, int startPos, List<PalindromeResult> results)
        {
            while (endPos > -1)
            {
                var substring = inputString.Substring(startPos, endPos - startPos + 1);
                if (_finder.IsPalindrome(substring))
                {
                    results.Add(new PalindromeResult { Palindrome = substring, StartIndex = startPos, EndIndex = endPos });
                    return true;
                }

                endPos = FindPossibleSubstring(inputString, startPos, endPos);
            }
            return false;
        }
    }
}
