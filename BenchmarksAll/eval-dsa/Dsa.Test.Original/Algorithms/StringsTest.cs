using System;
using Dsa.Algorithms;
using NUnit.Framework;

namespace Dsa.Test.Algorithms
{
    /// <summary>
    /// Tests for the Strings algorithms.
    /// </summary>
    [TestFixture]
    public sealed class StringsTest 
    {
        /// <summary>
        /// Check to see that the resulting string returned from Reverse is that expected.
        /// </summary>
        [Test]
        public void ReverseTest() 
        {
            const string s = "Granville";
            string actual = s.Reverse();

            Assert.AreEqual("ellivnarG", actual);
        }

        /// <summary>
        /// Check to see that an empty string is returned when passing in an empty string.
        /// </summary>
        [Test]
        public void ReverseEmptyStringTest()
        {
            const string s = "";

            Assert.AreEqual("", s.Reverse());
        }

        /// <summary>
        /// Check to see that the correct string is returned from a call to Reverse on a string of a single char.
        /// </summary>
        [Test]
        public void ReverseStringOfLength1Test()
        {
            const string s = "t";

            Assert.AreEqual("t", s.Reverse());
        }

        /// <summary>
        /// Check to see that calling Reverse on a null string results in the corrext exception being raised.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReverseNullStringTest()
        {
            const string s = null;

            s.Reverse();
        }

        /// <summary>
        /// Check to see that the correct index is returned when calling Any.
        /// </summary>
        [Test]
        public void AnyMatchingCharTest()
        {
            const string s = "test";

            Assert.AreEqual(2, s.Any("prtest"));
        }

        /// <summary>
        /// Check to see that the correct value is returned by any when the match string chars 
        /// have no match with any of that in the word.
        /// </summary>
        [Test]
        public void AnyNoMatchingCharTest()
        {
            const string s = "test";

            Assert.AreEqual(-1, s.Any("bbc"));
        }

        /// <summary>
        /// Check to see that the correct exception is raised when the word is null.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AnyWordNullTest()
        {
            const string s = null;

            s.Any("test");
        }

        /// <summary>
        /// Check to see that the correct exception is raised when the match is null.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AnyMatchNullException()
        {
            const string s = "test";

            s.Any(null);
        }

        /// <summary>
        /// Test to see that whitespace is ignored in both the word and match strings.
        /// </summary>
        [Test]
        public void AnyWhiteSpaceTest() 
        {
            const string first = "   test";
            const string second = "Gra as asdf  asdf";

            Assert.AreEqual(4, first.Any("   pters"));
            Assert.AreEqual(13, second.Any("T kf   q w   r fg"));
        }

        /// <summary>
        /// Check to see that a single word that is a palindrome returns true.
        /// </summary>
        [Test]
        public void IsPalindromeSingleWordTest()
        {
            const string actual = "mum";

            Assert.IsTrue(actual.IsPalindrome());
        }

        /// <summary>
        /// Check to see that the IsPalindrome method ignores case when testing for a palindrome.
        /// </summary>
        [Test]
        public void IsPalindromeCaseInsensitiveTest()
        {
            const string actual = "Madam";

            Assert.IsTrue(actual.IsPalindrome());
        }

        /// <summary>
        /// Check to see that a string comprising of a single char is a palindrome.
        /// </summary>
        [Test]
        public void IsPalindromeSingleCharTest()
        {
            const string actual = "m";

            Assert.IsTrue(actual.IsPalindrome());
        }

        /// <summary>
        /// Check to see that calling IsPalindrome with a null string results in the expected exception being thrown.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsPalindromeNullStringTest()
        {
            const string actual = null;

            actual.IsPalindrome();
        }

        /// <summary>
        /// Check to see that a string that has whitespace and punctuation is ignored.
        /// </summary>
        [Test]
        public void IsPalindromePuncAndWhitespaceIgnoredTest()
        {
            const string actual = "Are we not drawn onward, we few, drawn onward to new era?";

            Assert.IsTrue(actual.IsPalindrome());
        }

        /// <summary>
        /// Check to see that calling strip results in the expected string.
        /// </summary>
        [Test]
        public void StripTest()
        {
            const string actual = "asdf!!?*    p $$£";

            Assert.AreEqual("asdfp", actual.Strip());
        }

        /// <summary>
        /// Check to see that calling strip with a null string results in the expected exception being thrown.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StripNullStringTest()
        {
            const string actual = null;

            actual.Strip();
        }

        /// <summary>
        /// Check to see that WordCount returns the correct value.
        /// </summary>
        [Test]
        public void WordCountTest()
        {
            const string actual = "The boat is in";

            Assert.AreEqual(4, actual.WordCount());
        }

        /// <summary>
        /// Check to see that whitespace is ignored when counting words.
        /// </summary>
        [Test]
        public void WordCountWhitespaceTest()
        {
            const string actual = "   I ate pie    ";

            Assert.AreEqual(3, actual.WordCount());
        }

        /// <summary>
        /// Check to make sure that a string with nothing but whitespace returns the correct value.
        /// </summary>
        [Test]
        public void WordCountPureWhiteSpace()
        {
            const string actual = "      ";

            Assert.AreEqual(0, actual.WordCount());
        }

        /// <summary>
        /// Check to see that a null string raises the correct exception.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WordCountNullArgTest()
        {
            const string actual = null;

            actual.WordCount();
        }

        /// <summary>
        /// Check to see that the words of the string are reversed correctly.
        /// </summary>
        [Test]
        public void ReverseWordsTest()
        {
            Assert.AreEqual("day dad my", "my dad day".ReverseWords());
            Assert.AreEqual("belly beer a home went then and pop ate I", "I ate pop and then went home a beer belly".ReverseWords());
        }

        /// <summary>
        /// Check to see that any amount of whitespace doesn't affect the reverse words algorithm.  The whitespace is ignored.
        /// </summary>
        [Test]
        public void ReverseWordsWhiteSpaceTest()
        {
            Assert.AreEqual("belly beer a home went then and pop ate I", 
                            "    I ate         pop and then  went home a   beer belly    ".ReverseWords());
        }

        /// <summary>
        /// Check to see that the correct exception is thrown when calling reverse words on a null string.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReverseWordsStringNullTest()
        {
            const string s = null;

            s.ReverseWords();
        }

        /// <summary>
        /// Check to see that the correct value is returned.
        /// </summary>
        [Test]
        public void RepeatedWordCountTest()
        {
            const string actual = "Granville went to the market but Granville has yet to see the light";

            Assert.AreEqual(3, actual.RepeatedWordCount());
        }

        /// <summary>
        /// Check to see that the correct exception is thrown when the string is null.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RepeatedWordCountStringNullTest()
        {
            const string actual = null;

            actual.RepeatedWordCount();
        }

        /// <summary>
        /// Check to see that words followed immediatley with any kind of punctuation is removed so a more
        /// accurate count of repeated words can be done, e.g. Granville Granville! are both the same word but the latter
        /// has trailing punctuation that should be removed.
        /// </summary>
        [Test]
        public void RepeatedWordCountWithPunctuationTest()
        {
            const string s = "Granville is hopeless. But is still persisting though! poor Granville!";

            Assert.AreEqual(2, s.RepeatedWordCount());
        }
    }
}