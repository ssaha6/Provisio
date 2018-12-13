using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Using;
using System;
using System.Collections.Generic;
using Microsoft.Pex.Framework.Validation;
using Microsoft.Pex.Framework.Wizard;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PexAPIWrapper;

namespace QuickGraph.Collections
{
    public static class BinaryHeapFactory
    {
        [PexFactoryMethod(typeof(BinaryHeap<int, int>))]
        public static BinaryHeap<int, int> Create(int capacity)
        {
            var heap = new BinaryHeap<int, int>(capacity, (i, j) => i.CompareTo(j));
            return heap;
        }
    }

    /// <summary>
    /// This class contains parameterized unit tests for BinaryHeap`2
    /// </summary>
    /*[TestClass]
    [PexClass(typeof(BinaryHeap<,>))]
    [PexGenericArguments(typeof(int), typeof(int))]
    [PexAllowedContractRequiresFailureAtTypeUnderTestSurface]
    public partial class BinaryHeapTPriorityTValueTest
    {
        /// <summary>
        /// Checks heap invariant
        /// </summary>
        private static void AssertInvariant<TPriority, TValue>(
            BinaryHeap<TPriority, TValue> target
            )
        {
            Assert.IsTrue(target.Capacity >= 0);
            Assert.IsTrue(target.Count >= 0);
            Assert.IsTrue(target.Count <= target.Capacity);
        }

        [TestMethod]
        public void Constructor()
        {
            var target = new BinaryHeap<int, int>();
            AssertInvariant<int, int>(target);
        }

        [PexMethod]
        //[PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentNullException))]
        //[PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentOutOfRangeException))]
        public void Constructor<TPriority, TValue>(int capacity)
        {
            var target = new BinaryHeap<TPriority, TValue>(capacity, Comparer<TPriority>.Default.Compare);
            Assert.AreEqual(target.Capacity, capacity);
            AssertInvariant<TPriority, TValue>(target);
        }

        [PexMethod]
        //[PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
        public void Operations<TPriority, TValue>(
            [PexAssumeUnderTest]BinaryHeap<TPriority, TValue> target,
            [PexAssumeNotNull]KeyValuePair<bool, TPriority>[] values)
        {
            foreach (var value in values)
            {
                if (value.Key)
                    target.Add(value.Value, default(TValue));
                else
                {
                    var min = target.RemoveMinimum();
                }
                AssertInvariant<TPriority, TValue>(target);
            }
        }

        [PexMethod(MaxRuns = 20)]
        public void Insert<TPriority, TValue>(
            [PexAssumeUnderTest]BinaryHeap<TPriority, TValue> target,
            [PexAssumeNotNull] KeyValuePair<TPriority, TValue>[] kvs)
        {
            var count = target.Count;
            foreach (var kv in kvs)
            {
                target.Add(kv.Key, kv.Value);
                AssertInvariant<TPriority, TValue>(target);
            }
            Assert.IsTrue(count + kvs.Length == target.Count);
        }

        [PexMethod(MaxRuns = 20)]
        public void InsertAndIndexOf<TPriority, TValue>(
            [PexAssumeUnderTest]BinaryHeap<TPriority, TValue> target,
            [PexAssumeNotNull] KeyValuePair<TPriority, TValue>[] kvs)
        {
            foreach (var kv in kvs)
                target.Add(kv.Key, kv.Value);
            foreach (var kv in kvs)
                Assert.IsTrue(target.IndexOf(kv.Value) > -1, "target.IndexOf(kv.Value) > -1");
        }

        [PexMethod(MaxRuns = 20)]
        //[PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
        //[PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentOutOfRangeException))]
        public void InsertAndRemoveAt<TPriority, TValue>(
            [PexAssumeUnderTest]BinaryHeap<TPriority, TValue> target,
            [PexAssumeNotNull] KeyValuePair<TPriority, TValue>[] kvs,
            int removeAtIndex)
        {
            foreach (var kv in kvs)
                target.Add(kv.Key, kv.Value);
            var count = target.Count;
            var removed = target.RemoveAt(removeAtIndex);
            Assert.AreEqual(count - 1, target.Count);
            AssertInvariant<TPriority, TValue>(target);
        }

        [PexMethod(MaxRuns = 20)]
        public void InsertAndEnumerate<TPriority, TValue>(
            [PexAssumeUnderTest]BinaryHeap<TPriority, TValue> target,
            [PexAssumeNotNull] KeyValuePair<TPriority, TValue>[] kvs)
        {
            var dic = new Dictionary<TPriority, TValue>();
            foreach (var kv in kvs)
            {
                target.Add(kv.Key, kv.Value);
                dic[kv.Key] = kv.Value;
            }
            PexAssert.TrueForAll(target, kv => dic.ContainsKey(kv.Key));
        }

        [PexMethod(MaxRuns = 100)]
        //[PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
        public void InsertAndRemoveMinimum<TPriority, TValue>(
            [PexAssumeUnderTest]BinaryHeap<TPriority, TValue> target,
            [PexAssumeNotNull] KeyValuePair<TPriority, TValue>[] kvs)
        {
            var count = target.Count;
            foreach (var kv in kvs)
                target.Add(kv.Key, kv.Value);

            TPriority minimum = default(TPriority);
            for (int i = 0; i < kvs.Length; ++i)
            {
                if (i == 0)
                    minimum = target.RemoveMinimum().Key;
                else
                {
                    var m = target.RemoveMinimum().Key;
                    Assert.IsTrue(target.PriorityComparison(minimum, m) <= 0);
                    minimum = m;
                }
                AssertInvariant(target);
            }

            Assert.AreEqual(0, target.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveMinimumOnEmpty()
        {
            new BinaryHeap<int, int>().RemoveMinimum();
        }

        [PexMethod(MaxRuns = 40)]
        //[PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
        public void InsertAndMinimum<TPriority, TValue>(
            [PexAssumeUnderTest]BinaryHeap<TPriority, TValue> target,
            [PexAssumeNotNull] KeyValuePair<TPriority, TValue>[] kvs)
        {
            PexAssume.IsTrue(kvs.Length > 0);

            var count = target.Count;
            TPriority minimum = default(TPriority);
            for (int i = 0; i < kvs.Length; ++i)
            {
                var kv = kvs[i];
                if (i == 0)
                    minimum = kv.Key;
                else
                    minimum = target.PriorityComparison(kv.Key, minimum) < 0 ? kv.Key : minimum;
                target.Add(kv.Key, kv.Value);
                // check minimum
                var kvMin = target.Minimum();
                Assert.AreEqual(minimum, kvMin.Key);
            }
            AssertInvariant<TPriority, TValue>(target);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void MinimumOnEmpty()
        {
            new BinaryHeap<int, int>().Minimum();
        }
    }

    [TestClass]
    [PexClass(typeof(BinaryHeap<,>))]
    [PexGenericArguments(typeof(int), typeof(int))]
    public partial class BinaryHeapTPriorityTValueEnumeratorTest
    {
        [PexMethod(MaxRuns = 20)]
        public void InsertManyAndEnumerateUntyped<TPriority, TValue>(
            [PexAssumeUnderTest]BinaryHeap<TPriority, TValue> target,
            [PexAssumeNotNull] KeyValuePair<TPriority, TValue>[] kvs)
        {
            foreach (var kv in kvs)
                target.Add(kv.Key, kv.Value);
            foreach (KeyValuePair<TPriority, TValue> kv in (IEnumerable)target) ;
        }

        [PexMethod(MaxRuns = 20)]
        public void InsertManyAndDoubleForEach<TPriority, TValue>(
            [PexAssumeUnderTest]BinaryHeap<TPriority, TValue> target,
            [PexAssumeNotNull] KeyValuePair<TPriority, TValue>[] kvs)
        {
            foreach (var kv in kvs)
                target.Add(kv.Key, kv.Value);
            PexEnumerablePatterns.DoubleForEach(target);
        }

        [PexMethod(MaxRuns = 20)]
        public void InsertManyAndMoveNextAndReset<TPriority, TValue>(
            [PexAssumeUnderTest]BinaryHeap<TPriority, TValue> target,
            [PexAssumeNotNull] KeyValuePair<TPriority, TValue>[] kvs)
        {
            foreach (var kv in kvs)
                target.Add(kv.Key, kv.Value);
            PexEnumerablePatterns.MoveNextAndReset(target);
        }

        [PexMethod(MaxRuns = 20)]
        public void InsertAndMoveNextAndModify<TPriority, TValue>(
            [PexAssumeUnderTest]BinaryHeap<TPriority, TValue> target,
            KeyValuePair<TPriority, TValue> kv)
        {
            target.Add(kv.Key, kv.Value);
            PexAssert.Throws<InvalidOperationException>(delegate
            {
                var enumerator = target.GetEnumerator();
                target.Add(kv.Key, kv.Value);
                enumerator.MoveNext();
            });
        }

        [PexMethod(MaxRuns = 20)]
        public void InsertAndResetAndModify<TPriority, TValue>(
            [PexAssumeUnderTest]BinaryHeap<TPriority, TValue> target,
            KeyValuePair<TPriority, TValue> kv)
        {
            target.Add(kv.Key, kv.Value);
            PexAssert.Throws<InvalidOperationException>(delegate
            {
                var enumerator = target.GetEnumerator();
                target.Add(kv.Key, kv.Value);
                enumerator.Reset();
            });
        }

        [PexMethod(MaxRuns = 20)]
        public void InsertAndCurrentAndModify<TPriority, TValue>(
            [PexAssumeUnderTest]BinaryHeap<TPriority, TValue> target,
            KeyValuePair<TPriority, TValue> kv)
        {
            target.Add(kv.Key, kv.Value);
            PexAssert.Throws<InvalidOperationException>(delegate
            {
                var enumerator = target.GetEnumerator();
                target.Add(kv.Key, kv.Value);
                var current = enumerator.Current;
            });
        }

        [PexMethod(MaxRuns = 20)]
        public void CurrentAfterMoveNextFinished<TPriority, TValue>(
            [PexAssumeUnderTest]BinaryHeap<TPriority, TValue> target,
            KeyValuePair<TPriority, TValue> kv)
        {
            target.Add(kv.Key, kv.Value);
            PexAssert.Throws<InvalidOperationException>(delegate
            {
                var enumerator = target.GetEnumerator();
                while (enumerator.MoveNext()) ;
                var current = enumerator.Current;
            });
        }

        [PexMethod(MaxRuns = 20)]
        public void CurrentBeforeMoveNext<TPriority, TValue>(
            [PexAssumeUnderTest]BinaryHeap<TPriority, TValue> target,
            KeyValuePair<TPriority, TValue> kv)
        {
            target.Add(kv.Key, kv.Value);
            PexAssert.Throws<InvalidOperationException>(delegate
            {
                var enumerator = target.GetEnumerator();
                var current = enumerator.Current;
            });
        }
    }*/

