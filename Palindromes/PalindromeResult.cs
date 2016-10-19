using System;
using System.Diagnostics;

namespace Palindromes
{
    [DebuggerDisplay("Palindrome={Palindrome}, Length={Palindrome.Length}, StartIndex={StartIndex}, EndIndex={EndIndex}")]
    internal class PalindromeResult : IComparable<PalindromeResult>, IComparable
    {
        public String Palindrome { get; set; }
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }
        public int CompareTo(PalindromeResult other)
        {
            if (0 == Palindrome.CompareTo(other.Palindrome))
            {
                return StartIndex.CompareTo(other.StartIndex);
            }

            // We reverse the comaprsion for length, as longer means a better palindrome
            // so should appear first
            var comparison = other.Palindrome.Length.CompareTo(Palindrome.Length);
            return 0 == comparison ? other.StartIndex.CompareTo(StartIndex) : comparison;
        }

        public int CompareTo(object obj)
        {
            if (obj is PalindromeResult)
                return CompareTo(obj as PalindromeResult);

            throw new ArgumentException("Cannot compare a PalindromeResult with any other type", nameof(obj));
        }


        // Define the is greater than operator.
        public static bool operator >(PalindromeResult operand1, PalindromeResult operand2)
        {
            return operand1.CompareTo(operand2) == 1;
        }

        // Define the is less than operator.
        public static bool operator <(PalindromeResult operand1, PalindromeResult operand2)
        {
            return operand1.CompareTo(operand2) == -1;
        }

        // Define the is greater than or equal to operator.
        public static bool operator >=(PalindromeResult operand1, PalindromeResult operand2)
        {
            return operand1.CompareTo(operand2) >= 0;
        }

        // Define the is less than or equal to operator.
        public static bool operator <=(PalindromeResult operand1, PalindromeResult operand2)
        {
            return operand1.CompareTo(operand2) <= 0;
        }

        public override bool Equals(object obj)
        {
            if (obj is PalindromeResult)
            {
                var other = obj as PalindromeResult;
                return Palindrome.Equals(other.Palindrome)
                       && StartIndex.Equals(other.StartIndex)
                       && EndIndex.Equals(other.EndIndex);
            }

            throw new ArgumentException("Cannot compare to anything but a PalindromeResult", nameof(obj));
        }

        public override int GetHashCode()
        {
            return Palindrome.GetHashCode() ^ StartIndex.GetHashCode() ^ EndIndex.GetHashCode();
        }

        public override string ToString()
        {
            return
                String.Format(
                    $"Palindrome={Palindrome}, Length={Palindrome.Length}, StartIndex={StartIndex}, EndIndex={EndIndex}");
        }
    }
}
