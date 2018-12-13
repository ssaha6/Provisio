// <copyright file="Strings.cs" company="Data Structures and Algorithms">
//   Copyright (C) Data Structures and Algorithms Team.
// </copyright>
// <summary>
//   Algorithms to solve common string problems, implemented as extension methods.
// </summary>
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Dsa.Utility;
using Microsoft.Pex.Framework;

namespace Dsa.Algorithms
{
    /// <summary>
    /// String algorithms.
    /// </summary>
    public static class Strings
    {
        /// <summary>
        /// Reverses the characters of a <see cref="string"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(n) operation where n is the number of chars in the string to reverse.
        /// </remarks>
        /// <param name="value"><see cref="String"/> to reverse the characters of.</param>
        /// <returns><see cref="String"/> with characters in reverse order.</returns>
        /// <exception cref="ArgumentNullException"><strong>value</strong> is <strong>null</strong>.</exception>
        public static string Reverse(this string value)
        {
            //Guard.ArgumentNull(value, "value");

            char[] buffer = new char[value.Length]; 

            // place each char from value in its new location within the buffer
            for (int i = value.Length - 1, j = 0; i >= 0; i--, j++)
            {
                buffer[j] = value[i]; 
            }

            return new string(buffer);
        }

        /// <summary>
        /// Returns the index of the first character in the match <see cref="string"/> that matches any character in the word <see cref="string"/>.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method is an O(n^2) operation.
        /// </para>
        /// <para>
        /// Case sensitive, whitespace is ignored.
        /// </para>
        /// </remarks>
        /// <param name="word">Word to run the any match against.</param>
        /// <param name="match">The <see cref="string"/> of characters to match against the word.</param>
        /// <returns>
        /// A non-negative <see cref="Int32"/> index that represents the location of the first character in the match <see cref="string"/> that was 
        /// also in the word <see cref="string"/>; otherwise -1 if no characters in the match <see cref="string"/> matched any of the characters in the 
        /// word <see cref="string"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><strong>word</strong> is <strong>null</strong> or <strong>match</strong> is <strong>null</strong>.</exception>
        public static int Any(this string word, string match)
        {
            //Guard.ArgumentNull(word, "word");
            //Guard.ArgumentNull(match, "match");            
            for (int i = 0; i < word.Length; i++)
            {
                while (char.IsWhiteSpace(word[i]))
                {
                    i++;
                }

                // locate, if possible index of first matching character in both strings
                for (int j = 0; j < match.Length; j++)
                {
                    while (char.IsWhiteSpace(match[j]))
                    {
                        j++;
                    }

                    if (match[j] == word[i])
                    {
                        return j;
                    }
                }
            }

            return -1;
        }

        /// <summary>
        /// Detects whether or not the input string is a palindrome.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method is an O(n) operation where n is the number of chars to traverse in order to verify the string is a palindrome.
        /// </para>
        /// <para>
        /// Case, whitespace, punctuation and symbols are ignored.
        /// </para>
        /// </remarks>
        /// <param name="word"><see cref="String"/> that you want to verify is a palindrome.</param>
        /// <returns>True if the string is a palindrome; otherwise false.</returns>
        /// <exception cref="ArgumentNullException"><strong>word</strong> is <strong>null</strong>.</exception>
        public static bool IsPalindrome(this string word)
        {
            //Guard.ArgumentNull(word, "word");
        

            word = word.Strip().ToUpper(CultureInfo.InvariantCulture); 
            int left = 0;
            int right = word.Length - 1;

            // march in from the left and right bounds of the string
            while (word[left] == word[right] && left < right) 
            {
                left++;
                right--;
            }

            // if the two chars we are pointing to are equal we have a palindrome
            return word[left] == word[right];
        }

