// <copyright file="Numbers.cs" company="Data Structures and Algorithms">
//   Copyright (C) Data Structures and Algorithms Team.
// </copyright>
// <summary>
//   Implementations of algorithms to solve common numeric and mathematical problems.
//   Extensions methods.
// </summary>
using System;
using System.Globalization;
using System.Text;
using Dsa.Properties;
using Dsa.Utility;
using Microsoft.Pex.Framework;
using Dsa.Algorithms;
using PexAPIWrapper;

namespace Dsa.Algorithms
{
    /// <summary>
    /// Number algorithms.
    /// </summary>
    public static class Numbers
    {
        /// <summary>
        /// Computes the fibonacci number of a positive <see cref="System.Int32"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(1) operation for inputs 0 or 1, O(n) for larger numbers.
        /// </remarks>
        /// <param name="number">Integer to compute the fibonacci number for.</param>
        /// <returns>Fibonacci number for the specified <see cref="Int32"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><strong>number</strong> is less than <strong>0</strong>.</exception>
        public static int Fibonacci(this int number)
        {
            //Guard.OutOfRange(number < 0, "number", Resources.FibonacciLessThanZero);

            switch (number)
            {
                case 0:
                    return 0;
                case 1:
                    return 1;
                default:
                    {
                        //NotpAssume.IsTrue(number > -1 && number <int.MaxValue);
                        int[] fibs = new int[number + 1];
                        //NotpAssume.IsTrue(fibs.Length> 1);
                        fibs[0] = 0;
                        fibs[1] = 1;

                        // populate fibs with fib sequence
                        for (int i = 2; i <= number; i++)
                        {
                            fibs[i] = fibs[i - 1] + fibs[i - 2];
                        }

                        return fibs[number];
                    }
            }
        }

        /// <summary>
        /// Computes the factorial of an <see cref="System.Int32"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(1) operation for inputs less than 2, O(n) for larger numbers.
        /// </remarks>
        /// <param name="number">Integer to compute the factorial of.</param>
        /// <returns>The factorial of the specified <see cref="System.Int32"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><strong>number</strong> is less than <strong>0</strong>.</exception>
        public static int Factorial(this int number)
        {
            //Guard.OutOfRange(number < 0, "number", Resources.FactorialLessThanZero);

            if (number < 2)
            {
                return 1;
            }

            int factorial = 1;
            for (int i = 2; i <= number; i++)
            {
                factorial *= i;
            }

            return factorial;
        }

        /// <summary>
        /// Computes the power of an <see cref="System.Int32"/> to a given exponent.
        /// </summary>
        /// <remarks>
        /// This method is an O(1) method when the exponent is 1; otherwise O(n) for larger exponents.
        /// </remarks>
        /// <param name="baseNumber">Base number.</param>
        /// <param name="exponent">Exponent to use.</param>
        /// <returns>The value of the base raised to the exponent.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><strong>exponent</strong> is less than <strong>0</strong>.</exception>
        public static int Power(int baseNumber, int exponent)
        {
            //Guard.OutOfRange(exponent < 0, "exponent", Resources.PowerExponentLessThanZero);

            if (exponent == 0)
            {
                return 1; // n^0 = 1
            }

            int power = baseNumber;
            while (exponent > 1)
            {
                power *= baseNumber;
                exponent--;
            }

            return power;
        }

        /// <summary>
        /// Computes the greatest common denominator of two <see cref="System.Int32"/>'s.
        /// </summary>
        /// <param name="first">First integer.</param>
        /// <param name="second">Second integer.</param>
        /// <returns>The greatest common denominator of the two <see cref="System.Int32"/>'s.</returns>
        public static int GreatestCommonDenominator(int first, int second)
        {
             
            //return second == 0 ? first : GreatestCommonDenominator(second, first % second);
            if (second == 0)
                return first;
            else{
                //NotpAssume.IsTrue(first != int.MinValue || second != -1);
                return GreatestCommonDenominator(second, first % second);
                }
        }

