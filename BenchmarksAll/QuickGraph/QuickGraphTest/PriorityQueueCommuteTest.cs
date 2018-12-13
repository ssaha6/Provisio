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
    [PexClass(typeof(QuickGraph.PriorityQueue<int, int>))]
    [TestClass]
    public partial class PriorityQueueCommuteTest
    {
        /*[PexMethod(MaxConstraintSolverTime = 50, Timeout = 240)] 
        public void TestCloneCompare([PexAssumeUnderTest] QuickGraph.PriorityQueue<int, int> pq1)
        {
            PriorityQueue<int, int> pq2 = (PriorityQueue<int, int>)pq1.Clone();
            PriorityQueueEqualityComparer eq1 = new PriorityQueueEqualityComparer();
            BinaryHeapEqualityComparer eq2 = new BinaryHeapEqualityComparer();

            PexObserve.ValueForViewing("$input_Count1", pq1.Count);
            PexObserve.ValueForViewing("$input_Count2", pq2.Count);
            PexObserve.ValueForViewing("$input_DictionaryCompare", pq1.ToStringForInts().Equals(pq2.ToStringForInts()));
            PexObserve.ValueForViewing("$input_HeapCompare", eq2.Equals(pq1.Heap, pq2.Heap));

            PexAssert.IsTrue(eq1.Equals(pq1, pq2));
        }*/

        [PexMethod]
        public void PUT_CommutativityUpdateUpdateComm([PexAssumeUnderTest] QuickGraph.PriorityQueue<int, int> pq1, int value1, int value2)
        {
            PexAssume.IsTrue(value1 > -11 && value1 < 11 && value2 > -11 && value2 < 11);
            PriorityQueue<int, int> pq2 = (PriorityQueue<int, int>)pq1.Clone();
            PriorityQueueEqualityComparer eq = new PriorityQueueEqualityComparer();

            PexObserve.ValueForViewing("$input_Count", pq1.Count);
            PexObserve.ValueForViewing("$input_Value1", value1);
            PexObserve.ValueForViewing("$input_Value2", value2);
            PexObserve.ValueForViewing("$input_ContainsValue1", pq1.Contains(value1));
            PexObserve.ValueForViewing("$input_ContainsValue2", pq1.Contains(value2));

            AssumePrecondition.IsTrue( (pq1.Contains(value2) && ((pq1.Contains(value1))))  );

            pq1.Update(value1);
            pq1.Update(value2);

            pq2.Update(value2);
            pq2.Update(value1);

            NotpAssume.IsTrue(eq.Equals(pq1, pq2));
            PexAssert.IsTrue(eq.Equals(pq1, pq2));
        }

        [PexMethod]
        public void PUT_CommutativityUpdateCountComm([PexAssumeUnderTest] QuickGraph.PriorityQueue<int, int> pq1, int value)
        {
            PexAssume.IsTrue(value > -11 && value < 11);
            PriorityQueue<int, int> pq2 = (PriorityQueue<int, int>)pq1.Clone();
            PriorityQueueEqualityComparer eq = new PriorityQueueEqualityComparer();

            PexObserve.ValueForViewing("$input_Count", pq1.Count);
            PexObserve.ValueForViewing("$input_Value", value);
            PexObserve.ValueForViewing("$input_ContainsValue", pq1.Contains(value));
            

            AssumePrecondition.IsTrue(true);

            int c1 = 0, c2 = 0;

            pq1.Update(value);
            c1 = pq1.Count;

            c2 = pq2.Count;
            pq2.Update(value);

            //NotpAssume.IsTrue(c1 == c2 && eq.Equals(pq1, pq2));
            PexAssert.IsTrue(c1 == c2 && eq.Equals(pq1, pq2));
        }

        [PexMethod]
        public void PUT_CommutativityUpdateContainsComm([PexAssumeUnderTest] QuickGraph.PriorityQueue<int, int> pq1, int value1, int value2)
        {
            PexAssume.IsTrue(value1 > -11 && value1 < 11 && value2 > -11 && value2 < 11);
            PriorityQueue<int, int> pq2 = (PriorityQueue<int, int>)pq1.Clone();
            PriorityQueueEqualityComparer eq = new PriorityQueueEqualityComparer();

            PexObserve.ValueForViewing("$input_Count", pq1.Count);
            PexObserve.ValueForViewing("$input_Value1", value1);
            PexObserve.ValueForViewing("$input_Value2", value2);
            PexObserve.ValueForViewing("$input_ContainsValue1", pq1.Contains(value1));
            PexObserve.ValueForViewing("$input_ContainsValue2", pq1.Contains(value2));
            

            AssumePrecondition.IsTrue( (pq1.Contains(value1))  );

            bool c1 = true, c2 = true;

            pq1.Update(value1);
            c1 = pq1.Contains(value2);

            c2 = pq2.Contains(value2);
            pq2.Update(value1);

            NotpAssume.IsTrue(c1 == c2 && eq.Equals(pq1, pq2));
            PexAssert.IsTrue(c1 == c2 && eq.Equals(pq1, pq2));
        }

        [PexMethod]
        public void PUT_CommutativityUpdateEnqueueComm([PexAssumeUnderTest] QuickGraph.PriorityQueue<int, int> pq1, int value1, int value2)
        {
            PexAssume.IsTrue(value1 > -11 && value1 < 11 && value2 > -11 && value2 < 11);
            PriorityQueue<int, int> pq2 = (PriorityQueue<int, int>)pq1.Clone();
            PriorityQueueEqualityComparer eq = new PriorityQueueEqualityComparer();

            PexObserve.ValueForViewing("$input_Count", pq1.Count);
            PexObserve.ValueForViewing("$input_Value1", value1);
            PexObserve.ValueForViewing("$input_Value2", value2);
            PexObserve.ValueForViewing("$input_ContainsValue1", pq1.Contains(value1));
            PexObserve.ValueForViewing("$input_ContainsValue2", pq1.Contains(value2));
            

            AssumePrecondition.IsTrue( (pq1.Contains(value2))  );

            pq1.Update(value1);
            pq1.Enqueue(value2);

            pq2.Enqueue(value2);
            pq2.Update(value1);

            NotpAssume.IsTrue(eq.Equals(pq1, pq2));
            PexAssert.IsTrue(eq.Equals(pq1, pq2));
        }

        [PexMethod]
        public void PUT_CommutativityUpdateDequeueComm([PexAssumeUnderTest] QuickGraph.PriorityQueue<int, int> pq1, int value)
        {
            PexAssume.IsTrue(value > -11 && value < 11);
            PriorityQueue<int, int> pq2 = (PriorityQueue<int, int>)pq1.Clone();
            PriorityQueueEqualityComparer eq = new PriorityQueueEqualityComparer();

            PexObserve.ValueForViewing("$input_Count", pq1.Count);
            PexObserve.ValueForViewing("$input_Value", value);
            PexObserve.ValueForViewing("$input_ContainsValue", pq1.Contains(value));
            

            AssumePrecondition.IsTrue( (pq1.Contains(value) && (((!(pq1.Count == value)) && ((-pq1.Count + -value <= 0)))))  );

            int d1 = 0, d2 = 0;

            pq1.Update(value);
            d1 = pq1.Dequeue();

            d2 = pq2.Dequeue();
            pq2.Update(value);

            NotpAssume.IsTrue(d1 == d2 && eq.Equals(pq1, pq2));
            PexAssert.IsTrue(d1 == d2 && eq.Equals(pq1, pq2));
        }

        [PexMethod]
        public void PUT_CommutativityUpdatePeekComm([PexAssumeUnderTest] QuickGraph.PriorityQueue<int, int> pq1, int value)
        {
            PexAssume.IsTrue(value > -11 && value < 11);
            PriorityQueue<int, int> pq2 = (PriorityQueue<int, int>)pq1.Clone();
            PriorityQueueEqualityComparer eq = new PriorityQueueEqualityComparer();

            PexObserve.ValueForViewing("$input_Count", pq1.Count);
            PexObserve.ValueForViewing("$input_Value", value);
            PexObserve.ValueForViewing("$input_ContainsValue", pq1.Contains(value));
            

            AssumePrecondition.IsTrue( (pq1.Contains(value))  );

            int p1 = 0, p2 = 0;

            pq1.Update(value);
            p1 = pq1.Peek();

            p2 = pq2.Peek();
            pq2.Update(value);

            NotpAssume.IsTrue(p1 == p2 && eq.Equals(pq1, pq2));
            PexAssert.IsTrue(p1 == p2 && eq.Equals(pq1, pq2));
        }

        [PexMethod]
        public void PUT_CommutativityCountCountComm([PexAssumeUnderTest]Tuple<PriorityQueue<int, int>, PriorityQueue<int, int>> pqTuple)
        {
            // PriorityQueue<int, int> pq2 = (PriorityQueue<int, int>)pq1.Clone();
            var pq1 = pqTuple.Item1;
            var pq2 = pqTuple.Item2;

            PriorityQueueEqualityComparer eq = new PriorityQueueEqualityComparer();

            PexObserve.ValueForViewing("$input_Count", pq1.Count);

            AssumePrecondition.IsTrue(true);

            int c11 = 0, c12 = 0;
            int c21 = 0, c22 = 0;

            c11 = pq1.Count;
            c12 = pq1.Count;

            c22 = pq2.Count;
            c21 = pq2.Count;

            PexObserve.ValueForViewing("$input_Count", c11);
            PexObserve.ValueForViewing("$input_Count", c21);
            PexObserve.ValueForViewing("$input_Count", c12);
            PexObserve.ValueForViewing("$input_Count", c22);
            PexObserve.ValueForViewing("$input_Count", pq1.ToStringForInts());
            PexObserve.ValueForViewing("$input_Count", pq2.ToStringForInts());

            //NotpAssume.IsTrue(c11 == c21 && c12 == c22 && eq.Equals(pq1, pq2));
            PexAssert.IsTrue(c11 == c21 && c12 == c22 && eq.Equals(pq1, pq2));
        }

        [PexMethod]
        public void PUT_CommutativityCountContainsComm([PexAssumeUnderTest] QuickGraph.PriorityQueue<int, int> pq1, int value)
        {
            PexAssume.IsTrue(value > -11 && value < 11);
            PriorityQueue<int, int> pq2 = (PriorityQueue<int, int>)pq1.Clone();
            PriorityQueueEqualityComparer eq = new PriorityQueueEqualityComparer();

            PexObserve.ValueForViewing("$input_Count", pq1.Count);
            PexObserve.ValueForViewing("$input_Value", value);
            PexObserve.ValueForViewing("$input_ContainsValue", pq1.Contains(value));
            

            AssumePrecondition.IsTrue(!(  ((!(pq1.Peek() <= -2147484000.0)) && ((pq1.Count == value) ||  ((!(pq1.Count == value)) && ((pq1.Count == pq1.Peek()) ||  ((!(pq1.Count == pq1.Peek())) && ((pq1.Count <= 1) ||  ((!(pq1.Count <= 1)) && ((pq1.Contains(value) && ((pq1.Count <= 2 && ((value <= 0 && (((!(-pq1.Count + -value <= 0))))) ||  ((!(value <= 0))))) ||  ((!(pq1.Count <= 2)) && (((!(pq1.Count <= 3))))))) ||  ((!(pq1.Contains(value))) && ((pq1.Count <= 2 && ((-pq1.Count + value <= 1))) ||  ((!(pq1.Count <= 2))))))))))))) ));

            int c11 = 0, c12 = 0;
            bool c21 = true, c22 = true;

            c11 = pq1.Count;
            c21 = pq1.Contains(value);

            c22 = pq2.Contains(value);
            c12 = pq2.Count;

            NotpAssume.IsTrue(c11 == c12 && c21 == c22 && eq.Equals(pq1, pq2));
            PexAssert.IsTrue(c11 == c12 && c21 == c22 && eq.Equals(pq1, pq2));
        }

        [PexMethod]
        public void PUT_CommutativityCountEnqueueComm([PexAssumeUnderTest] QuickGraph.PriorityQueue<int, int> pq1, int value)
        {
            PexAssume.IsTrue(value > -11 && value < 11);
            PriorityQueue<int, int> pq2 = (PriorityQueue<int, int>)pq1.Clone();
            PriorityQueueEqualityComparer eq = new PriorityQueueEqualityComparer();

            PexObserve.ValueForViewing("$input_Count", pq1.Count);
            PexObserve.ValueForViewing("$input_Value", value);
            PexObserve.ValueForViewing("$input_ContainsValue", pq1.Contains(value));
            

            AssumePrecondition.IsTrue(true);

            int c1 = 0, c2 = 0;

            c1 = pq1.Count;
            pq1.Enqueue(value);

            pq2.Enqueue(value);
            c2 = pq2.Count;

            //NotpAssume.IsTrue(c1 == c2 && eq.Equals(pq1, pq2));
            PexAssert.IsTrue(c1 == c2 && eq.Equals(pq1, pq2));
        }

        [PexMethod]
        public void PUT_CommutativityCountDequeueComm([PexAssumeUnderTest] QuickGraph.PriorityQueue<int, int> pq1)
        {
            PriorityQueue<int, int> pq2 = (PriorityQueue<int, int>)pq1.Clone();
            PriorityQueueEqualityComparer eq = new PriorityQueueEqualityComparer();
            PexObserve.ValueForViewing("$input_Count", pq1.Count);
            

            AssumePrecondition.IsTrue(true);

            int c1 = 0, c2 = 0;
            int d1 = 0, d2 = 0;

            c1 = pq1.Count;
            d1 = pq1.Dequeue();

            d2 = pq2.Dequeue();
            c2 = pq2.Count;

            //NotpAssume.IsTrue(c1 == c2 && d1 == d2 && eq.Equals(pq1, pq2));
            PexAssert.IsTrue(c1 == c2 && d1 == d2 && eq.Equals(pq1, pq2));
        }

        [PexMethod]
        public void PUT_CommutativityCountPeekComm([PexAssumeUnderTest] QuickGraph.PriorityQueue<int, int> pq1)
        {
            PriorityQueue<int, int> pq2 = (PriorityQueue<int, int>)pq1.Clone();
            PriorityQueueEqualityComparer eq = new PriorityQueueEqualityComparer();

            PexObserve.ValueForViewing("$input_Count", pq1.Count);
            

            AssumePrecondition.IsTrue(true);

            int c1 = 0, c2 = 0;
            int p1 = 0, p2 = 0;

            c1 = pq1.Count;
            p1 = pq1.Peek();

            p2 = pq2.Peek();
            c2 = pq2.Count;

            //NotpAssume.IsTrue(c1 == c2 && p1 == p2 && eq.Equals(pq1, pq2));
            PexAssert.IsTrue(c1 == c2 && p1 == p2 && eq.Equals(pq1, pq2));
        }

        [PexMethod]
        public void PUT_CommutativityContainsContainsComm([PexAssumeUnderTest] QuickGraph.PriorityQueue<int, int> pq1, int value1, int value2)
        {
            PexAssume.IsTrue(value1 > -11 && value1 < 11 && value2 > -11 && value2 < 11);
            PriorityQueue<int, int> pq2 = (PriorityQueue<int, int>)pq1.Clone();
            PriorityQueueEqualityComparer eq = new PriorityQueueEqualityComparer();

            PexObserve.ValueForViewing("$input_Count", pq1.Count);
            PexObserve.ValueForViewing("$input_Value1", value1);
            PexObserve.ValueForViewing("$input_Value2", value2);
            PexObserve.ValueForViewing("$input_ContainsValue1", pq1.Contains(value1));
            PexObserve.ValueForViewing("$input_ContainsValue2", pq1.Contains(value2));
            

            AssumePrecondition.IsTrue(true);

            bool c11 = true, c12 = true;
            bool c21 = true, c22 = true;

            c11 = pq1.Contains(value1);
            c12 = pq1.Contains(value2);

            c22 = pq2.Contains(value2);
            c21 = pq2.Contains(value1);

            //NotpAssume.IsTrue(c11 == c21 && c12 == c22 && eq.Equals(pq1, pq2));
            PexAssert.IsTrue(c11 == c21 && c12 == c22 && eq.Equals(pq1, pq2));
        }

        [PexMethod]
        public void PUT_CommutativityContainsEnqueueComm([PexAssumeUnderTest] QuickGraph.PriorityQueue<int, int> pq1, int value1, int value2)
        {
            PexAssume.IsTrue(value1 > -11 && value1 < 11 && value2 > -11 && value2 < 11);
            PriorityQueue<int, int> pq2 = (PriorityQueue<int, int>)pq1.Clone();
            PriorityQueueEqualityComparer eq = new PriorityQueueEqualityComparer();

            PexObserve.ValueForViewing("$input_Count", pq1.Count);
            PexObserve.ValueForViewing("$input_Value1", value1);
            PexObserve.ValueForViewing("$input_Value2", value2);
            PexObserve.ValueForViewing("$input_ContainsValue1", pq1.Contains(value1));
            PexObserve.ValueForViewing("$input_ContainsValue2", pq1.Contains(value2));
            

            AssumePrecondition.IsTrue(true);

            bool c1 = true, c2 = true;

            c1 = pq1.Contains(value1);
            pq1.Enqueue(value2);

            pq2.Enqueue(value2);
            c2 = pq2.Contains(value1);

            //NotpAssume.IsTrue(c1 == c2 && eq.Equals(pq1, pq2));
            PexAssert.IsTrue(c1 == c2 && eq.Equals(pq1, pq2));
        }

        [PexMethod]
        public void PUT_CommutativityContainsDequeueComm([PexAssumeUnderTest] QuickGraph.PriorityQueue<int, int> pq1, int value)
        {
            PexAssume.IsTrue(value > -11 && value < 11);
            PriorityQueue<int, int> pq2 = (PriorityQueue<int, int>)pq1.Clone();
            PriorityQueueEqualityComparer eq = new PriorityQueueEqualityComparer();

            PexObserve.ValueForViewing("$input_Count", pq1.Count);
            PexObserve.ValueForViewing("$input_Value", value);
            PexObserve.ValueForViewing("$input_ContainsValue", pq1.Contains(value));
            

            AssumePrecondition.IsTrue(true);

            bool c1 = true, c2 = true;
            int d1 = 0, d2 = 0;

            c1 = pq1.Contains(value);
            d1 = pq1.Dequeue();

            d2 = pq2.Dequeue();
            c2 = pq2.Contains(value);

            //NotpAssume.IsTrue(c1 == c2 && d1 == d2 && eq.Equals(pq1, pq2));
            PexAssert.IsTrue(c1 == c2 && d1 == d2 && eq.Equals(pq1, pq2));
        }

        [PexMethod]
        public void PUT_CommutativityContainsPeekComm([PexAssumeUnderTest] QuickGraph.PriorityQueue<int, int> pq1, int value)
        {
            PexAssume.IsTrue(value > -11 && value < 11);
            PriorityQueue<int, int> pq2 = (PriorityQueue<int, int>)pq1.Clone();
            PriorityQueueEqualityComparer eq = new PriorityQueueEqualityComparer();

            PexObserve.ValueForViewing("$input_Count", pq1.Count);
            PexObserve.ValueForViewing("$input_Value", value);
            PexObserve.ValueForViewing("$input_ContainsValue", pq1.Contains(value));
            

            AssumePrecondition.IsTrue(true);

            bool c1 = true, c2 = true;
            int p1 = 0, p2 = 0;

            c1 = pq1.Contains(value);
            p1 = pq1.Peek();

            p2 = pq2.Peek();
            c2 = pq2.Contains(value);

            //NotpAssume.IsTrue(c1 == c2 && p1 == p2 && eq.Equals(pq1, pq2));
            PexAssert.IsTrue(c1 == c2 && p1 == p2 && eq.Equals(pq1, pq2));
        }

        [PexMethod]
        public void PUT_CommutativityEnqueueEnqueueComm([PexAssumeUnderTest] QuickGraph.PriorityQueue<int, int> pq1, int value1, int value2)
        {
            PexAssume.IsTrue(value1 > -11 && value1 < 11 && value2 > -11 && value2 < 11);
            PriorityQueue<int, int> pq2 = (PriorityQueue<int, int>)pq1.Clone();
            PriorityQueueEqualityComparer eq = new PriorityQueueEqualityComparer();

            PexObserve.ValueForViewing("$input_Count", pq1.Count);
            PexObserve.ValueForViewing("$input_Value1", value1);
            PexObserve.ValueForViewing("$input_Value2", value2);
            PexObserve.ValueForViewing("$input_ContainsValue1", pq1.Contains(value1));
            PexObserve.ValueForViewing("$input_ContainsValue2", pq1.Contains(value2));
            

            AssumePrecondition.IsTrue(true);

            pq1.Enqueue(value1);
            pq1.Enqueue(value2);

            pq2.Enqueue(value2);
            pq2.Enqueue(value1);

            //NotpAssume.IsTrue(eq.Equals(pq1, pq2));
            PexAssert.IsTrue(eq.Equals(pq1, pq2));
        }

        [PexMethod]
        public void PUT_CommutativityEnqueueDequeueComm([PexAssumeUnderTest] QuickGraph.PriorityQueue<int, int> pq1, int value)
        {
            PexAssume.IsTrue(value > -11 && value < 11);
            PriorityQueue<int, int> pq2 = (PriorityQueue<int, int>)pq1.Clone();
            PriorityQueueEqualityComparer eq = new PriorityQueueEqualityComparer();

            PexObserve.ValueForViewing("$input_Count", pq1.Count);
            PexObserve.ValueForViewing("$input_Value", value);
            PexObserve.ValueForViewing("$input_ContainsValue", pq1.Contains(value));
            

            AssumePrecondition.IsTrue(true);

            int d1 = 0, d2 = 0;

            pq1.Enqueue(value);
            d1 = pq1.Dequeue();

            d2 = pq2.Dequeue();
            pq2.Enqueue(value);

            //NotpAssume.IsTrue(d1 == d2 && eq.Equals(pq1, pq2));
            PexAssert.IsTrue(d1 == d2 && eq.Equals(pq1, pq2));
        }

        [PexMethod]
        public void PUT_CommutativityEnqueuePeekComm([PexAssumeUnderTest] QuickGraph.PriorityQueue<int, int> pq1, int value)
        {
            PexAssume.IsTrue(value > -11 && value < 11);
            PriorityQueue<int, int> pq2 = (PriorityQueue<int, int>)pq1.Clone();
            PriorityQueueEqualityComparer eq = new PriorityQueueEqualityComparer();

            PexObserve.ValueForViewing("$input_Count", pq1.Count);
            PexObserve.ValueForViewing("$input_Value", value); 
            PexObserve.ValueForViewing("$input_ContainsValue", pq1.Contains(value));
            

            AssumePrecondition.IsTrue(true);

            int p1 = 0, p2 = 0;

            pq1.Enqueue(value);
            p1 = pq1.Peek();

            p2 = pq2.Peek();
            pq2.Enqueue(value);

            //NotpAssume.IsTrue(p1 == p2 && eq.Equals(pq1, pq2));
            PexAssert.IsTrue(p1 == p2 && eq.Equals(pq1, pq2));
        }

        [PexMethod]
        public void PUT_CommutativityDequeueDequeueComm([PexAssumeUnderTest] QuickGraph.PriorityQueue<int, int> pq1)
        {
            PriorityQueue<int, int> pq2 = (PriorityQueue<int, int>)pq1.Clone();
            PriorityQueueEqualityComparer eq = new PriorityQueueEqualityComparer();

            PexObserve.ValueForViewing("$input_Count", pq1.Count);
            

            AssumePrecondition.IsTrue(true);

            int d11 = 0, d12 = 0;
            int d21 = 0, d22 = 0;

            d11 = pq1.Dequeue();
            d12 = pq1.Dequeue();

            d22 = pq2.Dequeue();
            d21 = pq2.Dequeue();

            //NotpAssume.IsTrue(d11 == d21 && d12 == d22 && eq.Equals(pq1, pq2));
            PexAssert.IsTrue(d11 == d21 && d12 == d22 && eq.Equals(pq1, pq2));
        }

        [PexMethod]
        public void PUT_CommutativityDequeuePeekComm([PexAssumeUnderTest] QuickGraph.PriorityQueue<int, int> pq1)
        {
            PriorityQueue<int, int> pq2 = (PriorityQueue<int, int>)pq1.Clone();
            PriorityQueueEqualityComparer eq = new PriorityQueueEqualityComparer();

            PexObserve.ValueForViewing("$input_Count", pq1.Count);
            

            AssumePrecondition.IsTrue(true);

            int d1 = 0, d2 = 0;
            int p1 = 0, p2 = 0;

            d1 = pq1.Dequeue();
            p1 = pq1.Peek();

            p2 = pq2.Peek();
            d2 = pq2.Dequeue();

            //NotpAssume.IsTrue(d1 == d2 && p1 == p2 && eq.Equals(pq1, pq2));
            PexAssert.IsTrue(d1 == d2 && p1 == p2 && eq.Equals(pq1, pq2));
        }

        [PexMethod]
        public void PUT_CommutativityPeekPeekComm([PexAssumeUnderTest] QuickGraph.PriorityQueue<int, int> pq1)
        {
            PriorityQueue<int, int> pq2 = (PriorityQueue<int, int>)pq1.Clone();
            PriorityQueueEqualityComparer eq = new PriorityQueueEqualityComparer();

            PexObserve.ValueForViewing("$input_Count", pq1.Count);
            

            AssumePrecondition.IsTrue(true);

            int p11 = 0, p12 = 0;
            int p21 = 0, p22 = 0;

            p11 = pq1.Peek();
            p12 = pq1.Peek();

            p22 = pq2.Peek();
            p21 = pq2.Peek();

            //NotpAssume.IsTrue(p11 == p21 && p12 == p22 && eq.Equals(pq1, pq2));
            PexAssert.IsTrue(p11 == p21 && p12 == p22 && eq.Equals(pq1, pq2));
        }
    }
}
