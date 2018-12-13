using System;
using System.Text;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures;
using DataStructures.Utility;
using PexAPIWrapper;
namespace DataStructures.Comm.Test
{
    [PexClass(typeof(DataStructures.HashSet<int>))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class HashSetCommuteTest
    {
        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityContainsContainsComm([PexAssumeUnderTest]DataStructures.HashSet<int> s1, int x, int y)
        {

            DataStructures.HashSet<int> s2 = new DataStructures.HashSet<int>(s1, s1.Comparer);

            HashSetEqualityComparer<int> eq = new HashSetEqualityComparer<int>();

            PexAssume.IsTrue(x > -101 && x < 101);
            PexAssume.IsTrue(y > -101 && y < 101);
            PexObserve.ValueForViewing("$input_s1.count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            AssumePrecondition.IsTrue(true);


            bool c1 = false, c2 = false;
            bool cc1 = false, cc2 = false;

            // First test
            c1 = s1.Contains(x);
            cc1 = s1.Contains(y);

            // Second test 
            cc2 = s2.Contains(y);
            c2 = s2.Contains(x);

            //NotpAssume.IsTrue(c1 == c2 && cc1 == cc2 && eq.Equals(s1, s2));
            PexAssert.IsTrue(c1 == c2 && cc1 == cc2 && eq.Equals(s1, s2));

        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityContainsAddComm([PexAssumeUnderTest]DataStructures.HashSet<int> s1, int x, int y)
        {

            DataStructures.HashSet<int> s2 = new DataStructures.HashSet<int>(s1, s1.Comparer);

            HashSetEqualityComparer<int> eq = new HashSetEqualityComparer<int>();

            PexAssume.IsTrue(x > -101 && x < 101);
            PexAssume.IsTrue(y > -101 && y < 101);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            AssumePrecondition.IsTrue( (( s1.Contains(x) ) && (true)) ||  ((!( s1.Contains(x) )) && ((( -1*x + 1*y <= -1 ) && (true)) ||  ((!( -1*x + 1*y <= -1 )) && ((( -1*x + 1*y <= 0 ) && (false)) ||  ((!( -1*x + 1*y <= 0 )) && (true)))))) );

            bool c1 = false, c2 = false;
            bool a1 = false, a2 = false;

            // First test
            c1 = s1.Contains(x);
            a1 = s1.Add(y);

            // Second test 
            a2 = s2.Add(y);
            c2 = s2.Contains(x);

            //NotpAssume.IsTrue(c1 == c2 && a1 == a2 && eq.Equals(s1, s2));
            PexAssert.IsTrue(c1 == c2 && a1 == a2 && eq.Equals(s1, s2));

        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityContainsRemoveComm([PexAssumeUnderTest]DataStructures.HashSet<int> s1, int x, int y)
        {
            
            DataStructures.HashSet<int> s2 = new DataStructures.HashSet<int>(s1, s1.Comparer);

            HashSetEqualityComparer<int> eq = new HashSetEqualityComparer<int>();

            PexAssume.IsTrue(x > -101 && x < 101);
            PexAssume.IsTrue(y > -101 && y < 101);
            PexObserve.ValueForViewing("$input_s1.count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            //PexObserve.ValueForViewing("S1 before State: ", s1.ToStringForInt());
            //PexObserve.ValueForViewing("S2 before State: ", s2.ToStringForInt());
            AssumePrecondition.IsTrue( (( s1.Contains(y) ) && ((( s1.Count <= 1 ) && (false)) ||  ((!( s1.Count <= 1 )) && ((( 0*s1.Count + -1*x + 1*y <= -1 ) && (true)) ||  ((!( 0*s1.Count + -1*x + 1*y <= -1 )) && ((( 0*s1.Count + -1*x + 1*y <= 0 ) && (false)) ||  ((!( 0*s1.Count + -1*x + 1*y <= 0 )) && (true)))))))) ||  ((!( s1.Contains(y) )) && (true)) );


            bool c1 = false, c2 = false;
            bool r1 = false, r2 = false;

            // First test
            c1 = s1.Contains(x);
            r1 = s1.Remove(y);

            // Second test 
            r2 = s2.Remove(y);
            c2 = s2.Contains(x);

            //PexObserve.ValueForViewing("S1 after State: ", s1.ToStringForInt());
            //PexObserve.ValueForViewing("S2 after State: ", s2.ToStringForInt());
            
            //NotpAssume.IsTrue(c1 == c2 && r1 == r2 && eq.Equals(s1, s2));
            PexAssert.IsTrue(c1 == c2 && r1 == r2 && eq.Equals(s1, s2));

        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityContainsSizeComm([PexAssumeUnderTest]DataStructures.HashSet<int> s1, int x)
        {

            DataStructures.HashSet<int> s2 = new DataStructures.HashSet<int>(s1, s1.Comparer);

            HashSetEqualityComparer<int> eq = new HashSetEqualityComparer<int>();

            PexAssume.IsTrue(x > -101 && x < 101);
            PexObserve.ValueForViewing("$input_s1.count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            AssumePrecondition.IsTrue(true);

            bool c1 = false, c2 = false;
            int si1 = -1, si2 = -1;

            // First test
            c1 = s1.Contains(x);
            si1 = s1.Count;

            // Second test 
            si2 = s2.Count;
            c2 = s2.Contains(x);

            //NotpAssume.IsTrue(c1 == c2 && si1 == si2 && eq.Equals(s1, s2));
            PexAssert.IsTrue(c1 == c2 && si1 == si2 && eq.Equals(s1, s2));

        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityAddAddComm([PexAssumeUnderTest]DataStructures.HashSet<int> s1, int x, int y)
        {

            DataStructures.HashSet<int> s2 = new DataStructures.HashSet<int>(s1, s1.Comparer);

            HashSetEqualityComparer<int> eq = new HashSetEqualityComparer<int>();

            PexAssume.IsTrue(x > -101 && x < 101);
            PexAssume.IsTrue(y > -101 && y < 101);
            //PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            AssumePrecondition.IsTrue( (( s1.Contains(x) ) && (true)) ||  ((!( s1.Contains(x) )) && ((( s1.Contains(y) ) && (true)) ||  ((!( s1.Contains(y) )) && ((( -1*x + 1*y <= -1 ) && (true)) ||  ((!( -1*x + 1*y <= -1 )) && ((( -1*x + 1*y <= 0 ) && (false)) ||  ((!( -1*x + 1*y <= 0 )) && (true)))))))) );

            bool a1 = false, a2 = false;
            bool ad1 = false, ad2 = false;

            // First test
            a1 = s1.Add(x);
            ad1 = s1.Add(y);

            // Second test 
            ad2 = s2.Add(y);
            a2 = s2.Add(x);

            //NotpAssume.IsTrue(a1 == a2 && ad1 == ad2 && eq.Equals(s1, s2));
            PexAssert.IsTrue(a1 == a2 && ad1 == ad2 && eq.Equals(s1, s2));

        }
        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityAddRemoveComm([PexAssumeUnderTest]DataStructures.HashSet<int> s1, int x, int y)
        {

            DataStructures.HashSet<int> s2 = new DataStructures.HashSet<int>(s1, s1.Comparer);

            HashSetEqualityComparer<int> eq = new HashSetEqualityComparer<int>();

            PexAssume.IsTrue(x > -101 && x < 101);
            PexAssume.IsTrue(y > -101 && y < 101);
            PexObserve.ValueForViewing("$input_s1.count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(x));
            AssumePrecondition.IsTrue( (( 0*s1.Count + -1*x + 1*y <= -1 ) && (true)) ||  ((!( 0*s1.Count + -1*x + 1*y <= -1 )) && ((( 0*s1.Count + -1*x + 1*y <= 0 ) && (false)) ||  ((!( 0*s1.Count + -1*x + 1*y <= 0 )) && (true)))) );

            bool a1 = false, a2 = false;
            bool r1 = false, r2 = false;

            // First test
            a1 = s1.Add(x);
            r1 = s1.Remove(y);

            // Second test 
            r2 = s2.Remove(y);
            a2 = s2.Add(x);

            //NotpAssume.IsTrue(a1 == a2 && r1 == r2 && eq.Equals(s1, s2));
            PexAssert.IsTrue(a1 == a2 && r1 == r2 && eq.Equals(s1, s2));

        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityAddSizeComm([PexAssumeUnderTest]DataStructures.HashSet<int> s1, int x)
        {

            DataStructures.HashSet<int> s2 = new DataStructures.HashSet<int>(s1, s1.Comparer);

            HashSetEqualityComparer<int> eq = new HashSetEqualityComparer<int>();

            PexAssume.IsTrue(x > -101 && x < 101);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            AssumePrecondition.IsTrue( (( s1.Contains(x) ) && (true)) ||  ((!( s1.Contains(x) )) && (false)) );

            bool a1 = false, a2 = false;
            int c1 = -1, c2 = -1;

            // First test
            a1 = s1.Add(x);
            c1 = s1.Count;

            // Second test 
            c2 = s2.Count;
            a2 = s2.Add(x);

            //NotpAssume.IsTrue(a1 == a2 && c1 == c2 && eq.Equals(s1, s2));
            PexAssert.IsTrue(a1 == a2 && c1 == c2 && eq.Equals(s1, s2));

        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityRemoveRemoveComm([PexAssumeUnderTest]DataStructures.HashSet<int> s1, int x, int y)
        {

            DataStructures.HashSet<int> s2 = new DataStructures.HashSet<int>(s1, s1.Comparer);

            HashSetEqualityComparer<int> eq = new HashSetEqualityComparer<int>();

            PexAssume.IsTrue(x > -101 && x < 101);
            PexAssume.IsTrue(y > -101 && y < 101);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_s1.Contains(y)", s1.Contains(y));
            AssumePrecondition.IsTrue( (( s1.Contains(y) ) && ((( s1.Count <= 1 ) && ((( s1.Contains(x) ) && (false)) ||  ((!( s1.Contains(x) )) && (true)))) ||  ((!( s1.Count <= 1 )) && ((( s1.Contains(x) ) && ((( 0*s1.Count + -1*x + 1*y <= -1 ) && (true)) ||  ((!( 0*s1.Count + -1*x + 1*y <= -1 )) && ((( 0*s1.Count + -1*x + 1*y <= 0 ) && (false)) ||  ((!( 0*s1.Count + -1*x + 1*y <= 0 )) && (true)))))) ||  ((!( s1.Contains(x) )) && (true)))))) ||  ((!( s1.Contains(y) )) && (true)) );

            bool r1 = false, r2 = false;
            bool re1 = false, re2 = false;

            // First test
            r1 = s1.Remove(x);
            re1 = s1.Remove(y);

            // Second test 
            re2 = s2.Remove(y);
            r2 = s2.Remove(x);

            //NotpAssume.IsTrue(r1 == r2 && re1 == re2 && eq.Equals(s1, s2));
            PexAssert.IsTrue(r1 == r2 && re1 == re2 && eq.Equals(s1, s2));

        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityRemoveSizeComm([PexAssumeUnderTest]DataStructures.HashSet<int> s1, int x)
        {

            DataStructures.HashSet<int> s2 = new DataStructures.HashSet<int>(s1, s1.Comparer);

            HashSetEqualityComparer<int> eq = new HashSetEqualityComparer<int>();

            PexAssume.IsTrue(x > -101 && x < 101);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_s1.Contains(x)", s1.Contains(x));
            AssumePrecondition.IsTrue( (( s1.Contains(x) ) && (false)) ||  ((!( s1.Contains(x) )) && (true)) );

            bool r1 = false, r2 = false;
            int c1 = -1, c2 = -1;

            // First test
            r1 = s1.Remove(x);
            c1 = s1.Count;

            // Second test 
            c2 = s2.Count;
            r2 = s2.Remove(x);

            //NotpAssume.IsTrue(r1 == r2 && c1 == c2 && eq.Equals(s1, s2));
            PexAssert.IsTrue(r1 == r2 && c1 == c2 && eq.Equals(s1, s2));

        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativitySizeSizeComm([PexAssumeUnderTest]DataStructures.HashSet<int> s1)
        {

            DataStructures.HashSet<int> s2 = new DataStructures.HashSet<int>(s1, s1.Comparer);

            HashSetEqualityComparer<int> eq = new HashSetEqualityComparer<int>();

            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            AssumePrecondition.IsTrue(true);

            int c1 = -1, c2 = -1;
            int cc1 = -1, cc2 = -1;

            // First test
            c1 = s1.Count;
            cc1 = s1.Count;

            // Second test 
            cc2 = s2.Count;
            c2 = s2.Count;

            //NotpAssume.IsTrue(c1 == c2 && cc1 == cc2 && eq.Equals(s1, s2));
            PexAssert.IsTrue(c1 == c2 && cc1 == cc2 && eq.Equals(s1, s2));

        }

    }
}
