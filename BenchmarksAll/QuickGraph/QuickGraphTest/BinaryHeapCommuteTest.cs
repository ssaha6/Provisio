using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickGraph;

using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Settings;
using Microsoft.Pex.Framework.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PexAPIWrapper;
using QuickGraph.Interfaces;
using QuickGraph.Utility;

namespace QuickGraphTest
{
    [PexClass(typeof(Tuple<BinaryHeap<int, int>, BinaryHeap<int, int>>))]
    [TestClass]
    public partial class BinaryHeapCommuteTest
    {
        int global = -12;
        /*[PexMethod]
        public void TestCloneCompare([PexAssumeUnderTest] Tuple<BinaryHeap<int, int>, BinaryHeap<int, int>> bhTuple, int priority, int value)
        {
            BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = bhTuple.Item2;
            
            BinaryHeapEqualityComparer eq = new BinaryHeapEqualityComparer();
            //PexAssume.IsTrue(eq.Equals(bh1, bh2) && !PexAssume.ReferenceEquals(bh1, bh2));

            PexObserve.ValueForViewing("bh1 Count: ", bh1.Count);
            PexObserve.ValueForViewing("bh2 Count: ", bh2.Count);
            PexObserve.ValueForViewing("bh1 Capacity", bh1.Capacity);
            PexObserve.ValueForViewing("bh2 Capacity", bh2.Capacity);

            bh1.Add(priority, value);
            bh2.Add(priority, value);

            PexAssert.IsTrue(eq.Equals(bh1, bh2));
        }*/

        [PexMethod]
        public void PUT_CommutativityCapacityCapacityComm([PexAssumeUnderTest] Tuple<BinaryHeap<int, int>, BinaryHeap<int, int>> bhTuple )
        {
            BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = bhTuple.Item2;

            BinaryHeapEqualityComparer eq = new BinaryHeapEqualityComparer();
            //PexAssume.IsTrue(eq.Equals(bh1, bh2) && !PexAssume.ReferenceEquals(bh1, bh2));

            PexObserve.ValueForViewing("$input_Count", bh1.Count);
            PexObserve.ValueForViewing("$input_Capacity", bh1.Capacity);
            PexObserve.ValueForViewing("$input_MinimumPriority", bh1.Count > 0 ? bh1.Minimum().Key : global--);

            AssumePrecondition.IsTrue(  true);

            int c11 = 0, c12 = 0;
            int c21 = 0, c22 = 0;

            c11 = bh1.Capacity;
            c12 = bh1.Capacity;

            c22 = bh2.Capacity;
            c21 = bh2.Capacity;

            //NotpAssume.IsTrue(c11 == c21 && c12 == c22 && eq.Equals(bh1, bh2));
            PexAssert.IsTrue(c11 == c21 && c12 == c22 && eq.Equals(bh1, bh2));
        }

        [PexMethod]
        public void PUT_CommutativityCapacityCountComm([PexAssumeUnderTest] Tuple<BinaryHeap<int, int>, BinaryHeap<int, int>> bhTuple )
        {
            BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = bhTuple.Item2;

            BinaryHeapEqualityComparer eq = new BinaryHeapEqualityComparer();
            //PexAssume.IsTrue(eq.Equals(bh1, bh2) && !PexAssume.ReferenceEquals(bh1, bh2));

            PexObserve.ValueForViewing("$input_Count", bh1.Count);
            PexObserve.ValueForViewing("$input_Capacity", bh1.Capacity);
            PexObserve.ValueForViewing("$input_MinimumPriority", bh1.Count > 0 ? bh1.Minimum().Key : global--);

            AssumePrecondition.IsTrue(  true);

            int c11 = 0, c12 = 0;
            int c21 = 0, c22 = 0;

            c11 = bh1.Capacity;
            c12 = bh1.Count;

            c22 = bh2.Count;
            c21 = bh2.Capacity;

            NotpAssume.IsTrue(c11 == c21 && c12 == c22 && eq.Equals(bh1, bh2));
            PexAssert.IsTrue(c11 == c21 && c12 == c22 && eq.Equals(bh1, bh2));
        }

