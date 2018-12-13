// <copyright file="StringsTest.cs"></copyright>
using System;
using Dsa.Algorithms;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dsa.Algorithms
{
    [PexClass(typeof(Strings))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class StringsTest
    {
        [PexMethod]
        public int Any(string word, string match)
        {
            int result = Strings.Any(word, match);
            return result;
        }

        [PexMethod]
        public bool IsPalindrome(string word)
        {
            bool result = Strings.IsPalindrome(word);
            return result;
        }

        [PexMethod]
        public int RepeatedWordCount(string value)
        {
            int result = Strings.RepeatedWordCount(value);
            return result;
        }

        [PexMethod]
        public string Reverse(string value)
        {
            string result = Strings.Reverse(value);
            return result;
        }

        [PexMethod]
        public string ReverseWords(string value)
        {
            string result = Strings.ReverseWords(value);
            return result;
        }

        [PexMethod]
        public string Strip(string value)
        {
            string result = Strings.Strip(value);
            return result;
        }

        [PexMethod]
        public int WordCount(string value)
        {
            int result = Strings.WordCount(value);
            return result;
        }
    }
}
