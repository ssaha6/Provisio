using System;
using Dsa.Algorithms;
using NUnit.Framework;
//using NUnit.Framework.Extensions;

namespace Dsa.Test.Algorithms
{
    /// <summary>
    /// Numbers tests.
    /// </summary>
    [TestFixture]
    public sealed class NumbersTest
    {
        ///// <summary>
        ///// Check to see that calling Fibonacci algorithm returns the correct value.
        ///// </summary>
        //[RowTest]
        //[Row(0, 0), Row(1, 1), Row(1, 2), Row(2,3), Row(3, 4), Row(5, 5), Row(8, 6), Row(13, 7)]
        //public void FibonacciTest(int expected, int actual)
        //{
        //    Assert.AreEqual(expected, actual.Fibonacci());
        //}

        ///// <summary>
        ///// Check to see that the correct exception is thrown when fibonacci is called with a number less than 0.
        ///// </summary>
        //[Test]
        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
        //public void FibonacciNumberLessThanZeroTest()
        //{
        //    (-1).Fibonacci();
        //}

        ///// <summary>
        ///// Check to see that calling Factorial algorithm returns the correct value.
        ///// </summary>
        //[RowTest]
        //[Row(1, 0), Row(1, 1), Row(2, 2), Row(6, 3), Row(24, 4), Row(120, 5), Row(720, 6)]
        //public void FactorialTest(int expected, int actual)
        //{
        //    Assert.AreEqual(expected, actual.Factorial());
        //}

        ///// <summary>
        ///// Check to see that the correct exception is thrown when calling Factorial using a negative integer.
        ///// </summary>
        //[Test]
        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
        //public void FactorialNumberLessThanZeroTest()
        //{
        //    (-1).Factorial();
        //}

        ///// <summary>
        ///// Check to see that the power method returns the correct value.
        ///// </summary>
        //[RowTest]
        //[Row(1, 0, 0), Row(4, 2, 2), Row(243, 3, 5), Row(1024, 2, 10), Row(4, -2, 2)]
        //public void PowerNotZeroTest(int expected, int baseNumber, int power)
        //{
        //    Assert.AreEqual(expected, Numbers.Power(baseNumber, power));
        //}
        
        ///// <summary>
        ///// Check to see that the correct exception is thrown when the exponent is negative.
        ///// </summary>
        //[Test]
        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
        //public void PowerExponentLessThanZeroTest()
        //{
        //    Numbers.Power(2, -1);
        //}

        ///// <summary>
        ///// Check to see that calling the Gcd method results in the expected value being returned.
        ///// </summary>
        //[RowTest]
        //[Row(1, 9, 4), Row(3, 3, 9), Row(5, 10, 5), Row(1, 5, 12), Row(5, -10, 5), Row(5, 5, -10)]
        //public void GcdTest(int expected, int first, int second)
        //{
        //    Assert.AreEqual(expected, Numbers.GreatestCommonDenominator(first, second));
        //}

        ///// <summary>
        ///// Check to see that the integer returned is correct.
        ///// </summary>
        //[Test]
        //public void ToBaseTwoTest()
        //{
        //    const int actual = 23;

        //    Assert.AreEqual(10111, actual.ToBinary());
        //}

        ///// <summary>
        ///// Check to see that the correct exception is raised when the int to convert to binary is negative.
        ///// </summary>
        //[Test]
        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
        //public void ToBaseTwoNegativeIntTest()
        //{
        //    const int actual = -1;

        //    actual.ToBinary();
        //}

        ///// <summary>
        ///// Check to see that the correct value is returned when converting a base 10 integer to
        ///// it's base 8 counterpart.
        ///// </summary>
        //[Test]
        //public void ToOctalTest()
        //{
        //    const int actual = 18;

        //    Assert.AreEqual(22, actual.ToOctal());
        //}

        ///// <summary>
        ///// Check to see that the correct exception is thrown when the int to covert to octal is negative.
        ///// </summary>
        //[Test]
        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
        //public void ToOctalNegativeIntTest()
        //{
        //    const int actual = -1;

        //    actual.ToOctal();
        //}

        ///// <summary>
        ///// Check to see that the correct string is returned when converting a base 10 integer its base 16
        ///// equivalent.
        ///// </summary>
        //[RowTest]
        //[Row("F9B3", 63923), Row("93A", 2362), Row("383D", 14397), Row("DE", 222), Row("ABC7", 43975)]
        //public void ToHexTest(string expected, int actual)
        //{
        //    Assert.AreEqual(expected, actual.ToHex());
        //}

        ///// <summary>
        ///// Check to see the correct exception is raised when the value provided is negative.
        ///// </summary>
        //[Test]
        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
        //public void ToHexNegativeIntTest()
        //{
        //    const int actual = -1;

        //    actual.ToHex();
        //}

        ///// <summary>
        ///// Check to see that the correct value is returned when checking a few numbers if they are primes.
        ///// </summary>
        //[RowTest]
        //[Row(false, 1), Row(true, 2), Row(true, 3), Row(false, 4), Row(true, 5), Row(false, 6), Row(true, 7), Row(false, 8)]
        //[Row(false, 9), Row(false, 10), Row(true, 11), Row(false, 12), Row(true, 13), Row(false, 14), Row(false, 15)]
        //public void IsPrimeTest(bool expected, int actual)
        //{
        //    Assert.AreEqual(expected, actual.IsPrime());
        //}

        ///// <summary>
        ///// Check to see that the correct value is returned when the number of digits is less
        ///// than 1.
        ///// </summary>
        //[Test]
        //public void MaxValueDigitsLessThanZeroTest()
        //{
        //    Assert.AreEqual(0, Numbers.MaxValue(Base.Binary, 0));
        //}

        ///// <summary>
        ///// Check to see that the correct max value is returned.
        ///// </summary>
        //[Test]
        //public void MaxValueHexadecimalTest()
        //{
        //    Assert.AreEqual(255, Numbers.MaxValue(Base.Hexadecimal, 2));
        //}

        ///// <summary>
        ///// Check to see correct max value for binary is returned.
        ///// </summary>
        //[Test]
        //public void MaxValueBinaryTest()
        //{
        //    Assert.AreEqual(1023, Numbers.MaxValue(Base.Binary, 10));
        //}

        ///// <summary>
        ///// Check to see that the correct max value for octal is returned.
        ///// </summary>
        //[Test]
        //public void MaxValueOctalTest()
        //{
        //    Assert.AreEqual(32767, Numbers.MaxValue(Base.Octal, 5));
        //}

        ///// <summary>
        ///// Check to see that the correct max value for decimal is returned.
        ///// </summary>
        //[Test]
        //public void MaxValueDecimalTest()
        //{
        //    Assert.AreEqual(9999, Numbers.MaxValue(Base.Decimal, 4));
        //}
    }
}