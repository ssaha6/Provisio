// <copyright file="NetBigIntegerTest.cs" company="Microsoft">Copyright © Microsoft 2010</copyright>
using System;
using Lidgren.Network;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Pex.Framework.Settings;
using PexAPIWrapper;
namespace Lidgren.Network
{
    [PexClass(typeof(NetBigInteger))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class NetBigIntegerTest
    {
        int global = -102;
        public static bool IsNull(NetBigInteger big)
        {
            return (big == null);
        }
        public static bool IsNull(object big)
        {
            return (big == null);
        }
        [PexMethod]
        public NetBigInteger PUT_Abs([PexAssumeUnderTest]NetBigInteger target)
        {
            int targetIntValue = target.IntValue;
            int targetSignValue = target.SignValue;

            PexObserve.ValueForViewing("$input_intVal", targetIntValue);
            PexObserve.ValueForViewing("$input_signVal", targetSignValue);

            AssumePrecondition.IsTrue(  true);
            NetBigInteger result = target.Abs();
            return result;
        }

        [PexMethod]
        public NetBigInteger PUT_Add([PexAssumeUnderTest]NetBigInteger target, NetBigInteger value)
        {
            int valueIntValue = !NetBigIntegerTest.IsNull(value) ? value.IntValue : -7;
            int valueSignValue = !NetBigIntegerTest.IsNull(value) ? value.SignValue : -7;
            int targetIntValue = target.IntValue;
            int targetSignValue = target.SignValue;

            PexObserve.ValueForViewing("$input_intVal", targetIntValue);
            PexObserve.ValueForViewing("$input_signVal", targetSignValue);
            PexObserve.ValueForViewing("$input_intVal", valueIntValue);
            PexObserve.ValueForViewing("$input_signVal", valueSignValue);
            PexObserve.ValueForViewing("$input_IsNull", NetBigIntegerTest.IsNull(value));

            AssumePrecondition.IsTrue( (NetBigIntegerTest.IsNull(value) && ((targetIntValue == targetSignValue && (((!(targetIntValue <= -1)) && ((targetIntValue <= 0))))))) ||  ((!(NetBigIntegerTest.IsNull(value)))) );
            
            NetBigInteger result = target.Add(value);
            
            return result;
        }

        [PexMethod]
        public NetBigInteger PUT_And([PexAssumeUnderTest]NetBigInteger target, NetBigInteger value)
        {
            int valueIntValue = !NetBigIntegerTest.IsNull(value) ? value.IntValue : -7;
            int valueSignValue = !NetBigIntegerTest.IsNull(value) ? value.SignValue : -7;
            int targetIntValue = target.IntValue;
            int targetSignValue = target.SignValue;

            PexObserve.ValueForViewing("$input_intVal", targetIntValue);
            PexObserve.ValueForViewing("$input_signVal", targetSignValue);
            PexObserve.ValueForViewing("$input_intVal", valueIntValue);
            PexObserve.ValueForViewing("$input_signVal", valueSignValue);
            PexObserve.ValueForViewing("$input_IsNull", NetBigIntegerTest.IsNull(value));

            AssumePrecondition.IsTrue( (NetBigIntegerTest.IsNull(value) && (((!(targetIntValue <= -1)) && ((targetIntValue <= 0))))) ||  ((!(NetBigIntegerTest.IsNull(value)))) );
            NetBigInteger result = target.And(value);
            return result;
        }

        [PexMethod]
        public int PUT_BitLengthGet([PexAssumeUnderTest]NetBigInteger target)
        {
            int targetIntValue = target.IntValue;
            int targetSignValue = target.SignValue;

            PexObserve.ValueForViewing("$input_intVal", targetIntValue);
            PexObserve.ValueForViewing("$input_signVal", targetSignValue);

            AssumePrecondition.IsTrue(  true);
            int result = target.BitLength;
            return result;
        }

        [PexMethod]
        public int PUT_CompareTo([PexAssumeUnderTest]NetBigInteger target, object obj)
        {
            bool typeEqualTestClass = NetBigIntegerTest.IsNull(obj) ? false : (obj.GetType() == typeof(NetBigInteger));
            int targetIntValue = target.IntValue;
            int targetSignValue = target.SignValue;

            PexObserve.ValueForViewing("$input_intVal", targetIntValue);
            PexObserve.ValueForViewing("$input_signVal", targetSignValue);
            PexObserve.ValueForViewing("$input_IsNull", NetBigIntegerTest.IsNull(obj));
            PexObserve.ValueForViewing("$input_Type", typeEqualTestClass);
            
            AssumePrecondition.IsTrue( (typeEqualTestClass)  );

            int result = target.CompareTo(obj);
            return result;
        }

        [PexMethod]
        public int PUT_CompareTo01([PexAssumeUnderTest]NetBigInteger target, NetBigInteger value)
        {
            int valueIntValue = !NetBigIntegerTest.IsNull(value) ? value.IntValue : -7;
            int valueSignValue = !NetBigIntegerTest.IsNull(value) ? value.SignValue : -7;
            int targetIntValue = target.IntValue;
            int targetSignValue = target.SignValue;

            PexObserve.ValueForViewing("$input_intVal", targetIntValue);
            PexObserve.ValueForViewing("$input_signVal", targetSignValue);
            PexObserve.ValueForViewing("$input_intVal", valueIntValue);
            PexObserve.ValueForViewing("$input_signVal", valueSignValue);
            PexObserve.ValueForViewing("$input_IsNull", NetBigIntegerTest.IsNull(value));

            AssumePrecondition.IsTrue(  ((!(NetBigIntegerTest.IsNull(value)))) );

            int result = target.CompareTo(value);
            return result;
        }

        public static bool startsWithNonZeroSequence(string value)
        {
            bool nonZero = false;
            foreach (var s in value)
            {
                if (!s.Equals('0') && !s.Equals('\0') && !s.Equals('-') && !s.Equals('+'))
                {
                    nonZero = true;
                }
            }
            return nonZero;


        }

        [PexMethod]
        public NetBigInteger PUT_Constructor(string value)
        {
            ulong temp;

            //int n;
            //bool isNumeric = int.TryParse(value, out n);
            bool nullAtEnd = value != null ? value.EndsWith("\0") : true;
            bool isNotBegZero = value != null ? startsWithNonZeroSequence(value) : false;
            bool startWithSign = value != null ? value.StartsWith("+") | value.StartsWith("-") : false;

            PexObserve.ValueForViewing("$input_stringIsNull", string.IsNullOrEmpty(value));
            PexObserve.ValueForViewing("$input_stringIsNull", string.IsNullOrWhiteSpace(value));
            PexObserve.ValueForViewing("$input_wasParsed", ulong.TryParse(value, out temp) ? ulong.TryParse(value, out temp) : false);
            PexObserve.ValueForViewing("$input_nullAtEnd", nullAtEnd);
            PexObserve.ValueForViewing("$input_isNotBegZero", isNotBegZero);
            PexObserve.ValueForViewing("$input_startWithSign", startWithSign);

            AssumePrecondition.IsTrue( (ulong.TryParse(value, out temp) && (((!(startWithSign)) && ((nullAtEnd && ((isNotBegZero))) ||  ((!(nullAtEnd)))))))  );
            
            //AssumePrecondition.IsTrue(!string.IsNullOrEmpty(value) && isNumeric && (isNotBegZero  || !nullAtEnd ));

            NetBigInteger target = new NetBigInteger(value);
            return target;
        }
        
        [PexMethod]
        public NetBigInteger PUT_Constructor01(string str, int radix)
        {
            ulong temp;

            bool nullAtEnd = str != null ? str.EndsWith("\0") : true;
            bool isNotBegZero = str != null ? startsWithNonZeroSequence(str) : false;
            bool startWithSign = str != null ? str.StartsWith("+") | str.StartsWith("-") : false;

            PexObserve.ValueForViewing("$input_intVal", radix);
            PexObserve.ValueForViewing("$input_stringIsNull", string.IsNullOrEmpty(str));
            PexObserve.ValueForViewing("$input_stringIsNull", string.IsNullOrWhiteSpace(str));
            PexObserve.ValueForViewing("$input_wasParsed", ulong.TryParse(str, out temp) ? ulong.TryParse(str, out temp) : false);
            PexObserve.ValueForViewing("$input_nullAtEnd", nullAtEnd);
            PexObserve.ValueForViewing("$input_isNotBegZero", isNotBegZero);
            PexObserve.ValueForViewing("$input_startWithSign", startWithSign);


            AssumePrecondition.IsTrue( (ulong.TryParse(str, out temp) && (((!(startWithSign)) && ((radix <= 9 && (((!(isNotBegZero)) && (((!(nullAtEnd)) && ((radix <= 2 && (((!(radix <= 1))))))))))) ||  ((!(radix <= 9)) && ((isNotBegZero && ((nullAtEnd) ||  ((!(nullAtEnd)) && ((radix <= 10) ||  ((!(radix <= 10)) && (((!(radix <= 15)) && ((radix <= 16))))))))) ||  ((!(isNotBegZero)) && (((!(nullAtEnd)) && ((radix <= 10) ||  ((!(radix <= 10)) && (((!(radix <= 15)) && ((radix <= 16)))))))))))))))  );

            NetBigInteger target = new NetBigInteger(str, radix);
            return target;
        }

        [PexMethod]
        public NetBigInteger PUT_Constructor02(byte[] bytes)
        {
            int bytesLength = !NetBigIntegerTest.IsNull(bytes) ? bytes.Length : -1;

            PexObserve.ValueForViewing("$input_bytes", bytesLength);
            PexObserve.ValueForViewing("$input_bytes", NetBigIntegerTest.IsNull(bytes));


            AssumePrecondition.IsTrue( (bytesLength <= 12 && (((!(NetBigIntegerTest.IsNull(bytes))) && ((bytesLength <= 1 && (((!(bytesLength <= 0))))))))) ||  ((!(bytesLength <= 12)) && ((bytesLength <= 14) ||  ((!(bytesLength <= 14)) && (((!(bytesLength <= 15))))))) );

            NetBigInteger target = new NetBigInteger(bytes);
            return target;
        }

        [PexMethod]
        public NetBigInteger PUT_Constructor03(
            byte[] bytes,
            int offset,
            int length
        )
        {
            //PexAssume.IsTrue(offset > -11 && offset < 11);
            //PexAssume.IsTrue(length > -11 && length < 11);

            int bytesLength = !NetBigIntegerTest.IsNull(bytes) ? bytes.Length : int.MinValue;

            PexObserve.ValueForViewing("$input_bytes", bytesLength);
            PexObserve.ValueForViewing("$input_offset", offset);
            PexObserve.ValueForViewing("$input_length", length);
            PexObserve.ValueForViewing("$input_bytes", NetBigIntegerTest.IsNull(bytes));

            AssumePrecondition.IsTrue( (-bytesLength + offset + length <= 0 && (((!(offset <= -1)) && ((-bytesLength + offset <= -1 && ((offset == length && (((!(offset <= 0))))) ||  ((!(offset == length)))))))))  );
            NetBigInteger target = new NetBigInteger(bytes, offset, length);
            return target;
        }

        [PexMethod]
        public NetBigInteger PUT_Constructor04(int sign, byte[] bytes)
        {
            PexAssume.IsTrue(sign > -101 && sign < 101);

            int bytesLength = !NetBigIntegerTest.IsNull(bytes) ? bytes.Length : -1;

            PexObserve.ValueForViewing("$input_bytes", bytesLength);
            PexObserve.ValueForViewing("$input_offset", sign);
            PexObserve.ValueForViewing("$input_bytes", NetBigIntegerTest.IsNull(bytes));
            AssumePrecondition.IsTrue(  ((!(sign <= -2)) && (((!(NetBigIntegerTest.IsNull(bytes))) && ((sign <= 1))))) );

            NetBigInteger target = new NetBigInteger(sign, bytes);
            return target;
        }

        [PexMethod]
        public NetBigInteger PUT_Constructor05(
            int sign,
            byte[] bytes,
            int offset,
            int length
        )
        {
            //PexAssume.IsTrue(offset > -101 && offset < 101);
            //PexAssume.IsTrue(length > -101 && length < 101);
            //PexAssume.IsTrue(sign > -101 && sign < 101);

            int bytesLength = !NetBigIntegerTest.IsNull(bytes) ? bytes.Length : -1;

            PexObserve.ValueForViewing("$input_bytes", bytesLength);
            PexObserve.ValueForViewing("$input_sign", sign);
            PexObserve.ValueForViewing("$input_offset", offset);
            PexObserve.ValueForViewing("$input_length", length);

            PexObserve.ValueForViewing("$input_bytes", NetBigIntegerTest.IsNull(bytes));
            AssumePrecondition.IsTrue(!( (-bytesLength + -sign + -length <= 1 && ((-bytesLength + sign + offset <= 1)))  ));

            NetBigInteger target = new NetBigInteger(sign, bytes, offset, length);
            return target;
        }

        [PexMethod]
        public NetBigInteger PUT_Divide([PexAssumeUnderTest]NetBigInteger target, NetBigInteger value)
        {
            int valueIntValue = !NetBigIntegerTest.IsNull(value) ? value.IntValue : -7;
            int valueSignValue = !NetBigIntegerTest.IsNull(value) ? value.SignValue : -7;
            int targetIntValue = target.IntValue;
            int targetSignValue = target.SignValue;

            PexObserve.ValueForViewing("$input_intVal", targetIntValue);
            PexObserve.ValueForViewing("$input_signVal", targetSignValue);
            PexObserve.ValueForViewing("$input_intVal", valueIntValue);
            PexObserve.ValueForViewing("$input_signVal", valueSignValue);
            PexObserve.ValueForViewing("$input_IsNull", NetBigIntegerTest.IsNull(value));

            AssumePrecondition.IsTrue(  ((!(NetBigIntegerTest.IsNull(value))) && ((valueIntValue == valueSignValue && ((valueIntValue <= 0 && ((valueIntValue <= -1))) ||  ((!(valueIntValue <= 0))))) ||  ((!(valueIntValue == valueSignValue))))) );

            NetBigInteger result = target.Divide(value);
            return result;
        }

        [PexMethod]
        public NetBigInteger[] PUT_DivideAndRemainder([PexAssumeUnderTest]NetBigInteger target, NetBigInteger value)
        {
            int valueIntValue = !NetBigIntegerTest.IsNull(value) ? value.IntValue : -7;
            int valueSignValue = !NetBigIntegerTest.IsNull(value) ? value.SignValue : -7;
            int targetIntValue = target.IntValue;
            int targetSignValue = target.SignValue;

            PexObserve.ValueForViewing("$input_intVal", targetIntValue);
            PexObserve.ValueForViewing("$input_signVal", targetSignValue);
            PexObserve.ValueForViewing("$input_intVal", valueIntValue);
            PexObserve.ValueForViewing("$input_signVal", valueSignValue);
            PexObserve.ValueForViewing("$input_IsNull", NetBigIntegerTest.IsNull(value));

            AssumePrecondition.IsTrue(  ((!(NetBigIntegerTest.IsNull(value))) && ((valueIntValue == valueSignValue && ((valueIntValue <= -1) ||  ((!(valueIntValue <= -1)) && (((!(valueIntValue <= 0))))))) ||  ((!(valueIntValue == valueSignValue))))) );

            NetBigInteger[] result = target.DivideAndRemainder(value);
            return result;
        }

        [PexMethod]
        public bool PUT_Equals01([PexAssumeUnderTest]NetBigInteger target, object obj)
        {
            bool typeEqualTestClass = NetBigIntegerTest.IsNull(obj) ? false : (obj.GetType() == typeof(NetBigInteger));
            int targetIntValue = target.IntValue;
            int targetSignValue = target.SignValue;

            PexObserve.ValueForViewing("$input_intVal", targetIntValue);
            PexObserve.ValueForViewing("$input_signVal", targetSignValue);
            PexObserve.ValueForViewing("$input_IsNull", NetBigIntegerTest.IsNull(obj));
            PexObserve.ValueForViewing("$input_Type", typeEqualTestClass);

            AssumePrecondition.IsTrue(  true);

            bool result = target.Equals(obj);
            return result;
        }

        [PexMethod]
        public NetBigInteger PUT_Gcd([PexAssumeUnderTest]NetBigInteger target, NetBigInteger value)
        {
            int valueIntValue = !NetBigIntegerTest.IsNull(value) ? value.IntValue : -7;
            int valueSignValue = !NetBigIntegerTest.IsNull(value) ? value.SignValue : -7;
            int targetIntValue = target.IntValue;
            int targetSignValue = target.SignValue;

            PexObserve.ValueForViewing("$input_intVal", targetIntValue);
            PexObserve.ValueForViewing("$input_signValTarget", targetSignValue);
            PexObserve.ValueForViewing("$input_intVal", valueIntValue);
            PexObserve.ValueForViewing("$input_signValValue", valueSignValue);
            PexObserve.ValueForViewing("$input_IsNull", NetBigIntegerTest.IsNull(value));

            AssumePrecondition.IsTrue((-targetSignValue + -valueSignValue <= 1));

            NetBigInteger result = target.Gcd(value);
            return result;
        }

        [PexMethod]
        public int PUT_GetHashCode01([PexAssumeUnderTest]NetBigInteger target)
        {
            int targetIntValue = target.IntValue;
            int targetSignValue = target.SignValue;

            PexObserve.ValueForViewing("$input_intVal", targetIntValue);
            PexObserve.ValueForViewing("$input_signVal", targetSignValue);

            AssumePrecondition.IsTrue(  true);
            int result = target.GetHashCode();
            return result;
        }

        [PexMethod]
        public int PUT_GetLowestSetBit([PexAssumeUnderTest]NetBigInteger target)
        {
            int targetIntValue = target.IntValue;
            int targetSignValue = target.SignValue;

            PexObserve.ValueForViewing("$input_intVal", targetIntValue);
            PexObserve.ValueForViewing("$input_signVal", targetSignValue);

            AssumePrecondition.IsTrue(  true);
            int result = target.GetLowestSetBit();
            return result;
        }

        [PexMethod]
        public int PUT_IntValueGet([PexAssumeUnderTest]NetBigInteger target)
        {
            int targetIntValue = target.IntValue;
            int targetSignValue = target.SignValue;

            PexObserve.ValueForViewing("$input_intVal", targetIntValue);
            PexObserve.ValueForViewing("$input_signVal", targetSignValue);

            AssumePrecondition.IsTrue(  true);
            int result = target.IntValue;
            return result;
        }

        [PexMethod]
        public NetBigInteger PUT_Max([PexAssumeUnderTest]NetBigInteger target, NetBigInteger value)
        {
            int valueIntValue = !NetBigIntegerTest.IsNull(value) ? value.IntValue : -7;
            int valueSignValue = !NetBigIntegerTest.IsNull(value) ? value.SignValue : -7;
            int targetIntValue = target.IntValue;
            int targetSignValue = target.SignValue;

            PexObserve.ValueForViewing("$input_intVal", targetIntValue);
            PexObserve.ValueForViewing("$input_signVal", targetSignValue);
            PexObserve.ValueForViewing("$input_intVal", valueIntValue);
            PexObserve.ValueForViewing("$input_signVal", valueSignValue);
            PexObserve.ValueForViewing("$input_IsNull", NetBigIntegerTest.IsNull(value));

            AssumePrecondition.IsTrue(  ((!(NetBigIntegerTest.IsNull(value)))) );


            NetBigInteger result = target.Max(value);
            return result;
        }

        [PexMethod]
        public NetBigInteger PUT_Min([PexAssumeUnderTest]NetBigInteger target, NetBigInteger value)
        {
            int valueIntValue = !NetBigIntegerTest.IsNull(value) ? value.IntValue : -7;
            int valueSignValue = !NetBigIntegerTest.IsNull(value) ? value.SignValue : -7;
            int targetIntValue = target.IntValue;
            int targetSignValue = target.SignValue;

            PexObserve.ValueForViewing("$input_intVal", targetIntValue);
            PexObserve.ValueForViewing("$input_signVal", targetSignValue);
            PexObserve.ValueForViewing("$input_intVal", valueIntValue);
            PexObserve.ValueForViewing("$input_signVal", valueSignValue);
            PexObserve.ValueForViewing("$input_IsNull", NetBigIntegerTest.IsNull(value));

            AssumePrecondition.IsTrue(  ((!(NetBigIntegerTest.IsNull(value)))) );
            NetBigInteger result = target.Min(value);
            return result;
        }

        [PexMethod]
        public NetBigInteger PUT_Mod([PexAssumeUnderTest]NetBigInteger target, NetBigInteger value)
        {
            int valueIntValue = !NetBigIntegerTest.IsNull(value) ? value.IntValue : -7;
            int valueSignValue = !NetBigIntegerTest.IsNull(value) ? value.SignValue : -7;
            int targetIntValue = target.IntValue;
            int targetSignValue = target.SignValue;

            PexObserve.ValueForViewing("$input_intVal", targetIntValue);
            PexObserve.ValueForViewing("$input_signVal", targetSignValue);
            PexObserve.ValueForViewing("$input_intVal", valueIntValue);
            PexObserve.ValueForViewing("$input_signVal", valueSignValue);
            PexObserve.ValueForViewing("$input_IsNull", NetBigIntegerTest.IsNull(value));

            AssumePrecondition.IsTrue(  ((!(valueSignValue <= 0))) );
            
            NetBigInteger result = target.Mod(value);
            return result;
        }

        [PexMethod/*(TestEmissionFilter =PexTestEmissionFilter.All)*/]
        public NetBigInteger PUT_ModInverse([PexAssumeUnderTest]NetBigInteger target, NetBigInteger value)
        {
            int valueIntValue = !NetBigIntegerTest.IsNull(value) ? value.IntValue : -7;
            int valueSignValue = !NetBigIntegerTest.IsNull(value) ? value.SignValue : -7;
            int targetIntValue = target.IntValue;
            int targetSignValue = target.SignValue;
            int intGcd = value != null? NetBigInteger.ExtEuclid(target, value, new NetBigInteger(), null).IntValue: -7;
            PexObserve.ValueForViewing("$input_intVal", targetIntValue);
            PexObserve.ValueForViewing("$input_signVal", targetSignValue);
            PexObserve.ValueForViewing("$input_intVal", valueIntValue);
            PexObserve.ValueForViewing("$input_signVal", valueSignValue);
            PexObserve.ValueForViewing("$input_Gcd", intGcd);
            PexObserve.ValueForViewing("$input_IsNull", NetBigIntegerTest.IsNull(value));

            AssumePrecondition.IsTrue( (valueSignValue == intGcd && (((!(valueIntValue <= 0)))))  );
            //AssumePrecondition.IsTrue(!NetBigIntegerTest.IsNull(value) && value.IntValue > 0 && NetBigInteger.ExtEuclid(target, value, new NetBigInteger(), null).Equals(NetBigInteger.One));
            
            NetBigInteger result = target.ModInverse(value);
            return result;
        }

        [PexMethod]
        public NetBigInteger PUT_ModPow(
            [PexAssumeUnderTest]NetBigInteger target,
            NetBigInteger exponent,
            NetBigInteger value
        )
        {
            /*int targetInt = !NetBigIntegerTest.IsNull(target) ? target.IntValue : 0;
            int exponentInt = !NetBigIntegerTest.IsNull(exponent) ? exponent.IntValue : 0;
            int valueInt = !NetBigIntegerTest.IsNull(value) ? value.IntValue : 0;

            PexAssume.IsTrue(targetInt > -101 && targetInt < 101);
            PexAssume.IsTrue(exponentInt > -101 && exponentInt < 101);
            PexAssume.IsTrue(valueInt > -101 && valueInt < 101);*/

            int valueIntValue = !NetBigIntegerTest.IsNull(value) ? value.IntValue : -7;
            int valueSignValue = !NetBigIntegerTest.IsNull(value) ? value.SignValue : -7;
            int exponentIntValue = !NetBigIntegerTest.IsNull(exponent) ? exponent.IntValue : -7;
            int exponentSignValue = !NetBigIntegerTest.IsNull(exponent) ? exponent.SignValue : -7;
            int targetIntValue = target.IntValue;
            int targetSignValue = target.SignValue;

            PexObserve.ValueForViewing("$input_intVal", targetIntValue);
            PexObserve.ValueForViewing("$input_signVal", targetSignValue);
            PexObserve.ValueForViewing("$input_intVal", exponentIntValue);
            PexObserve.ValueForViewing("$input_signVal", exponentSignValue);
            PexObserve.ValueForViewing("$input_intVal", valueIntValue);
            PexObserve.ValueForViewing("$input_signVal", valueSignValue);
            PexObserve.ValueForViewing("$input_IsNull", NetBigIntegerTest.IsNull(exponent));
            PexObserve.ValueForViewing("$input_IsNull", NetBigIntegerTest.IsNull(value));

            AssumePrecondition.IsTrue(  ((!(valueSignValue <= 0)) && ((NetBigIntegerTest.IsNull(exponent) && ((valueIntValue == valueSignValue))) ||  ((!(NetBigIntegerTest.IsNull(exponent)))))) );
            
            NetBigInteger result = target.ModPow(exponent, value);
            return result;
        }

        [PexMethod]
        public NetBigInteger PUT_Modulus([PexAssumeUnderTest]NetBigInteger target, NetBigInteger value)
        {
            int valueIntValue = !NetBigIntegerTest.IsNull(value) ? value.IntValue : -7;
            int valueSignValue = !NetBigIntegerTest.IsNull(value) ? value.SignValue : -7;
            int targetIntValue = target.IntValue;
            int targetSignValue = target.SignValue;

            PexObserve.ValueForViewing("$input_intVal", targetIntValue);
            PexObserve.ValueForViewing("$input_signVal", targetSignValue);
            PexObserve.ValueForViewing("$input_intVal", valueIntValue);
            PexObserve.ValueForViewing("$input_signVal", valueSignValue);
            PexObserve.ValueForViewing("$input_IsNull", NetBigIntegerTest.IsNull(value));

            AssumePrecondition.IsTrue(  ((!(valueSignValue <= 0))) );

            NetBigInteger result = target.Modulus(value);
            return result;
        }

        [PexMethod]
        public NetBigInteger PUT_Multiply([PexAssumeUnderTest]NetBigInteger target, NetBigInteger value)
        {
            int valueIntValue = !NetBigIntegerTest.IsNull(value) ? value.IntValue : -7;
            int valueSignValue = !NetBigIntegerTest.IsNull(value) ? value.SignValue : -7;
            int targetIntValue = target.IntValue;
            int targetSignValue = target.SignValue;

            PexObserve.ValueForViewing("$input_intVal", targetIntValue);
            PexObserve.ValueForViewing("$input_signVal", targetSignValue);
            PexObserve.ValueForViewing("$input_intVal", valueIntValue);
            PexObserve.ValueForViewing("$input_signVal", valueSignValue);
            PexObserve.ValueForViewing("$input_IsNull", NetBigIntegerTest.IsNull(value));

            AssumePrecondition.IsTrue( (NetBigIntegerTest.IsNull(value) && (((!(targetIntValue <= -1)) && ((targetIntValue <= 0))))) ||  ((!(NetBigIntegerTest.IsNull(value)))) );

            NetBigInteger result = target.Multiply(value);
            return result;
        }

        [PexMethod]
        public NetBigInteger PUT_Negate([PexAssumeUnderTest]NetBigInteger target)
        {
            int targetIntValue = target.IntValue;
            int targetSignValue = target.SignValue;

            PexObserve.ValueForViewing("$input_intVal", targetIntValue );
            PexObserve.ValueForViewing("$input_signVal", targetSignValue );

            AssumePrecondition.IsTrue(  true);

            NetBigInteger result = target.Negate();
            return result;
        }

        [PexMethod]
        public NetBigInteger PUT_Not([PexAssumeUnderTest]NetBigInteger target)
        {
            int targetIntValue = target.IntValue;
            int targetSignValue = target.SignValue;

            PexObserve.ValueForViewing("$input_intVal", targetIntValue);
            PexObserve.ValueForViewing("$input_signVal", targetSignValue);
            
            AssumePrecondition.IsTrue(  true);

            NetBigInteger result = target.Not();
            return result;
        }

        [PexMethod]
        public NetBigInteger PUT_Pow([PexAssumeUnderTest]NetBigInteger target, int exp)
        {
            int targetIntValue = target.IntValue;
            int targetSignValue = target.SignValue;

            PexObserve.ValueForViewing("$input_intVal", targetIntValue);
            PexObserve.ValueForViewing("$input_signVal", targetSignValue);
            PexObserve.ValueForViewing("$input_exp", exp);
            
            AssumePrecondition.IsTrue(true);

            NetBigInteger result = target.Pow(exp);
            return result;
        }

        [PexMethod]
        public NetBigInteger PUT_Remainder([PexAssumeUnderTest]NetBigInteger target, NetBigInteger value)
        {

            int valueIntValue = !NetBigIntegerTest.IsNull(value) ? value.IntValue : -7;
            int valueSignValue = !NetBigIntegerTest.IsNull(value) ? value.SignValue : -7;
            int targetIntValue = target.IntValue;
            int targetSignValue = target.SignValue;

            PexObserve.ValueForViewing("$input_intVal", targetIntValue);
            PexObserve.ValueForViewing("$input_signVal", targetSignValue);
            PexObserve.ValueForViewing("$input_intVal", valueIntValue);
            PexObserve.ValueForViewing("$input_signVal", valueSignValue);
            PexObserve.ValueForViewing("$input_IsNull", NetBigIntegerTest.IsNull(value));

            AssumePrecondition.IsTrue(((!(NetBigIntegerTest.IsNull(value))) && ((valueIntValue == valueSignValue && ((valueIntValue <= -1) || ((!(valueIntValue <= -1)) && (((!(valueIntValue <= 0))))))) || ((!(valueIntValue == valueSignValue))))));
            
            NetBigInteger result = target.Remainder(value);
            return result;
        }   

        [PexMethod]
        public NetBigInteger PUT_ShiftLeft([PexAssumeUnderTest]NetBigInteger target, int n)
        {

            int targetIntValue = target.IntValue;
            int targetSignValue = target.SignValue;

            PexObserve.ValueForViewing("$input_intVal", targetIntValue);
            PexObserve.ValueForViewing("$input_signVal", targetSignValue);
            PexObserve.ValueForViewing("$input_n", n);
            
            AssumePrecondition.IsTrue(  true);

            NetBigInteger result = target.ShiftLeft(n);
            return result;
        }

        [PexMethod]
        public NetBigInteger PUT_ShiftRight([PexAssumeUnderTest]NetBigInteger target, int n)
        {
            int targetIntValue = target.IntValue;
            int targetSignValue = target.SignValue;

            PexObserve.ValueForViewing("$input_intVal", targetIntValue);
            PexObserve.ValueForViewing("$input_signVal", targetSignValue);
            PexObserve.ValueForViewing("$input_n", n);
            
            AssumePrecondition.IsTrue(  true);

            NetBigInteger result = target.ShiftRight(n);
            return result;
        }

        [PexMethod]
        public int PUT_SignValueGet([PexAssumeUnderTest]NetBigInteger target)
        {
            int targetIntValue = target.IntValue;
            int targetSignValue = target.SignValue;

            PexObserve.ValueForViewing("$input_intVal", targetIntValue);
            PexObserve.ValueForViewing("$input_signVal", targetSignValue);
            
            AssumePrecondition.IsTrue(  true);

            int result = target.SignValue;
            return result;
        }

        [PexMethod]
        public NetBigInteger PUT_Subtract([PexAssumeUnderTest]NetBigInteger target, NetBigInteger value)
        {
            int valueIntValue = !NetBigIntegerTest.IsNull(value) ? value.IntValue : -7;
            int valueSignValue = !NetBigIntegerTest.IsNull(value) ? value.SignValue : -7;
            int targetIntValue = target.IntValue;
            int targetSignValue = target.SignValue;

            PexObserve.ValueForViewing("$input_intVal", targetIntValue);
            PexObserve.ValueForViewing("$input_signVal", targetSignValue);
            PexObserve.ValueForViewing("$input_intVal", valueIntValue);
            PexObserve.ValueForViewing("$input_signVal", valueSignValue);
            PexObserve.ValueForViewing("$input_IsNull", NetBigIntegerTest.IsNull(value));

            AssumePrecondition.IsTrue(  ((!(NetBigIntegerTest.IsNull(value)))) );


            NetBigInteger result = target.Subtract(value);
            return result;
        }

        [PexMethod]
        public bool PUT_TestBit([PexAssumeUnderTest]NetBigInteger target, int n)
        {
            int targetIntValue = target.IntValue;
            int targetSignValue = target.SignValue;

            PexAssume.IsTrue(n > -101 && n < 101);

            PexObserve.ValueForViewing("$input_intVal", targetIntValue);
            PexObserve.ValueForViewing("$input_signVal", targetSignValue);
            PexObserve.ValueForViewing("$input_n", n);
            
            AssumePrecondition.IsTrue(  ((!(n <= -1))) );

            bool result = target.TestBit(n);
            return result;
        }

        [PexMethod]
        public byte[] PUT_ToByteArray([PexAssumeUnderTest]NetBigInteger target)
        {
            int targetIntValue = target.IntValue;
            int targetSignValue = target.SignValue;

            PexObserve.ValueForViewing("$input_intVal", targetIntValue);
            PexObserve.ValueForViewing("$input_signVal", targetSignValue);
            
            AssumePrecondition.IsTrue(  true);


            byte[] result = target.ToByteArray();
            return result;
        }

        [PexMethod]
        public byte[] PUT_ToByteArrayUnsigned([PexAssumeUnderTest]NetBigInteger target)
        {
            int targetIntValue = target.IntValue;
            int targetSignValue = target.SignValue;

            PexObserve.ValueForViewing("$input_intVal", targetIntValue);
            PexObserve.ValueForViewing("$input_signVal", targetSignValue);

            AssumePrecondition.IsTrue(  true);
            byte[] result = target.ToByteArrayUnsigned();
            return result;
        }

        [PexMethod]
        public string PUT_ToString01([PexAssumeUnderTest]NetBigInteger target)
        {
            int targetIntValue = target.IntValue;
            int targetSignValue = target.SignValue;

            PexObserve.ValueForViewing("$input_intVal", targetIntValue);
            PexObserve.ValueForViewing("$input_signVal", targetSignValue);

            AssumePrecondition.IsTrue(  true);
            string result = target.ToString();
            return result;
        }

        [PexMethod]
        public string PUT_ToString02([PexAssumeUnderTest]NetBigInteger target, int radix)
        {
            int targetIntValue = target.IntValue;
            int targetSignValue = target.SignValue;

            PexObserve.ValueForViewing("$input_intVal", targetIntValue);
            PexObserve.ValueForViewing("$input_signVal", targetSignValue);
            PexObserve.ValueForViewing("$input_radix", radix);

            AssumePrecondition.IsTrue( (radix <= 16 && (((!(radix <= 1)) && ((radix <= 2) ||  ((!(radix <= 2)) && (((!(radix <= 9)) && ((radix <= 10) ||  ((!(radix <= 10)) && (((!(radix <= 15)))))))))))))  );
            string result = target.ToString(radix);
            return result;
        }

        [PexMethod]
        public NetBigInteger PUT_ValueOf(long value)
        {
            PexObserve.ValueForViewing("$input_radix", value);

            AssumePrecondition.IsTrue(  true);

            NetBigInteger result = NetBigInteger.ValueOf(value);
            return result;
        }
    }
}