        /// <summary>
        /// Converts a positive base 10 integer to it's binary counterpart (base 2).
        /// </summary>
        /// <param name="value">Integer to convert to binary form.</param>
        /// <returns>Binary (base 2) representation of value.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><strong>value</strong> is less than<strong>0</strong>.</exception>
        public static int ToBinary(this int value)
        {
            //Guard.OutOfRange(value < 0, "value", Resources.ToBaseNIntNegative);
            StringBuilder sb = new StringBuilder();
            while (value > 0)
            {
                sb.Append(value % 2);
                value /= 2;
            }
            //NotpAssume.IsTrue(sb.ToString().Length > 0 && sb.ToString().Length <= 10); 
            return Int32.Parse(sb.ToString().Reverse(), CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts a positive base 10 integer into it's octal counterpart (base 8).
        /// </summary>
        /// <param name="value">Integer to convert to octal form.</param>
        /// <returns>Octal (base 8) representation of value.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><strong>value</strong> is less than <strong>0</strong>.</exception>
        public static int ToOctal(this int value)
        {
            //Guard.OutOfRange(value < 0, "value", Resources.ToBaseNIntNegative);

            StringBuilder sb = new StringBuilder();
            while (value > 0)
            {
                sb.Append(value % 8);
                value /= 8;
            }
            //NotpAssume.IsTrue(sb.ToString().Length > 0 && sb.ToString().Length < 10); 
            return Int32.Parse(sb.ToString().Reverse(), CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts a positive base 10 integer into it's hexadecimal counterpart (base 16).
        /// </summary>
        /// <param name="value">Integer to convert to hexadecimal form.</param>
        /// <returns>Hexadecimal (base 16) representation of value.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><strong>value</strong> is less than <strong>0</strong>.</exception>
        public static string ToHex(this int value)
        {
            //Guard.OutOfRange(value < 0, "value", Resources.ToBaseNIntNegative);

            StringBuilder sb = new StringBuilder();
            while (value > 0)
            {
                int result = value % 16;
                if (result < 10)
                {
                    sb.Append(result);
                }
                else
                {
                    sb.Append(GetHexSymbol(result));
                }

                value /= 16;
            }

            return sb.ToString().Reverse();
        }

        /// <summary>
        /// Determines whether or not an integer is a prime number.
        /// </summary>
        /// <param name="number">Number to check is a prime.</param>
        /// <returns>True if the number is a prime; otherwise false.</returns>
        public static bool IsPrime(this int number)
        {
            // smallest prime is 2
            if (number < 2)
            {
                return false;
            }

            // most effecient worst case, if number-1 * sqrt(number) != number then we have a prime
            int innerLoopBound = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 1; i < number; i++)
            {
                for (int j = 1; j <= innerLoopBound; j++)
                {
                    if (i * j == number)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Computes the maximum value that a given number base can hold for N digits.
        /// </summary>
        /// <param name="numberBase">Number base to use.</param>
        /// <param name="digits">Number of digits.</param>
        /// <returns>Maximum value for the given number base with the number of digits specified.</returns>
        public static int MaxValue(Base numberBase, int digits)
        {
            int baseNumber = (int)numberBase;

            // to get the max value for a base: B^n - 1 where B is the base, n is the number of digits
            return Power(baseNumber, digits) - 1;
        }

        /// <summary>
        /// Gets char symbol for hex numbers 10 .. 15 (A .. F).
        /// </summary>
        /// <param name="result">Integer to get hex symbol for.</param>
        /// <returns>Hex symbol for that number.</returns>
        private static char GetHexSymbol(int result)
        {
            char symbol = ' ';

            // match relevent symbol with result
            switch (result)
            {
                case 10:
                    symbol = 'A';
                    break;
                case 11:
                    symbol = 'B';
                    break;
                case 12:
                    symbol = 'C';
                    break;
                case 13:
                    symbol = 'D';
                    break;
                case 14:
                    symbol = 'E';
                    break;
                case 15:
                    symbol = 'F';
                    break;
            }

            return symbol;
        }
    }
}