        [PexMethod]
        public void PUT_CommutativityCapacityAddComm([PexAssumeUnderTest] Tuple<BinaryHeap<int, int>, BinaryHeap<int, int>> bhTuple, int priority, int value)
        {
            BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = bhTuple.Item2;

            PexAssume.IsTrue(priority > -11 && priority < 11);
            PexAssume.IsTrue(value > -11 && value < 11);
            
            //BinaryHeap<int, int> bh2 = (BinaryHeap<int, int>)bh1.Clone();
            BinaryHeapEqualityComparer eq = new BinaryHeapEqualityComparer();
            //PexAssume.IsTrue(eq.Equals(bh1, bh2) && !PexAssume.ReferenceEquals(bh1, bh2));

            PexObserve.ValueForViewing("$input_Priority", priority);
            PexObserve.ValueForViewing("$input_Value", value);
            PexObserve.ValueForViewing("$input_Count", bh1.Count);
            PexObserve.ValueForViewing("$input_Capacity", bh1.Capacity);
            PexObserve.ValueForViewing("$input_IndexOf", bh1.IndexOf(value));
            PexObserve.ValueForViewing("$input_MinimumPriority", bh1.Count > 0 ? bh1.Minimum().Key : global--);

            AssumePrecondition.IsTrue(  ((!(bh1.Count == bh1.Capacity))) );

            int c1 = 0, c2 = 0;

            c1 = bh1.Capacity; // == count  --> bh1, bh2
            bh1.Add(priority, value);// count + n --> bh1 , bh2
            bh2.Add(priority, value);  //  adds to bh1 and bh2 --> capacity remains unchanged
            c2 = bh2.Capacity;

            NotpAssume.IsTrue(c1 == c2 && eq.Equals(bh1, bh2));
            //try { PexAssert.IsTrue(false); }catch { return; }
            PexAssert.IsTrue(c1 == c2 && eq.Equals(bh1, bh2));
        }

        [PexMethod]
        public void PUT_CommutativityCapacityMinimumComm([PexAssumeUnderTest] Tuple<BinaryHeap<int, int>, BinaryHeap<int, int>> bhTuple )
        {
            BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = bhTuple.Item2;

            BinaryHeapEqualityComparer eq = new BinaryHeapEqualityComparer();
            //PexAssume.IsTrue(eq.Equals(bh1, bh2) && !PexAssume.ReferenceEquals(bh1, bh2));

            PexObserve.ValueForViewing("$input_Count", bh1.Count);
            PexObserve.ValueForViewing("$input_Capacity", bh1.Capacity);
            PexObserve.ValueForViewing("$input_MinimumPriority", bh1.Count > 0 ? bh1.Minimum().Key : global--);

            AssumePrecondition.IsTrue(  ((!(bh1.Count <= 0))) );

            int c1 = 0, c2 = 0;

            c1 = bh1.Capacity;
            var m1 = bh1.Minimum();

            var m2 = bh2.Minimum();
            c2 = bh2.Capacity;

            NotpAssume.IsTrue(c1 == c2 && m1.Key == m2.Key && m1.Value == m2.Value && eq.Equals(bh1, bh2));
            //try { PexAssert.IsTrue(false); }catch { return; }
            PexAssert.IsTrue(c1 == c2 && m1.Key == m2.Key && m1.Value == m2.Value && eq.Equals(bh1, bh2));
        }

        [PexMethod]
        public void PUT_CommutativityCapacityRemoveMinimumComm([PexAssumeUnderTest] Tuple<BinaryHeap<int, int>, BinaryHeap<int, int>> bhTuple )
        {
            BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = bhTuple.Item2;

            BinaryHeapEqualityComparer eq = new BinaryHeapEqualityComparer();
            //PexAssume.IsTrue(eq.Equals(bh1, bh2) && !PexAssume.ReferenceEquals(bh1, bh2));

            PexObserve.ValueForViewing("$input_Count", bh1.Count);
            PexObserve.ValueForViewing("$input_Capacity", bh1.Capacity);
            PexObserve.ValueForViewing("$input_MinimumPriority", bh1.Count > 0 ? bh1.Minimum().Key : global--);

            AssumePrecondition.IsTrue(  ((!(bh1.Count <= 0))) );

            int c1 = 0, c2 = 0;

            c1 = bh1.Capacity;
            var rm1 = bh1.RemoveMinimum();

            var rm2 = bh2.RemoveMinimum();
            c2 = bh2.Capacity;

            NotpAssume.IsTrue(c1 == c2 && rm1.Key == rm2.Key && rm1.Value == rm2.Value && eq.Equals(bh1, bh2));
            //try { PexAssert.IsTrue(false); }catch { return; }
            PexAssert.IsTrue(c1 == c2 && rm1.Key == rm2.Key && rm1.Value == rm2.Value && eq.Equals(bh1, bh2));
        }