    [PexClass(typeof(Tuple<BinaryHeap<int, int>, BinaryHeap<int, int>>))]
    [TestClass]
    public partial class BinaryHeapCommuteTest
    {
        int global = -24;
        /*[PexMethod]
        public void TestCloneCompare([PexAssumeUnderTest] BinaryHeap<int, int> bh1, int priority, int value)
        {
            //BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = (BinaryHeap<int, int>) bh1.Clone();
            
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
        public void PUT_CommutativityCapacityCapacityComm([PexAssumeUnderTest] BinaryHeap<int, int> bh1)
        {
            //BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = (BinaryHeap<int, int>) bh1.Clone();

            BinaryHeapEqualityComparer eq = new BinaryHeapEqualityComparer();
            //PexAssume.IsTrue(eq.Equals(bh1, bh2) && !PexAssume.ReferenceEquals(bh1, bh2));

            PexObserve.ValueForViewing("$input_Count", bh1.Count);
            PexObserve.ValueForViewing("$input_Capacity", bh1.Capacity);
            PexObserve.ValueForViewing("$input_MinimumPriority", bh1.Count > 0 ? bh1.Minimum().Key : global);

            AssumePrecondition.IsTrue(  true);

            int c11 = 0, c12 = 0;
            int c21 = 0, c22 = 0;

            c11 = bh1.Capacity;
            c12 = bh1.Capacity;

            c22 = bh2.Capacity;
            c21 = bh2.Capacity;

            //NotpAssume.IsTrue(c11 == c21 && c12 == c22 && eq.Equals(bh1, bh2));
            //try{PexAssert.IsTrue(false);}catch { return; }
            PexAssert.IsTrue(c11 == c21 && c12 == c22 && eq.Equals(bh1, bh2));
        }

        [PexMethod]
        public void PUT_CommutativityCapacityCountComm([PexAssumeUnderTest] BinaryHeap<int, int> bh1)
        {
            //BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = (BinaryHeap<int, int>) bh1.Clone();

            BinaryHeapEqualityComparer eq = new BinaryHeapEqualityComparer();
            //PexAssume.IsTrue(eq.Equals(bh1, bh2) && !PexAssume.ReferenceEquals(bh1, bh2));

            PexObserve.ValueForViewing("$input_Count", bh1.Count);
            PexObserve.ValueForViewing("$input_Capacity", bh1.Capacity);
            PexObserve.ValueForViewing("$input_MinimumPriority", bh1.Count > 0 ? bh1.Minimum().Key : global);

            AssumePrecondition.IsTrue(  true);

            int c11 = 0, c12 = 0;
            int c21 = 0, c22 = 0;

            c11 = bh1.Capacity;
            c12 = bh1.Count;

            c22 = bh2.Count;
            c21 = bh2.Capacity;

            //NotpAssume.IsTrue(c11 == c21 && c12 == c22 && eq.Equals(bh1, bh2));
            //try{PexAssert.IsTrue(false);}catch { return; }
            PexAssert.IsTrue(c11 == c21 && c12 == c22 && eq.Equals(bh1, bh2));
        }

        [PexMethod]
        public void PUT_CommutativityCapacityAddComm([PexAssumeUnderTest] BinaryHeap<int, int> bh1, int priority, int value)
        {
            //BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = (BinaryHeap<int, int>) bh1.Clone();

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
            PexObserve.ValueForViewing("$input_MinimumPriority", bh1.Count > 0 ? bh1.Minimum().Key : global);

            AssumePrecondition.IsTrue(  ((!(bh1.Count == bh1.Capacity))) );

            int c1 = 0, c2 = 0;

            c1 = bh1.Capacity; // == count  --> bh1, bh2
            bh1.Add(priority, value);// count + n --> bh1 , bh2
            bh2.Add(priority, value);  //  adds to bh1 and bh2 --> capacity remains unchanged
            c2 = bh2.Capacity;

            //NotpAssume.IsTrue(c1 == c2 && eq.Equals(bh1, bh2));
            //try{PexAssert.IsTrue(false); }catch { return; }
            PexAssert.IsTrue(c1 == c2 && eq.Equals(bh1, bh2));
        }

        [PexMethod]
        public void PUT_CommutativityCapacityMinimumComm([PexAssumeUnderTest] BinaryHeap<int, int> bh1)
        {
            //BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = (BinaryHeap<int, int>) bh1.Clone();

            BinaryHeapEqualityComparer eq = new BinaryHeapEqualityComparer();
            //PexAssume.IsTrue(eq.Equals(bh1, bh2) && !PexAssume.ReferenceEquals(bh1, bh2));

            PexObserve.ValueForViewing("$input_Count", bh1.Count);
            PexObserve.ValueForViewing("$input_Capacity", bh1.Capacity);
            PexObserve.ValueForViewing("$input_MinimumPriority", bh1.Count > 0 ? bh1.Minimum().Key : global);

            AssumePrecondition.IsTrue(  ((!(bh1.Count <= 0))) );

            int c1 = 0, c2 = 0;

            c1 = bh1.Capacity;
            var m1 = bh1.Minimum();

            var m2 = bh2.Minimum();
            c2 = bh2.Capacity;

            //NotpAssume.IsTrue(c1 == c2 && m1.Key == m2.Key && m1.Value == m2.Value && eq.Equals(bh1, bh2));
            //try{PexAssert.IsTrue(false); }catch { return; }
            PexAssert.IsTrue(c1 == c2 && m1.Key == m2.Key && m1.Value == m2.Value && eq.Equals(bh1, bh2));
        }

        [PexMethod]
        public void PUT_CommutativityCapacityRemoveMinimumComm([PexAssumeUnderTest] BinaryHeap<int, int> bh1)
        {
            //BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = (BinaryHeap<int, int>) bh1.Clone();

            BinaryHeapEqualityComparer eq = new BinaryHeapEqualityComparer();
            //PexAssume.IsTrue(eq.Equals(bh1, bh2) && !PexAssume.ReferenceEquals(bh1, bh2));

            PexObserve.ValueForViewing("$input_Count", bh1.Count);
            PexObserve.ValueForViewing("$input_Capacity", bh1.Capacity);
            PexObserve.ValueForViewing("$input_MinimumPriority", bh1.Count > 0 ? bh1.Minimum().Key : global);

            AssumePrecondition.IsTrue(  ((!(bh1.Count <= 0))) );

            int c1 = 0, c2 = 0;

            c1 = bh1.Capacity;
            var rm1 = bh1.RemoveMinimum();

            var rm2 = bh2.RemoveMinimum();
            c2 = bh2.Capacity;

            NotpAssume.IsTrue(c1 == c2 && rm1.Key == rm2.Key && rm1.Value == rm2.Value && eq.Equals(bh1, bh2));
            //try{PexAssert.IsTrue(false); }catch { return; }
            PexAssert.IsTrue(c1 == c2 && rm1.Key == rm2.Key && rm1.Value == rm2.Value && eq.Equals(bh1, bh2));
        }

        [PexMethod]
        public void PUT_CommutativityCapacityRemoveAtComm([PexAssumeUnderTest] BinaryHeap<int, int> bh1, int index)
        {
            //BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = (BinaryHeap<int, int>) bh1.Clone();

            PexAssume.IsTrue(index > -11 && index < 11);

            //BinaryHeap<int, int> bh2 = (QuickGraph.BinaryHeap<int, int>)bh1.Clone();
            BinaryHeapEqualityComparer eq = new BinaryHeapEqualityComparer();
            //PexAssume.IsTrue(eq.Equals(bh1, bh2) && !PexAssume.ReferenceEquals(bh1, bh2));

            PexObserve.ValueForViewing("$input_Index", index);
            PexObserve.ValueForViewing("$input_Count", bh1.Count);
            PexObserve.ValueForViewing("$input_Capacity", bh1.Capacity);
            PexObserve.ValueForViewing("$input_MinimumPriority", bh1.Count > 0 ? bh1.Minimum().Key : global);

            AssumePrecondition.IsTrue(true);
            int c1 = 0, c2 = 0;

            c1 = bh1.Capacity;
            var ra1 = bh1.RemoveAt(index);

            var ra2 = bh2.RemoveAt(index);
            c2 = bh2.Capacity;


            //NotpAssume.IsTrue(c1 == c2 && ra1.Key == ra2.Key && ra1.Value == ra2.Value && eq.Equals(bh1, bh2));
            //try{PexAssert.IsTrue(false);}catch{return;}
            PexAssert.IsTrue(c1 == c2 && ra1.Key == ra2.Key && ra1.Value == ra2.Value && eq.Equals(bh1, bh2));
        }

        [PexMethod]
        public void PUT_CommutativityCapacityIndexOfComm([PexAssumeUnderTest] BinaryHeap<int, int> bh1, int value)
        {
            //BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = (BinaryHeap<int, int>) bh1.Clone();

            PexAssume.IsTrue(value > -11 && value < 11);

            BinaryHeapEqualityComparer eq = new BinaryHeapEqualityComparer();
            //PexAssume.IsTrue(eq.Equals(bh1, bh2) && !PexAssume.ReferenceEquals(bh1, bh2));

            PexObserve.ValueForViewing("$input_Count", bh1.Count);
            PexObserve.ValueForViewing("$input_Capacity", bh1.Capacity);
            PexObserve.ValueForViewing("$input_MinimumPriority", bh1.Count > 0 ? bh1.Minimum().Key : global);

            AssumePrecondition.IsTrue(  true);

            int c1 = 0, c2 = 0;
            int io1 = 0, io2 = 0;

            c1 = bh1.Capacity;
            io1 = bh1.IndexOf(value);

            io2 = bh2.IndexOf(value);
            c2 = bh2.Capacity;

            NotpAssume.IsTrue(c1 == c2 && io1 == io2 && eq.Equals(bh1, bh2));
            //try{PexAssert.IsTrue(false);}catch {return;}
            PexAssert.IsTrue(c1 == c2 && io1 == io2 && eq.Equals(bh1, bh2));
        }

        [PexMethod]
        public void PUT_CommutativityCapacityUpdateComm([PexAssumeUnderTest] BinaryHeap<int, int> bh1, int priority, int value)
        {
            //BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = (BinaryHeap<int, int>) bh1.Clone();

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
            PexObserve.ValueForViewing("$input_MinimumPriority", bh1.Count > 0 ? bh1.Minimum().Key : global);

            AssumePrecondition.IsTrue(  ((!(-bh1.Count + bh1.Capacity + bh1.IndexOf(value) <= -1)) && (((!(bh1.Count <= 0)) && ((bh1.Count <= 5) ||  ((!(bh1.Count <= 5)) && ((value == bh1.IndexOf(value) && ((value == bh1.Minimum().Key) ||  ((!(value == bh1.Minimum().Key)) && (((!(-priority + -value + bh1.Count + bh1.Capacity + -bh1.IndexOf(value) <= 8))))))) ||  ((!(value == bh1.IndexOf(value)))))))))) );

            int c1 = 0, c2 = 0;

            c1 = bh1.Capacity;
            bh1.Update(priority, value);

            bh2.Update(priority, value);
            c2 = bh2.Capacity;

            NotpAssume.IsTrue(c1 == c2 && eq.Equals(bh1, bh2));
            //try{PexAssert.IsTrue(false);}catch {return;}
            PexAssert.IsTrue(c1 == c2 && eq.Equals(bh1, bh2));
        }

        [PexMethod]
        public void PUT_CommutativityCountCountComm([PexAssumeUnderTest] BinaryHeap<int, int> bh1)
        {
            //BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = (BinaryHeap<int, int>) bh1.Clone();

            BinaryHeapEqualityComparer eq = new BinaryHeapEqualityComparer();
            //PexAssume.IsTrue(eq.Equals(bh1, bh2) && !PexAssume.ReferenceEquals(bh1, bh2));

            PexObserve.ValueForViewing("$input_Count", bh1.Count);
            PexObserve.ValueForViewing("$input_Capacity", bh1.Capacity);
            PexObserve.ValueForViewing("$input_MinimumPriority", bh1.Count > 0 ? bh1.Minimum().Key : global);

            AssumePrecondition.IsTrue(  true);

            int c11 = 0, c12 = 0;
            int c21 = 0, c22 = 0;

            c11 = bh1.Count;
            c12 = bh1.Count;

            c22 = bh2.Count;
            c21 = bh2.Count;

            //NotpAssume.IsTrue(c11 == c21 && c12 == c22 && eq.Equals(bh1, bh2));
            //try{PexAssert.IsTrue(false);}catch {return;}
            PexAssert.IsTrue(c11 == c21 && c12 == c22 && eq.Equals(bh1, bh2));
        }

        [PexMethod]
        public void PUT_CommutativityCountAddComm([PexAssumeUnderTest] BinaryHeap<int, int> bh1, int priority, int value)
        {
            //BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = (BinaryHeap<int, int>) bh1.Clone();

            PexAssume.IsTrue(priority > -11 && priority < 11);
            PexAssume.IsTrue(value > -11 && value < 11);

            BinaryHeapEqualityComparer eq = new BinaryHeapEqualityComparer();
            //PexAssume.IsTrue(eq.Equals(bh1, bh2) && !PexAssume.ReferenceEquals(bh1, bh2));

            PexObserve.ValueForViewing("$input_Priority", priority);
            PexObserve.ValueForViewing("$input_Value", value);
            PexObserve.ValueForViewing("$input_Count", bh1.Count);
            PexObserve.ValueForViewing("$input_Capacity", bh1.Capacity);
            PexObserve.ValueForViewing("$input_IndexOf", bh1.IndexOf(value));
            PexObserve.ValueForViewing("$input_MinimumPriority", bh1.Count > 0 ? bh1.Minimum().Key : global);

            AssumePrecondition.IsTrue(  false);

            int c1 = 0, c2 = 0;

            c1 = bh1.Count;
            bh1.Add(priority, value);

            bh2.Add(priority, value);
            c2 = bh2.Count;

            //NotpAssume.IsTrue(c1 == c2 && eq.Equals(bh1, bh2));
            //try{PexAssert.IsTrue(false);}catch {return;}
            PexAssert.IsTrue(c1 == c2 && eq.Equals(bh1, bh2));
        }

        [PexMethod]
        public void PUT_CommutativityCountMinimumComm([PexAssumeUnderTest] BinaryHeap<int, int> bh1/* */)
        {
            //BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = (BinaryHeap<int, int>) bh1.Clone();

            //BinaryHeap<int, int> bh2 = (QuickGraph.BinaryHeap<int, int>)bh1.Clone();
            BinaryHeapEqualityComparer eq = new BinaryHeapEqualityComparer();
            ////PexAssume.IsTrue(eq.Equals(bh1, bh2) && !PexAssume.ReferenceEquals(bh1, bh2));

            PexObserve.ValueForViewing("$input_Count", bh1.Count);
            PexObserve.ValueForViewing("$input_Capacity", bh1.Capacity);
            PexObserve.ValueForViewing("$input_MinimumPriority", bh1.Count > 0 ? bh1.Minimum().Key : global);

            AssumePrecondition.IsTrue(  ((!(bh1.Count <= 0))) );

            int c1 = 0, c2 = 0;

            c1 = bh1.Count;
            var m1 = bh1.Minimum();

            var m2 = bh2.Minimum();
            c2 = bh2.Count;

            //NotpAssume.IsTrue(c1 == c2 && m1.Key == m2.Key && m1.Value == m2.Value && eq.Equals(bh1, bh2));
            //try{PexAssert.IsTrue(false);}catch {return;}
            PexAssert.IsTrue(c1 == c2 && m1.Key == m2.Key && m1.Value == m2.Value && eq.Equals(bh1, bh2));
        }

