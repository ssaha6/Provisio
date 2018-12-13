// <copyright file="ArrayListTest.cs">Copyright ©  2018</copyright>
using System;
using System.Collections;
using DataStructures;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.Pex.Framework.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PexAPIWrapper;
using DataStructures.Utility;

namespace DataStructures.Test
{
    /// <summary>This class contains parameterized unit tests for ArrayList</summary>
    [PexClass(typeof(ArrayList))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class ArrayListTest
    {


        /// <summary>Test stub for Add(Object)</summary>
        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityAddAdd([PexAssumeUnderTest] DataStructures.ArrayList s1, int x, int y)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(x > -101 && x < 101);
            PexAssume.IsTrue(y > -101 && y < 101);

            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            
            AssumePrecondition.IsTrue(  false);

            int a1 = -1, ad1 = -1;
            int a2 = -1, ad2 = -1;

            //First Test
            a1 = s1.Add(x);
            ad1 = s1.Add(y);

            //Second Test
            ad2 = s2.Add(y);
            a2 = s2.Add(x);

            
            //NotpAssume.IsTrue(a1 == a2 && ad1 == ad2 && eq.Equals(s1, s2));
            PexAssert.IsTrue(a1 == a2 && ad1 == ad2 && eq.Equals(s1, s2));
        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityAddContains([PexAssumeUnderTest] DataStructures.ArrayList s1, int x, int y)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(x > -101 && x < 101);
            PexAssume.IsTrue(y > -101 && y < 101);

            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            AssumePrecondition.IsTrue(((s1.Contains(x)) && (true)) || ((!(s1.Contains(x))) && (((-1 * s1.Count + -1 * x + 1 * y <= 3) && (((-1 * s1.Count + -1 * x + 1 * y <= -1) && (((-1 * s1.Count + 1 * x + -1 * y <= 0) && (((0 * s1.Count + -1 * x + 1 * y <= 0) && (false)) || ((!(0 * s1.Count + -1 * x + 1 * y <= 0)) && (true)))) || ((!(-1 * s1.Count + 1 * x + -1 * y <= 0)) && (true)))) || ((!(-1 * s1.Count + -1 * x + 1 * y <= -1)) && (false)))) || ((!(-1 * s1.Count + -1 * x + 1 * y <= 3)) && (true)))));
            int a1 = -1, a2 = -1;
            bool ad1 = false, ad2 = false;

            //First Test
            a1 = s1.Add(x);
            ad1 = s1.Contains(y);

            //Second Test
            ad2 = s2.Contains(y);
            a2 = s2.Add(x);
            
            
            //NotpAssume.IsTrue(a1 == a2 && ad1 == ad2 && eq.Equals(s1, s2));
            PexAssert.IsTrue(a1 == a2 && ad1 == ad2 && eq.Equals(s1, s2));
        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityAddCount([PexAssumeUnderTest] DataStructures.ArrayList s1, int x)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(x > -101 && x < 101);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            AssumePrecondition.IsTrue(  false);

            int a1 = -1, a2 = -1;
            int ad1 = -1, ad2 = -1;

            //First Test
            a1 = s1.Add(x);
            ad1 = s1.Count;

            //Second Test
            ad2 = s2.Count;
            a2 = s2.Add(x);

            //NotpAssume.IsTrue(a1 == a2 && ad1 == ad2 && eq.Equals(s1, s2));
            PexAssert.IsTrue(a1 == a2 && ad1 == ad2 && eq.Equals(s1, s2));
        }


        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityAddGet([PexAssumeUnderTest] DataStructures.ArrayList s1, int x, int y)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(x > -101 && x < 101);
            PexAssume.IsTrue(y > -101 && y < 101);


            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            AssumePrecondition.IsTrue( (( -1*s1.Count + 0*x + 1*y <= 0 ) && ((( -1*s1.Count + 0*x + 1*y <= -1 ) && (true)) ||  ((!( -1*s1.Count + 0*x + 1*y <= -1 )) && (false)))) ||  ((!( -1*s1.Count + 0*x + 1*y <= 0 )) && (true)) );

            int a1 = -1, a2 = -1;
            int ad1 = -1, ad2 = -1;
            bool first = false, second = false;
            try
            {
                //First Test
                a1 = s1.Add(x);
                ad1 = (int)s1[y]; //this is how you write the method get
            }
            catch (ArgumentOutOfRangeException)
            {
                first = true;
            }
            try
            {
                //Second Test
                ad2 = (int)s2[y]; //this is how you write the method get
                a2 = s2.Add(x);
            }
            catch (ArgumentOutOfRangeException)
            {
                second = true;
            }
            //NotpAssume.IsTrue((first && second) || (!first && !second && a1 == a2 && ad1 == ad2 && eq.Equals(s1, s2)));            
            PexAssert.IsTrue((first && second) || (!first && !second && a1 == a2 && ad1 == ad2 && eq.Equals(s1, s2)));
        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityAddIndexOf([PexAssumeUnderTest] DataStructures.ArrayList s1, int x, int y)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(x > -101 && x < 101);
            PexAssume.IsTrue(y > -101 && y < 101);

            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            AssumePrecondition.IsTrue( (( s1.Contains(y) ) && (true)) ||  ((!( s1.Contains(y) )) && ((( s1.Contains(x) ) && (true)) ||  ((!( s1.Contains(x) )) && ((( 0*s1.Count + -1*x + 1*y <= -1 ) && (true)) ||  ((!( 0*s1.Count + -1*x + 1*y <= -1 )) && ((( 0*s1.Count + -1*x + 1*y <= 0 ) && (false)) ||  ((!( 0*s1.Count + -1*x + 1*y <= 0 )) && (true)))))))) );

            int a1 = -1, a2 = -1;
            int ad1 = -1, ad2 = -1;

            //First Test
            a1 = s1.Add(x);
            ad1 = s1.IndexOf(y);

            //Second Test
            ad2 = s2.IndexOf(y);
            a2 = s2.Add(x);

            //NotpAssume.IsTrue(a1 == a2 && ad1 == ad2 && eq.Equals(s1, s2));
            PexAssert.IsTrue(a1 == a2 && ad1 == ad2 && eq.Equals(s1, s2));


        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityAddInsert([PexAssumeUnderTest] DataStructures.ArrayList s1, int x, int y, int y1)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(x > -101 && x < 101);
            PexAssume.IsTrue(y > -101 && y < 101);
            PexAssume.IsTrue(y1 > -101 && y1 < 101);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_y1", y1);
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            PexObserve.ValueForViewing("$input_s1.Contains(y1)", s1.Contains(y1));
            AssumePrecondition.IsTrue(  false);

            int a1 = -1, a2 = -1;
            int ad1 = -1, ad2 = -1;

            //First Test
            a1 = s1.Add(x);
            s1.Insert(y, y1);

            //Second Test
            s2.Insert(y, y1);
            a2 = s2.Add(x);

            //NotpAssume.IsTrue(a1 == a2 && eq.Equals(s1, s2));
            PexAssert.IsTrue(a1 == a2 && eq.Equals(s1, s2));
        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityAddLastIndexOf([PexAssumeUnderTest] DataStructures.ArrayList s1, int x, int y)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(x > -101 && x < 101);
            PexAssume.IsTrue(y > -101 && y < 101);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            AssumePrecondition.IsTrue( (( 0*s1.Count + -1*x + 1*y <= -1 ) && (true)) ||  ((!( 0*s1.Count + -1*x + 1*y <= -1 )) && ((( 0*s1.Count + -1*x + 1*y <= 0 ) && (false)) ||  ((!( 0*s1.Count + -1*x + 1*y <= 0 )) && (true)))) );

            int a1 = -1, a2 = -1;
            int ad1 = -1, ad2 = -1;

            //First Test
            a1 = s1.Add(x);
            ad1 = s1.LastIndexOf(y);

            //Second Test
            ad2 = s2.LastIndexOf(y);
            a2 = s2.Add(x);

            //NotpAssume.IsTrue(a1 == a2 && ad1 == ad2 && eq.Equals(s1, s2));
            PexAssert.IsTrue(a1 == a2 && ad1 == ad2 && eq.Equals(s1, s2));

        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityAddRemove([PexAssumeUnderTest] DataStructures.ArrayList s1, int x, int y)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(x > -101 && x < 101);
            PexAssume.IsTrue(y > -101 && y < 101);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            AssumePrecondition.IsTrue( (( s1.Contains(y) ) && (false)) ||  ((!( s1.Contains(y) )) && ((( s1.Contains(x) ) && (true)) ||  ((!( s1.Contains(x) )) && ((( 0*s1.Count + -1*x + 1*y <= -1 ) && (true)) ||  ((!( 0*s1.Count + -1*x + 1*y <= -1 )) && ((( 0*s1.Count + -1*x + 1*y <= 0 ) && (false)) ||  ((!( 0*s1.Count + -1*x + 1*y <= 0 )) && (true)))))))) );

            int a1 = -1, a2 = -1;
            int ad1 = -1, ad2 = -1;

            //First Test
            a1 = s1.Add(x);
            s1.Remove(y);

            //Second Test
            s2.Remove(y);
            a2 = s2.Add(x);

            //NotpAssume.IsTrue(a1 == a2 && eq.Equals(s1, s2));
            PexAssert.IsTrue(a1 == a2 && eq.Equals(s1, s2));

        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityAddRemoveAt([PexAssumeUnderTest] DataStructures.ArrayList s1, int x, int y)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(x > -101 && x < 101);
            PexAssume.IsTrue(y > -101 && y < 101);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            AssumePrecondition.IsTrue( (( y <= -1 ) && (true)) ||  ((!( y <= -1 )) && ((( -1*s1.Count + 0*x + 1*y <= 0 ) && (false)) ||  ((!( -1*s1.Count + 0*x + 1*y <= 0 )) && (true)))) );

            int a1 = -1, a2 = -1;
            int ad1 = -1, ad2 = -1;
            bool first = false, second = false;
            //First Test
            try
            {
                a1 = s1.Add(x);
                s1.RemoveAt(y);
            }
            catch (ArgumentOutOfRangeException)
            {
                first = true;
            }
            try
            {
                //Second Test
                s2.RemoveAt(y);
                a2 = s2.Add(x);
            }
            catch (ArgumentOutOfRangeException)
            {
                second = true;
            }
            //NotpAssume.IsTrue((first && second) || (!first && !second && a1 == a2 && eq.Equals(s1, s2)));            
            PexAssert.IsTrue((first && second) || (!first && !second && a1 == a2 && eq.Equals(s1, s2)));

        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityAddSet([PexAssumeUnderTest] DataStructures.ArrayList s1, int x, int y, int y1)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(x > -101 && x < 101);
            PexAssume.IsTrue(y > -101 && y < 101);
            PexAssume.IsTrue(y1 > -101 && y1 < 101);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_y1", y1);
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            PexObserve.ValueForViewing("$input_s1.Contains(y1)", s1.Contains(y1));
            AssumePrecondition.IsTrue( (( -1*s1.Count + 0*x + 1*y + 0*y1 <= 0 ) && ((( y <= -1 ) && (true)) ||  ((!( y <= -1 )) && ((( s1.Contains(y1) ) && ((( 0*s1.Count + 0*x + -1*y + 1*y1 <= 49 ) && ((( 0*s1.Count + 0*x + -1*y + -1*y1 <= -3 ) && ((( -1*s1.Count + 0*x + -1*y + -1*y1 <= -34 ) && (true)) ||  ((!( -1*s1.Count + 0*x + -1*y + -1*y1 <= -34 )) && (false)))) ||  ((!( 0*s1.Count + 0*x + -1*y + -1*y1 <= -3 )) && (true)))) ||  ((!( 0*s1.Count + 0*x + -1*y + 1*y1 <= 49 )) && (false)))) ||  ((!( s1.Contains(y1) )) && ((( -1*s1.Count + -1*x + 1*y + 1*y1 <= -1 ) && (false)) ||  ((!( -1*s1.Count + -1*x + 1*y + 1*y1 <= -1 )) && ((( -1*s1.Count + 1*x + 1*y + -1*y1 <= -1 ) && (false)) ||  ((!( -1*s1.Count + 1*x + 1*y + -1*y1 <= -1 )) && (true)))))))))) ||  ((!( -1*s1.Count + 0*x + 1*y + 0*y1 <= 0 )) && (true)) );

            int a1 = -1, a2 = -1;
            int ad1 = -1, ad2 = -1;
            bool first = false, second = false;
            try
            {
                //First Test
                a1 = s1.Add(x);
                s1[y] = y1;
            }
            catch (ArgumentOutOfRangeException)
            {
                first = true;
            }
            try
            {
                //Second Test
                s1[y] = y1;
                a2 = s2.Add(x);
            }
            catch (ArgumentOutOfRangeException)
            {
                second = true;
            }
            //NotpAssume.IsTrue((first && second) || (!first && !second && a1 == a2 && eq.Equals(s1, s2)));            
            PexAssert.IsTrue((first && second) || (!first && !second && a1 == a2 && eq.Equals(s1, s2)));

        }