        [PexMethod]
        public void PUT_CommutativityCapacityRemoveAtComm([PexAssumeUnderTest] Tuple<BinaryHeap<int, int>, BinaryHeap<int, int>> bhTuple, int index)
        {
            BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = bhTuple.Item2;

            PexAssume.IsTrue(index > -11 && index < 11);
            
            //BinaryHeap<int, int> bh2 = (QuickGraph.BinaryHeap<int, int>)bh1.Clone();
            BinaryHeapEqualityComparer eq = new BinaryHeapEqualityComparer();
            //PexAssume.IsTrue(eq.Equals(bh1, bh2) && !PexAssume.ReferenceEquals(bh1, bh2));

            PexObserve.ValueForViewing("$input_Index", index);
            PexObserve.ValueForViewing("$input_Count", bh1.Count);
            PexObserve.ValueForViewing("$input_Capacity", bh1.Capacity);
            PexObserve.ValueForViewing("$input_MinimumPriority", bh1.Count > 0 ? bh1.Minimum().Key : global--);

            AssumePrecondition.IsTrue(((index >= 0) && (-1*index + bh1.Count >= 1) && (bh1.Count >= 1)));

            int c1 = 0, c2 = 0;

            c1 = bh1.Capacity;
            var ra1 = bh1.RemoveAt(index);

            var ra2 = bh2.RemoveAt(index);
            c2 = bh2.Capacity;


            NotpAssume.IsTrue(c1 == c2 && ra1.Key == ra2.Key && ra1.Value == ra2.Value && eq.Equals(bh1, bh2));
            try{PexAssert.IsTrue(false);}catch{return;}
            PexAssert.IsTrue(c1 == c2 && ra1.Key == ra2.Key && ra1.Value == ra2.Value && eq.Equals(bh1, bh2));
        }

        [PexMethod]
        public void PUT_CommutativityCapacityIndexOfComm([PexAssumeUnderTest] Tuple<BinaryHeap<int, int>, BinaryHeap<int, int>> bhTuple, int value )
        {
            BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = bhTuple.Item2;

            PexAssume.IsTrue(value > -11 && value < 11);

            BinaryHeapEqualityComparer eq = new BinaryHeapEqualityComparer();
            //PexAssume.IsTrue(eq.Equals(bh1, bh2) && !PexAssume.ReferenceEquals(bh1, bh2));

            PexObserve.ValueForViewing("$input_Count", bh1.Count);
            PexObserve.ValueForViewing("$input_Capacity", bh1.Capacity);
            PexObserve.ValueForViewing("$input_MinimumPriority", bh1.Count > 0 ? bh1.Minimum().Key : global--);

            AssumePrecondition.IsTrue(  true);

            int c1 = 0, c2 = 0;
            int io1 = 0, io2 = 0;

            c1 = bh1.Capacity;
            io1 = bh1.IndexOf(value);

            io2 = bh2.IndexOf(value);
            c2 = bh2.Capacity;

            NotpAssume.IsTrue(c1 == c2 && io1 == io2 && eq.Equals(bh1, bh2));
            //try { PexAssert.IsTrue(false); }catch { return; }
            PexAssert.IsTrue(c1 == c2 && io1 == io2 && eq.Equals(bh1, bh2));
        }

        [PexMethod]
        public void PUT_CommutativityCapacityUpdateComm([PexAssumeUnderTest] Tuple<BinaryHeap<int, int>, BinaryHeap<int, int>> bhTuple, int priority, int value )
        {
            BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = bhTuple.Item2;

            //BinaryHeap<int, int> bh2 = (BinaryHeap<int, int>)bh1.Clone();
            PexAssume.IsTrue(priority > -11 && priority < 11);
            PexAssume.IsTrue(value > -11 && value < 11);

            BinaryHeapEqualityComparer eq = new BinaryHeapEqualityComparer();
            //PexAssume.IsTrue(eq.Equals(bh1, bh2) && !PexAssume.ReferenceEquals(bh1, bh2));

            PexObserve.ValueForViewing("$input_Priority", priority);
            PexObserve.ValueForViewing("$input_Value", value);
            PexObserve.ValueForViewing("$input_Count", bh1.Count);
            PexObserve.ValueForViewing("$input_Capacity", bh1.Capacity);
            PexObserve.ValueForViewing("$input_IndexOf", bh1.IndexOf(value));
            PexObserve.ValueForViewing("$input_MinimumPriority", bh1.Count > 0 ? bh1.Minimum().Key : global--);

            AssumePrecondition.IsTrue(  ((!(bh1.IndexOf(value) <= -1))) );

            int c1 = 0, c2 = 0;

            c1 = bh1.Capacity;
            bh1.Update(priority, value);

            bh2.Update(priority, value);
            c2 = bh2.Capacity;

            NotpAssume.IsTrue(c1 == c2 && eq.Equals(bh1, bh2));
            //try { PexAssert.IsTrue(false); }catch { return; }
            PexAssert.IsTrue(c1 == c2 && eq.Equals(bh1, bh2));
        }

