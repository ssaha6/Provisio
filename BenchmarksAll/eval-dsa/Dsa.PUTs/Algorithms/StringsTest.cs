// <copyright file="StringsTest.cs"></copyright>
using System;
using Dsa.Algorithms;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Settings;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
namespace Dsa.Algorithms
{
    /// <summary>This class contains parameterized unit tests for Strings</summary>
    [PexClass(typeof(Strings))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class StringsTest
    {
        /// <summary>Test stub for Any(String, String)</summary>
        [PexMethod]
        public int Any(string word, string match)
        {
           
           Func<string, string, bool> CharInAnotherString = (_word, _match) =>
            {
                if (_match == null)
                    return false;
                foreach (char s in _match)
                {
                    if (!char.IsWhiteSpace(s) && _word.Contains(s))
                        return true;
                }
                return false;
            };
            //match, word
            Func<string, string, bool> CharInAnotherStringBeforeOrAtIndex = (_s1, _s2) =>
            {
                /*foreach (char s in _s2)
                {
                    if (!char.IsWhiteSpace(s) && _s1.Contains(s))
                        return true;
                }*/
                if (_s2.TrimStart().Length == 0)
                    return true;
                if (_s1.Contains(_s2.TrimStart()[0]))
                    return true;
                return false;
            };
            Func<string, bool> EndWithWhiteSpace = (_word) =>
            {
                if (_word == null)
                    return false;
                bool suffixIsWhite = false;
                for (int i = 0; i < _word.Length; i++)
                {
                    if (char.IsWhiteSpace(_word[i]))
                        suffixIsWhite = true;
                    else
                        suffixIsWhite = false;

                }
                return suffixIsWhite;



            };
            Func<string, bool> AllIsWhiteSpace = (_word) =>
            {
                int allWhite = 0;
                for (int i = 0; i < _word.Length; i++)
                {
                    if (char.IsWhiteSpace(_word[i]))
                        allWhite++;

                }
                if (_word.Length == 0)
                    return false;
                if (allWhite == _word.Length)
                    return true;
                return false;
            };
            //Isolate one exception
            //PexAssume.IsTrue(word != null);
            //PexAssume.IsTrue(match != null/* || word.Length == 0 || AllIsWhiteSpace(word) == true*/);
            //PexAssume.IsTrue(EndWithWhiteSpace(word) == false || CharInAnotherString(word, match) == true);
            //PexAssume.IsTrue(EndWithWhiteSpace(match) == false || CharInAnotherStringBeforeOrAtIndex(match, word) == true || word.Length == 0);


            int result = Strings.Any(word, match);
            return result;
            // TODO: add assertions to method StringsTest.Any(String, String)
        }

        /// <summary>Test stub for IsPalindrome(String)</summary>
        [PexMethod(MaxRuns=100)]
        public bool IsPalindrome(string word)
        {
            
            //NullRefernce:
            PexAssume.IsTrue(word != null);
            //IndexOutOfRange:
            //PexAssume.TrueForAny(0, word.Length, i => !char.IsWhiteSpace(word[i]) && !char.IsPunctuation(word[i]) && !char.IsSymbol(word[i])); 
            bool result = Strings.IsPalindrome(word);
            return result;
            // TODO: add assertions to method StringsTest.IsPalindrome(String)
        }

        /// <summary>Test stub for RepeatedWordCount(String)</summary>
        [PexMethod]
        public int RepeatedWordCount(string value)
        {
            int result = Strings.RepeatedWordCount(value);
            return result;
            // TODO: add assertions to method StringsTest.RepeatedWordCount(String)
        }

        /// <summary>Test stub for Reverse(String)</summary>
        [PexMethod]
        public string Reverse(string value)
        {
            string result = Strings.Reverse(value);
            return result;
            // TODO: add assertions to method StringsTest.Reverse(String)
        }

        /// <summary>Test stub for ReverseWords(String)</summary>
        [PexMethod(MaxRuns = 100, TestEmissionFilter = PexTestEmissionFilter.All)]
        public string ReverseWords(string value)
        {
            //PexAssume.IsTrue(value != null); -> NullReference
            //PexAssume.TrueForAny(0, value.Length, i => char.IsWhiteSpace(value[i]) == false ); -> IndexOutofRange
            //PexAssume.TrueForAll(0, value.Length, i => char.IsWhiteSpace(value[i]) == true); negated precondition -> IndexOutOfRange
            string result = Strings.ReverseWords(value);
            return result;
            // TODO: add assertions to method StringsTest.ReverseWords(String)
        }

        /*** Seed test for ReverseWords(string value) ***/
        [TestMethod]
        public void seedReverseWords()
        {
            string seed = "\t\t\t\t\t\t\t\t"; // string of length 8
            ReverseWords(seed);
        }

        /// <summary>Test stub for Strip(String)</summary>
        [PexMethod]
        public string Strip(string value)
        {
            string result = Strings.Strip(value);
            return result;
            // TODO: add assertions to method StringsTest.Strip(String)
        }

        /// <summary>Test stub for WordCount(String)</summary>
        [PexMethod]
        public int WordCount(string value)
        {
            int result = Strings.WordCount(value);
            return result;
            // TODO: add assertions to method StringsTest.WordCount(String)
        }
    }
}
