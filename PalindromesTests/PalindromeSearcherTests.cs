using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Palindromes;

namespace PalindromesTests
{
    [TestClass]
    public class PalindromeSearcherTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "An empty string was not detected.")]
        public void FindPossibleSubstring_NullInputString_ThrowsArgumentException()
        {
            var mockFinder = new Mock<IPalindromeFinder>();
            var searcher = new PalindromeSearcher(mockFinder.Object);

            searcher.FindPossibleSubstring(String.Empty, 0, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "An invalid starting pos of less than zero was not detected.")]
        public void FindPossibleSubstring_InvalidStartPosLTZero_ThrowsArgumentException()
        {
            var mockFinder = new Mock<IPalindromeFinder>();
            var searcher = new PalindromeSearcher(mockFinder.Object);

            searcher.FindPossibleSubstring("12345", -1, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "An invalid starting pos of less than zero was not detected.")]
        public void FindPossibleSubstring_InvalidStartPosBeyondLastCharacter_ThrowsArgumentException()
        {
            var mockFinder = new Mock<IPalindromeFinder>();
            var searcher = new PalindromeSearcher(mockFinder.Object);

            searcher.FindPossibleSubstring("12345", 5, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "An end pos less than the start pos was not detected.")]
        public void FindPossibleSubstring_EndPosLowerThanStartPos_ThrowsArgumentException()
        {
            var mockFinder = new Mock<IPalindromeFinder>();
            var searcher = new PalindromeSearcher(mockFinder.Object);

            searcher.FindPossibleSubstring("12345", 3, 2);
        }

        [TestMethod]
        public void FindPossibleSubstring_NoValidPossibleSubstring_ReturnsMinusOne()
        {
            var mockFinder = new Mock<IPalindromeFinder>();
            var searcher = new PalindromeSearcher(mockFinder.Object);

            var result = searcher.FindPossibleSubstring("12345", 0, 4);

            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void FindPossibleSubstring_ValidPossibleSubstring_ReturnsCorrectEndPosition()
        {
            var mockFinder = new Mock<IPalindromeFinder>();
            var searcher = new PalindromeSearcher(mockFinder.Object);

            var result = searcher.FindPossibleSubstring("123123", 0, 4);

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void FindPossibleSubstring_ValidPossibleSubstringOutsideEndPosition_ReturnsMinusOne()
        {
            var mockFinder = new Mock<IPalindromeFinder>();
            var searcher = new PalindromeSearcher(mockFinder.Object);

            var result = searcher.FindPossibleSubstring("123123", 0, 2);

            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void ScanSubstring_NoPalindromes_AddsNoResults()
        {
            var mockFinder = new Mock<IPalindromeFinder>();
            mockFinder.Setup(foo => foo.IsPalindrome(It.IsAny<String>())).Returns(false);
            var searcher = new PalindromeSearcher(mockFinder.Object);
            var results = new List<PalindromeResult>();

            searcher.ScanSubstring("12345", 4, 1, results);

            Assert.AreEqual(0, results.Count);
            mockFinder.Verify(foo => foo.IsPalindrome(It.IsAny<String>()), Times.AtLeastOnce());
        }

        [TestMethod]
        public void ScanSubstring_HasPalindromes_AddsSingleResult()
        {
            var mockFinder = new Mock<IPalindromeFinder>();
            mockFinder.Setup(foo => foo.IsPalindrome(It.IsAny<String>())).Returns(true);
            var searcher = new PalindromeSearcher(mockFinder.Object);
            var results = new List<PalindromeResult>();

            searcher.ScanSubstring("1234321", 4, 1, results);

            Assert.AreEqual(1, results.Count);
            mockFinder.Verify(foo => foo.IsPalindrome(It.IsAny<String>()), Times.Once());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "A null string was not detected.")]
        public void FindPalindromes_NullInputString_ThrowsArgumentException()
        {
            var mockFinder = new Mock<IPalindromeFinder>();
            var searcher = new PalindromeSearcher(mockFinder.Object);

            searcher.FindPalindromes(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "An empty string was not detected.")]
        public void FindPalindromes_EmptyInputString_ThrowsArgumentException()
        {
            var mockFinder = new Mock<IPalindromeFinder>();
            var searcher = new PalindromeSearcher(mockFinder.Object);

            searcher.FindPalindromes(String.Empty);
        }

        [TestMethod]
        public void FindPalindromes_GivenInputExample_FindsAllPalindromes()
        {
            var finder = new PalindromeFinder();
            var searcher = new PalindromeSearcher(finder);

            var results = searcher.FindPalindromes("sqrrqabccbatudefggfedvwhijkllkjihxymnnmzpop");

            Assert.AreEqual(6, results.Count);
            Assert.AreEqual(results[0], new PalindromeResult { Palindrome = "hijkllkjih", StartIndex = 23, EndIndex = 32 });
            Assert.AreEqual(results[1], new PalindromeResult { Palindrome = "defggfed", StartIndex = 13, EndIndex = 20 });
            Assert.AreEqual(results[2], new PalindromeResult { Palindrome = "abccba", StartIndex = 5, EndIndex = 10 });
        }
    }
}