        [PexMethod]
        public void PUT_CommutativityCountCountComm([PexAssumeUnderTest] Tuple<BinaryHeap<int, int>, BinaryHeap<int, int>> bhTuple )
        {
            BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = bhTuple.Item2;

            BinaryHeapEqualityComparer eq = new BinaryHeapEqualityComparer();
            //PexAssume.IsTrue(eq.Equals(bh1, bh2) && !PexAssume.ReferenceEquals(bh1, bh2));

            PexObserve.ValueForViewing("$input_Count", bh1.Count);
            PexObserve.ValueForViewing("$input_Capacity", bh1.Capacity);
            PexObserve.ValueForViewing("$input_MinimumPriority", bh1.Count > 0 ? bh1.Minimum().Key : global--);

            AssumePrecondition.IsTrue(  true);

            int c11 = 0, c12 = 0;
            int c21 = 0, c22 = 0;

            c11 = bh1.Count;
            c12 = bh1.Count;

            c22 = bh2.Count;
            c21 = bh2.Count;

            NotpAssume.IsTrue(c11 == c21 && c12 == c22 && eq.Equals(bh1, bh2));
            PexAssert.IsTrue(c11 == c21 && c12 == c22 && eq.Equals(bh1, bh2));
        }

        [PexMethod]
        public void PUT_CommutativityCountAddComm([PexAssumeUnderTest] Tuple<BinaryHeap<int, int>, BinaryHeap<int, int>> bhTuple, int priority, int value )
        {
            BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = bhTuple.Item2;

            PexAssume.IsTrue(priority > -11 && priority < 11);
            PexAssume.IsTrue(value > -11 && value < 11);

            BinaryHeapEqualityComparer eq = new BinaryHeapEqualityComparer();
            //PexAssume.IsTrue(eq.Equals(bh1, bh2) && !PexAssume.ReferenceEquals(bh1, bh2));

            PexObserve.ValueForViewing("$input_Priority", priority);
            PexObserve.ValueForViewing("$input_Value", value);
            PexObserve.ValueForViewing("$input_Count", bh1.Count);
            PexObserve.ValueForViewing("$input_Capacity", bh1.Capacity);
            PexObserve.ValueForViewing("$input_IndexOf", bh1.IndexOf(value));
            PexObserve.ValueForViewing("$input_MinimumPriority", bh1.Count > 0 ? bh1.Minimum().Key : global--);

            AssumePrecondition.IsTrue(  false);

            int c1 = 0, c2 = 0;

            c1 = bh1.Count;
            bh1.Add(priority, value);

            bh2.Add(priority, value);
            c2 = bh2.Count;

            NotpAssume.IsTrue(c1 == c2 && eq.Equals(bh1, bh2));
            PexAssert.IsTrue(c1 == c2 && eq.Equals(bh1, bh2));
        }

        [PexMethod]
        public void PUT_CommutativityCountMinimumComm([PexAssumeUnderTest] Tuple<BinaryHeap<int, int>, BinaryHeap<int, int>> bhTuple/* */)
        {
            BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = bhTuple.Item2;

            //BinaryHeap<int, int> bh2 = (QuickGraph.BinaryHeap<int, int>)bh1.Clone();
            BinaryHeapEqualityComparer eq = new BinaryHeapEqualityComparer();
            ////PexAssume.IsTrue(eq.Equals(bh1, bh2) && !PexAssume.ReferenceEquals(bh1, bh2));

            PexObserve.ValueForViewing("$input_Count", bh1.Count);
            PexObserve.ValueForViewing("$input_Capacity", bh1.Capacity);
            PexObserve.ValueForViewing("$input_MinimumPriority", bh1.Count > 0 ? bh1.Minimum().Key : global--);

            AssumePrecondition.IsTrue(  ((!(bh1.Count <= 0))) );

            int c1 = 0, c2 = 0;

            c1 = bh1.Count;
            var m1 = bh1.Minimum();

            var m2 = bh2.Minimum();
            c2 = bh2.Count;

            NotpAssume.IsTrue(c1 == c2 && m1.Key == m2.Key && m1.Value == m2.Value && eq.Equals(bh1, bh2));
            PexAssert.IsTrue(c1 == c2 && m1.Key == m2.Key && m1.Value == m2.Value && eq.Equals(bh1, bh2));
        }