        [PexMethod]
        public void PUT_CommutativityContainsContains([PexAssumeUnderTest] DataStructures.ArrayList s1, int x, int y)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();
            PexAssume.IsTrue(x > -101 && x < 101);
            PexAssume.IsTrue(y > -101 && y < 101);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            AssumePrecondition.IsTrue(true);

            bool a1 = false, a2 = false;
            bool ad1 = false, ad2 = false;


            //First Test
            a1 = s1.Contains(x);
            ad1 = s1.Contains(y);

            //Second Test
            ad2 = s2.Contains(y);
            a2 = s2.Contains(x);

            //NotpAssume.IsTrue(a1 == a2 && ad1 == ad2 && eq.Equals(s1, s2));
            PexAssert.IsTrue(a1 == a2 && ad1 == ad2 && eq.Equals(s1, s2));
        }

        [PexMethod]
        public void PUT_CommutativityContainsCount([PexAssumeUnderTest] DataStructures.ArrayList s1, int x)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();
            PexAssume.IsTrue(x > -101 && x < 101);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            AssumePrecondition.IsTrue(true);

            bool a1 = false, a2 = false;
            int ad1 = -1, ad2 = -1;


            //First Test
            a1 = s1.Contains(x);
            ad1 = s1.Count;

            //Second Test
            ad2 = s2.Count;
            a2 = s2.Contains(x);

            //NotpAssume.IsTrue(a1 == a2 && ad1 == ad2 && eq.Equals(s1, s2));
            PexAssert.IsTrue(a1 == a2 && ad1 == ad2 && eq.Equals(s1, s2));
        }
        [PexMethod]
        public void PUT_CommutativityContainsGet([PexAssumeUnderTest] DataStructures.ArrayList s1, int x, int y)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(x > -101 && x < 101);
            PexAssume.IsTrue(y > -101 && y < 101);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            AssumePrecondition.IsTrue(true);

            bool a1 = false, a2 = false;
            int ad1 = -1, ad2 = -1;
            bool first = false, second = false;
            try
            {
                //First Test
                a1 = s1.Contains(x);
                ad1 = (int)s1[y];
            }
            catch (ArgumentOutOfRangeException)
            {
                first = true;
            }

            try
            {
                //Second Test
                ad2 = (int)s2[y];
                a2 = s2.Contains(x);
            }
            catch (ArgumentOutOfRangeException)
            {
                second = true;
            }

            //NotpAssume.IsTrue((first && second) || (!first && !second && a1 == a2 && ad1 == ad2 && eq.Equals(s1, s2)));
            PexAssert.IsTrue((first && second) || (!first && !second && a1 == a2 && ad1 == ad2 && eq.Equals(s1, s2)));

        }



        [PexMethod]
        public void PUT_CommutativityContainsIndexOf([PexAssumeUnderTest] DataStructures.ArrayList s1, int x, int y)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(x > -101 && x < 101);
            PexAssume.IsTrue(y > -101 && y < 101);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            AssumePrecondition.IsTrue(true);

            bool a1 = false, a2 = false;
            int ad1 = -1, ad2 = -1;


            //First Test
            a1 = s1.Contains(x);
            ad1 = s1.IndexOf(y);

            //Second Test
            ad2 = s2.IndexOf(y);
            a2 = s2.Contains(x);

            //NotpAssume.IsTrue(a1 == a2 && ad1 == ad2 && eq.Equals(s1, s2));
            PexAssert.IsTrue(a1 == a2 && ad1 == ad2 && eq.Equals(s1, s2));
        }

        [PexMethod]
        public void PUT_CommutativityContainsInsert([PexAssumeUnderTest] DataStructures.ArrayList s1, int x, int y, int y1)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(x > -101 && x < 101);
            PexAssume.IsTrue(y > -101 && y < 101);
            PexAssume.IsTrue(y1 > -101 && y1 < 101);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_y1", y1);
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            PexObserve.ValueForViewing("$input_s1.Contains(y1)", s1.Contains(y1));
            AssumePrecondition.IsTrue(true);

            bool a1 = false, a2 = false;
            int ad1 = -1, ad2 = -1;
            bool first = false, second = false;
            try
            {
                //First Test
                a1 = s1.Contains(x);
                s1.Insert(y, y1);
            }
            catch (ArgumentOutOfRangeException)
            {
                first = true;
            }
            try
            {
                //Second Test
                s2.Insert(y, y1);
                a2 = s2.Contains(x);
            }
            catch (ArgumentOutOfRangeException)
            {
                second = true;
            }
            //NotpAssume.IsTrue((first && second) || (!first & !second && a1 == a2 && ad1 == ad2 && eq.Equals(s1, s2)));            
            PexAssert.IsTrue((first && second) || (!first & !second && a1 == a2 && ad1 == ad2 && eq.Equals(s1, s2)));

        }
        [PexMethod]
        public void PUT_CommutativityContainsRemove([PexAssumeUnderTest]  DataStructures.ArrayList s1, int x, int y)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(x > -101 && x < 101);
            PexAssume.IsTrue(y > -101 && y < 101);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            AssumePrecondition.IsTrue(true);

            bool a1 = false, a2 = false;
            int ad1 = -1, ad2 = -1;


            //First Test
            a1 = s1.Contains(x);
            s1.Remove(y);

            //Second Test
            s2.Remove(y);
            a2 = s2.Contains(x);

            //NotpAssume.IsTrue(a1 == a2 && eq.Equals(s1, s2));
            PexAssert.IsTrue(a1 == a2 && eq.Equals(s1, s2));

        }

        [PexMethod]
        public void PUT_CommutativityContainsRemoveAt([PexAssumeUnderTest] DataStructures.ArrayList s1, int x, int y)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(x > -101 && x < 101);
            PexAssume.IsTrue(y > -101 && y < 101);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            AssumePrecondition.IsTrue(true);

            bool a1 = false, a2 = false;
            int ad1 = -1, ad2 = -1;
            bool first = false, second = false;

            try
            {
                //First Test
                a1 = s1.Contains(x);
                s1.RemoveAt(y);
            }
            catch (ArgumentOutOfRangeException)
            {
                first = true;
            }
            try
            {
                //Second Test
                s2.RemoveAt(y);
                a2 = s2.Contains(x);
            }
            catch (ArgumentOutOfRangeException)
            {
                second = true;
            }

            //NotpAssume.IsTrue((first && second) || (!first && !second && a1 == a2 && eq.Equals(s1, s2)));
            PexAssert.IsTrue((first && second) || (!first && !second && a1 == a2 && eq.Equals(s1, s2)));

        }

        [PexMethod]
        public void PUT_CommutativityContainsSet([PexAssumeUnderTest] DataStructures.ArrayList s1, int x, int y, int y1)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(x > -101 && x < 101);
            PexAssume.IsTrue(y > -101 && y < 101);
            PexAssume.IsTrue(y1 > -101 && y1 < 101);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_y1", y1);
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            PexObserve.ValueForViewing("$input_s1.Contains(y1)", s1.Contains(y1));
            AssumePrecondition.IsTrue(true);

            bool a1 = false, a2 = false;
            int ad1 = -1, ad2 = -1;
            bool first = false, second = false;

            try
            {
                //First Test
                a1 = s1.Contains(x);
                s1[y] = y1;
            }
            catch (ArgumentOutOfRangeException)
            {
                first = true;
            }
            try
            {
                //Second Test
                s2[y] = y1;
                a2 = s2.Contains(x);
            }
            catch (ArgumentOutOfRangeException)
            {
                second = true;
            }
            //NotpAssume.IsTrue((first && second) || (!first && !second & a1 == a2 && eq.Equals(s1, s2)));            
            PexAssert.IsTrue((first && second) || (!first && !second & a1 == a2 && eq.Equals(s1, s2)));
        }



        [PexMethod]
        public void PUT_CommutativityCountCount([PexAssumeUnderTest]DataStructures.ArrayList s1)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            AssumePrecondition.IsTrue(true);


            int a1 = -1, a2 = -1;
            int ad1 = -1, ad2 = -1;


            //First Test
            a1 = s1.Count;
            ad1 = s1.Count;

            //Second Test
            ad2 = s2.Count;
            a2 = s2.Count;
            //NotpAssume.IsTrue(a1 == a2 && ad1 == ad2 && eq.Equals(s1, s2));            
            PexAssert.IsTrue(a1 == a2 && ad1 == ad2 && eq.Equals(s1, s2));

        }

        [PexMethod]
        public void PUT_CommutativityCountGet([PexAssumeUnderTest] DataStructures.ArrayList s1, int y)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(y > -101 && y < 101);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            AssumePrecondition.IsTrue(true);

            int a1 = -1, a2 = -1;
            int ad1 = -1, ad2 = -1;
            bool first = false, second = false;

            try
            {
                //First Test
                a1 = s1.Count;
                ad1 = (int)s1[y];
            }
            catch (ArgumentOutOfRangeException)
            {
                first = true;
            }
            try
            {
                //Second Test
                ad2 = (int)s2[y];
                a2 = s2.Count;
            }
            catch (ArgumentOutOfRangeException)
            {
                second = true;
            }
            //NotpAssume.IsTrue((first && second) || (!first && !second && a1 == a2 && ad1 == ad2 && eq.Equals(s1, s2)));            
            PexAssert.IsTrue((first && second) || (!first && !second && a1 == a2 && ad1 == ad2 && eq.Equals(s1, s2)));

        }

        [PexMethod]
        public void PUT_CommutativityCountIndexOf([PexAssumeUnderTest] DataStructures.ArrayList s1, int y)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(y > -101 && y < 101);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            AssumePrecondition.IsTrue(true);

            int a1 = -1, a2 = -1;
            int ad1 = -1, ad2 = -1;


            //First Test
            a1 = s1.Count;
            ad1 = s1.IndexOf(y);

            //Second Test
            ad2 = s2.IndexOf(y);
            a2 = s2.Count;
            //NotpAssume.IsTrue(a1 == a2 && ad1 == ad2 && eq.Equals(s1, s2));            
            PexAssert.IsTrue(a1 == a2 && ad1 == ad2 && eq.Equals(s1, s2));

        }

        [PexMethod]
        public void PUT_CommutativityCountInsert([PexAssumeUnderTest] DataStructures.ArrayList s1, int y, int y1)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(y > -101 && y < 101);
            PexAssume.IsTrue(y1 > -101 && y1 < 101);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.IndexOf(y)", s1.IndexOf(y));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(y)", s1.LastIndexOf(y));
            PexObserve.ValueForViewing("$input_y1", y1);
            PexObserve.ValueForViewing("$input_s1.IndexOf(y1)", s1.IndexOf(y1));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(y1)", s1.LastIndexOf(y1));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            PexObserve.ValueForViewing("$input_s1.Contains(y1)", s1.Contains(y1));
            AssumePrecondition.IsTrue(true);

            int a1 = -1, a2 = -1;
            int ad1 = -1, ad2 = -1;
            bool first = false, second = false;

            try
            {
                //First Test
                a1 = s1.Count;
                s1.Insert(y, y1);
            }
            catch (ArgumentOutOfRangeException)
            {
                first = true;
            }

            try
            {
                //Second Test
                s2.Insert(y, y1);
                a2 = s2.Count;
            }
            catch (ArgumentOutOfRangeException)
            {
                second = true;
            }

            //NotpAssume.IsTrue((first && second) || (!first && !second && a1 == a2 && eq.Equals(s1, s2)));
            PexAssert.IsTrue((first && second) || (!first && !second && a1 == a2 && eq.Equals(s1, s2)));

        }

        [PexMethod]
        public void PUT_CommutativityCountLastIndexOf([PexAssumeUnderTest] DataStructures.ArrayList s1, int y)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(y > -101 && y < 101);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.IndexOf(y)", s1.IndexOf(y));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(y)", s1.LastIndexOf(y));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            AssumePrecondition.IsTrue(true);

            int a1 = -1, a2 = -1;
            int ad1 = -1, ad2 = -1;


            //First Test
            a1 = s1.Count;
            ad1 = s1.LastIndexOf(y);

            //Second Test
            ad2 = s2.LastIndexOf(y);
            a2 = s2.Count;
            //NotpAssume.IsTrue(a1 == a2 && ad1 == ad2 && eq.Equals(s1, s2));            
            PexAssert.IsTrue(a1 == a2 && ad1 == ad2 && eq.Equals(s1, s2));

        }

        [PexMethod]
        public void PUT_CommutativityCountRemove([PexAssumeUnderTest] DataStructures.ArrayList s1, int y)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(y > -101 && y < 101);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.IndexOf(y)", s1.IndexOf(y));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(y)", s1.LastIndexOf(y));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            AssumePrecondition.IsTrue(true);

            int a1 = -1, a2 = -1;
            int ad1 = -1, ad2 = -1;


            //First Test
            a1 = s1.Count;
            s1.Remove(y);

            //Second Test
            s2.Remove(y);
            a2 = s2.Count;
            //NotpAssume.IsTrue(a1 == a2 && eq.Equals(s1, s2));            
            PexAssert.IsTrue(a1 == a2 && eq.Equals(s1, s2));

        }

        [PexMethod]
        public void PUT_CommutativityCountRemoveAt([PexAssumeUnderTest] DataStructures.ArrayList s1, int x)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(x > -101 && x < 101);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_s1.IndexOf(x)", s1.IndexOf(x));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(x)",s1.LastIndexOf(x));
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            AssumePrecondition.IsTrue(true);

            int a1 = -1, a2 = -1;
            int ad1 = -1, ad2 = -1;
            bool first = false, second = false;

            try
            {
                //First Test
                a1 = s1.Count;
                s1.RemoveAt(x);
            }
            catch (ArgumentOutOfRangeException)
            {
                first = true;
            }
            try
            {
                //Second Test
                s2.RemoveAt(x);
                a2 = s2.Count;
            }
            catch (ArgumentOutOfRangeException)
            {
                second = true;
            }
            //NotpAssume.IsTrue((first && second) || (!first && !second && a1 == a2 && eq.Equals(s1, s2)));            
            PexAssert.IsTrue((first && second) || (!first && !second && a1 == a2 && eq.Equals(s1, s2)));

        }

        [PexMethod]
        public void PUT_CommutativityCountSet([PexAssumeUnderTest] DataStructures.ArrayList s1, int x, int y, int y1)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(x > -101 && x < 101);
            PexAssume.IsTrue(y > -101 && y < 101);
            PexAssume.IsTrue(y1 > -101 && y1 < 101);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_s1.IndexOf(x)", s1.IndexOf(x));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(x)",s1.LastIndexOf(x));
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.IndexOf(y)", s1.IndexOf(y));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(y)", s1.LastIndexOf(y));
            PexObserve.ValueForViewing("$input_y1", y1);
            PexObserve.ValueForViewing("$input_s1.IndexOf(y1)", s1.IndexOf(y1));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(y1)", s1.LastIndexOf(y1));
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            PexObserve.ValueForViewing("$input_s1.Contains(y1)", s1.Contains(y1));
            AssumePrecondition.IsTrue(true);

            int a1 = -1, a2 = -1;
            int ad1 = -1, ad2 = -1;
            bool first = false, second = false;

            try
            {
                //First Test
                a1 = s1.Count;
                s1[y] = y1;
            }
            catch (ArgumentOutOfRangeException)
            {
                first = true;
            }

            try
            {
                //Second Test
                s2[y] = y1;
                a2 = s2.Count;
            }
            catch (ArgumentOutOfRangeException)
            {
                second = true;
            }

            //NotpAssume.IsTrue((first && second) || (!first && !second && a1 == a2 && eq.Equals(s1, s2)));
            PexAssert.IsTrue((first && second) || (!first && !second && a1 == a2 && eq.Equals(s1, s2)));

        }

        [PexMethod]
        public void PUT_CommutativityGetGet([PexAssumeUnderTest] DataStructures.ArrayList s1, int x, int y)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(x > -101 && x < 101);
            PexAssume.IsTrue(y > -101 && y < 101);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_s1.IndexOf(x)", s1.IndexOf(x));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(x)",s1.LastIndexOf(x));
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.IndexOf(y)", s1.IndexOf(y));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(y)", s1.LastIndexOf(y));
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            AssumePrecondition.IsTrue(true);

            int a1 = -1, a2 = -1;
            int ad1 = -1, ad2 = -1;
            bool first = false, second = false;

            try
            {
                //First Test
                a1 = (int)s1[x];
                ad1 = (int)s1[y];
            }
            catch (ArgumentOutOfRangeException)
            {
                first = true;
            }
            try
            {
                //Second Test
                ad2 = (int)s2[y];
                a2 = (int)s2[x];
            }
            catch (ArgumentOutOfRangeException)
            {
                second = true;
            }

            //NotpAssume.IsTrue((first && second) || (!first && !second && a1 == a2 && ad1 == ad2 && eq.Equals(s1, s2)));
            PexAssert.IsTrue((first && second) || (!first && !second && a1 == a2 && ad1 == ad2 && eq.Equals(s1, s2)));

        }

        [PexMethod]
        public void PUT_CommutativityGetIndexof([PexAssumeUnderTest] DataStructures.ArrayList s1, int x, int y)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(x > -101 && x < 101);
            PexAssume.IsTrue(y > -101 && y < 101);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_s1.IndexOf(x)", s1.IndexOf(x));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(x)",s1.LastIndexOf(x));
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.IndexOf(y)", s1.IndexOf(y));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(y)", s1.LastIndexOf(y));
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            AssumePrecondition.IsTrue(true);

            int a1 = -1, a2 = -1;
            int ad1 = -1, ad2 = -1;
            bool first = true, second = false;
            try
            {
                //First Test
                a1 = (int)s1[x];
                ad1 = s1.IndexOf(y);
            }
            catch (ArgumentOutOfRangeException)
            {

                first = true;
            }
            try
            {
                //Second Test
                ad2 = s2.IndexOf(y);
                a2 = (int)s2[x];
            }
            catch (ArgumentOutOfRangeException)
            {
                second = true;
            }

            //NotpAssume.IsTrue((first && second) || (!first && !second && a1 == a2 && ad1 == ad2 && eq.Equals(s1, s2)));
            PexAssert.IsTrue((first && second) || (!first && !second && a1 == a2 && ad1 == ad2 && eq.Equals(s1, s2)));

        }

        [PexMethod]
        public void PUT_CommutativityGetInsert([PexAssumeUnderTest] DataStructures.ArrayList s1, int x, int y, int y1)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(x > -101 && x < 101);
            PexAssume.IsTrue(y > -101 && y < 101);
            PexAssume.IsTrue(y1 > -101 && y1 < 101);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_s1.IndexOf(x)", s1.IndexOf(x));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(x)",s1.LastIndexOf(x));
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.IndexOf(y)", s1.IndexOf(y));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(y)", s1.LastIndexOf(y));
            PexObserve.ValueForViewing("$input_y1", y1);
            PexObserve.ValueForViewing("$input_s1.IndexOf(y1)", s1.IndexOf(y1));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(y1)", s1.LastIndexOf(y1));
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            PexObserve.ValueForViewing("$input_s1.Contains(y1)", s1.Contains(y1));
            AssumePrecondition.IsTrue(true);

            int a1 = -1, a2 = -1;
            int ad1 = -1, ad2 = -1;
            bool first = false, second = false;

            try
            {
                //First Test
                a1 = (int)s1[x];
                s1.Insert(y, y1);
            }
            catch (ArgumentOutOfRangeException)
            {
                first = true;
            }
            try
            {
                //Second Test
                s2.Insert(y, y1);
                a2 = (int)s2[x];
            }
            catch (ArgumentOutOfRangeException)
            {
                second = true;
            }
            //NotpAssume.IsTrue((first && second) || (!first && !second && a1 == a2 && eq.Equals(s1, s2)));            
            PexAssert.IsTrue((first && second) || (!first && !second && a1 == a2 && eq.Equals(s1, s2)));

        }

        [PexMethod]
        public void PUT_CommutativityGetLastIndexOf([PexAssumeUnderTest] DataStructures.ArrayList s1, int x, int y)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(x > -101 && x < 101);
            PexAssume.IsTrue(y > -101 && y < 101);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_s1.IndexOf(x)", s1.IndexOf(x));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(x)",s1.LastIndexOf(x));
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.IndexOf(y)", s1.IndexOf(y));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(y)", s1.LastIndexOf(y));
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            AssumePrecondition.IsTrue(true);

            int a1 = -1, a2 = -1;
            int ad1 = -1, ad2 = -1;
            bool first = false, second = false;

            try
            {
                //First Test
                a1 = (int)s1[x];
                ad1 = s1.LastIndexOf(y);
            }
            catch (ArgumentOutOfRangeException)
            {
                first = true;
            }
            try
            {
                //Second Test
                ad2 = s2.LastIndexOf(y);
                a2 = (int)s2[x];
            }
            catch (ArgumentOutOfRangeException)
            {
                second = true;
            }
            //NotpAssume.IsTrue((first && second) || (!first && !second && a1 == a2 && ad1 == ad2 && eq.Equals(s1, s2)));            
            PexAssert.IsTrue((first && second) || (!first && !second && a1 == a2 && ad1 == ad2 && eq.Equals(s1, s2)));

        }

        [PexMethod]
        public void PUT_CommutativityGetRemove([PexAssumeUnderTest] DataStructures.ArrayList s1, int x, int y)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(x > -101 && x < 101);
            PexAssume.IsTrue(y > -101 && y < 101);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_s1.IndexOf(x)", s1.IndexOf(x));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(x)",s1.LastIndexOf(x));
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.IndexOf(y)", s1.IndexOf(y));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(y)", s1.LastIndexOf(y));
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            AssumePrecondition.IsTrue(true);

            int a1 = -1, a2 = -1;
            int ad1 = -1, ad2 = -1;
            bool first = false, second = false;

            try
            {
                //First Test
                a1 = (int)s1[x];
                s1.Remove(y);
            }
            catch (ArgumentOutOfRangeException)
            {
                first = true;
            }
            try
            {
                //Second Test
                s2.Remove(y);
                a2 = (int)s2[x];
            }
            catch (ArgumentOutOfRangeException)
            {
                second = true;
            }

            //NotpAssume.IsTrue((first && second) || (!first && !second && a1 == a2 && eq.Equals(s1, s2)));
            PexAssert.IsTrue((first && second) || (!first && !second && a1 == a2 && eq.Equals(s1, s2)));

        }

        [PexMethod]
        public void PUT_CommutativityGetRemoveAt([PexAssumeUnderTest] DataStructures.ArrayList s1, int x, int y)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(x > -101 && x < 101);
            PexAssume.IsTrue(y > -101 && y < 101);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_s1.IndexOf(x)", s1.IndexOf(x));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(x)",s1.LastIndexOf(x));
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.IndexOf(y)", s1.IndexOf(y));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(y)", s1.LastIndexOf(y));
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            AssumePrecondition.IsTrue(true);

            int a1 = -1, a2 = -1;
            int ad1 = -1, ad2 = -1;
            bool first = false, second = false;
            try
            {
                //First Test
                a1 = (int)s1[x];
                s1.RemoveAt(y);
            }
            catch (ArgumentOutOfRangeException)
            {
                first = true;
            }

            try
            {
                //Second Test
                s2.RemoveAt(y);
                a2 = (int)s2[x];
            }
            catch (ArgumentOutOfRangeException)
            {
                second = true;
            }

            //NotpAssume.IsTrue((first && second) || (!first && !second && a1 == a2 && eq.Equals(s1, s2)));
            PexAssert.IsTrue((first && second) || (!first && !second && a1 == a2 && eq.Equals(s1, s2)));

        }



        [PexMethod]
        public void PUT_CommutativityGetSet([PexAssumeUnderTest] DataStructures.ArrayList s1, int x, int y, int y1)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(x > -101 && x < 101);
            PexAssume.IsTrue(y > -101 && y < 101);
            PexAssume.IsTrue(y1 > -101 && y1 < 101);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_s1.IndexOf(x)", s1.IndexOf(x));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(x)",s1.LastIndexOf(x));
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.IndexOf(y)", s1.IndexOf(y));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(y)", s1.LastIndexOf(y));
            PexObserve.ValueForViewing("$input_y1", y1);
            PexObserve.ValueForViewing("$input_s1.IndexOf(y1)", s1.IndexOf(y1));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(y1)", s1.LastIndexOf(y1));
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            PexObserve.ValueForViewing("$input_s1.Contains(y1)", s1.Contains(y1));
            AssumePrecondition.IsTrue(true);

            int a1 = -1, a2 = -1;
            int ad1 = -1, ad2 = -1;
            bool first = false, second = false;

            try
            {
                //First Test
                a1 = (int)s1[x];
                s1[y] = y1;
            }
            catch (ArgumentOutOfRangeException)
            {
                first = true;
            }
            try
            {
                //Second Test
                s2[y] = y1;
                a2 = (int)s2[x];
            }
            catch (ArgumentOutOfRangeException)
            {
                second = true;
            }
            //NotpAssume.IsTrue((first && second) || (!first && !second && a1 == a2 && eq.Equals(s1, s2)));            
            PexAssert.IsTrue((first && second) || (!first && !second && a1 == a2 && eq.Equals(s1, s2)));

        }

        [PexMethod]
        public void PUT_CommutativityIndexOfIndexOf([PexAssumeUnderTest] DataStructures.ArrayList s1, int x, int y)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(x > -101 && x < 101);
            PexAssume.IsTrue(y > -101 && y < 101);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_s1.IndexOf(x)", s1.IndexOf(x));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(x)",s1.LastIndexOf(x));
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.IndexOf(y)", s1.IndexOf(y));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(y)", s1.LastIndexOf(y));
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            AssumePrecondition.IsTrue(true);

            int a1 = -1, a2 = -1;
            int ad1 = -1, ad2 = -1;


            //First Test
            a1 = s1.IndexOf(x);
            ad1 = s1.IndexOf(y);

            //Second Test
            ad2 = s2.IndexOf(y);
            a2 = s2.IndexOf(x);
            //NotpAssume.IsTrue(a1 == a2 && ad1 == ad2 && eq.Equals(s1, s2));            
            PexAssert.IsTrue(a1 == a2 && ad1 == ad2 && eq.Equals(s1, s2));

        }

        [PexMethod]
        public void PUT_CommutativityIndexOfInsert([PexAssumeUnderTest] DataStructures.ArrayList s1, int x, int y, int y1)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(x > -101 && x < 101);
            PexAssume.IsTrue(y > -101 && y < 101);
            PexAssume.IsTrue(y1 > -101 && y1 < 101);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_s1.IndexOf(x)", s1.IndexOf(x));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(x)",s1.LastIndexOf(x));
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.IndexOf(y)", s1.IndexOf(y));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(y)", s1.LastIndexOf(y));
            PexObserve.ValueForViewing("$input_y1", y1);
            PexObserve.ValueForViewing("$input_s1.IndexOf(y1)", s1.IndexOf(y1));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(y1)", s1.LastIndexOf(y1));
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            PexObserve.ValueForViewing("$input_s1.Contains(y1)", s1.Contains(y1));
            AssumePrecondition.IsTrue(true);

            int a1 = -1, a2 = -1;
            int ad1 = -1, ad2 = -1;
            bool first = false, second = false;
            try
            {
                //First Test
                a1 = s1.IndexOf(x);
                s1.Insert(y, y1);
            }
            catch (ArgumentOutOfRangeException)
            {
                first = true;
            }
            try
            {
                //Second Test
                s2.Insert(y, y1);
                a2 = s2.IndexOf(x);
            }
            catch (ArgumentOutOfRangeException)
            {
                second = true;
            }
            //NotpAssume.IsTrue((first && second) || (!first && !second && a1 == a2 && eq.Equals(s1, s2)));            
            PexAssert.IsTrue((first && second) || (!first && !second && a1 == a2 && eq.Equals(s1, s2)));

        }

        [PexMethod]
        public void PUT_CommutativityIndexOfLastIndexOf([PexAssumeUnderTest] DataStructures.ArrayList s1, int x, int y)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(x > -101 && x < 101);
            PexAssume.IsTrue(y > -101 && y < 101);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_s1.IndexOf(x)", s1.IndexOf(x));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(x)",s1.LastIndexOf(x));
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.IndexOf(y)", s1.IndexOf(y));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(y)", s1.LastIndexOf(y));
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            AssumePrecondition.IsTrue(true);

            int a1 = -1, a2 = -1;
            int ad1 = -1, ad2 = -1;


            //First Test
            a1 = s1.IndexOf(x);
            ad1 = s1.LastIndexOf(y);

            //Second Test
            ad2 = s2.LastIndexOf(y);
            a2 = s2.IndexOf(x);
            //NotpAssume.IsTrue(a1 == a2 && ad1 == ad2 && eq.Equals(s1, s2));            
            PexAssert.IsTrue(a1 == a2 && ad1 == ad2 && eq.Equals(s1, s2));

        }

        [PexMethod]
        public void PUT_CommutativityIndexOfRemove([PexAssumeUnderTest] DataStructures.ArrayList s1, int x, int y)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(x > -101 && x < 101);
            PexAssume.IsTrue(y > -101 && y < 101);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_s1.IndexOf(x)", s1.IndexOf(x));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(x)",s1.LastIndexOf(x));
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.IndexOf(y)", s1.IndexOf(y));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(y)", s1.LastIndexOf(y));
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            AssumePrecondition.IsTrue(true);

            int a1 = -1, a2 = -1;
            int ad1 = -1, ad2 = -1;


            //First Test
            a1 = s1.IndexOf(x);
            s1.Remove(y);

            //Second Test
            s2.Remove(y);
            a2 = s2.IndexOf(x);
            //NotpAssume.IsTrue(a1 == a2 && eq.Equals(s1, s2));            
            PexAssert.IsTrue(a1 == a2 && eq.Equals(s1, s2));

        }

        [PexMethod]
        public void PUT_CommutativityIndexOfRemoveAt([PexAssumeUnderTest] DataStructures.ArrayList s1, int x, int y)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(x > -101 && x < 101);
            PexAssume.IsTrue(y > -101 && y < 101);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_s1.IndexOf(x)", s1.IndexOf(x));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(x)",s1.LastIndexOf(x));
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.IndexOf(y)", s1.IndexOf(y));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(y)", s1.LastIndexOf(y));
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            AssumePrecondition.IsTrue(true);

            int a1 = -1, a2 = -1;
            int ad1 = -1, ad2 = -1;
            bool first = false, second = false;

            try
            {
                //First Test
                a1 = s1.IndexOf(x);
                s1.RemoveAt(y);
            }
            catch (ArgumentOutOfRangeException)
            {
                first = true;
            }
            try
            {
                //Second Test
                s2.RemoveAt(y);
                a2 = s2.IndexOf(x);
            }
            catch (ArgumentOutOfRangeException)
            {
                second = true;
            }
            //NotpAssume.IsTrue((first && second) || (!first && !second && a1 == a2 && eq.Equals(s1, s2)));            
            PexAssert.IsTrue((first && second) || (!first && !second && a1 == a2 && eq.Equals(s1, s2)));

        }

        [PexMethod]
        public void PUT_CommutativityIndexOfSet([PexAssumeUnderTest] DataStructures.ArrayList s1, int x, int y, int y1)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(x > -101 && x < 101);
            PexAssume.IsTrue(y > -101 && y < 101);
            PexAssume.IsTrue(y1 > -101 && y1 < 101);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_s1.IndexOf(x)", s1.IndexOf(x));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(x)",s1.LastIndexOf(x));
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.IndexOf(y)", s1.IndexOf(y));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(y)", s1.LastIndexOf(y));
            PexObserve.ValueForViewing("$input_y1", y1);
            PexObserve.ValueForViewing("$input_s1.IndexOf(y1)", s1.IndexOf(y1));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(y1)", s1.LastIndexOf(y1));
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            PexObserve.ValueForViewing("$input_s1.Contains(y1)", s1.Contains(y1));
            AssumePrecondition.IsTrue(true);

            int a1 = -1, a2 = -1;
            int ad1 = -1, ad2 = -1;
            bool first = false, second = false;

            try
            {
                //First Test
                a1 = s1.IndexOf(x);
                s1[y] = y1;
            }
            catch (ArgumentOutOfRangeException)
            {
                first = true;
            }

            try
            {
                //Second Test
                s1[y] = y1;
                a2 = s2.IndexOf(x);
            }
            catch (ArgumentOutOfRangeException)
            {
                second = true;
            }

            //NotpAssume.IsTrue((first && second) || (!first && !second && a1 == a2 && eq.Equals(s1, s2)));
            PexAssert.IsTrue((first && second) || (!first && !second && a1 == a2 && eq.Equals(s1, s2)));

        }

        [PexMethod]
        public void PUT_CommutativityInsertInsert([PexAssumeUnderTest] DataStructures.ArrayList s1, int x, int x1, int y, int y1)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(x > -101 && x < 101);
            PexAssume.IsTrue(x1 > -101 && x1 < 101);
            PexAssume.IsTrue(y > -101 && y < 101);
            PexAssume.IsTrue(y1 > -101 && y1 < 101);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_s1.IndexOf(x)", s1.IndexOf(x));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(x)",s1.LastIndexOf(x));
            PexObserve.ValueForViewing("$input_x1", x1);
            PexObserve.ValueForViewing("$input_s1.IndexOf(x1)", s1.IndexOf(x1));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(x1)", s1.LastIndexOf(x1));
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.IndexOf(y)", s1.IndexOf(y));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(y)", s1.LastIndexOf(y));
            PexObserve.ValueForViewing("$input_y1", y1);
            PexObserve.ValueForViewing("$input_s1.IndexOf(y1)", s1.IndexOf(y1));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(y1)", s1.LastIndexOf(y1));
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(x1)", s1.Contains(x1));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            PexObserve.ValueForViewing("$input_s1.Contains(y1)", s1.Contains(y1));
            AssumePrecondition.IsTrue(true);

            int a1 = -1, a2 = -1;
            int ad1 = -1, ad2 = -1;
            bool first = false, second = false;
            try
            {
                //First Test
                s1.Insert(x, x1);
                s1.Insert(y, y1);
            }
            catch (ArgumentOutOfRangeException)
            {
                first = true;
            }
            try
            {
                //Second Test
                s2.Insert(y, y1);
                s2.Insert(x, x1);
            }
            catch (ArgumentOutOfRangeException)
            {
                second = true;
            }
            //NotpAssume.IsTrue((first && second) || (!first && !second && eq.Equals(s1, s2)));            
            PexAssert.IsTrue((first && second) || (!first && !second && eq.Equals(s1, s2)));

        }

        [PexMethod]
        public void PUT_CommutativityInsertLastIndexOf([PexAssumeUnderTest] DataStructures.ArrayList s1, int x, int x1, int y)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(x > -101 && x < 101);
            PexAssume.IsTrue(x1 > -101 && x1 < 101);
            PexAssume.IsTrue(y > -101 && y < 101);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_s1.IndexOf(x)", s1.IndexOf(x));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(x)",s1.LastIndexOf(x));
            PexObserve.ValueForViewing("$input_x1", x1);
            PexObserve.ValueForViewing("$input_s1.IndexOf(x1)", s1.IndexOf(x1));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(x1)", s1.LastIndexOf(x1));
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.IndexOf(y)", s1.IndexOf(y));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(y)", s1.LastIndexOf(y));
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(x1)", s1.Contains(x1));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            AssumePrecondition.IsTrue(true);

            int a1 = -1, a2 = -1;
            int ad1 = -1, ad2 = -1;
            bool first = false, second = false;
            try
            {
                //First Test
                s1.Insert(x, x1);
                ad1 = s1.LastIndexOf(y);
            }
            catch (ArgumentOutOfRangeException)
            {
                first = true;
            }
            try
            {
                //Second Test
                ad2 = s2.LastIndexOf(y);
                s2.Insert(x, x1);
            }
            catch (ArgumentOutOfRangeException)
            {
                second = true;
            }
            //NotpAssume.IsTrue((first && second) || (!first && !second && ad1 == ad2 && eq.Equals(s1, s2)));            
            PexAssert.IsTrue((first && second) || (!first && !second && ad1 == ad2 && eq.Equals(s1, s2)));

        }

        [PexMethod]
        public void PUT_CommutativityInsertRemove([PexAssumeUnderTest]  DataStructures.ArrayList s1, int x, int x1, int y)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(x > -101 && x < 101);
            PexAssume.IsTrue(x1 > -101 && x1 < 101);
            PexAssume.IsTrue(y > -101 && y < 101);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_s1.IndexOf(x)", s1.IndexOf(x));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(x)",s1.LastIndexOf(x));
            PexObserve.ValueForViewing("$input_x1", x1);
            PexObserve.ValueForViewing("$input_s1.IndexOf(x1)", s1.IndexOf(x1));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(x1)", s1.LastIndexOf(x1));
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.IndexOf(y)", s1.IndexOf(y));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(y)", s1.LastIndexOf(y));
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(x1)", s1.Contains(x1));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            AssumePrecondition.IsTrue(true);

            int a1 = -1, a2 = -1;
            int ad1 = -1, ad2 = -1;
            bool first = false, second = false;
            try
            {
                //First Test
                s1.Insert(x, x1);
                s1.Remove(y);
            }
            catch (ArgumentOutOfRangeException)
            {
                first = true;
            }
            try
            {
                //Second Test
                s2.Remove(y);
                s2.Insert(x, x1);
            }
            catch (ArgumentOutOfRangeException)
            {
                second = true;
            }
            //NotpAssume.IsTrue((first && second) || (!first && !second && eq.Equals(s1, s2)));            
            PexAssert.IsTrue((first && second) || (!first && !second && eq.Equals(s1, s2)));

        }

        [PexMethod]
        public void PUT_CommutativityInsertRemoveAt([PexAssumeUnderTest] DataStructures.ArrayList s1, int x, int x1, int y)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(x > -101 && x < 101);
            PexAssume.IsTrue(x1 > -101 && x1 < 101);
            PexAssume.IsTrue(y > -101 && y < 101);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_s1.IndexOf(x)", s1.IndexOf(x));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(x)",s1.LastIndexOf(x));
            PexObserve.ValueForViewing("$input_x1", x1);
            PexObserve.ValueForViewing("$input_s1.IndexOf(x1)", s1.IndexOf(x1));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(x1)", s1.LastIndexOf(x1));
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.IndexOf(y)", s1.IndexOf(y));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(y)", s1.LastIndexOf(y));
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(x1)", s1.Contains(x1));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            AssumePrecondition.IsTrue(true);

            int a1 = -1, a2 = -1;
            int ad1 = -1, ad2 = -1;
            bool first = false, second = false;

            try
            {
                //First Test
                s1.Insert(x, x1);
                s1.RemoveAt(y);
            }
            catch (ArgumentOutOfRangeException)
            {
                first = true;
            }
            try
            {
                //Second Test
                s2.RemoveAt(y);
                s2.Insert(x, x1);
            }
            catch (ArgumentOutOfRangeException)
            {
                second = true;
            }
            //NotpAssume.IsTrue((first && second) || (!first && !second && eq.Equals(s1, s2)));            
            PexAssert.IsTrue((first && second) || (!first && !second && eq.Equals(s1, s2)));

        }

        [PexMethod]
        public void PUT_CommutativityInsertSet([PexAssumeUnderTest] DataStructures.ArrayList s1, int x, int x1, int y, int y1)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(x > -101 && x < 101);
            PexAssume.IsTrue(x1 > -101 && x1 < 101);
            PexAssume.IsTrue(y > -101 && y < 101);
            PexAssume.IsTrue(y1 > -101 && y1 < 101);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_s1.IndexOf(x)", s1.IndexOf(x));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(x)",s1.LastIndexOf(x));
            PexObserve.ValueForViewing("$input_x1", x1);
            PexObserve.ValueForViewing("$input_s1.IndexOf(x1)", s1.IndexOf(x1));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(x1)", s1.LastIndexOf(x1));
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.IndexOf(y)", s1.IndexOf(y));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(y)", s1.LastIndexOf(y));
            PexObserve.ValueForViewing("$input_y1", y1);
            PexObserve.ValueForViewing("$input_s1.IndexOf(y1)", s1.IndexOf(y1));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(y1)", s1.LastIndexOf(y1));
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(x1)", s1.Contains(x1));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            PexObserve.ValueForViewing("$input_s1.Contains(y1)", s1.Contains(y1));
            AssumePrecondition.IsTrue(true);

            int a1 = -1, a2 = -1;
            int ad1 = -1, ad2 = -1;
            bool first = false, second = false;

            try
            {
                //First Test
                s1.Insert(x, x1);
                s1[y] = y1;
            }
            catch (ArgumentOutOfRangeException)
            {
                first = true;
            }

            try
            {
                //Second Test
                s2[y] = y1;
                s2.Insert(x, x1);
            }
            catch (ArgumentOutOfRangeException)
            {
                second = true;
            }
            //NotpAssume.IsTrue((first && second) || (!first && !second && eq.Equals(s1, s2)));            
            PexAssert.IsTrue((first && second) || (!first && !second && eq.Equals(s1, s2)));

        }

        [PexMethod]
        public void PUT_CommutativityLastIndexOfLastIndexOf([PexAssumeUnderTest] DataStructures.ArrayList s1, int x, int y)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(x > -101 && x < 101);
            PexAssume.IsTrue(y > -101 && y < 101);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_s1.IndexOf(x)", s1.IndexOf(x));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(x)",s1.LastIndexOf(x));
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.IndexOf(y)", s1.IndexOf(y));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(y)", s1.LastIndexOf(y));
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            AssumePrecondition.IsTrue(true);

            int a1 = -1, a2 = -1;
            int ad1 = -1, ad2 = -1;


            //First Test
            a1 = s1.LastIndexOf(x);
            ad1 = s1.LastIndexOf(y);


            //Second Test
            ad2 = s2.LastIndexOf(y);
            a2 = s2.LastIndexOf(x);
            //NotpAssume.IsTrue(a1 == a2 && ad1 == ad2 && eq.Equals(s1, s2));            
            PexAssert.IsTrue(a1 == a2 && ad1 == ad2 && eq.Equals(s1, s2));

        }

        [PexMethod]
        public void PUT_CommutativityLastIndexOfRemove([PexAssumeUnderTest] DataStructures.ArrayList s1, int x, int y)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(x > -101 && x < 101);
            PexAssume.IsTrue(y > -101 && y < 101);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_s1.IndexOf(x)", s1.IndexOf(x));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(x)",s1.LastIndexOf(x));
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.IndexOf(y)", s1.IndexOf(y));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(y)", s1.LastIndexOf(y));
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            AssumePrecondition.IsTrue(true);

            int a1 = -1, a2 = -1;
            int ad1 = -1, ad2 = -1;


            //First Test
            a1 = s1.LastIndexOf(x);
            s1.Remove(y);


            //Second Test
            s2.Remove(y);
            a2 = s2.LastIndexOf(x);
            //NotpAssume.IsTrue(a1 == a2 && eq.Equals(s1, s2));            
            PexAssert.IsTrue(a1 == a2 && eq.Equals(s1, s2));

        }

        [PexMethod]
        public void PUT_CommutativityLastIndexOfRemoveAt([PexAssumeUnderTest] DataStructures.ArrayList s1, int x, int y)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(x > -101 && x < 101);
            PexAssume.IsTrue(y > -101 && y < 101);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_s1.IndexOf(x)", s1.IndexOf(x));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(x)",s1.LastIndexOf(x));
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.IndexOf(y)", s1.IndexOf(y));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(y)", s1.LastIndexOf(y));
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            AssumePrecondition.IsTrue(true);

            int a1 = -1, a2 = -1;
            int ad1 = -1, ad2 = -1;
            bool first = false, second = false;

            try
            {
                //First Test
                a1 = s1.LastIndexOf(x);
                s1.RemoveAt(y);
            }
            catch (ArgumentOutOfRangeException)
            {
                first = true;
            }

            try
            {
                //Second Test
                s2.RemoveAt(y);
                a2 = s2.LastIndexOf(x);
            }
            catch (ArgumentOutOfRangeException)
            {
                second = true;
            }
            //NotpAssume.IsTrue((first && second) || (!first && !second && a1 == a2 && eq.Equals(s1, s2)));            
            PexAssert.IsTrue((first && second) || (!first && !second && a1 == a2 && eq.Equals(s1, s2)));

        }

        [PexMethod]
        public void PUT_CommutativityLastIndexOfSet([PexAssumeUnderTest] DataStructures.ArrayList s1, int x, int y, int y1)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(x > -101 && x < 101);
            PexAssume.IsTrue(y > -101 && y < 101);
            PexAssume.IsTrue(y1 > -101 && y1 < 101);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_s1.IndexOf(x)", s1.IndexOf(x));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(x)",s1.LastIndexOf(x));
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.IndexOf(y)", s1.IndexOf(y));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(y)", s1.LastIndexOf(y));
            PexObserve.ValueForViewing("$input_y1", y1);
            PexObserve.ValueForViewing("$input_s1.IndexOf(y1)", s1.IndexOf(y1));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(y1)", s1.LastIndexOf(y1));
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            PexObserve.ValueForViewing("$input_s1.Contains(y1)", s1.Contains(y1));
            AssumePrecondition.IsTrue(true);

            int a1 = -1, a2 = -1;
            int ad1 = -1, ad2 = -1;
            bool first = false, second = false;
            try
            {
                //First Test
                a1 = s1.LastIndexOf(x);
                s1[y] = y1;
            }
            catch (ArgumentOutOfRangeException)
            {
                first = true;
            }
            try
            {
                //Second Test
                s2[y] = y1;
                a2 = s2.LastIndexOf(x);
            }
            catch (ArgumentOutOfRangeException)
            {
                second = true;
            }
            //NotpAssume.IsTrue((first && second) || (!first && !second && a1 == a2 && eq.Equals(s1, s2)));            
            PexAssert.IsTrue((first && second) || (!first && !second && a1 == a2 && eq.Equals(s1, s2)));

        }

        [PexMethod]
        public void PUT_CommutativityRemoveRemove([PexAssumeUnderTest] DataStructures.ArrayList s1, int x, int y)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(x > -101 && x < 101);
            PexAssume.IsTrue(y > -101 && y < 101);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_s1.IndexOf(x)", s1.IndexOf(x));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(x)",s1.LastIndexOf(x));
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.IndexOf(y)", s1.IndexOf(y));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(y)", s1.LastIndexOf(y));
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            AssumePrecondition.IsTrue(true);

            int a1 = -1, a2 = -1;
            int ad1 = -1, ad2 = -1;


            //First Test
            s1.Remove(x);
            s1.Remove(y);


            //Second Test
            s2.Remove(y);
            s2.Remove(x);
            //NotpAssume.IsTrue(eq.Equals(s1, s2));            
            PexAssert.IsTrue(eq.Equals(s1, s2));

        }

        [PexMethod]
        public void PUT_CommutativityRemoveRemoveAt([PexAssumeUnderTest] DataStructures.ArrayList s1, int x, int y)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(x > -101 && x < 101);
            PexAssume.IsTrue(y > -101 && y < 101);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_s1.IndexOf(x)", s1.IndexOf(x));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(x)",s1.LastIndexOf(x));
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.IndexOf(y)", s1.IndexOf(y));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(y)", s1.LastIndexOf(y));
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            AssumePrecondition.IsTrue(true);

            int a1 = -1, a2 = -1;
            int ad1 = -1, ad2 = -1;
            bool first = false, second = false;

            try
            {
                //First Test
                s1.Remove(x);
                s1.RemoveAt(y);
            }
            catch (ArgumentOutOfRangeException)
            {
                first = true;
            }
            try
            {
                //Second Test
                s2.RemoveAt(y);
                s2.Remove(x);
            }
            catch (ArgumentOutOfRangeException)
            {
                second = true;
            }
            //NotpAssume.IsTrue((first && second) || (!first && !second && eq.Equals(s1, s2)));            
            PexAssert.IsTrue((first && second) || (!first && !second && eq.Equals(s1, s2)));

        }

        [PexMethod]
        public void PUT_CommutativityRemoveSet([PexAssumeUnderTest] DataStructures.ArrayList s1, int x, int y, int y1)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(x > -101 && x < 101);
            PexAssume.IsTrue(y > -101 && y < 101);
            PexAssume.IsTrue(y1 > -101 && y1 < 101);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_s1.IndexOf(x)", s1.IndexOf(x));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(x)",s1.LastIndexOf(x));
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.IndexOf(y)", s1.IndexOf(y));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(y)", s1.LastIndexOf(y));
            PexObserve.ValueForViewing("$input_y1", y1);
            PexObserve.ValueForViewing("$input_s1.IndexOf(y1)", s1.IndexOf(y1));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(y1)", s1.LastIndexOf(y1));
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            PexObserve.ValueForViewing("$input_s1.Contains(y1)", s1.Contains(y1));
            AssumePrecondition.IsTrue(true);

            int a1 = -1, a2 = -1;
            int ad1 = -1, ad2 = -1;
            bool first = false, second = false;

            try
            {
                //First Test
                s1.Remove(x);
                s1[y] = y1;
            }
            catch (ArgumentOutOfRangeException)
            {
                first = true;
            }
            try
            {
                //Second Test
                s2[y] = y1;
                s2.Remove(x);
            }
            catch (ArgumentOutOfRangeException)
            {
                second = true;
            }

            //NotpAssume.IsTrue((first && second) || (!first && !second && eq.Equals(s1, s2)));
            PexAssert.IsTrue((first && second) || (!first && !second && eq.Equals(s1, s2)));

        }

        [PexMethod]
        public void PUT_CommutativityRemoveAtRemoveAt([PexAssumeUnderTest] DataStructures.ArrayList s1, int x, int y)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(x > -101 && x < 101);
            PexAssume.IsTrue(y > -101 && y < 101);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_s1.IndexOf(x)", s1.IndexOf(x));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(x)",s1.LastIndexOf(x));
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.IndexOf(y)", s1.IndexOf(y));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(y)", s1.LastIndexOf(y));
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            AssumePrecondition.IsTrue(true);

            int a1 = -1, a2 = -1;
            int ad1 = -1, ad2 = -1;
            bool first = false, second = false;

            try
            {
                //First Test
                s1.RemoveAt(x);
                s1.RemoveAt(y);
            }
            catch (ArgumentOutOfRangeException)
            {
                first = true;
            }
            try
            {
                //Second Test
                s2.RemoveAt(y);
                s2.RemoveAt(x);
            }
            catch (ArgumentOutOfRangeException)
            {
                second = true;
            }
            //NotpAssume.IsTrue((first && second) || (!first && !second && eq.Equals(s1, s2)));            
            PexAssert.IsTrue((first && second) || (!first && !second && eq.Equals(s1, s2)));

        }


        [PexMethod]
        public void PUT_CommutativityRemoveAtSet([PexAssumeUnderTest] DataStructures.ArrayList s1, int x, int y, int y1)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(x > -101 && x < 101);
            PexAssume.IsTrue(y > -101 && y < 101);
            PexAssume.IsTrue(y1 > -101 && y1 < 101);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_s1.IndexOf(x)", s1.IndexOf(x));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(x)",s1.LastIndexOf(x));
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.IndexOf(y)", s1.IndexOf(y));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(y)", s1.LastIndexOf(y));
            PexObserve.ValueForViewing("$input_y1", y1);
            PexObserve.ValueForViewing("$input_s1.IndexOf(y1)", s1.IndexOf(y1));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(y1)", s1.LastIndexOf(y1));
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            PexObserve.ValueForViewing("$input_s1.Contains(y1)", s1.Contains(y1));
            AssumePrecondition.IsTrue(true);

            int a1 = -1, a2 = -1;
            int ad1 = -1, ad2 = -1;
            bool first = false, second = false;

            try
            {
                //First Test
                s1.RemoveAt(x);
                s1[y] = y1;
            }
            catch (ArgumentOutOfRangeException)
            {
                first = true;
            }

            try
            {
                //Second Test
                s2[y] = y1;
                s2.RemoveAt(x);
            }
            catch (ArgumentOutOfRangeException)
            {
                second = true;
            }
            //NotpAssume.IsTrue((first && second) || (!first && !second && eq.Equals(s1, s2)));            
            PexAssert.IsTrue((first && second) || (!first && !second && eq.Equals(s1, s2)));

        }

        [PexMethod]
        public void PUT_CommutativitySetSet([PexAssumeUnderTest] DataStructures.ArrayList s1, int x, int x1, int y, int y1)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(x > -101 && x < 101);
            PexAssume.IsTrue(x1 > -101 && x1 < 101);
            PexAssume.IsTrue(y > -101 && y < 101);
            PexAssume.IsTrue(y1 > -101 && y1 < 101);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_s1.IndexOf(x)", s1.IndexOf(x));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(x)",s1.LastIndexOf(x));
            PexObserve.ValueForViewing("$input_x1", x1);
            PexObserve.ValueForViewing("$input_s1.IndexOf(x1)", s1.IndexOf(x1));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(x1)", s1.LastIndexOf(x1));
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.IndexOf(y)", s1.IndexOf(y));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(y)", s1.LastIndexOf(y));
            PexObserve.ValueForViewing("$input_y1", y1);
            PexObserve.ValueForViewing("$input_s1.IndexOf(y1)", s1.IndexOf(y1));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(y1)", s1.LastIndexOf(y1));
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(x1)", s1.Contains(x1));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            PexObserve.ValueForViewing("$input_s1.Contains(y1)", s1.Contains(y1));
            AssumePrecondition.IsTrue(true);

            int a1 = -1, a2 = -1;
            int ad1 = -1, ad2 = -1;
            bool first = false, second = false;

            try
            {
                //First Test
                s1[x] = x1;
                s1[y] = y1;
            }
            catch (ArgumentOutOfRangeException)
            {
                first = true;
            }

            try
            {
                //Second Test
                s2[y] = y1;
                s2[x] = x1;
            }
            catch (ArgumentOutOfRangeException)
            {
                second = true;
            }
            //NotpAssume.IsTrue((first && second) || (!first && !second && eq.Equals(s1, s2)));            
            PexAssert.IsTrue((first && second) || (!first && !second && eq.Equals(s1, s2)));

        }

    }
}
