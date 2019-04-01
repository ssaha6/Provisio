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
            PexObserve.ValueForViewing("$input_s1.IndexOf(x)", s1.IndexOf(x));
            PexObserve.ValueForViewing("$input_s1.IndexOf(y)", s1.IndexOf(y));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(x)", s1.LastIndexOf(x));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(y)", s1.LastIndexOf(y));
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));



            AssumePrecondition.IsTrue(!(true));

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

            PexAssume.IsTrue(x > -11 && x < 11);
            PexAssume.IsTrue(y > -11 && y < 11);

            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.IndexOf(x)", s1.IndexOf(x));
            PexObserve.ValueForViewing("$input_s1.IndexOf(y)", s1.IndexOf(y));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(x)", s1.LastIndexOf(x));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(y)", s1.LastIndexOf(y));
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));

            AssumePrecondition.IsTrue(true);
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

            PexAssume.IsTrue(x > -11 && x < 11);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_s1.IndexOf(x)", s1.IndexOf(x));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(x)", s1.LastIndexOf(x));
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

            NotpAssume.IsTrue(a1 == a2 && ad1 == ad2 && eq.Equals(s1, s2));
            PexAssert.IsTrue(a1 == a2 && ad1 == ad2 && eq.Equals(s1, s2));
        }


        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityAddGet([PexAssumeUnderTest] DataStructures.ArrayList s1, int x, int y)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(x > -11 && x < 11);
            PexAssume.IsTrue(y > -11 && y < 11);


            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.IndexOf(x)", s1.IndexOf(x));
            PexObserve.ValueForViewing("$input_s1.IndexOf(y)", s1.IndexOf(y));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(x)", s1.LastIndexOf(x));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(y)", s1.LastIndexOf(y));
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));

            AssumePrecondition.IsTrue(!(((y == s1.LastIndexOf(x)) && (s1.Contains(x))) || (( ! (s1.IndexOf(x) == s1.LastIndexOf(x))) && (y == s1.IndexOf(x))) || (( ! (y == s1.LastIndexOf(x))) && ( ! (y == s1.IndexOf(x))) && (-1*s1.Count +  y +  -1*s1.IndexOf(x) +  -1*s1.IndexOf(y) +  s1.LastIndexOf(x) +  s1.LastIndexOf(y) <=  -1) && (y >= 0))));

            int a1 = -1, a2 = -1;
            Object ad1 = -1, ad2 = -1;
            
            
                //First Test
                a1 = s1.Add(x);
                ad1 = s1[y]; //this is how you write the method get
            
                //Second Test
                ad2 = s2[y]; //this is how you write the method get
                a2 = s2.Add(x);

            NotpAssume.IsTrue((a1 == a2 && ad1 == ad2 && eq.Equals(s1, s2)));            
            PexAssert.IsTrue( (a1 == a2 && ad1.Equals(ad2) && eq.Equals(s1, s2)));
        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityAddIndexOf([PexAssumeUnderTest] DataStructures.ArrayList s1, int x, int y)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(x > -11 && x < 11);
            PexAssume.IsTrue(y > -11 && y < 11);

            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.IndexOf(x)", s1.IndexOf(x));
            PexObserve.ValueForViewing("$input_s1.IndexOf(y)", s1.IndexOf(y));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(x)", s1.LastIndexOf(x));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(y)", s1.LastIndexOf(y));
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            AssumePrecondition.IsTrue((( false )));

            int a1 = -1, a2 = -1;
            int ad1 = -1, ad2 = -1;

            //First Test
            a1 = s1.Add(x);
            ad1 = s1.IndexOf(y);

            //Second Test
            ad2 = s2.IndexOf(y);
            a2 = s2.Add(x);

            NotpAssume.IsTrue(a1 == a2 && ad1 == ad2 && eq.Equals(s1, s2));
            PexAssert.IsTrue(a1 == a2 && ad1 == ad2 && eq.Equals(s1, s2));


        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityAddInsert([PexAssumeUnderTest] DataStructures.ArrayList s1, int x, int y, int y1)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(x > -11 && x < 11);
            PexAssume.IsTrue(y > -11 && y < 11);
            PexAssume.IsTrue(y1 > -101 && y1 < 101);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_y1", y1);
            PexObserve.ValueForViewing("$input_s1.IndexOf(x)", s1.IndexOf(x));
            PexObserve.ValueForViewing("$input_s1.IndexOf(y)", s1.IndexOf(y));
            PexObserve.ValueForViewing("$input_s1.IndexOf(y1)", s1.IndexOf(y1));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(x)", s1.LastIndexOf(x));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(y)", s1.LastIndexOf(y));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(y1)", s1.LastIndexOf(y1));
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

            NotpAssume.IsTrue(a1 == a2 && eq.Equals(s1, s2));
            PexAssert.IsTrue(a1 == a2 && eq.Equals(s1, s2));
        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityAddLastIndexOf([PexAssumeUnderTest] DataStructures.ArrayList s1, int x, int y)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(x > -11 && x < 11);
            PexAssume.IsTrue(y > -11 && y < 11);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.IndexOf(x)", s1.IndexOf(x));
            PexObserve.ValueForViewing("$input_s1.IndexOf(y)", s1.IndexOf(y));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(x)", s1.LastIndexOf(x));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(y)", s1.LastIndexOf(y));
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            AssumePrecondition.IsTrue(  ((!(x == y))) );

            int a1 = -1, a2 = -1;
            int ad1 = -1, ad2 = -1;

            //First Test
            a1 = s1.Add(x);
            ad1 = s1.LastIndexOf(y);

            //Second Test
            ad2 = s2.LastIndexOf(y);
            a2 = s2.Add(x);

            NotpAssume.IsTrue(a1 == a2 && ad1 == ad2 && eq.Equals(s1, s2));
            PexAssert.IsTrue(a1 == a2 && ad1 == ad2 && eq.Equals(s1, s2));

        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityAddRemove([PexAssumeUnderTest] DataStructures.ArrayList s1, int x, int y)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(x > -11 && x < 11);
            PexAssume.IsTrue(y > -11 && y < 11);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.IndexOf(x)", s1.IndexOf(x));
            PexObserve.ValueForViewing("$input_s1.IndexOf(y)", s1.IndexOf(y));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(x)", s1.LastIndexOf(x));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(y)", s1.LastIndexOf(y));
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            AssumePrecondition.IsTrue((( false )));

            int a1 = -1, a2 = -1;
            int ad1 = -1, ad2 = -1;

            //First Test
            a1 = s1.Add(x);
            s1.Remove(y);

            //Second Test
            s2.Remove(y);
            a2 = s2.Add(x);

            NotpAssume.IsTrue(a1 == a2 && eq.Equals(s1, s2));
            PexAssert.IsTrue(a1 == a2 && eq.Equals(s1, s2));

        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityAddRemoveAt([PexAssumeUnderTest] DataStructures.ArrayList s1, int x, int y)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(x > -11 && x < 11);
            PexAssume.IsTrue(y > -11 && y < 11);

            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.IndexOf(x)", s1.IndexOf(x));
            PexObserve.ValueForViewing("$input_s1.IndexOf(y)", s1.IndexOf(y));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(x)", s1.LastIndexOf(x));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(y)", s1.LastIndexOf(y));
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            
            AssumePrecondition.IsTrue(  true);

            int a1 = -1, a2 = -1;

            
            //First Test
            a1 = s1.Add(x);
            s1.RemoveAt(y);
            
            //Second Test
            s2.RemoveAt(y);
            a2 = s2.Add(x);

            //NotpAssume.IsTrue((a1 == a2 && eq.Equals(s1, s2)));            
            PexAssert.IsTrue((a1 == a2 && eq.Equals(s1, s2)));

        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityAddSet([PexAssumeUnderTest] DataStructures.ArrayList s1, int x, int y, int y1)
        {
            DataStructures.ArrayList s2 = new DataStructures.ArrayList(s1);
            ArrayListEqualityComparer eq = new ArrayListEqualityComparer();

            PexAssume.IsTrue(x > -11 && x < 11);
            PexAssume.IsTrue(y > -11 && y < 11);
            PexAssume.IsTrue(y1 > -11 && y1 < 11);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_y1", y1);
            PexObserve.ValueForViewing("$input_s1.IndexOf(x)", s1.IndexOf(x));
            PexObserve.ValueForViewing("$input_s1.IndexOf(y)", s1.IndexOf(y));
            PexObserve.ValueForViewing("$input_s1.IndexOf(y1)", s1.IndexOf(y1));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(x)", s1.LastIndexOf(x));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(y)", s1.LastIndexOf(y));
            PexObserve.ValueForViewing("$input_s1.LastIndexOf(y1)", s1.LastIndexOf(y1));
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            PexObserve.ValueForViewing("$input_s1.Contains(y1)", s1.Contains(y1));
            AssumePrecondition.IsTrue(!(true));

            int a1 = -1, a2 = -1;
            int ad1 = -1, ad2 = -1;


            //First Test
            a1 = s1.Add(x);
            s1[y] = y1;

            //Second Test
            s2[y] = y1;
            a2 = s2.Add(x);

            NotpAssume.IsTrue((a1 == a2 && eq.Equals(s1, s2)));
            PexAssert.IsTrue((a1 == a2 && eq.Equals(s1, s2)));

        }
    }
}
       