        [PexMethod]
        public void PUT_CommutativityCountRemoveMinimumComm([PexAssumeUnderTest] Tuple<BinaryHeap<int, int>, BinaryHeap<int, int>> bhTuple )
        {
            BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = bhTuple.Item2;

            BinaryHeapEqualityComparer eq = new BinaryHeapEqualityComparer();
            //PexAssume.IsTrue(eq.Equals(bh1, bh2) && !PexAssume.ReferenceEquals(bh1, bh2));

            PexObserve.ValueForViewing("$input_Count", bh1.Count);
            PexObserve.ValueForViewing("$input_Capacity", bh1.Capacity);
            PexObserve.ValueForViewing("$input_MinimumPriority", bh1.Count > 0 ? bh1.Minimum().Key : global--);

            AssumePrecondition.IsTrue(  false);

            int c1 = 0, c2 = 0;

            c1 = bh1.Count;
            var rm1 = bh1.RemoveMinimum();

            var rm2 = bh2.RemoveMinimum();
            c2 = bh2.Count;

            NotpAssume.IsTrue(c1 == c2 && rm1.Key == rm2.Key && rm1.Value == rm2.Value && eq.Equals(bh1, bh2));
            PexAssert.IsTrue(c1 == c2 && rm1.Key == rm2.Key && rm1.Value == rm2.Value && eq.Equals(bh1, bh2));
        }

        [PexMethod]
        public void PUT_CommutativityCountRemoveAtComm([PexAssumeUnderTest] Tuple<BinaryHeap<int, int>, BinaryHeap<int, int>> bhTuple, int index )
        {
            BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = bhTuple.Item2;

            PexAssume.IsTrue(index > -11 && index < 11);

            BinaryHeapEqualityComparer eq = new BinaryHeapEqualityComparer();
            //PexAssume.IsTrue(eq.Equals(bh1, bh2) && !PexAssume.ReferenceEquals(bh1, bh2));

            PexObserve.ValueForViewing("$input_Index", index);
            PexObserve.ValueForViewing("$input_Count", bh1.Count);
            PexObserve.ValueForViewing("$input_Capacity", bh1.Capacity);
            PexObserve.ValueForViewing("$input_MinimumPriority", bh1.Count > 0 ? bh1.Minimum().Key : global--);

            AssumePrecondition.IsTrue(  false);

            int c1 = 0, c2 = 0;

            c1 = bh1.Count;
            var ra1 = bh1.RemoveAt(index);

            var ra2 = bh2.RemoveAt(index);
            c2 = bh2.Count;

            NotpAssume.IsTrue(c1 == c2 && ra1.Key == ra2.Key && ra1.Value == ra2.Value && eq.Equals(bh1, bh2));
            PexAssert.IsTrue(c1 == c2 && ra1.Key == ra2.Key && ra1.Value == ra2.Value && eq.Equals(bh1, bh2));
        }

        [PexMethod]
        public void PUT_CommutativityCountIndexOfComm([PexAssumeUnderTest] Tuple<BinaryHeap<int, int>, BinaryHeap<int, int>> bhTuple, int value )
        {
            BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = bhTuple.Item2;

            PexAssume.IsTrue(value > -11 && value < 11);

            BinaryHeapEqualityComparer eq = new BinaryHeapEqualityComparer();
            //PexAssume.IsTrue(eq.Equals(bh1, bh2) && !PexAssume.ReferenceEquals(bh1, bh2));

            PexObserve.ValueForViewing("$input_Value", value);
            PexObserve.ValueForViewing("$input_Count", bh1.Count);
            PexObserve.ValueForViewing("$input_Capacity", bh1.Capacity);
            PexObserve.ValueForViewing("$input_IndexOf", bh1.IndexOf(value));
            PexObserve.ValueForViewing("$input_MinimumPriority", bh1.Count > 0 ? bh1.Minimum().Key : global--);

            AssumePrecondition.IsTrue(  true);

            int c1 = 0, c2 = 0;
            int io1 = 0, io2 = 0;

            c1 = bh1.Count;
            io1 = bh1.IndexOf(value);

            io2 = bh2.IndexOf(value);
            c2 = bh2.Count;

            NotpAssume.IsTrue(c1 == c2 && io1 == io2 && eq.Equals(bh1, bh2));
            PexAssert.IsTrue(c1 == c2 && io1 == io2 && eq.Equals(bh1, bh2));
        }

