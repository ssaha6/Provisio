using System;
using System.Text;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures;
using DataStructures.Utility;
using PexAPIWrapper;
using Microsoft.Pex.Framework.Using;
namespace DataStructures.Comm.Test
{
    [PexClass(typeof(DataStructures.Dictionary<int, int>))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class DictionaryCommuteTest
    {
        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityRemoveRemoveComm([PexAssumeUnderTest]DataStructures.Dictionary<int, int> s1, int x, int y)
        {
            Dictionary<int, int> s2 = new Dictionary<int, int>(s1, s1.Comparer);
            PexAssume.IsTrue(-11 < x && x < 11);
            PexAssume.IsTrue(-11 < y && y < 11);

            DictionaryEqualityComparer eq = new DictionaryEqualityComparer();

            
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.ContainsKey(x)", s1.ContainsKey(x));
            PexObserve.ValueForViewing("$input_s1.ContainsKey(y)", s1.ContainsKey(y));
            PexObserve.ValueForViewing("$input_s1.ContainsValue(x)", s1.ContainsValue(x));
            PexObserve.ValueForViewing("$input_s1.ContainsValue(y)", s1.ContainsValue(y));
            
            AssumePrecondition.IsTrue(((s1.ContainsKey(x)) && ( ! (x == y))) || (( ! (s1.ContainsKey(y))) && ( ! (s1.ContainsKey(x)))) || (( ! (s1.ContainsKey(y))) && ( ! (x == y))) || ((s1.ContainsValue(y)) && ( ! (s1.ContainsKey(x)))) || ((s1.ContainsValue(y)) && ( ! (x == y))) || (( ! (s1.ContainsKey(x))) && (-1*s1.Count + x <= 0)) || (( ! (x == y)) && (-1*s1.Count + x <= 0)));
            

            bool r1 = false, r2 = false;
            bool re1 = false, re2 = false;

            // First test
            r1 = s1.Remove(x);
            re1 = s1.Remove(y);

            // Second test 
            re2 = s2.Remove(y);
            r2 = s2.Remove(x);

            NotpAssume.IsTrue(r1 == r2 && re1 == re2 && eq.Equals(s1,s2));
            PexAssert.IsTrue(r1 == r2 && re1 == re2 && eq.Equals(s1, s2));
        }


        //[PexMethod]
        [PexMethod(TestEmissionFilter = PexTestEmissionFilter.FailuresAndUniquePaths, MaxRuns = 100)] // 000, MaxConditions = 2000)] //0000, MaxConditions = 1000000000, MaxBranches = 1000000000, MaxConstraintSolverTime = 10, MaxConstraintSolverMemory = 1000000000)]
        public void PUT_ExceptionAdd([PexAssumeUnderTest]DataStructures.Dictionary<int, int> s, int x, int y)
        {

            //Dictionary<int, int> s0 = new Dictionary<int, int>(s, s.Comparer);

            //DictionaryEqualityComparer eq = new DictionaryEqualityComparer();
            PexAssume.IsTrue(-11 < x && x < 11);
            PexAssume.IsTrue(-11 < y && y < 11);
            //PexAssume.IsTrue(-11 < y1 && y1 < 11);

            //PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            //PexObserve.ValueForViewing("$input_x", x);
            //PexObserve.ValueForViewing("$input_y", y);
            //PexObserve.ValueForViewing("$input_s1.ContainsKey(x)", s1.ContainsKey(x));
            //PexObserve.ValueForViewing("$input_s1.ContainsKey(y)", s1.ContainsKey(y));
            //PexObserve.ValueForViewing("$input_s1.ContainsValue(x)", s1.ContainsValue(x));
            //PexObserve.ValueForViewing("$input_s1.ContainsValue(y)", s1.ContainsValue(y));


            int old_s_Count = s.Count;
            int old_x = x;
            int old_y = y;
            bool old_s_ContainsKeyx = s.ContainsKey(x);
            bool old_s_ContainsKeyy = s.ContainsKey(y);
            bool old_s_ContainsValue_x = s.ContainsValue(x);
            bool old_s_ContainsValue_y = s.ContainsValue(y);


            //PexAssume.IsTrue(Old_x != Old_Top); 

            PexAssume.IsTrue(!((((s.ContainsKey(x))))));
            PexAssume.IsTrue(s.ContainsValue(x));
            PexAssume.IsTrue(!(s.Count == x));


            s.Add(x, y);


            int new_s_Count = s.Count;
            int new_x = x;
            int new_y = y;

            bool new_s_ContainsKeyx = s.ContainsKey(x);
            bool new_s_ContainsKeyy = s.ContainsKey(y);
            bool new_s_ContainsValue_x = s.ContainsValue(x);
            bool new_s_ContainsValue_y = s.ContainsValue(y);



            PexObserve.ValueForViewing("$old_s_Count", old_s_Count);
            PexObserve.ValueForViewing("$new_s_Count", new_s_Count);
            PexObserve.ValueForViewing("$old_x", old_x);
            PexObserve.ValueForViewing("$new_x", new_x);
            PexObserve.ValueForViewing("$old_y", old_y);
            PexObserve.ValueForViewing("$new_y", new_y);

            PexObserve.ValueForViewing("$old_s_ContainsKeyx", old_s_ContainsKeyx);
            PexObserve.ValueForViewing("$new_s_ContainsKeyx", new_s_ContainsKeyx);
            PexObserve.ValueForViewing("$old_s_ContainsKeyy", old_s_ContainsKeyy);
            PexObserve.ValueForViewing("$new_s_ContainsKeyy", new_s_ContainsKeyy);

            PexObserve.ValueForViewing("$old_s_ContainsValue_x", old_s_ContainsValue_x);
            PexObserve.ValueForViewing("$new_s_ContainsValue_x", new_s_ContainsValue_x);
            PexObserve.ValueForViewing("$old_s_ContainsValue_y", old_s_ContainsValue_y);
            PexObserve.ValueForViewing("$new_s_ContainsValue_y", new_s_ContainsValue_y);


            PexAssert.IsTrue(((new_s_ContainsKeyx) && (new_s_ContainsValue_y) && (!(old_s_Count == new_s_Count)) && (old_s_ContainsValue_y) && (new_s_ContainsKeyy) && (new_x == old_x) && (new_y == old_x) && (old_x == old_y) && (!(old_s_Count == old_x)) && (old_s_ContainsValue_x) && (!(new_s_Count == old_x)) && (new_s_ContainsValue_x)) || ((new_s_ContainsKeyx) && (new_s_ContainsValue_y) && (!(old_s_Count == new_s_Count)) && (old_x == new_x) && (old_y == new_y)));

        }   



        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityRemoveAddComm([PexAssumeUnderTest]DataStructures.Dictionary<int, int> s1, int x, int y, int y1)
        {

            Dictionary<int, int> s2 = new Dictionary<int, int>(s1, s1.Comparer);

            DictionaryEqualityComparer eq = new DictionaryEqualityComparer();
            PexAssume.IsTrue(-11 < x && x < 11);
            PexAssume.IsTrue(-11 < y && y < 11);
            PexAssume.IsTrue(-11 < y1 && y1 < 11);


            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_y1", y1);
            PexObserve.ValueForViewing("$input_s1.ContainsKey(x)", s1.ContainsKey(x));
            PexObserve.ValueForViewing("$input_s1.ContainsKey(y)", s1.ContainsKey(y));
            PexObserve.ValueForViewing("$input_s1.ContainsKey(y1)", s1.ContainsKey(y1));
            PexObserve.ValueForViewing("$input_s1.ContainsValue(x)", s1.ContainsValue(x));
            PexObserve.ValueForViewing("$input_s1.ContainsValue(y)", s1.ContainsValue(y));
            PexObserve.ValueForViewing("$input_s1.ContainsValue(y1)", s1.ContainsValue(y1));

            AssumePrecondition.IsTrue((( ! (x == y)) && ( ! (s1.ContainsKey(y)))));

            bool r1 = false, r2 = false;

            // First test
            r1 = s1.Remove(x);
            s1.Add(y, y1);

            // Second test 
            s2.Add(y, y1);
            r2 = s2.Remove(x);

            NotpAssume.IsTrue(r1 == r2 && eq.Equals(s1, s2));
            PexAssert.IsTrue(r1 == r2 && eq.Equals(s1, s2));

        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityAddAddComm([PexAssumeUnderTest]DataStructures.Dictionary<int, int> s1, int x, int x1, int y, int y1)
        {

            Dictionary<int, int> s2 = new Dictionary<int, int>(s1,s1.Comparer);
            DictionaryEqualityComparer eq = new DictionaryEqualityComparer();
            PexAssume.IsTrue(-11 < x && x < 11);
            PexAssume.IsTrue(-11 < x1 && x1 < 11);
            PexAssume.IsTrue(-11 < y && y < 11);
            PexAssume.IsTrue(-11 < y1 && y1 < 11);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_x1", x1);
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_y1", y1);
            PexObserve.ValueForViewing("$input_s1.ContainsKey(x)", s1.ContainsKey(x));
            PexObserve.ValueForViewing("$input_s1.ContainsKey(y)",s1.ContainsKey(y));
            PexObserve.ValueForViewing("$input_s1.ContainsKey(x1)",s1.ContainsKey(x1));
            PexObserve.ValueForViewing("$input_s1.ContainsKey(y1)",s1.ContainsKey(y1));
            PexObserve.ValueForViewing("$input_s1.ContainsValue(x)",s1.ContainsValue(x));
            PexObserve.ValueForViewing("$input_s1.ContainsValue(y)",s1.ContainsValue(y));
            PexObserve.ValueForViewing("$input_s1.ContainsValue(x1)",s1.ContainsValue(x1));
            PexObserve.ValueForViewing("$input_s1.ContainsValue(y1)",s1.ContainsValue(y1));

            AssumePrecondition.IsTrue((( ! (s1.ContainsKey(y))) && ( ! (x == y))));


           // First test
            s1.Add(x, x1);
            s1.Add(y, y1);

            // Second test 
            s2.Add(y, y1);
            s2.Add(x, x1);

            NotpAssume.IsTrue(eq.Equals(s1, s2));
            PexAssert.IsTrue(eq.Equals(s1, s2));

        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityGetGetComm([PexAssumeUnderTest]DataStructures.Dictionary<int, int> s1, int x, int y)
        {

            Dictionary<int, int> s2 = new Dictionary<int, int>(s1, s1.Comparer);

            DictionaryEqualityComparer eq = new DictionaryEqualityComparer();
            PexAssume.IsTrue(-11 < x && x < 11);
            PexAssume.IsTrue(-11 < y && y < 11);


            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.ContainsKey(x)", s1.ContainsKey(x));
            PexObserve.ValueForViewing("$input_s1.ContainsKey(y)", s1.ContainsKey(y));
            PexObserve.ValueForViewing("$input_s1.ContainsValue(x)", s1.ContainsValue(x));
            PexObserve.ValueForViewing("$input_s1.ContainsValue(y)", s1.ContainsValue(y));

            AssumePrecondition.IsTrue(true);


            int g1 = -1, g2 = -3;
            int ge1 = -1, ge2 = -3;
            bool first = false, second = false;


            // First test
            g1 = s1[x];
            ge1 = s1[y];


            first = true;


            // Second test 
            ge2 = s2[y];
            g2 = s2[x];






            //NotpAssume.IsTrue(ge1 == ge2 && g1 == g2 && eq.Equals(s1, s2));
            PexAssert.IsTrue(ge1 == ge2 && g1 == g2 && eq.Equals(s1, s2));

        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityGetAddComm([PexAssumeUnderTest]DataStructures.Dictionary<int, int> s1, int x, int y, int y1)
        {

            Dictionary<int, int> s2 = new Dictionary<int, int>(s1, s1.Comparer);

            DictionaryEqualityComparer eq = new DictionaryEqualityComparer();
            PexAssume.IsTrue(-11 < x && x < 11);
            PexAssume.IsTrue(-11 < y && y < 11);
            PexAssume.IsTrue(-11 < y1 && y1 < 11);
            int val = -1;

            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_y", y1);
            PexObserve.ValueForViewing("$input_s1.ContainsKey(x)", s1.ContainsKey(x));
            PexObserve.ValueForViewing("$input_s1.ContainsKey(y)", s1.ContainsKey(y));
            PexObserve.ValueForViewing("$input_s1.ContainsKey(y1)", s1.ContainsKey(y1));
            PexObserve.ValueForViewing("$input_s1.ContainsValue(x)", s1.ContainsValue(x));
            PexObserve.ValueForViewing("$input_s1.ContainsValue(y)", s1.ContainsValue(y));
            PexObserve.ValueForViewing("$input_s1.ContainsValue(y1)", s1.ContainsValue(y1));
            
            AssumePrecondition.IsTrue((( ! (s1.ContainsKey(y))) && (s1.ContainsKey(x))));
            
            int g1 = -1, g2 = -3;
            bool first = false, second = false;
            bool firstKey = false, secondKey = false;

            // First test
            g1 = s1[x];
            s1.Add(y, y1);

            // Second test 
            s2.Add(y, y1);
            g2 = s2[x];
            
            NotpAssume.IsTrue(g1 == g2 && eq.Equals(s1, s2));
            PexAssert.IsTrue(g1 == g2 && eq.Equals(s1, s2));

        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityGetRemoveComm([PexAssumeUnderTest]DataStructures.Dictionary<int, int> s1, int x, int y)
        {

            Dictionary<int, int> s2 = new Dictionary<int, int>(s1, s1.Comparer);
            DictionaryEqualityComparer eq = new DictionaryEqualityComparer();
            
            PexAssume.IsTrue(-11 < x && x < 11);
            PexAssume.IsTrue(-11 < y && y < 11);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.ContainsKey(x)", s1.ContainsKey(x));
            PexObserve.ValueForViewing("$input_s1.ContainsKey(y)", s1.ContainsKey(y));
            PexObserve.ValueForViewing("$input_s1.ContainsValue(x)", s1.ContainsValue(x));
            PexObserve.ValueForViewing("$input_s1.ContainsValue(y)", s1.ContainsValue(y));

            AssumePrecondition.IsTrue(true);
            
            int g1 = -1, g2 = -3;
            bool r1 = false, r2 = false;
            bool first = false, second = false;

            // First test
            g1 = s1[x];
            r1 = s1.Remove(y);

            // Second test 
            r2 = s2.Remove(y);
            g2 = s2[x];

            //NotpAssume.IsTrue(r1 == r2 && g1 == g2 && eq.Equals(s1, s2));
            PexAssert.IsTrue(r1 == r2 && g1 == g2 && eq.Equals(s1, s2));

        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativitySetSetComm([PexAssumeUnderTest]DataStructures.Dictionary<int, int> s1, int x, int x1, int y, int y1)
        {

            Dictionary<int, int> s2 = new Dictionary<int, int>(s1, s1.Comparer);

            DictionaryEqualityComparer eq = new DictionaryEqualityComparer();
            PexAssume.IsTrue(-11 < x && x < 11);
            PexAssume.IsTrue(-11 < y && y < 11);
            PexAssume.IsTrue(-11 < x1 && x1 < 11);
            PexAssume.IsTrue(-11 < y1 && y1 < 11);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_x1", x1);
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_y1", y1);
            PexObserve.ValueForViewing("$input_s1.ContainsKey(x)", s1.ContainsKey(x));
            PexObserve.ValueForViewing("$input_s1.ContainsKey(y)", s1.ContainsKey(y));
            PexObserve.ValueForViewing("$input_s1.ContainsKey(x1)", s1.ContainsKey(x1));
            PexObserve.ValueForViewing("$input_s1.ContainsKey(y1)", s1.ContainsKey(y1));
            PexObserve.ValueForViewing("$input_s1.ContainsValue(x)", s1.ContainsValue(x));
            PexObserve.ValueForViewing("$input_s1.ContainsValue(y)", s1.ContainsValue(y));
            PexObserve.ValueForViewing("$input_s1.ContainsValue(x1)", s1.ContainsValue(x1));
            PexObserve.ValueForViewing("$input_s1.ContainsValue(y1)", s1.ContainsValue(y1));
            
            AssumePrecondition.IsTrue((( ! (x == y))) || ((x1 == y1)));
            //bool firstKey = false, secondKey = false;
            //bool first = false, second = false;

            // First test
            s1[x] = x1;
            s1[y] = y1;
            // Second test 
            s2[y] = y1;
            s2[x] = x1;

            NotpAssume.IsTrue(eq.Equals(s1, s2));
            PexAssert.IsTrue(eq.Equals(s1, s2));

        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativitySetAddComm([PexAssumeUnderTest]DataStructures.Dictionary<int, int> s1, int x, int x1, int y, int y1)
        {

            Dictionary<int, int> s2 = new Dictionary<int, int>(s1, s1.Comparer);
            DictionaryEqualityComparer eq = new DictionaryEqualityComparer();
            PexAssume.IsTrue(-11 < x && x < 11);
            PexAssume.IsTrue(-11 < y && y < 11);
            PexAssume.IsTrue(-11 < x1 && x1 < 11);
            PexAssume.IsTrue(-11 < y1 && y1 < 11);

            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_x1", x1);
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_y1", y1);
            
            PexObserve.ValueForViewing("$input_s1.ContainsKey(x)", s1.ContainsKey(x));
            PexObserve.ValueForViewing("$input_s1.ContainsKey(y)", s1.ContainsKey(y));
            PexObserve.ValueForViewing("$input_s1.ContainsKey(x1)", s1.ContainsKey(x1));
            PexObserve.ValueForViewing("$input_s1.ContainsKey(y1)", s1.ContainsKey(y1));
            PexObserve.ValueForViewing("$input_s1.ContainsValue(x)", s1.ContainsValue(x));
            PexObserve.ValueForViewing("$input_s1.ContainsValue(y)", s1.ContainsValue(y));
            PexObserve.ValueForViewing("$input_s1.ContainsValue(x1)", s1.ContainsValue(x1));
            PexObserve.ValueForViewing("$input_s1.ContainsValue(y1)", s1.ContainsValue(y1));
            
            AssumePrecondition.IsTrue((( ! (x == y)) && ( ! (s1.ContainsKey(y)))));

            bool firstKey = false, secondKey = false;
            bool first = false, second = false;

            // First test
            s1[x] = x1;
            s1.Add(y, y1);

            // Second test 
            s2.Add(y, y1);
            s2[x] = x1;

            NotpAssume.IsTrue(eq.Equals(s1, s2));
            PexAssert.IsTrue(eq.Equals(s1, s2));

        }


        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativitySetRemoveComm([PexAssumeUnderTest]DataStructures.Dictionary<int, int> s1, int x, int x1, int y)
        {

            Dictionary<int, int> s2 = new Dictionary<int, int>(s1, s1.Comparer);

            DictionaryEqualityComparer eq = new DictionaryEqualityComparer();
            PexAssume.IsTrue(-11 < x && x < 11);
            PexAssume.IsTrue(-11 < y && y < 11);
            PexAssume.IsTrue(-11 < x1 && x1 < 11);

            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_x1", x1);
            PexObserve.ValueForViewing("$input_y", y);

            PexObserve.ValueForViewing("$input_s1.ContainsKey(x)", s1.ContainsKey(x));
            PexObserve.ValueForViewing("$input_s1.ContainsKey(y)", s1.ContainsKey(y));
            PexObserve.ValueForViewing("$input_s1.ContainsKey(x1)", s1.ContainsKey(x1));
            
            PexObserve.ValueForViewing("$input_s1.ContainsValue(x)", s1.ContainsValue(x));
            PexObserve.ValueForViewing("$input_s1.ContainsValue(y)", s1.ContainsValue(y));
            PexObserve.ValueForViewing("$input_s1.ContainsValue(x1)", s1.ContainsValue(x1));
            

            AssumePrecondition.IsTrue(true);
                


            bool r1 = false, r2 = false;
            bool firstKey = false, secondKey = false;
            bool first = false, second = false;

            // First test
            s1[x] = x1;
            r1 = s1.Remove(y);
                
            // Second test 
            r2 = s2.Remove(y);
            s2[x] = x1;

            //NotpAssume.IsTrue(r1 == r2 && eq.Equals(s1, s2));
            PexAssert.IsTrue(r1 == r2 && eq.Equals(s1, s2));

        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativitySetGetComm([PexAssumeUnderTest]DataStructures.Dictionary<int, int> s1, int x, int x1, int y)
        {
            Dictionary<int, int> s2 = new Dictionary<int, int>(s1, s1.Comparer);
            DictionaryEqualityComparer eq = new DictionaryEqualityComparer();
            PexAssume.IsTrue(-11 < x && x < 11);
            PexAssume.IsTrue(-11 < y && y < 11);
            PexAssume.IsTrue(-11 < x1 && x1 < 11);
            int val = -2;
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_x1", x1);
            PexObserve.ValueForViewing("$input_y", y);

            PexObserve.ValueForViewing("$input_s1.ContainsKey(x)", s1.ContainsKey(x));
            PexObserve.ValueForViewing("$input_s1.ContainsKey(y)", s1.ContainsKey(y));
            PexObserve.ValueForViewing("$input_s1.ContainsKey(x1)", s1.ContainsKey(x1));

            PexObserve.ValueForViewing("$input_s1.ContainsValue(x)", s1.ContainsValue(x));
            PexObserve.ValueForViewing("$input_s1.ContainsValue(y)", s1.ContainsValue(y));
            PexObserve.ValueForViewing("$input_s1.ContainsValue(x1)", s1.ContainsValue(x1));

            AssumePrecondition.IsTrue(!((( false ))));

            int r1 = -1, r2 = -1;
            bool firstKey = false, secondKey = false;
            bool first = false, second = false;

            // First test
            s1[x] = x1;
            r1 = s1[y];

            // Second test 
            r2 = s2[y];
            s2[x] = x1;

            NotpAssume.IsTrue(r1 == r2 && eq.Equals(s1, s2));
            PexAssert.IsTrue(r1 == r2 && eq.Equals(s1, s2));
        }

    }
}
