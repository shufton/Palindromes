using System;
using Palindromes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PalindromesTests
{
    [TestClass]
    public class PalindromeFinderTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "A null string was not detected.")]
        public void IsPalindrome_NullString_ThrowsArgumentException()
        {
            var pf = new PalindromeFinder();

            pf.IsPalindrome(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "An empty string was not detected.")]
        public void IsPalindrome_EmptyString_ThrowsArgumentException()
        {
            var pf = new PalindromeFinder();

            pf.IsPalindrome(String.Empty);
        }

        [TestMethod]
        public void IsPalindrome_NonPalindrome_ReturnsFalse()
        {
            var pf = new PalindromeFinder();

            var result = pf.IsPalindrome("AOIFSJGOADIFJGOADIFJ");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsPalindrome_CloseButNonPalindrome_ReturnsFalse()
        {
            var pf = new PalindromeFinder();

            var result = pf.IsPalindrome("ASDFGHJKLLJHGFDSA");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsPalindrome_SingleCharacterString_ReturnsTrue()
        {
            var pf = new PalindromeFinder();

            var result = pf.IsPalindrome("S");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsPalindrome_ActualPalindromeOfSingleCharacter_ReturnsTrue()
        {
            var pf = new PalindromeFinder();

            var result = pf.IsPalindrome("SSSSSSSSSSSSSSSSSSS");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsPalindrome_ActualPalindromeWithEvenLength_ReturnsTrue()
        {
            var pf = new PalindromeFinder();

            var result = pf.IsPalindrome("STTS");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsPalindrome_ActualPalindromeWithOddLength_ReturnsTrue()
        {
            var pf = new PalindromeFinder();

            var result = pf.IsPalindrome("STUTS");

            Assert.IsTrue(result);
        }
    }
}