        [PexMethod]
        public void PUT_CommutativityCountUpdateComm([PexAssumeUnderTest] Tuple<BinaryHeap<int, int>, BinaryHeap<int, int>> bhTuple, int priority, int value )
        {
            BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = bhTuple.Item2;

            PexAssume.IsTrue(priority > -11 && priority < 11);
            PexAssume.IsTrue(value > -11 && value < 11);

            BinaryHeapEqualityComparer eq = new BinaryHeapEqualityComparer();
            //PexAssume.IsTrue(eq.Equals(bh1, bh2) && !PexAssume.ReferenceEquals(bh1, bh2));

            PexObserve.ValueForViewing("$input_Priority", priority);
            PexObserve.ValueForViewing("$input_Value", value);
            PexObserve.ValueForViewing("$input_Count", bh1.Count);
            PexObserve.ValueForViewing("$input_Capacity", bh1.Capacity);
            PexObserve.ValueForViewing("$input_IndexOf", bh1.IndexOf(value));
            PexObserve.ValueForViewing("$input_MinimumPriority", bh1.Count > 0 ? bh1.Minimum().Key : global--);

            AssumePrecondition.IsTrue(  ((!(bh1.IndexOf(value) <= -1))) );

            int c1 = 0, c2 = 0;

            c1 = bh1.Count;
            bh1.Update(priority, value);

            bh2.Update(priority, value);
            c2 = bh2.Count;

            NotpAssume.IsTrue(c1 == c2 && eq.Equals(bh1, bh2));
            PexAssert.IsTrue(c1 == c2 && eq.Equals(bh1, bh2));
        }

        [PexMethod]
        public void PUT_CommutativityAddAddComm([PexAssumeUnderTest] Tuple<BinaryHeap<int, int>, BinaryHeap<int, int>> bhTuple, int priority1, int value1, int priority2, int value2 )
        {
            BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = bhTuple.Item2;

            PexAssume.IsTrue(priority1 > -11 && priority1 < 11);
            PexAssume.IsTrue(value1 > -11 && value1 < 11);
            PexAssume.IsTrue(priority2 > -11 && priority2 < 11);
            PexAssume.IsTrue(value2 > -11 && value2 < 11);

            BinaryHeapEqualityComparer eq = new BinaryHeapEqualityComparer();
            //PexAssume.IsTrue(eq.Equals(bh1, bh2) && !PexAssume.ReferenceEquals(bh1, bh2));

            PexObserve.ValueForViewing("$input_Priority1", priority1);
            PexObserve.ValueForViewing("$input_Value1", value1);
            PexObserve.ValueForViewing("$input_Priority2", priority2);
            PexObserve.ValueForViewing("$input_Value2", value2);
            PexObserve.ValueForViewing("$input_Count", bh1.Count);
            PexObserve.ValueForViewing("$input_Capacity", bh1.Capacity);
            PexObserve.ValueForViewing("$input_IndexOf1", bh1.IndexOf(value1));
            PexObserve.ValueForViewing("$input_IndexOf2", bh1.IndexOf(value2));
            PexObserve.ValueForViewing("$input_MinimumPriority", bh1.Count > 0 ? bh1.Minimum().Key : global--);

            AssumePrecondition.IsTrue(!(true));

            bh1.Add(priority1, value1);
            bh1.Add(priority2, value2);

            bh2.Add(priority2, value2);
            bh2.Add(priority1, value1);

            NotpAssume.IsTrue(eq.Equals(bh1, bh2));
            PexAssert.IsTrue(eq.Equals(bh1, bh2));
        }

