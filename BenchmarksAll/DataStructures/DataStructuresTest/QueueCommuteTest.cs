using System;
using System.Text;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures;
using DataStructures.Utility;
using PexAPIWrapper;
using Microsoft.Pex.Framework.Exceptions;

namespace DataStructures.Comm.Test
{
    [PexClass(typeof(DataStructures.Queue<int>))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class QueueCommuteTest
    {
        public int global = -7;
        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityPeekPeekComm([PexAssumeUnderTest]DataStructures.Queue<int> s1)
        {
            /* Peek throws exception when stack is empty*/

            DataStructures.Queue<int> s2 = new DataStructures.Queue<int>(s1);
            QueueEqualityComparer eq = new QueueEqualityComparer();
            int dummy = -1;
            PexObserve.ValueForViewing("$input_q1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_s1.Peek", s1.TryPeek(out dummy) ? s1.Peek() : global--);

            //try
            //{
                AssumePrecondition.IsTrue(((s1.Count >= 1)));
            //}
            //catch (InvalidOperationException)
            //{
            //    throw new PexAssumeFailedException();
            //}
            
            bool first = false;
            bool second = false;
            int p1 = -1, p2 = -1;
            int pp1 = -1, pp2 = -1;

            // First test 
            p1 = s1.Peek();
            pp1 = s1.Peek();


            // Second test 
            pp2 = s2.Peek();
            p2 = s2.Peek();

            //NotpAssume.IsTrue( p1 == p2 && pp1 == pp2 && eq.Equals(s1, s2));
            PexAssert.IsTrue( p1 == p2 && pp1 == pp2 && eq.Equals(s1, s2));
        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityPeekDequeueComm([PexAssumeUnderTest]DataStructures.Queue<int> s1)
        {
            /* Pop throws exception when stack is empty*/

            DataStructures.Queue<int> s2 = new DataStructures.Queue<int>(s1);
            QueueEqualityComparer eq = new QueueEqualityComparer();
            int dummy = -1;
            PexObserve.ValueForViewing("$input_q1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_q1.Peek", s1.TryPeek(out dummy) ? s1.Peek() : -12);
            try
            {
                AssumePrecondition.IsTrue(  false);
            }
            catch (InvalidOperationException)
            {
                throw new PexAssumeFailedException();
            }
            


            bool first = false;
            bool second = false;
            int p1 = -1, p2 = -1;
            int pp1 = -1, pp2 = -1;

                // First test 
                p1 = s1.Peek();
                pp1 = s1.Dequeue();
            

                // Second test 
                pp2 = s2.Dequeue();
                p2 = s2.Peek();


            NotpAssume.IsTrue( p1 == p2 && pp1 == pp2 && eq.Equals(s1, s2));
            PexAssert.IsTrue( p1 == p2 && pp1 == pp2 && eq.Equals(s1, s2));
        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityDequeueDequeueComm([PexAssumeUnderTest]DataStructures.Queue<int> s1)
        {
            /* Pop throws exception when stack is empty*/

            DataStructures.Queue<int> s2 = new DataStructures.Queue<int>(s1);
            QueueEqualityComparer eq = new QueueEqualityComparer();
            int dummy = -1;
            PexObserve.ValueForViewing("$input_q1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_q1.Peek", s1.TryPeek(out dummy) ? s1.Peek() : -12);
                        
            AssumePrecondition.IsTrue(  false);

            bool first = false;
            bool second = false;
            int p1 = -1, p2 = -1;
            int pp1 = -1, pp2 = -1;

            // First test 
                p1 = s1.Dequeue();
                pp1 = s1.Dequeue();

            // Second test 
                pp2 = s2.Dequeue();
                p2 = s2.Dequeue();
            NotpAssume.IsTrue( p1 == p2 && pp1 == pp2 && eq.Equals(s1, s2));
            PexAssert.IsTrue(p1 == p2 && pp1 == pp2 && eq.Equals(s1, s2));
        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityEnqueuePeekComm([PexAssumeUnderTest]DataStructures.Queue<int> s1, int x)
        {
            QueueEqualityComparer eq = new QueueEqualityComparer();
            DataStructures.Queue<int> s2 = new DataStructures.Queue<int>(s1);
            PexAssume.IsTrue(x > -11 && x < 11);

            int dummy = -1;
            PexObserve.ValueForViewing("$input_q1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_q1.Peek", s1.TryPeek(out dummy) ? s1.Peek() : global--);
            PexObserve.ValueForViewing("$input_q1.Contains", s1.Contains(x));
            
            //try
            //{
                AssumePrecondition.IsTrue(  ((!(s1.Count <= 0))) );
            //}
            //catch (InvalidOperationException e)
            //{
            //    throw new PexAssumeFailedException();
            //}

            

            bool first = false;
            bool second = false;

            int p1 = -1, p2 = -2;

            // First test 
            s1.Enqueue(x);
            p1 = s1.Peek();

            // Second test 
            p2 = s2.Peek();
            s2.Enqueue(x);
            NotpAssume.IsTrue( p1 == p2 && eq.Equals(s1, s2));
            PexAssert.IsTrue(p1 == p2 && eq.Equals(s1, s2));
        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityEnqueueDequeueComm([PexAssumeUnderTest]DataStructures.Queue<int> s1, int x)
        {
            /* Pop throws exception when stack is empty*/

            DataStructures.Queue<int> s2 = new DataStructures.Queue<int>(s1);
            QueueEqualityComparer eq = new QueueEqualityComparer();
            PexAssume.IsTrue(x > -11 && x < 11);
            int dummy = -1;
            PexObserve.ValueForViewing("$input_q1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_q1.Peek", s1.TryPeek(out dummy) ? s1.Peek() : global--);
            PexObserve.ValueForViewing("$input_s1.Contains", s1.Contains(x));

            //try
            //{
                AssumePrecondition.IsTrue(  ((!(s1.Count <= 0))) );
            //}
            //catch (InvalidOperationException)
            //{
            //    throw new PexAssumeFailedException();
            //}
            
            int p1 = -1, p2 = -1;

            // First test
                s1.Enqueue(x);
                p1 = s1.Dequeue();
            

                // Second test 
                p2 = s2.Dequeue();
                s2.Enqueue(x);


            NotpAssume.IsTrue( p1 == p2 && eq.Equals(s1, s2));
            PexAssert.IsTrue( p1 == p2 && eq.Equals(s1, s2));
        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityEnqueueEnqueueComm([PexAssumeUnderTest]DataStructures.Queue<int> s1, int x, int y)
        {

            DataStructures.Queue<int> s2 = new DataStructures.Queue<int>(s1);
            QueueEqualityComparer eq = new QueueEqualityComparer();

            PexAssume.IsTrue(x > -11 && x < 11);
            PexAssume.IsTrue(y > -11 && y < 11);
            int dummy = -1;
            //bool prec = false;
            PexObserve.ValueForViewing("$input_q1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_q1.Peek", s1.TryPeek(out dummy) ? s1.Peek() : global--);
            PexObserve.ValueForViewing("$input_q1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_q1.Contains(y)", s1.Contains(y));
            
            //try
            //{
                AssumePrecondition.IsTrue( (x == y)  );
            //}
            //catch (InvalidOperationException)
            //{
              //  throw new PexAssumeFailedException();
                
            //}
            

            // First test 
            s1.Enqueue(x);
            s1.Enqueue(y);
            // Second test 
            s2.Enqueue(y);
            s2.Enqueue(x);

            NotpAssume.IsTrue(eq.Equals(s1, s2));
            PexAssert.IsTrue(eq.Equals(s1, s2));
        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativitySizePeekComm([PexAssumeUnderTest]DataStructures.Queue<int> s1)
        {
            /* Peek throws exception when stack is empty*/
            Queue<int> s2 = new Queue<int>(s1);
            QueueEqualityComparer eq = new QueueEqualityComparer();
            //PexAssume.IsTrue(s1.Count > 0);
            int dummy = -1;
            PexObserve.ValueForViewing("$input_q1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_q1.Peek", s1.TryPeek(out dummy) ? s1.Peek() : global--);
            
            AssumePrecondition.IsTrue(  ((!(s1.Count <= 0))) );


            int c1 = -1, p1 = -2;
            int c2 = -1, p2 = -2;

            // First test
                c1 = s1.Count;
                p1 = s1.Peek();

            // Second test 
                p2 = s2.Peek();
                c2 = s2.Count;


            NotpAssume.IsTrue(c1 == c2 && p1 == p2 && eq.Equals(s1, s2));
            PexAssert.IsTrue( c1 == c2 && p1 == p2 && eq.Equals(s1, s2));
        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativitySizeDequeueComm([PexAssumeUnderTest]DataStructures.Queue<int> s1)
        {
            /* Pop throws exception when stack is empty*/
            Queue<int> s2 = new Queue<int>(s1);
            QueueEqualityComparer eq = new QueueEqualityComparer();

            int dummy = -1;
            PexObserve.ValueForViewing("$input_q1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_q1.Peek", s1.TryPeek(out dummy) ? s1.Peek() : -12);
            
            AssumePrecondition.IsTrue(  false);

            int c1 = -1, c2 = -1;
            int p1 = -1, p2 = -1;

                // First test 
                c1 = s1.Count;
                p1 = s1.Dequeue();

                // Second test 
                p2 = s2.Dequeue();
                c2 = s2.Count;


            NotpAssume.IsTrue(c1 == c2 && p1 == p2 && eq.Equals(s1, s2));
            PexAssert.IsTrue( c1 == c2 && p1 == p2 && eq.Equals(s1, s2));
        }


        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativitySizeEnqueueComm([PexAssumeUnderTest]DataStructures.Queue<int> s1, int x)
        {

            Queue<int> s2 = new Queue<int>(s1);
            QueueEqualityComparer eq = new QueueEqualityComparer();
            PexAssume.IsTrue(x > -11 && x < 11);
            int dummy = -1;
            PexObserve.ValueForViewing("$input_q1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_q1.Peek", s1.TryPeek(out dummy) ? s1.Peek() : -12);
            PexObserve.ValueForViewing("$input_q1.Contains(x)", s1.Contains(x));
            
            AssumePrecondition.IsTrue(  false);

            
            int c1 = -1, c2 = -1;
            // First test
            c1 = s1.Count;
            s1.Enqueue(x);
            // Second test 
            s2.Enqueue(x);
            c2 = s2.Count;

            NotpAssume.IsTrue(c1 == c2 && eq.Equals(s1, s2));
            PexAssert.IsTrue(c1 == c2 && eq.Equals(s1, s2));

        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativitySizeSizeComm([PexAssumeUnderTest]DataStructures.Queue<int> s1)
        {

            Queue<int> s2 = new Queue<int>(s1);
            QueueEqualityComparer eq = new QueueEqualityComparer();
            int dummy = -1;
            PexObserve.ValueForViewing("$input_q1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_q1.Peek", s1.TryPeek(out dummy) ? s1.Peek() : -12);
            
            AssumePrecondition.IsTrue(  true);


            int c1 = -1, c2 = -1;
            int cc1 = -1, cc2 = -1;

            // First test
            c1 = s1.Count;
            cc1 = s1.Count;

            // Second test 
            cc2 = s2.Count;
            c2 = s2.Count;


            NotpAssume.IsTrue(c1 == c2 && cc1 == cc2 && eq.Equals(s1, s2));
            PexAssert.IsTrue(c1 == c2 && cc1 == cc2 && eq.Equals(s1, s2));

        }

    }

}