        [PexMethod]
        public void PUT_CommutativityCountRemoveMinimumComm([PexAssumeUnderTest] BinaryHeap<int, int> bh1)
        {
            //BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = (BinaryHeap<int, int>) bh1.Clone();

            BinaryHeapEqualityComparer eq = new BinaryHeapEqualityComparer();
            //PexAssume.IsTrue(eq.Equals(bh1, bh2) && !PexAssume.ReferenceEquals(bh1, bh2));

            PexObserve.ValueForViewing("$input_Count", bh1.Count);
            PexObserve.ValueForViewing("$input_Capacity", bh1.Capacity);
            PexObserve.ValueForViewing("$input_MinimumPriority", bh1.Count > 0 ? bh1.Minimum().Key : global);

            AssumePrecondition.IsTrue(  false);

            int c1 = 0, c2 = 0;

            c1 = bh1.Count;
            var rm1 = bh1.RemoveMinimum();

            var rm2 = bh2.RemoveMinimum();
            c2 = bh2.Count;

            //NotpAssume.IsTrue(c1 == c2 && rm1.Key == rm2.Key && rm1.Value == rm2.Value && eq.Equals(bh1, bh2));
            //try{PexAssert.IsTrue(false);}catch {return;}
            PexAssert.IsTrue(c1 == c2 && rm1.Key == rm2.Key && rm1.Value == rm2.Value && eq.Equals(bh1, bh2));
        }

        [PexMethod]
        public void PUT_CommutativityCountRemoveAtComm([PexAssumeUnderTest] BinaryHeap<int, int> bh1, int index)
        {
            //BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = (BinaryHeap<int, int>) bh1.Clone();

            PexAssume.IsTrue(index > -11 && index < 11);

            BinaryHeapEqualityComparer eq = new BinaryHeapEqualityComparer();
            //PexAssume.IsTrue(eq.Equals(bh1, bh2) && !PexAssume.ReferenceEquals(bh1, bh2));

            PexObserve.ValueForViewing("$input_Index", index);
            PexObserve.ValueForViewing("$input_Count", bh1.Count);
            PexObserve.ValueForViewing("$input_Capacity", bh1.Capacity);
            PexObserve.ValueForViewing("$input_MinimumPriority", bh1.Count > 0 ? bh1.Minimum().Key : global);

            AssumePrecondition.IsTrue( (bh1.Count <= 3 && (((!(bh1.Count <= 0)) && ((-index + bh1.Count <= 0) ||  ((!(-index + bh1.Count <= 0)) && ((index <= -1)))))))  );

            int c1 = 0, c2 = 0;

            c1 = bh1.Count;
            var ra1 = bh1.RemoveAt(index);

            var ra2 = bh2.RemoveAt(index);
            c2 = bh2.Count;

            //NotpAssume.IsTrue(c1 == c2 && ra1.Key == ra2.Key && ra1.Value == ra2.Value && eq.Equals(bh1, bh2));
            //try{PexAssert.IsTrue(false);}catch {return;}
            PexAssert.IsTrue(c1 == c2 && ra1.Key == ra2.Key && ra1.Value == ra2.Value && eq.Equals(bh1, bh2));
        }

        [PexMethod]
        public void PUT_CommutativityCountIndexOfComm([PexAssumeUnderTest] BinaryHeap<int, int> bh1, int value)
        {
            //BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = (BinaryHeap<int, int>) bh1.Clone();

            PexAssume.IsTrue(value > -11 && value < 11);

            BinaryHeapEqualityComparer eq = new BinaryHeapEqualityComparer();
            //PexAssume.IsTrue(eq.Equals(bh1, bh2) && !PexAssume.ReferenceEquals(bh1, bh2));

            PexObserve.ValueForViewing("$input_Value", value);
            PexObserve.ValueForViewing("$input_Count", bh1.Count);
            PexObserve.ValueForViewing("$input_Capacity", bh1.Capacity);
            PexObserve.ValueForViewing("$input_IndexOf", bh1.IndexOf(value));
            PexObserve.ValueForViewing("$input_MinimumPriority", bh1.Count > 0 ? bh1.Minimum().Key : global);

            AssumePrecondition.IsTrue(  true);

            int c1 = 0, c2 = 0;
            int io1 = 0, io2 = 0;

            c1 = bh1.Count;
            io1 = bh1.IndexOf(value);

            io2 = bh2.IndexOf(value);
            c2 = bh2.Count;

            //NotpAssume.IsTrue(c1 == c2 && io1 == io2 && eq.Equals(bh1, bh2));
            //try{PexAssert.IsTrue(false);}catch {return;}
            PexAssert.IsTrue(c1 == c2 && io1 == io2 && eq.Equals(bh1, bh2));
        }

        [PexMethod]
        public void PUT_CommutativityCountUpdateComm([PexAssumeUnderTest] BinaryHeap<int, int> bh1, int priority, int value)
        {
            //BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = (BinaryHeap<int, int>) bh1.Clone();

            PexAssume.IsTrue(priority > -11 && priority < 11);
            PexAssume.IsTrue(value > -11 && value < 11);

            BinaryHeapEqualityComparer eq = new BinaryHeapEqualityComparer();
            //PexAssume.IsTrue(eq.Equals(bh1, bh2) && !PexAssume.ReferenceEquals(bh1, bh2));

            PexObserve.ValueForViewing("$input_Priority", priority);
            PexObserve.ValueForViewing("$input_Value", value);
            PexObserve.ValueForViewing("$input_Count", bh1.Count);
            PexObserve.ValueForViewing("$input_Capacity", bh1.Capacity);
            PexObserve.ValueForViewing("$input_IndexOf", bh1.IndexOf(value));
            PexObserve.ValueForViewing("$input_MinimumPriority", bh1.Count > 0 ? bh1.Minimum().Key : global);

            AssumePrecondition.IsTrue(  ((!(bh1.IndexOf(value) <= -1))) );

            int c1 = 0, c2 = 0;

            c1 = bh1.Count;
            bh1.Update(priority, value);

            bh2.Update(priority, value);
            c2 = bh2.Count;

            //NotpAssume.IsTrue(c1 == c2 && eq.Equals(bh1, bh2));
            //try{PexAssert.IsTrue(false);}catch{return;}
            PexAssert.IsTrue(c1 == c2 && eq.Equals(bh1, bh2));
        }