        [PexMethod]
        public void PUT_CommutativityAddMinimumComm([PexAssumeUnderTest] Tuple<BinaryHeap<int, int>, BinaryHeap<int, int>> bhTuple, int priority, int value/* */)
        {
            BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = bhTuple.Item2;

            PexAssume.IsTrue(priority > -11 && priority < 11);
            PexAssume.IsTrue(value > -11 && value < 11);
            
            //BinaryHeap<int, int> bh2 = (QuickGraph.BinaryHeap<int, int>) bh1.Clone();
            BinaryHeapEqualityComparer eq = new BinaryHeapEqualityComparer();
            //PexAssume.IsTrue(eq.Equals(bh1, bh2) && !PexAssume.ReferenceEquals(bh1, bh2));

            PexObserve.ValueForViewing("$input_Priority", priority);
            PexObserve.ValueForViewing("$input_Value", value);
            PexObserve.ValueForViewing("$input_Count", bh1.Count);
            PexObserve.ValueForViewing("$input_Capacity", bh1.Capacity);
            PexObserve.ValueForViewing("$input_IndexOf", bh1.IndexOf(value));
            PexObserve.ValueForViewing("$input_MinimumPriority", bh1.Count > 0 ? bh1.Minimum().Key : global--);

            AssumePrecondition.IsTrue((( false )));
            bh1.Add(priority, value);
            var m1 = bh1.Minimum();

            var m2 = bh2.Minimum();
            bh2.Add(priority, value);

            NotpAssume.IsTrue(m1.Key == m2.Key && m1.Value == m2.Value && eq.Equals(bh1, bh2));
            PexAssert.IsTrue(m1.Key == m2.Key && m1.Value == m2.Value && eq.Equals(bh1, bh2));
        }

        [PexMethod]
        public void PUT_CommutativityMinimumMinimumComm([PexAssumeUnderTest] Tuple<BinaryHeap<int, int>, BinaryHeap<int, int>> bhTuple )
        {
            BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = bhTuple.Item2;

            BinaryHeapEqualityComparer eq = new BinaryHeapEqualityComparer();
            //PexAssume.IsTrue(eq.Equals(bh1, bh2) && !PexAssume.ReferenceEquals(bh1, bh2));

            PexObserve.ValueForViewing("$input_Count", bh1.Count);
            PexObserve.ValueForViewing("$input_Capacity", bh1.Capacity);
            PexObserve.ValueForViewing("$input_MinimumPriority", bh1.Count > 0 ? bh1.Minimum().Key : global--);

            AssumePrecondition.IsTrue(((bh1.Count >= 1)));

            var m11 = bh1.Minimum();
            var m12 = bh1.Minimum();

            var m22 = bh2.Minimum();
            var m21 = bh2.Minimum();

            NotpAssume.IsTrue(m11.Key == m21.Key && m11.Value == m21.Value && m12.Key == m22.Key && m12.Value == m22.Value && eq.Equals(bh1, bh2));
            PexAssert.IsTrue(m11.Key == m21.Key && m11.Value == m21.Value && m12.Key == m22.Key && m12.Value == m22.Value && eq.Equals(bh1, bh2));
        }

        [PexMethod]
        public void PUT_CommutativityMinimumRemoveMinimumComm([PexAssumeUnderTest] Tuple<BinaryHeap<int, int>, BinaryHeap<int, int>> bhTuple )
        {
            BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = bhTuple.Item2;

            BinaryHeapEqualityComparer eq = new BinaryHeapEqualityComparer();
            //PexAssume.IsTrue(eq.Equals(bh1, bh2) && !PexAssume.ReferenceEquals(bh1, bh2));

            PexObserve.ValueForViewing("$input_Count", bh1.Count);
            PexObserve.ValueForViewing("$input_Capacity", bh1.Capacity);
            PexObserve.ValueForViewing("$input_MinimumPriority", bh1.Count > 0 ? bh1.Minimum().Key : global--);

            AssumePrecondition.IsTrue(!((( false ))));

            var m1 = bh1.Minimum();
            var rm1 = bh1.RemoveMinimum();

            var rm2 = bh2.RemoveMinimum();
            var m2 = bh2.Minimum();

            NotpAssume.IsTrue(m1.Key == m2.Key && m1.Value == m2.Value && rm1.Key == rm2.Key && rm1.Value == rm2.Value && eq.Equals(bh1, bh2));
            PexAssert.IsTrue(m1.Key == m2.Key && m1.Value == m2.Value && rm1.Key == rm2.Key && rm1.Value == rm2.Value && eq.Equals(bh1, bh2));
        }
    }
}
