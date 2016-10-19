using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Palindromes;

namespace PalindromesTests
{
    [TestClass]
    public class PalindromeResultTests
    {
        [TestMethod]
        public void CompareTo_IdenticalObject_ReturnsZero()
        {
            var pres = new PalindromeResult {Palindrome = "1221", StartIndex = 1, EndIndex = 4};

            var result = pres.CompareTo(pres);

            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void CompareTo_CompareAgainstLongerPalindrome_ReturnsPlusOne()
        {
            var pres1 = new PalindromeResult { Palindrome = "1221", StartIndex = 1, EndIndex = 4 };
            var pres2 = new PalindromeResult { Palindrome = "12221", StartIndex = 5, EndIndex = 9 };

            var result = pres1.CompareTo(pres2);

            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void CompareTo_CompareAgainstShorterPalindrome_ReturnsMinusOne()
        {
            var pres1 = new PalindromeResult { Palindrome = "1221", StartIndex = 1, EndIndex = 4 };
            var pres2 = new PalindromeResult { Palindrome = "12221", StartIndex = 5, EndIndex = 9 };

            var result = pres2.CompareTo(pres1);

            Assert.AreEqual(-1, result);
        }
        [TestMethod]
        public void CompareTo_IndenticalPalindromeFurtherInString_ReturnsPlusOne()
        {
            var pres1 = new PalindromeResult { Palindrome = "1221", StartIndex = 1, EndIndex = 4 };
            var pres2 = new PalindromeResult { Palindrome = "1221", StartIndex = 5, EndIndex = 8 };

            var result = pres1.CompareTo(pres2);

            Assert.AreEqual(-1, result);
        }
        [TestMethod]
        public void CompareTo_IndenticalPalindromeEarlierInString_ReturnsPlusOne()
        {
            var pres1 = new PalindromeResult { Palindrome = "1221", StartIndex = 1, EndIndex = 4 };
            var pres2 = new PalindromeResult { Palindrome = "1221", StartIndex = 5, EndIndex = 8 };

            var result = pres2.CompareTo(pres1);

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void CompareTo_CollectionOfResult_IsSortedInExpectedOrder()
        {
            var pres1 = new PalindromeResult { Palindrome = "1221", StartIndex = 10, EndIndex = 13 };
            var pres2 = new PalindromeResult { Palindrome = "12221", StartIndex = 5, EndIndex = 9 };
            var pres3 = new PalindromeResult { Palindrome = "1221", StartIndex = 1, EndIndex = 4 };

            var list = new List<PalindromeResult> {pres1, pres2, pres3};
            var expected = new List<PalindromeResult> {pres2, pres3, pres1};
            list.Sort();

            Assert.IsTrue(expected.SequenceEqual(list));
        }
    }
}