        [PexMethod]
        public void PUT_CommutativityAddAddComm([PexAssumeUnderTest] BinaryHeap<int, int> bh1, int priority1, int value1, int priority2, int value2)
        {
            //BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = (BinaryHeap<int, int>) bh1.Clone();

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
            PexObserve.ValueForViewing("$input_MinimumPriority", bh1.Count > 0 ? bh1.Minimum().Key : global);

            AssumePrecondition.IsTrue( (-priority1 + bh1.Minimum().Key <= -1 && ((priority1 == priority2 && ((value1 == value2 && (((!(bh1.Count <= 0))))))) ||  ((!(priority1 == priority2)) && ((bh1.Count <= 0))))) ||  ((!(-priority1 + bh1.Minimum().Key <= -1)) && (((!(-priority2 + -bh1.IndexOf(value1) + bh1.IndexOf(value2) + bh1.Minimum().Key <= -1)) && ((priority1 == priority2 && ((value1 == value2))) ||  ((!(priority1 == priority2))))))) );

            bh1.Add(priority1, value1);
            bh1.Add(priority2, value2);

            bh2.Add(priority2, value2);
            bh2.Add(priority1, value1);

            //NotpAssume.IsTrue(eq.Equals(bh1, bh2));
            //try{PexAssert.IsTrue(false);}catch {return;}
            PexAssert.IsTrue(eq.Equals(bh1, bh2));
        }

        [PexMethod]
        public void PUT_CommutativityAddMinimumComm([PexAssumeUnderTest] BinaryHeap<int, int> bh1, int priority, int value/* */)
        {
            //BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = (BinaryHeap<int, int>) bh1.Clone();

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
            PexObserve.ValueForViewing("$input_MinimumPriority", bh1.Count > 0 ? bh1.Minimum().Key : global);

            AssumePrecondition.IsTrue( (-priority + -bh1.IndexOf(value) + bh1.Minimum().Key <= 0 && (((!(bh1.Count <= 0)) && ((-priority + bh1.IndexOf(value) + bh1.Minimum().Key <= 0)))))  );
            bh1.Add(priority, value);
            var m1 = bh1.Minimum();

            var m2 = bh2.Minimum();
            bh2.Add(priority, value);

            //NotpAssume.IsTrue(m1.Key == m2.Key && m1.Value == m2.Value && eq.Equals(bh1, bh2));
            //try{PexAssert.IsTrue(false);}catch {return;}
            PexAssert.IsTrue(m1.Key == m2.Key && m1.Value == m2.Value && eq.Equals(bh1, bh2));
        }

        [PexMethod]
        public void PUT_CommutativityAddRemoveMinimumComm([PexAssumeUnderTest] BinaryHeap<int, int> bh1, int priority, int value)
        {
            //BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = (BinaryHeap<int, int>) bh1.Clone();

            PexAssume.IsTrue(priority > -11 && priority < 11);
            PexAssume.IsTrue(value > -11 && value < 11);

            BinaryHeapEqualityComparer eq = new BinaryHeapEqualityComparer();
            //PexAssume.IsTrue(eq.Equals(bh1, bh2) && !PexAssume.ReferenceEquals(bh1, bh2));

            PexObserve.ValueForViewing("$input_Priority", priority);
            PexObserve.ValueForViewing("$input_Value", value);
            PexObserve.ValueForViewing("$input_Count", bh1.Count);
            PexObserve.ValueForViewing("$input_Capacity", bh1.Capacity);
            PexObserve.ValueForViewing("$input_IndexOf", bh1.IndexOf(value));
            PexObserve.ValueForViewing("$input_MinimumPriority", bh1.Count > 0 ? bh1.Minimum().Key : global);

            AssumePrecondition.IsTrue(  ((!(bh1.Count == bh1.Capacity)) && ((-priority + -bh1.IndexOf(value) + bh1.Minimum().Key <= 0 && ((bh1.Count <= 2 && ((-priority + bh1.IndexOf(value) + bh1.Minimum().Key <= 0 && (((!(bh1.Count <= 0))))))) ||  ((!(bh1.Count <= 2)) && (((!(value == bh1.Count)) && (((!(bh1.Count == bh1.Minimum().Key)) && (((!(bh1.Capacity == bh1.Minimum().Key)) && ((-priority + value + bh1.Capacity <= 7 && ((bh1.IndexOf(value) == bh1.Minimum().Key && ((bh1.Count <= 5 && ((value == bh1.Capacity) ||  ((!(value == bh1.Capacity)) && (((!(bh1.Count <= 3)) && ((-bh1.Count + bh1.Capacity + -bh1.IndexOf(value) + -bh1.Minimum().Key <= 1 && (((!(priority == bh1.IndexOf(value))) && ((value == bh1.IndexOf(value) && ((priority == bh1.Count && ((-priority + -value + -bh1.Count + bh1.Capacity + -bh1.IndexOf(value) + -bh1.Minimum().Key <= -4))) ||  ((!(priority == bh1.Count)) && ((bh1.Count <= 4) ||  ((!(bh1.Count <= 4)) && (((!(-priority + -value + bh1.Count + bh1.Capacity + -bh1.IndexOf(value) + -bh1.Minimum().Key <= 2)) && ((-priority + -value + bh1.Capacity + -bh1.IndexOf(value) + -bh1.Minimum().Key <= -2))))))))))))) ||  ((!(-bh1.Count + bh1.Capacity + -bh1.IndexOf(value) + -bh1.Minimum().Key <= 1)) && (((!(-priority + -bh1.Count + -bh1.IndexOf(value) + -bh1.Minimum().Key <= -14))))))))))) ||  ((!(bh1.Count <= 5)) && (((!(value == bh1.IndexOf(value))) && (((!(priority == bh1.Count)) && (((!(priority == value)) && (((!(value == bh1.Capacity)) && (((!(priority + value + -bh1.Capacity + -bh1.IndexOf(value) + -bh1.Minimum().Key <= 0)) && (((!(-priority + bh1.Capacity + -bh1.IndexOf(value) + -bh1.Minimum().Key <= -3)) && ((-priority + bh1.Capacity + -bh1.IndexOf(value) + -bh1.Minimum().Key <= -2 && (((!(-priority + -value + bh1.Count + bh1.Capacity + -bh1.IndexOf(value) + -bh1.Minimum().Key <= -1))))))))))))))))))))) ||  ((!(bh1.IndexOf(value) == bh1.Minimum().Key)) && (((!(priority == bh1.IndexOf(value))) && ((priority == value && ((-priority + -value + bh1.Count + bh1.IndexOf(value) + bh1.Minimum().Key <= 2))) ||  ((!(priority == value)) && ((-value + bh1.Capacity <= 6 && ((-priority + value + bh1.Count + bh1.Capacity + -bh1.IndexOf(value) <= 5) ||  ((!(-priority + value + bh1.Count + bh1.Capacity + -bh1.IndexOf(value) <= 5)) && ((-bh1.Count + -bh1.Capacity + bh1.IndexOf(value) <= -10 && ((-bh1.Count + -bh1.Capacity + bh1.IndexOf(value) <= -12 && ((priority == bh1.Minimum().Key && ((-priority + value + bh1.Count + -bh1.IndexOf(value) + -bh1.Minimum().Key <= 1))) ||  ((!(priority == bh1.Minimum().Key)) && ((value == bh1.Minimum().Key && ((-value + -bh1.Count + bh1.Capacity + -bh1.IndexOf(value) <= -1))) ||  ((!(value == bh1.Minimum().Key)) && ((priority == bh1.Count && ((-priority + -value + bh1.Capacity + -bh1.IndexOf(value) <= -2) ||  ((!(-priority + -value + bh1.Capacity + -bh1.IndexOf(value) <= -2)) && ((-priority + -value + bh1.Capacity + -bh1.IndexOf(value) <= -1 && (((!(-priority + -value + -bh1.Count + -bh1.Capacity + -bh1.IndexOf(value) + -bh1.Minimum().Key <= 51))))) ||  ((!(-priority + -value + bh1.Capacity + -bh1.IndexOf(value) <= -1)) && ((-priority + -value + -bh1.Count + -bh1.Capacity + -bh1.IndexOf(value) + -bh1.Minimum().Key <= 63))))))) ||  ((!(priority == bh1.Count)) && ((-bh1.Count + -bh1.Capacity + -bh1.IndexOf(value) + -bh1.Minimum().Key <= 84 && (((!(priority == bh1.Capacity)) && ((-priority + value + bh1.Count + bh1.Capacity + -bh1.IndexOf(value) + bh1.Minimum().Key <= -35 && (((!(-priority + value + -bh1.Count + -bh1.Capacity + -bh1.IndexOf(value) + -bh1.Minimum().Key <= 57)) && ((-priority + value + -bh1.Count + -bh1.Capacity + -bh1.IndexOf(value) + -bh1.Minimum().Key <= 70))))) ||  ((!(-priority + value + bh1.Count + bh1.Capacity + -bh1.IndexOf(value) + bh1.Minimum().Key <= -35)) && ((value == bh1.Capacity) ||  ((!(value == bh1.Capacity)) && (((!(-priority + -value + bh1.Capacity + -bh1.IndexOf(value) <= -3))))))))))) ||  ((!(-bh1.Count + -bh1.Capacity + -bh1.IndexOf(value) + -bh1.Minimum().Key <= 84))))))))))) ||  ((!(-bh1.Count + -bh1.Capacity + bh1.IndexOf(value) <= -12))))))))) ||  ((!(-value + bh1.Capacity <= 6)) && (((!(-priority + bh1.Capacity + -bh1.IndexOf(value) <= -3)) && ((bh1.Capacity <= 6) ||  ((!(bh1.Capacity <= 6)) && ((bh1.Capacity <= 7 && ((value == bh1.IndexOf(value) && (((!(priority == bh1.Count)) && ((priority == bh1.Capacity && ((-priority + -value + -bh1.Count + -bh1.Capacity + -bh1.IndexOf(value) + -bh1.Minimum().Key <= 77))) ||  ((!(priority == bh1.Capacity)) && ((priority == bh1.Minimum().Key && (((!(-priority + -value + bh1.Capacity + -bh1.IndexOf(value) + -bh1.Minimum().Key <= 0)) && ((-priority + -value + -bh1.Count + bh1.Capacity + -bh1.IndexOf(value) <= -1))))) ||  ((!(priority == bh1.Minimum().Key)) && ((-priority + -value + -bh1.Count + bh1.Capacity + -bh1.IndexOf(value) <= -2 && ((-priority + -value + bh1.Count + -bh1.IndexOf(value) <= 1 && ((-priority + -value + bh1.Capacity + -bh1.IndexOf(value) <= -2 && ((-priority + -value + -bh1.Count + -bh1.Capacity + -bh1.IndexOf(value) + -bh1.Minimum().Key <= 57))) ||  ((!(-priority + -value + bh1.Capacity + -bh1.IndexOf(value) <= -2)) && ((-priority + -value + -bh1.Count + -bh1.Capacity + -bh1.IndexOf(value) + -bh1.Minimum().Key <= 5 && (((!(-priority + -value + bh1.Capacity + -bh1.IndexOf(value) <= 0)) && (((!(priority + -value + -bh1.Capacity + -bh1.IndexOf(value) + bh1.Minimum().Key <= 0)) && ((-priority + -value + -bh1.Count + bh1.Capacity + -bh1.IndexOf(value) + bh1.Minimum().Key <= -1))))))) ||  ((!(-priority + -value + -bh1.Count + -bh1.Capacity + -bh1.IndexOf(value) + -bh1.Minimum().Key <= 5)) && ((-priority + -value + -bh1.Count + -bh1.Capacity + -bh1.IndexOf(value) + -bh1.Minimum().Key <= 79))))))))) ||  ((!(-priority + -value + -bh1.Count + bh1.Capacity + -bh1.IndexOf(value) <= -2))))))))))) ||  ((!(value == bh1.IndexOf(value))) && ((-bh1.Count + bh1.Capacity + -bh1.IndexOf(value) <= 1 && ((priority == bh1.Count && ((-priority + -value + -bh1.IndexOf(value) <= 0) ||  ((!(-priority + -value + -bh1.IndexOf(value) <= 0)) && (((!(value == bh1.Minimum().Key)) && ((-priority + value + -bh1.Count + -bh1.Capacity + -bh1.IndexOf(value) + -bh1.Minimum().Key <= 40))))))) ||  ((!(priority == bh1.Count)) && ((priority == bh1.Minimum().Key && ((-priority + -value + -bh1.Count + -bh1.IndexOf(value) + bh1.Minimum().Key <= -2) ||  ((!(-priority + -value + -bh1.Count + -bh1.IndexOf(value) + bh1.Minimum().Key <= -2)) && (((!(-priority + value + -bh1.Capacity + -bh1.IndexOf(value) + -bh1.Minimum().Key <= 0))))))) ||  ((!(priority == bh1.Minimum().Key)) && ((priority == bh1.Capacity && ((-priority + -value + -bh1.Count + bh1.Capacity + -bh1.IndexOf(value) <= -2))) ||  ((!(priority == bh1.Capacity)) && ((value == bh1.Minimum().Key && ((-priority + -value + -bh1.Count + -bh1.Capacity + -bh1.IndexOf(value) + -bh1.Minimum().Key <= 0))) ||  ((!(value == bh1.Minimum().Key)) && (((!(-value + -bh1.Count + -bh1.IndexOf(value) <= -1)) && ((-value + -bh1.Capacity + -bh1.IndexOf(value) <= 2) ||  ((!(-value + -bh1.Capacity + -bh1.IndexOf(value) <= 2)) && ((-priority + value + -bh1.Count + -bh1.Capacity + -bh1.IndexOf(value) + -bh1.Minimum().Key <= -1))))))))))))))) ||  ((!(-bh1.Count + bh1.Capacity + -bh1.IndexOf(value) <= 1))))))))))))))))))))))))))))))))) );

            bh1.Add(priority, value);
            var rm1 = bh1.RemoveMinimum();

            var rm2 = bh2.RemoveMinimum();
            bh2.Add(priority, value);

            //NotpAssume.IsTrue(rm1.Key == rm2.Key && rm1.Value == rm2.Value && eq.Equals(bh1, bh2));
            //try{PexAssert.IsTrue(false);}catch {return;}
            PexAssert.IsTrue(rm1.Key == rm2.Key && rm1.Value == rm2.Value && eq.Equals(bh1, bh2));
        }