        /// <summary>
        /// Takes a <see cref="string"/> and strips it of whitespace, punctuation and symbols returning the resulting stripped <see cref="string"/>.
        /// </summary>
        /// <remarks>
        /// This methods is an O(n) operation where n is the number of chars in the string to strip.
        /// </remarks>
        /// <param name="value"><see cref="String"/> to strip.</param>
        /// <returns>The stripped version of the <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException"><strong>value</strong> is <strong>null</strong>.</exception>
        public static string Strip(this string value)
        {
            //Guard.ArgumentNull(value, "value");

            StringBuilder sb = new StringBuilder(); 
            for (int i = 0; i < value.Length; i++)
            {
                if (!char.IsWhiteSpace(value[i]) && !char.IsPunctuation(value[i]) && !char.IsSymbol(value[i]))
                {
                    sb.Append(value[i]);
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Counts the number of words in a <see cref="string"/>.
        /// </summary>
        /// <remarks>
        /// This is an O(n) operation where n is the number of chars in the string to count the words of.
        /// </remarks>
        /// <param name="value">The <see cref="string"/> to count the words of.</param>
        /// <returns>An <see cref="Int32"/> indicating the number of words in the <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException"><strong>value</strong> is <strong>null</strong>.</exception>
        public static int WordCount(this string value)
        {
            //Guard.ArgumentNull(value, "value");
            
            bool inWord = true; 
            int wordCount = 0; 
            int index = 0;
            while (char.IsWhiteSpace(value[index]) && index < value.Length - 1)
            {
                index++;
            }

            // check to see if value was only whitespace, if it was then there are 0 words
            if (index == value.Length - 1 && char.IsWhiteSpace(value[index]))
            {
                return 0;
            }

            for (; index < value.Length; index++)
            {
                if (char.IsWhiteSpace(value[index]))
                {
                    // skip all consecutive whitespace
                    while (char.IsWhiteSpace(value[index]) && index < value.Length - 1)
                    {
                        index++;
                    }

                    inWord = false; // as we are hitting whitespace we are not in a word
                    wordCount++; // I assume that words are delimited by whitespace, thus wordCount should be incremented
                }
                else
                {
                    inWord = true; 
                }
            }

            // the last word may of not been followed by whitespace, in that case increment wordCount
            if (inWord)
            {
                wordCount++; 
            }

            return wordCount;
        }

        /// <summary>
        /// Reverses the words of a string.
        /// </summary>
        /// <remarks>
        /// This is an O(n) operation where n is the number of chars in the string to reverse the words of.
        /// </remarks>
        /// <param name="value"><see cref="String"/> to reverse the words of.</param>
        /// <returns><see cref="String"/> with original words in reverse order.</returns>
        /// <exception cref="ArgumentNullException"><strong>value</strong> is <strong>null</strong>.</exception>
        public static string ReverseWords(this string value)
        {
            //Guard.ArgumentNull(value, "value");

            int last = value.Length - 1;
            int start = last; // will be used to mark the beginning of a word in the string
            StringBuilder sb = new StringBuilder();
            while (last >= 0)
            {
                while (start >= 0 && char.IsWhiteSpace(value[start]))
                {
                    start--;
                }

                last = start; 

                // march the start index down to the index before a word starts
                while (start >= 0 && !char.IsWhiteSpace(value[start]))
                {
                    start--;
                }

                for (int i = start + 1; i < last + 1; i++)
                {
                    sb.Append(value[i]);
                }

                // add whitespace to delimit the words in sb if this is not the last word. Whitespace at the beginning of a string is cut.
                if (start > 0)
                {
                    sb.Append(' ');
                }

                // point last to the index of the last char in the next word
                last = start - 1;
                start = last;
            }

            // check to see if we have added some whitespace at the right of sb if so just cut the sb length by 1
            if (char.IsWhiteSpace(sb[sb.Length - 1]))
            {
                sb.Length = sb.Length - 1;
            }

            return sb.ToString();
        }

        /// <summary>
        /// Counts the number of words that are repeated within a string.
        /// </summary>
        /// <remarks>
        /// This method is an O(n) operation where n is the number of words in the string delimited by whitespace.
        /// </remarks>
        /// <param name="value"><see cref="String"/> to count repeated words of.</param>
        /// <returns>Number of words repeated in the given string.</returns>
        /// <exception cref="ArgumentNullException"><strong>value</strong> is <strong>null</strong>.</exception>
        public static int RepeatedWordCount(this string value)
        {
            //Guard.ArgumentNull(value, "value");

            string[] words = value.Split(' ');
            HashSet<string> uniques = new HashSet<string>();
            foreach (string s in words)
            {
                uniques.Add(s.Strip());
            }

            return words.Length - uniques.Count;
        }
    }
}