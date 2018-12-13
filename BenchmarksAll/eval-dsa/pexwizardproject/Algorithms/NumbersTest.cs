// <copyright file="NumbersTest.cs"></copyright>
using System;
using Dsa.Algorithms;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dsa.Algorithms
{
    [PexClass(typeof(Numbers))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class NumbersTest
    {
        [PexMethod]
        public int Factorial(int number)
        {
            int result = Numbers.Factorial(number);
            return result;
        }

        [PexMethod]
        public int Fibonacci(int number)
        {
            int result = Numbers.Fibonacci(number);
            return result;
        }

        [PexMethod]
        public int GreatestCommonDenominator(int first, int second)
        {
            int result = Numbers.GreatestCommonDenominator(first, second);
            return result;
        }

        [PexMethod]
        public bool IsPrime(int number)
        {
            bool result = Numbers.IsPrime(number);
            return result;
        }

        [PexMethod]
        public int MaxValue(Base numberBase, int digits)
        {
            int result = Numbers.MaxValue(numberBase, digits);
            return result;
        }

        [PexMethod]
        public int Power(int baseNumber, int exponent)
        {
            int result = Numbers.Power(baseNumber, exponent);
            return result;
        }

        [PexMethod]
        public int ToBinary(int value)
        {
            int result = Numbers.ToBinary(value);
            return result;
        }

        [PexMethod]
        public string ToHex(int value)
        {
            string result = Numbers.ToHex(value);
            return result;
        }

        [PexMethod]
        public int ToOctal(int value)
        {
            int result = Numbers.ToOctal(value);
            return result;
        }
    }
}