        [PexMethod]
        public void PUT_CommutativityAddRemoveAtComm([PexAssumeUnderTest] BinaryHeap<int, int> bh1, int priority, int value, int index)
        {
            //BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = (BinaryHeap<int, int>) bh1.Clone();

            PexAssume.IsTrue(index > -11 && index < 11);

            PexAssume.IsTrue(priority > -11 && priority < 11);
            PexAssume.IsTrue(value > -11 && value < 11);

            BinaryHeapEqualityComparer eq = new BinaryHeapEqualityComparer();
            //PexAssume.IsTrue(eq.Equals(bh1, bh2) && !PexAssume.ReferenceEquals(bh1, bh2));

            PexObserve.ValueForViewing("$input_Priority", priority);
            PexObserve.ValueForViewing("$input_Value", value);
            PexObserve.ValueForViewing("$input_Index", index);
            PexObserve.ValueForViewing("$input_Count", bh1.Count);
            PexObserve.ValueForViewing("$input_Capacity", bh1.Capacity);
            PexObserve.ValueForViewing("$input_IndexOf", bh1.IndexOf(value));
            PexObserve.ValueForViewing("$input_MinimumPriority", bh1.Count > 0 ? bh1.Minimum().Key : global);

            AssumePrecondition.IsTrue( (bh1.Count <= 2 && ((index <= 0 && (((!(-index + bh1.Capacity <= 1)) && ((-priority + index + -bh1.IndexOf(value) + bh1.Minimum().Key <= 0 && ((-priority + index + bh1.IndexOf(value) + bh1.Minimum().Key <= 0))) ||  ((!(-priority + index + -bh1.IndexOf(value) + bh1.Minimum().Key <= 0)) && ((index <= -1))))))) ||  ((!(index <= 0))))) ||  ((!(bh1.Count <= 2)) && ((index <= -1) ||  ((!(index <= -1)) && ((-index + bh1.Count <= 0) ||  ((!(-index + bh1.Count <= 0)) && (((!(bh1.Count == bh1.Capacity)) && ((-priority + index + bh1.Count + bh1.IndexOf(value) + bh1.Minimum().Key <= 4 && (((!(-index + -bh1.Count + -bh1.Capacity <= -16)) && ((-index + -bh1.IndexOf(value) <= -3) ||  ((!(-index + -bh1.IndexOf(value) <= -3)) && ((index <= 0 && ((priority == bh1.IndexOf(value)) ||  ((!(priority == bh1.IndexOf(value))) && (((!(priority == value)) && ((priority == bh1.Capacity && ((-priority + value + -index + -bh1.Capacity + -bh1.IndexOf(value) + -bh1.Minimum().Key <= 15 && (((!(value == bh1.Minimum().Key)) && ((-priority + -value + -index + -bh1.Count + bh1.Capacity + -bh1.IndexOf(value) + bh1.Minimum().Key <= 0))))))) ||  ((!(priority == bh1.Capacity)) && ((-index + -bh1.Count + bh1.Capacity <= 4 && ((bh1.Count == bh1.Minimum().Key) ||  ((!(bh1.Count == bh1.Minimum().Key)) && ((priority == bh1.Count && (((!(-priority + -index + -bh1.Count + bh1.Capacity + -bh1.IndexOf(value) <= -1))))) ||  ((!(priority == bh1.Count)) && ((index == bh1.Minimum().Key && ((-value + -index + -bh1.Count + -bh1.IndexOf(value) + -bh1.Minimum().Key <= -5 && ((-priority + -value + -index + -bh1.Capacity + bh1.IndexOf(value) + -bh1.Minimum().Key <= -15))) ||  ((!(-value + -index + -bh1.Count + -bh1.IndexOf(value) + -bh1.Minimum().Key <= -5))))) ||  ((!(index == bh1.Minimum().Key)) && ((priority == bh1.Minimum().Key) ||  ((!(priority == bh1.Minimum().Key)) && ((value == bh1.IndexOf(value) && (((!(-value + -index + -bh1.Count + -bh1.IndexOf(value) <= -7)) && (((!(-priority + value + -index + bh1.Count + bh1.Capacity + bh1.IndexOf(value) + bh1.Minimum().Key <= -71)) && (((!(-priority + value + -index + bh1.Count + bh1.Capacity + bh1.IndexOf(value) <= -1))))))))) ||  ((!(value == bh1.IndexOf(value))) && ((priority == index) ||  ((!(priority == index)) && ((-index + -bh1.Count + bh1.Capacity + bh1.IndexOf(value) <= 3 && ((value == bh1.Minimum().Key) ||  ((!(value == bh1.Minimum().Key)) && ((value == bh1.Capacity && ((index == bh1.IndexOf(value)))) ||  ((!(value == bh1.Capacity)) && ((index == bh1.IndexOf(value) && ((value == bh1.Count && ((-priority + value + -index + bh1.Count + bh1.Capacity + -bh1.IndexOf(value) <= 12))) ||  ((!(value == bh1.Count)) && ((bh1.Capacity == bh1.Minimum().Key && ((-value + -index + bh1.Count + -bh1.IndexOf(value) + bh1.Minimum().Key <= 0))) ||  ((!(bh1.Capacity == bh1.Minimum().Key)) && ((-index + -bh1.Count + bh1.Capacity + -bh1.IndexOf(value) <= 1 && ((-priority + value + -index + -bh1.Count + -bh1.Capacity + -bh1.IndexOf(value) + -bh1.Minimum().Key <= 66) ||  ((!(-priority + value + -index + -bh1.Count + -bh1.Capacity + -bh1.IndexOf(value) + -bh1.Minimum().Key <= 66)) && ((bh1.Count <= 4 && ((-priority + -index + bh1.Count + bh1.Capacity + -bh1.IndexOf(value) <= 0 && (((!(-priority + -value + -index + bh1.Count + bh1.Capacity + -bh1.IndexOf(value) + bh1.Minimum().Key <= -106))))))))))) ||  ((!(-index + -bh1.Count + bh1.Capacity + -bh1.IndexOf(value) <= 1))))))))) ||  ((!(index == bh1.IndexOf(value))) && ((-value + -index + -bh1.Count + -bh1.Capacity + bh1.IndexOf(value) <= -6))))))))))))))))))))))))))))))) ||  ((!(index <= 0)) && ((-priority + -index + -bh1.IndexOf(value) <= 3 && (((!(index <= 1)) && ((value == bh1.Capacity) ||  ((!(value == bh1.Capacity)) && ((priority == value) ||  ((!(priority == value)) && (((!(-value + -index + -bh1.Count + bh1.Capacity + -bh1.IndexOf(value) <= 0))))))))))) ||  ((!(-priority + -index + -bh1.IndexOf(value) <= 3))))))))))))))))))) );

            bh1.Add(priority, value);
            var ra1 = bh1.RemoveAt(index);

            var ra2 = bh2.RemoveAt(index);
            bh2.Add(priority, value);

            NotpAssume.IsTrue(ra1.Key == ra2.Key && ra1.Value == ra2.Value && eq.Equals(bh1, bh2));
            try{PexAssert.IsTrue(false);}catch {return;}
            PexAssert.IsTrue(ra1.Key == ra2.Key && ra1.Value == ra2.Value && eq.Equals(bh1, bh2));
        }

