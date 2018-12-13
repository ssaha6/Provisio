// <copyright file="NumbersTest.cs"></copyright>
using System;
using Dsa.Algorithms;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Microsoft.Pex.Framework.Settings;
using PexAPIWrapper;

namespace Dsa.PUTs
{
    /// <summary>This class contains parameterized unit tests for Numbers</summary>
    [PexClass(typeof(Numbers))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class NumbersTest
    {
        /// <summary>Test stub for Factorial(Int32)</summary>
        //[PexMethod]
        //public int Factorial(int number)
        //{
        //    int result = Numbers.Factorial(number);
        //    return result;
        //    // TODO: add assertions to method NumbersTest.Factorial(Int32)
        //}

        /// <summary>Test stub for Fibonacci(Int32)</summary>
        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public int PUT_Fibonacci(int number)
        {
            AssumePrecondition.IsTrue(!(  ((!(number <= -1)) && ((number <= 248))) ));
            PexObserve.ValueForViewing("$input_number", number);
            int result = Numbers.Fibonacci(number);
            return result;
            // TODO: add assertions to method NumbersTest.Fibonacci(Int32)
        }
        /*[TestMethod]
        public void testFib()
        {
            this.PUT_Fibonacci(249);
        }*/

        /// <summary>Test stub for GreatestCommonDenominator(Int32, Int32)</summary>
        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public int PUT_GreatestCommonDenominator(int first, int second)
        {
            PexObserve.ValueForViewing("$input_first", first);
            PexObserve.ValueForViewing("$input_second", second);

            AssumePrecondition.IsTrue((-first + -second <= 0));            
            int result = Numbers.GreatestCommonDenominator(first, second);
            return result;
            // TODO: add assertions to method NumbersTest.GreatestCommonDenominator(Int32, Int32)
        }

        /*[TestMethod]
        public void testGCD()
        {
            this.PUT_GreatestCommonDenominator(int.MaxValue,int.MinValue);
        }*/
        /// <summary>Test stub for IsPrime(Int32)</summary>
        //[PexMethod]
        //public bool IsPrime(int number)
        //{
        //    bool result = Numbers.IsPrime(number);
        //    return result;
        //    // TODO: add assertions to method NumbersTest.IsPrime(Int32)
        //}

        /// <summary>Test stub for MaxValue(Base, Int32)</summary>
        //[PexMethod]
        //public int MaxValue(Base numberBase, int digits)
        //{
        //    int result = Numbers.MaxValue(numberBase, digits);
        //    return result;
        //    // TODO: add assertions to method NumbersTest.MaxValue(Base, Int32)
        //}

        /// <summary>Test stub for Power(Int32, Int32)</summary>
        //[PexMethod]
        //public int Power(int baseNumber, int exponent)
        //{
        //    int result = Numbers.Power(baseNumber, exponent);
        //    return result;
            // TODO: add assertions to method NumbersTest.Power(Int32, Int32)
        //}

        
        /// <summary>Test stub for ToBinary(Int32)</summary>
        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public int PUT_ToBinary(int value)
        {

            AssumePrecondition.IsTrue( (value <= 1023 && (((!(value <= 0)))))  );
            PexObserve.ValueForViewing("$input_value", value);
            int result = Numbers.ToBinary(value);
            return result;
            // TODO: add assertions to method NumbersTest.ToBinary(Int32)
        }

        /// <summary>Test stub for ToHex(Int32)</summary>
        //[PexMethod]
        //public string ToHex(int value)
        //{
        //    string result = Numbers.ToHex(value);
        //    return result;
        //    // TODO: add assertions to method NumbersTest.ToHex(Int32)
        //}

        /// <summary>Test stub for ToOctal(Int32)</summary>
        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public int PUT_ToOctal(int value)
        {
            AssumePrecondition.IsTrue( (value <= 907 && (((!(value <= 0)))))  );
            PexObserve.ValueForViewing("$input_value", value);
            int result = Numbers.ToOctal(value);
            return result;
            // TODO: add assertions to method NumbersTest.ToOctal(Int32)
        }
      
    }
}
