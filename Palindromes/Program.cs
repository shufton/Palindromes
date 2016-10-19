using System;
using System.Linq;

namespace Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            if (String.IsNullOrEmpty(args[0]))
            {
                Console.WriteLine("Usage: Palindromes <input string>");
                return;
            }
            var finder = new PalindromeFinder();
            var searcher = new PalindromeSearcher(finder);

            var results = searcher.FindPalindromes(args[0].Trim());

            if (results.Count > 3)
                results = results.Take(3).ToList();

            foreach (var result in results)
            {
                Console.WriteLine($"Text: {result.Palindrome}, Index: {result.StartIndex}, Length: {result.Palindrome.Length}");
            }
        }
    }
}