        [PexMethod]
        public void PUT_CommutativityAddIndexOfComm([PexAssumeUnderTest] BinaryHeap<int, int> bh1, int priority, int value1, int value2)
        {
            //BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = (BinaryHeap<int, int>) bh1.Clone();

            PexAssume.IsTrue(priority > -11 && priority < 11);
            PexAssume.IsTrue(value1 > -11 && value2 < 11);
            PexAssume.IsTrue(value1 > -11 && value2 < 11);

            BinaryHeapEqualityComparer eq = new BinaryHeapEqualityComparer();
            //PexAssume.IsTrue(eq.Equals(bh1, bh2) && !PexAssume.ReferenceEquals(bh1, bh2));

            PexObserve.ValueForViewing("$input_Priority", priority);
            PexObserve.ValueForViewing("$input_Value1", value1);
            PexObserve.ValueForViewing("$input_Value2", value2);
            PexObserve.ValueForViewing("$input_Count", bh1.Count);
            PexObserve.ValueForViewing("$input_Capacity", bh1.Capacity);
            PexObserve.ValueForViewing("$input_IndexOf1", bh1.IndexOf(value1));
            PexObserve.ValueForViewing("$input_IndexOf2", bh1.IndexOf(value2));
            PexObserve.ValueForViewing("$input_MinimumPriority", bh1.Count > 0 ? bh1.Minimum().Key : global);

            AssumePrecondition.IsTrue(!(  ((!(bh1.Capacity <= 0)) && ((bh1.Count <= 0 && ((-value2 + -bh1.Count + bh1.Capacity + -bh1.IndexOf(value1) + -bh1.IndexOf(value2) + bh1.Minimum().Key <= -16))) ||  ((!(bh1.Count <= 0)) && ((-bh1.Count + -bh1.IndexOf(value1) <= -1) ||  ((!(-bh1.Count + -bh1.IndexOf(value1) <= -1)) && (((!(value1 == value2)) && ((-priority + -bh1.Count + -bh1.IndexOf(value1) + bh1.IndexOf(value2) + bh1.Minimum().Key <= -1) ||  ((!(-priority + -bh1.Count + -bh1.IndexOf(value1) + bh1.IndexOf(value2) + bh1.Minimum().Key <= -1)) && ((bh1.IndexOf(value1) == bh1.IndexOf(value2)))))))))))) ));

            int io1 = 0, io2 = 0;

            bh1.Add(priority, value1);
            io1 = bh1.IndexOf(value2);

            io2 = bh2.IndexOf(value2);
            bh2.Add(priority, value1);

            //NotpAssume.IsTrue(io1 == io2 && eq.Equals(bh1, bh2));
            //try{PexAssert.IsTrue(false);}catch { return; }
            PexAssert.IsTrue(io1 == io2 && eq.Equals(bh1, bh2));
        }

        [PexMethod]
        public void PUT_CommutativityAddUpdateComm([PexAssumeUnderTest] BinaryHeap<int, int> bh1, int priority1, int value1, int priority2, int value2)
        {
            //BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = (BinaryHeap<int, int>) bh1.Clone();

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
            PexObserve.ValueForViewing("$input_MinimumPriority", bh1.Count > 0 ? bh1.Minimum().Key : global);

            AssumePrecondition.IsTrue(!( (value1 == bh1.Count) ||  ((!(value1 == bh1.Count)) && ((-priority1 + -value1 + -value2 + bh1.Count + -bh1.IndexOf(value2) + -bh1.Minimum().Key <= -14) ||  ((!(-priority1 + -value1 + -value2 + bh1.Count + -bh1.IndexOf(value2) + -bh1.Minimum().Key <= -14)) && ((priority1 == bh1.Count && (((!(priority1 == value2))))))))) ));

            bh1.Add(priority1, value1);
            bh1.Update(priority2, value2);

            bh2.Update(priority2, value2);
            bh2.Add(priority1, value1);

            //NotpAssume.IsTrue(eq.Equals(bh1, bh2));
            //try{PexAssert.IsTrue(false);}catch { return; }
            PexAssert.IsTrue(eq.Equals(bh1, bh2));
        }

        [PexMethod]
        public void PUT_CommutativityMinimumMinimumComm([PexAssumeUnderTest] BinaryHeap<int, int> bh1)
        {
            //BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = (BinaryHeap<int, int>) bh1.Clone();

            BinaryHeapEqualityComparer eq = new BinaryHeapEqualityComparer();
            //PexAssume.IsTrue(eq.Equals(bh1, bh2) && !PexAssume.ReferenceEquals(bh1, bh2));

            PexObserve.ValueForViewing("$input_Count", bh1.Count);
            PexObserve.ValueForViewing("$input_Capacity", bh1.Capacity);
            PexObserve.ValueForViewing("$input_MinimumPriority", bh1.Count > 0 ? bh1.Minimum().Key : global);

            AssumePrecondition.IsTrue(  ((!(bh1.Count <= 0))) );

            var m11 = bh1.Minimum();
            var m12 = bh1.Minimum();

            var m22 = bh2.Minimum();
            var m21 = bh2.Minimum();

            //NotpAssume.IsTrue(m11.Key == m21.Key && m11.Value == m21.Value && m12.Key == m22.Key && m12.Value == m22.Value && eq.Equals(bh1, bh2));
            //try{PexAssert.IsTrue(false);}catch { return; }
            PexAssert.IsTrue(m11.Key == m21.Key && m11.Value == m21.Value && m12.Key == m22.Key && m12.Value == m22.Value && eq.Equals(bh1, bh2));
        }

        [PexMethod]
        public void PUT_CommutativityMinimumRemoveMinimumComm([PexAssumeUnderTest] BinaryHeap<int, int> bh1)
        {
            //BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = (BinaryHeap<int, int>) bh1.Clone();

            BinaryHeapEqualityComparer eq = new BinaryHeapEqualityComparer();
            //PexAssume.IsTrue(eq.Equals(bh1, bh2) && !PexAssume.ReferenceEquals(bh1, bh2));

            PexObserve.ValueForViewing("$input_Count", bh1.Count);
            PexObserve.ValueForViewing("$input_Capacity", bh1.Capacity);
            PexObserve.ValueForViewing("$input_MinimumPriority", bh1.Count > 0 ? bh1.Minimum().Key : global);

            AssumePrecondition.IsTrue(!(  ((!(bh1.Capacity == bh1.Minimum().Key)) && (((!(bh1.Count <= 1)) && ((bh1.Count == bh1.Minimum().Key) ||  ((!(bh1.Count == bh1.Minimum().Key)) && ((bh1.Count == bh1.Capacity && (((!(-bh1.Count + bh1.Minimum().Key <= 4)) && ((-bh1.Count + -bh1.Capacity + -bh1.Minimum().Key <= -90 && ((-bh1.Count + -bh1.Minimum().Key <= -99 && (((!(-bh1.Count + -bh1.Capacity + bh1.Minimum().Key <= 93))))) ||  ((!(-bh1.Count + -bh1.Minimum().Key <= -99))))) ||  ((!(-bh1.Count + -bh1.Capacity + -bh1.Minimum().Key <= -90)) && (((!(-bh1.Count + -bh1.Capacity + -bh1.Minimum().Key <= -70)) && ((-bh1.Count + bh1.Minimum().Key <= 5) ||  ((!(-bh1.Count + bh1.Minimum().Key <= 5)) && (((!(-bh1.Count + -bh1.Capacity + bh1.Minimum().Key <= 15)) && ((bh1.Count <= 2 && ((-bh1.Count + -bh1.Capacity + bh1.Minimum().Key <= 16) ||  ((!(-bh1.Count + -bh1.Capacity + bh1.Minimum().Key <= 16)) && ((-bh1.Count + -bh1.Capacity + bh1.Minimum().Key <= 60 && ((-bh1.Count + -bh1.Capacity + bh1.Minimum().Key <= 26 && ((-bh1.Count + -bh1.Capacity + bh1.Minimum().Key <= 22 && ((-bh1.Count + -bh1.Capacity + bh1.Minimum().Key <= 19 && (((!(-bh1.Count + -bh1.Capacity + bh1.Minimum().Key <= 18))))))) ||  ((!(-bh1.Count + -bh1.Capacity + bh1.Minimum().Key <= 22))))))) ||  ((!(-bh1.Count + -bh1.Capacity + bh1.Minimum().Key <= 60))))))) ||  ((!(bh1.Count <= 2)) && (((!(bh1.Count + bh1.Capacity + -bh1.Minimum().Key <= -26)) && ((-bh1.Count + -bh1.Capacity + bh1.Minimum().Key <= 19) ||  ((!(-bh1.Count + -bh1.Capacity + bh1.Minimum().Key <= 19)) && (((!(-bh1.Count + -bh1.Capacity + bh1.Minimum().Key <= 21))))))))))))))))))))) ||  ((!(bh1.Count == bh1.Capacity)) && ((bh1.Count <= 4 && ((bh1.Count <= 3 && ((bh1.Count <= 2 && ((-bh1.Count + bh1.Minimum().Key <= 46 && ((-bh1.Count + bh1.Capacity + bh1.Minimum().Key <= 4 && ((-bh1.Count + bh1.Capacity <= 2 && ((-bh1.Count + bh1.Capacity <= 1 && (((!(-bh1.Count + bh1.Capacity + -bh1.Minimum().Key <= 0)) && ((-bh1.Count + -bh1.Capacity + -bh1.Minimum().Key <= 55 && ((-bh1.Count + -bh1.Capacity + -bh1.Minimum().Key <= -2 && (((!(bh1.Minimum().Key <= -1))))) ||  ((!(-bh1.Count + -bh1.Capacity + -bh1.Minimum().Key <= -2))))))))) ||  ((!(-bh1.Count + bh1.Capacity <= 1))))))) ||  ((!(-bh1.Count + bh1.Capacity + bh1.Minimum().Key <= 4))))))) ||  ((!(bh1.Count <= 2)) && ((-bh1.Count + bh1.Capacity <= 3 && (((!(bh1.Minimum().Key <= -1)) && ((-bh1.Count + bh1.Capacity <= 1) ||  ((!(-bh1.Count + bh1.Capacity <= 1)) && (((!(-bh1.Count + bh1.Capacity <= 2))))))))))))))) ||  ((!(bh1.Count <= 4))))))))))) ));

            var m1 = bh1.Minimum();
            var rm1 = bh1.RemoveMinimum();

            var rm2 = bh2.RemoveMinimum();
            var m2 = bh2.Minimum();

            //NotpAssume.IsTrue(m1.Key == m2.Key && m1.Value == m2.Value && rm1.Key == rm2.Key && rm1.Value == rm2.Value && eq.Equals(bh1, bh2));
            //try{PexAssert.IsTrue(false);}catch { return; }
            PexAssert.IsTrue(m1.Key == m2.Key && m1.Value == m2.Value && rm1.Key == rm2.Key && rm1.Value == rm2.Value && eq.Equals(bh1, bh2));
        }

        [PexMethod]
        public void PUT_CommutativityMinimumRemoveAtComm([PexAssumeUnderTest] BinaryHeap<int, int> bh1, int index)
        {
            //BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = (BinaryHeap<int, int>) bh1.Clone();

            BinaryHeapEqualityComparer eq = new BinaryHeapEqualityComparer();
            //PexAssume.IsTrue(eq.Equals(bh1, bh2) && !PexAssume.ReferenceEquals(bh1, bh2));

            PexObserve.ValueForViewing("$input_Index", index);
            PexObserve.ValueForViewing("$input_Count", bh1.Count);
            PexObserve.ValueForViewing("$input_Capacity", bh1.Capacity);
            PexObserve.ValueForViewing("$input_MinimumPriority", bh1.Count > 0 ? bh1.Minimum().Key : global);

            AssumePrecondition.IsTrue(false);

            var m1 = bh1.Minimum();
            var ra1 = bh1.RemoveAt(index);

            var ra2 = bh2.RemoveAt(index);
            var m2 = bh2.Minimum();

            //NotpAssume.IsTrue(m1.Key == m2.Key && m1.Value == m2.Value && ra1.Key == ra2.Key && ra1.Value == ra2.Value && eq.Equals(bh1, bh2));
            //try{PexAssert.IsTrue(false);}catch { return; }
            PexAssert.IsTrue(m1.Key == m2.Key && m1.Value == m2.Value && ra1.Key == ra2.Key && ra1.Value == ra2.Value && eq.Equals(bh1, bh2));
        }

        [PexMethod]
        public void PUT_CommutativityMinimumIndexOfComm([PexAssumeUnderTest] BinaryHeap<int, int> bh1, int value)
        {
            //BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = (BinaryHeap<int, int>) bh1.Clone();

            PexAssume.IsTrue(value > -11 && value < 11);

            BinaryHeapEqualityComparer eq = new BinaryHeapEqualityComparer();
            //PexAssume.IsTrue(eq.Equals(bh1, bh2) && !PexAssume.ReferenceEquals(bh1, bh2));

            PexObserve.ValueForViewing("$input_Value", value);
            PexObserve.ValueForViewing("$input_Count", bh1.Count);
            PexObserve.ValueForViewing("$input_Capacity", bh1.Capacity);
            PexObserve.ValueForViewing("$input_IndexOf", bh1.IndexOf(value));
            PexObserve.ValueForViewing("$input_MinimumPriority", bh1.Count > 0 ? bh1.Minimum().Key : global);

            AssumePrecondition.IsTrue((bh1.Count == bh1.Capacity));

            int io1 = 0, io2 = 0;

            var m1 = bh1.Minimum();
            io1 = bh1.IndexOf(value);

            io2 = bh2.IndexOf(value);
            var m2 = bh2.Minimum();

            //NotpAssume.IsTrue(m1.Key == m2.Key && m1.Value == m2.Value && io1 == io2 && eq.Equals(bh1, bh2));
            //try{PexAssert.IsTrue(false);}catch { return; }
            PexAssert.IsTrue(m1.Key == m2.Key && m1.Value == m2.Value && io1 == io2 && eq.Equals(bh1, bh2));
        }

        [PexMethod]
        public void PUT_CommutativityMinimumUpdateComm([PexAssumeUnderTest] BinaryHeap<int, int> bh1, int priority, int value)
        {
            //BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = (BinaryHeap<int, int>) bh1.Clone();

            PexAssume.IsTrue(priority > -11 && priority < 11);
            PexAssume.IsTrue(value > -11 && value < 11);

            BinaryHeapEqualityComparer eq = new BinaryHeapEqualityComparer();
            //PexAssume.IsTrue(eq.Equals(bh1, bh2) && !PexAssume.ReferenceEquals(bh1, bh2));

            PexObserve.ValueForViewing("$input_Priority", priority);
            PexObserve.ValueForViewing("$input_Value", value);
            PexObserve.ValueForViewing("$input_Count", bh1.Count);
            PexObserve.ValueForViewing("$input_Capacity", bh1.Capacity);
            PexObserve.ValueForViewing("$input_IndexOf", bh1.IndexOf(value));
            PexObserve.ValueForViewing("$input_MinimumPriority", bh1.Count > 0 ? bh1.Minimum().Key : global);

            AssumePrecondition.IsTrue(((!(bh1.IndexOf(value) <= -1)) && ((priority == value))));

            var m1 = bh1.Minimum();
            bh1.Update(priority, value);

            bh2.Update(priority, value);
            var m2 = bh2.Minimum();

            //NotpAssume.IsTrue(m1.Key == m2.Key && m1.Value == m2.Value && eq.Equals(bh1, bh2));
            //try{PexAssert.IsTrue(false);}catch { return; }
            PexAssert.IsTrue(m1.Key == m2.Key && m1.Value == m2.Value && eq.Equals(bh1, bh2));
        }

        [PexMethod]
        public void PUT_CommutativityRemoveMinimumRemoveMinimumComm([PexAssumeUnderTest] BinaryHeap<int, int> bh1)
        {
            //BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = (BinaryHeap<int, int>) bh1.Clone();

            BinaryHeapEqualityComparer eq = new BinaryHeapEqualityComparer();
            //PexAssume.IsTrue(eq.Equals(bh1, bh2) && !PexAssume.ReferenceEquals(bh1, bh2));

            PexObserve.ValueForViewing("$input_Count", bh1.Count);
            PexObserve.ValueForViewing("$input_Capacity", bh1.Capacity);
            PexObserve.ValueForViewing("$input_MinimumPriority", bh1.Count > 0 ? bh1.Minimum().Key : global);

            AssumePrecondition.IsTrue(false);

            var rm11 = bh1.RemoveMinimum();
            var rm12 = bh1.RemoveMinimum();

            var rm22 = bh2.RemoveMinimum();
            var rm21 = bh2.RemoveMinimum();

            //NotpAssume.IsTrue(rm11.Key == rm21.Key && rm11.Value == rm21.Value && rm12.Key == rm22.Key && rm12.Value == rm22.Value && eq.Equals(bh1, bh2));
            //try{PexAssert.IsTrue(false);}catch { return; }
            PexAssert.IsTrue(rm11.Key == rm21.Key && rm11.Value == rm21.Value && rm12.Key == rm22.Key && rm12.Value == rm22.Value && eq.Equals(bh1, bh2));
        }

        [PexMethod]
        public void PUT_CommutativityRemoveMinimumRemoveAtComm([PexAssumeUnderTest] BinaryHeap<int, int> bh1, int index)
        {
            //BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = (BinaryHeap<int, int>) bh1.Clone();

            PexAssume.IsTrue(index > -11 && index < 11);

            BinaryHeapEqualityComparer eq = new BinaryHeapEqualityComparer();
            //PexAssume.IsTrue(eq.Equals(bh1, bh2) && !PexAssume.ReferenceEquals(bh1, bh2));

            PexObserve.ValueForViewing("$input_Index", index);
            PexObserve.ValueForViewing("$input_Count", bh1.Count);
            PexObserve.ValueForViewing("$input_Capacity", bh1.Capacity);
            PexObserve.ValueForViewing("$input_MinimumPriority", bh1.Count > 0 ? bh1.Minimum().Key : global);

            AssumePrecondition.IsTrue(false);

            var rm1 = bh1.RemoveMinimum();
            var ra1 = bh1.RemoveAt(index);

            var ra2 = bh2.RemoveAt(index);
            var rm2 = bh2.RemoveMinimum();

            //NotpAssume.IsTrue(rm1.Key == rm2.Key && rm1.Value == rm2.Value && ra1.Key == ra2.Key && ra1.Value == ra2.Value && eq.Equals(bh1, bh2));
            //try{PexAssert.IsTrue(false);}catch { return; }
            PexAssert.IsTrue(rm1.Key == rm2.Key && rm1.Value == rm2.Value && ra1.Key == ra2.Key && ra1.Value == ra2.Value && eq.Equals(bh1, bh2));
        }

        [PexMethod]
        public void PUT_CommutativityRemoveMinimumIndexOfComm([PexAssumeUnderTest] BinaryHeap<int, int> bh1, int value)
        {
            //BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = (BinaryHeap<int, int>) bh1.Clone();

            PexAssume.IsTrue(value > -11 && value < 11);

            BinaryHeapEqualityComparer eq = new BinaryHeapEqualityComparer();
            //PexAssume.IsTrue(eq.Equals(bh1, bh2) && !PexAssume.ReferenceEquals(bh1, bh2));

            PexObserve.ValueForViewing("$input_Value", value);
            PexObserve.ValueForViewing("$input_Count", bh1.Count);
            PexObserve.ValueForViewing("$input_Capacity", bh1.Capacity);
            PexObserve.ValueForViewing("$input_IndexOf", bh1.IndexOf(value));
            PexObserve.ValueForViewing("$input_MinimumPriority", bh1.Count > 0 ? bh1.Minimum().Key : global);

            AssumePrecondition.IsTrue((-bh1.Count + bh1.Capacity + bh1.IndexOf(value) <= -1));

            int io1 = 0, io2 = 0;

            var rm1 = bh1.RemoveMinimum();
            io1 = bh1.IndexOf(value);

            io2 = bh2.IndexOf(value);
            var rm2 = bh2.RemoveMinimum();

            //NotpAssume.IsTrue(rm1.Key == rm2.Key && rm1.Value == rm2.Value && io1 == io2 && eq.Equals(bh1, bh2));
            //try{PexAssert.IsTrue(false);}catch { return; }
            PexAssert.IsTrue(rm1.Key == rm2.Key && rm1.Value == rm2.Value && io1 == io2 && eq.Equals(bh1, bh2));
        }

        [PexMethod]
        public void PUT_CommutativityRemoveMinimumUpdateComm([PexAssumeUnderTest] BinaryHeap<int, int> bh1, int priority, int value)
        {
            //BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = (BinaryHeap<int, int>) bh1.Clone();

            PexAssume.IsTrue(priority > -11 && priority < 11);
            PexAssume.IsTrue(value > -11 && value < 11);

            BinaryHeapEqualityComparer eq = new BinaryHeapEqualityComparer();
            //PexAssume.IsTrue(eq.Equals(bh1, bh2) && !PexAssume.ReferenceEquals(bh1, bh2));

            PexObserve.ValueForViewing("$input_Priority", priority);
            PexObserve.ValueForViewing("$input_Value", value);
            PexObserve.ValueForViewing("$input_Count", bh1.Count);
            PexObserve.ValueForViewing("$input_Capacity", bh1.Capacity);
            PexObserve.ValueForViewing("$input_IndexOf", bh1.IndexOf(value));
            PexObserve.ValueForViewing("$input_MinimumPriority", bh1.Count > 0 ? bh1.Minimum().Key : global);

            AssumePrecondition.IsTrue(false);

            var rm1 = bh1.RemoveMinimum();
            bh1.Update(priority, value);

            bh2.Update(priority, value);
            var rm2 = bh2.RemoveMinimum();

            //NotpAssume.IsTrue(rm1.Key == rm2.Key && rm1.Value == rm2.Value && eq.Equals(bh1, bh2));
            //try{PexAssert.IsTrue(false);}catch { return; }
            PexAssert.IsTrue(rm1.Key == rm2.Key && rm1.Value == rm2.Value && eq.Equals(bh1, bh2));
        }

        [PexMethod]
        public void PUT_CommutativityRemoveAtRemoveAtComm([PexAssumeUnderTest] BinaryHeap<int, int> bh1, int index1, int index2)
        {
            //BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = (BinaryHeap<int, int>) bh1.Clone();

            PexAssume.IsTrue(index1 > -11 && index1 < 11);
            PexAssume.IsTrue(index2 > -11 && index2 < 11);

            BinaryHeapEqualityComparer eq = new BinaryHeapEqualityComparer();
            //PexAssume.IsTrue(eq.Equals(bh1, bh2) && !PexAssume.ReferenceEquals(bh1, bh2));

            PexObserve.ValueForViewing("$input_Index1", index1);
            PexObserve.ValueForViewing("$input_Index2", index2);
            PexObserve.ValueForViewing("$input_Count", bh1.Count);
            PexObserve.ValueForViewing("$input_Capacity", bh1.Capacity);
            PexObserve.ValueForViewing("$input_MinimumPriority", bh1.Count > 0 ? bh1.Minimum().Key : global);

            AssumePrecondition.IsTrue(false);

            var ra11 = bh1.RemoveAt(index1);
            var ra12 = bh1.RemoveAt(index2);

            var ra22 = bh2.RemoveAt(index2);
            var ra21 = bh2.RemoveAt(index1);

            //NotpAssume.IsTrue(ra11.Key == ra21.Key && ra11.Value == ra21.Value && ra12.Key == ra22.Key && ra12.Value == ra22.Value && eq.Equals(bh1, bh2));
            //try{PexAssert.IsTrue(false);}catch { return; }
            PexAssert.IsTrue(ra11.Key == ra21.Key && ra11.Value == ra21.Value && ra12.Key == ra22.Key && ra12.Value == ra22.Value && eq.Equals(bh1, bh2));
        }

        [PexMethod]
        public void PUT_CommutativityRemoveAtIndexOfComm([PexAssumeUnderTest] BinaryHeap<int, int> bh1, int index, int value)
        {
            //BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = (BinaryHeap<int, int>) bh1.Clone();

            PexAssume.IsTrue(index > -11 && index < 11);
            PexAssume.IsTrue(value > -11 && value < 11);

            BinaryHeapEqualityComparer eq = new BinaryHeapEqualityComparer();
            //PexAssume.IsTrue(eq.Equals(bh1, bh2) && !PexAssume.ReferenceEquals(bh1, bh2));

            PexObserve.ValueForViewing("$input_Index", index);
            PexObserve.ValueForViewing("$input_Value", value);
            PexObserve.ValueForViewing("$input_Count", bh1.Count);
            PexObserve.ValueForViewing("$input_Capacity", bh1.Capacity);
            PexObserve.ValueForViewing("$input_IndexOf", bh1.IndexOf(value));
            PexObserve.ValueForViewing("$input_MinimumPriority", bh1.Count > 0 ? bh1.Minimum().Key : global);

            AssumePrecondition.IsTrue((-bh1.Count + bh1.IndexOf(value) <= -2 && (((!(index == value))))));

            int io1 = 0, io2 = 0;

            var ra1 = bh1.RemoveAt(index);
            io1 = bh1.IndexOf(value);

            io2 = bh2.IndexOf(value);
            var ra2 = bh2.RemoveAt(index);

            //NotpAssume.IsTrue(ra1.Key == ra2.Key && ra1.Value == ra2.Value && io1 == io2 && eq.Equals(bh1, bh2));
            //try{PexAssert.IsTrue(false);}catch { return; }
            PexAssert.IsTrue(ra1.Key == ra2.Key && ra1.Value == ra2.Value && io1 == io2 && eq.Equals(bh1, bh2));
        }

        [PexMethod]
        public void PUT_CommutativityRemoveAtUpdateComm([PexAssumeUnderTest] BinaryHeap<int, int> bh1, int index, int priority, int value)
        {
            //BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = (BinaryHeap<int, int>) bh1.Clone();

            PexAssume.IsTrue(index > -11 && index < 11);
            PexAssume.IsTrue(priority > -11 && priority < 11);
            PexAssume.IsTrue(value > -11 && value < 11);

            BinaryHeapEqualityComparer eq = new BinaryHeapEqualityComparer();
            //PexAssume.IsTrue(eq.Equals(bh1, bh2) && !PexAssume.ReferenceEquals(bh1, bh2));

            PexObserve.ValueForViewing("$input_Index", index);
            PexObserve.ValueForViewing("$input_Priority", priority);
            PexObserve.ValueForViewing("$input_Value", value);
            PexObserve.ValueForViewing("$input_Count", bh1.Count);
            PexObserve.ValueForViewing("$input_Capacity", bh1.Capacity);
            PexObserve.ValueForViewing("$input_IndexOf", bh1.IndexOf(value));
            PexObserve.ValueForViewing("$input_MinimumPriority", bh1.Count > 0 ? bh1.Minimum().Key : global);

            AssumePrecondition.IsTrue(false);

            var ra1 = bh1.RemoveAt(index);
            bh1.Update(priority, value);

            bh2.Update(priority, value);
            var ra2 = bh2.RemoveAt(index);

            //NotpAssume.IsTrue(ra1.Key == ra2.Key && ra1.Value == ra2.Value && eq.Equals(bh1, bh2));
            //try{PexAssert.IsTrue(false);}catch { return; }
            PexAssert.IsTrue(ra1.Key == ra2.Key && ra1.Value == ra2.Value && eq.Equals(bh1, bh2));
        }

        [PexMethod]
        public void PUT_CommutativityIndexOfIndexOfComm([PexAssumeUnderTest] BinaryHeap<int, int> bh1, int value1, int value2)
        {
            //BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = (BinaryHeap<int, int>) bh1.Clone();

            PexAssume.IsTrue(value1 > -11 && value2 < 11);
            PexAssume.IsTrue(value1 > -11 && value2 < 11);

            BinaryHeapEqualityComparer eq = new BinaryHeapEqualityComparer();
            //PexAssume.IsTrue(eq.Equals(bh1, bh2) && !PexAssume.ReferenceEquals(bh1, bh2));

            PexObserve.ValueForViewing("$input_Value1", value1);
            PexObserve.ValueForViewing("$input_Value2", value2);
            PexObserve.ValueForViewing("$input_Count", bh1.Count);
            PexObserve.ValueForViewing("$input_Capacity", bh1.Capacity);
            PexObserve.ValueForViewing("$input_IndexOf1", bh1.IndexOf(value1));
            PexObserve.ValueForViewing("$input_IndexOf2", bh1.IndexOf(value2));
            PexObserve.ValueForViewing("$input_MinimumPriority", bh1.Count > 0 ? bh1.Minimum().Key : global);

            AssumePrecondition.IsTrue(true);

            int io11 = 0, io12 = 0;
            int io21 = 0, io22 = 0;

            io11 = bh1.IndexOf(value1);
            io12 = bh1.IndexOf(value2);

            io22 = bh2.IndexOf(value2);
            io21 = bh2.IndexOf(value1);

            //NotpAssume.IsTrue(io11 == io21 && io12 == io22 && eq.Equals(bh1, bh2));
            //try{PexAssert.IsTrue(false);}catch { return; }
            PexAssert.IsTrue(io11 == io21 && io12 == io22 && eq.Equals(bh1, bh2));
        }

        [PexMethod]
        public void PUT_CommutativityIndexOfUpdateComm([PexAssumeUnderTest] BinaryHeap<int, int> bh1, int value1, int priority, int value2)
        {
            //BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = (BinaryHeap<int, int>) bh1.Clone();

            PexAssume.IsTrue(priority > -11 && priority < 11);
            PexAssume.IsTrue(value1 > -11 && value2 < 11);
            PexAssume.IsTrue(value1 > -11 && value2 < 11);

            BinaryHeapEqualityComparer eq = new BinaryHeapEqualityComparer();
            //PexAssume.IsTrue(eq.Equals(bh1, bh2) && !PexAssume.ReferenceEquals(bh1, bh2));

            PexObserve.ValueForViewing("$input_Value1", value1);
            PexObserve.ValueForViewing("$input_Priority", priority);
            PexObserve.ValueForViewing("$input_Value2", value2);
            PexObserve.ValueForViewing("$input_Count", bh1.Count);
            PexObserve.ValueForViewing("$input_Capacity", bh1.Capacity);
            PexObserve.ValueForViewing("$input_IndexOf1", bh1.IndexOf(value1));
            PexObserve.ValueForViewing("$input_IndexOf2", bh1.IndexOf(value2));
            PexObserve.ValueForViewing("$input_MinimumPriority", bh1.Count > 0 ? bh1.Minimum().Key : global);

            AssumePrecondition.IsTrue((bh1.Count == bh1.Capacity));

            int io1 = 0, io2 = 0;

            io1 = bh1.IndexOf(value1);
            bh1.Update(priority, value2);

            bh2.Update(priority, value2);
            io2 = bh2.IndexOf(value1);

            //NotpAssume.IsTrue(io1 == io2 && eq.Equals(bh1, bh2));
            //try{PexAssert.IsTrue(false);}catch { return; }
            PexAssert.IsTrue(io1 == io2 && eq.Equals(bh1, bh2));
        }

        [PexMethod]
        public void PUT_CommutativityUpdateUpdateComm([PexAssumeUnderTest] BinaryHeap<int, int> bh1, int priority1, int value1, int priority2, int value2)
        {
            //BinaryHeap<int, int> bh1 = bhTuple.Item1;
            BinaryHeap<int, int> bh2 = (BinaryHeap<int, int>) bh1.Clone();

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
            PexObserve.ValueForViewing("$input_MinimumPriority", bh1.Count > 0 ? bh1.Minimum().Key : global);

            AssumePrecondition.IsTrue(false);

            bh1.Update(priority1, value1);
            bh1.Update(priority2, value2);

            bh2.Update(priority2, value2);
            bh2.Update(priority1, value1);

            //NotpAssume.IsTrue(eq.Equals(bh1, bh2));
            //try{PexAssert.IsTrue(false);}catch { return; }
            PexAssert.IsTrue(eq.Equals(bh1, bh2));
        }
    }
}
