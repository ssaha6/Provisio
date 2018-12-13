using System;
using System.Text;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures;
using DataStructures.Utility;
using PexAPIWrapper;

namespace DataStructures.Test
{
    [PexClass(typeof(DataStructures.Queue<int>))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class QueueTest
    {

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityPeekPeek([PexAssumeUnderTest]DataStructures.Queue<int> s1)
        {
            /* Peek throws exception when stack is empty*/

            DataStructures.Queue<int> s2 = new DataStructures.Queue<int>(s1);
            QueueEqualityComparer eq = new QueueEqualityComparer();

            AssumePrecondition.IsTrue(true);

            PexObserve.ValueForViewing("$input_q1.Count", s1.Count);


            bool first = false;
            bool second = false;
            int p1 = -1, p2 = -1;
            int pp1 = -1, pp2 = -1;

            try
            {
                // First test 
                p1 = s1.Peek();
                pp1 = s1.Peek();
            }
            catch (InvalidOperationException )
            {
                first = true;
            }

            try
            {
                // Second test 
                pp2 = s2.Peek();
                p2 = s2.Peek();
            }
            catch (InvalidOperationException )
            {
                second = true;
            }

            //NotpAssume.IsTrue((first && second) || (!first && !second && p1 == p2 && pp1 == pp2 && eq.Equals(s1, s2)));
            PexAssert.IsTrue((first && second) || (!first && !second && p1 == p2 && pp1 == pp2 && eq.Equals(s1, s2)));
        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityPeekDequeue([PexAssumeUnderTest]DataStructures.Queue<int> s1)
        {
            /* Pop throws exception when stack is empty*/

            DataStructures.Queue<int> s2 = new DataStructures.Queue<int>(s1);
            QueueEqualityComparer eq = new QueueEqualityComparer();

            try
            {
                AssumePrecondition.IsTrue(true);
            }
            catch (InvalidOperationException )
            {

            }
            int dummy = -1;
            PexObserve.ValueForViewing("$input_q1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_q1.Peek", s1.TryPeek(out dummy) ? s1.Peek() : -7 + dummy);


            bool first = false;
            bool second = false;
            int p1 = -1, p2 = -1;
            int pp1 = -1, pp2 = -1;

            try
            {
                // First test 
                p1 = s1.Peek();
                pp1 = s1.Dequeue();
            }
            catch (InvalidOperationException )
            {
                first = true;
            }

            try
            {
                // Second test 
                pp2 = s2.Dequeue();
                p2 = s2.Peek();
            }
            catch (InvalidOperationException )
            {
                second = true;
            }


            //NotpAssume.IsTrue((first && second) || (!first && !second && p1 == p2 && pp1 == pp2 && eq.Equals(s1, s2)));
            PexAssert.IsTrue((first && second) || (!first && !second && p1 == p2 && pp1 == pp2 && eq.Equals(s1, s2)));
        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityDequeueDequeue([PexAssumeUnderTest]DataStructures.Queue<int> s1)
        {
            /* Pop throws exception when stack is empty*/

            DataStructures.Queue<int> s2 = new DataStructures.Queue<int>(s1);
            QueueEqualityComparer eq = new QueueEqualityComparer();

            AssumePrecondition.IsTrue(true);
            PexObserve.ValueForViewing("$input_q1.Count", s1.Count);

            bool first = false;
            bool second = false;
            int p1 = -1, p2 = -1;
            int pp1 = -1, pp2 = -1;

            // First test 
            try
            {
                p1 = s1.Dequeue();
                pp1 = s1.Dequeue();
            }
            catch (InvalidOperationException )
            {
                first = true;
            }

            // Second test 
            try
            {
                pp2 = s2.Dequeue();
                p2 = s2.Dequeue();
            }
            catch (InvalidOperationException )
            {
                second = true;
            }
            //NotpAssume.IsTrue((first && second) || (!first && !second && p1 == p2 && pp1 == pp2 && eq.Equals(s1, s2)));
            PexAssert.IsTrue((first && second) || (!first && !second && p1 == p2 && pp1 == pp2 && eq.Equals(s1, s2)));
        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityEnqueuePeek([PexAssumeUnderTest]DataStructures.Queue<int> s1, int x)
        {
            QueueEqualityComparer eq = new QueueEqualityComparer();
            DataStructures.Queue<int> s2 = new DataStructures.Queue<int>(s1);
            PexAssume.IsTrue(x > -101 && x < 101);
            int dummy = -111;
            try
            {
                AssumePrecondition.IsTrue(true);
            }
            catch (InvalidOperationException e)
            {
                PexObserve.ValueForViewing("$input_q1.Count", s1.Count);
                PexObserve.ValueForViewing("$input_x", x);
                PexObserve.ValueForViewing("$input_q1.Peek", s1.TryPeek(out dummy) ? s1.Peek() : -100 + x);
                PexObserve.ValueForViewing("$input_q1.Contains", s1.Contains(x));
                throw e;
            }

            PexObserve.ValueForViewing("$input_q1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_q1.Peek", s1.TryPeek(out dummy) ? s1.Peek() : -100 + x);
            PexObserve.ValueForViewing("$input_q1.Contains", s1.Contains(x));

            bool first = false;
            bool second = false;

            int p1 = -1, p2 = -2;

            try
            {
                // First test 
                s1.Enqueue(x);
                p1 = s1.Peek();
            }
            catch (InvalidOperationException )
            {
                first = true;
            }

            try
            {
                // Second test 
                p2 = s2.Peek();
                s2.Enqueue(x);
            }
            catch (InvalidOperationException )
            {
                second = true;
            }
            //NotpAssume.IsTrue((first && second) || (!first && !second && p1 == p2 && eq.Equals(s1, s2)));
            PexAssert.IsTrue((first && second) || (!first && !second && p1 == p2 && eq.Equals(s1, s2)));
        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityEnqueueDequeue([PexAssumeUnderTest]DataStructures.Queue<int> s1, int x)
        {
            /* Pop throws exception when stack is empty*/

            DataStructures.Queue<int> s2 = new DataStructures.Queue<int>(s1);
            QueueEqualityComparer eq = new QueueEqualityComparer();
            PexAssume.IsTrue(x > -101 && x < 101);
            int dummy = -1;


            try
            {
                AssumePrecondition.IsTrue((((s1.Count <= 0)) && (false)) || (!((s1.Count <= 0)) && (true)));
            }
            catch (InvalidOperationException e)
            {
                PexObserve.ValueForViewing("$input_q1.Count", s1.Count);
                PexObserve.ValueForViewing("$input_x", x);
                PexObserve.ValueForViewing("$input_q1.Peek", s1.TryPeek(out dummy) ? s1.Peek() : -7 + x);
                PexObserve.ValueForViewing("$input_s1.Contains", s1.Contains(x));
                throw e;

            }
            PexObserve.ValueForViewing("$input_q1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_q1.Peek", s1.TryPeek(out dummy) ? s1.Peek() : -7 + x);
            PexObserve.ValueForViewing("$input_s1.Contains", s1.Contains(x));

            bool first = false;
            bool second = false;
            int p1 = -1, p2 = -1;

            // First test
            try
            {
                s1.Enqueue(x);
                p1 = s1.Dequeue();
            }

            catch (InvalidOperationException )
            {
                first = true;
            }

            try
            {
                // Second test 
                p2 = s2.Dequeue();
                s2.Enqueue(x);

            }
            catch (InvalidOperationException )
            {
                second = true;
            }

            //NotpAssume.IsTrue((first && second) || (!first && !second && p1 == p2 && eq.Equals(s1, s2)));
            PexAssert.IsTrue((first && second) || (!first && !second && p1 == p2 && eq.Equals(s1, s2)));
        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityEnqueueEnqueue([PexAssumeUnderTest]DataStructures.Queue<int> s1, int x, int y)
        {

            DataStructures.Queue<int> s2 = new DataStructures.Queue<int>(s1);
            QueueEqualityComparer eq = new QueueEqualityComparer();

            PexAssume.IsTrue(x > -100 && x < 100);
            PexAssume.IsTrue(y > -100 && y < 100);
            //int dummy = -1;
            //bool prec = false;
            try
            {
                AssumePrecondition.IsTrue( ((( 0*s1.Count + -1*x + 1*y <= 0 )) && (((( 0*s1.Count + -1*x + 1*y <= -1 )) && (false)) ||  (!(( 0*s1.Count + -1*x + 1*y <= -1 )) && (true)))) ||  (!(( 0*s1.Count + -1*x + 1*y <= 0 )) && (false)) );
            }
            catch (InvalidOperationException)
            {

                //prec = true; 
                //throw e;
            }
            PexObserve.ValueForViewing("$input_q1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_q1.Contains(x)", s1.Contains(x));
            PexObserve.ValueForViewing("$input_q1.Contains(y)", s1.Contains(y));

            // First test 
            s1.Enqueue(x);
            s1.Enqueue(y);
            // Second test 
            s2.Enqueue(y);
            s2.Enqueue(x);

            //NotpAssume.IsTrue(eq.Equals(s1, s2));
            PexAssert.IsTrue(eq.Equals(s1, s2));
        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativitySizePeek([PexAssumeUnderTest]DataStructures.Queue<int> s1)
        {
            /* Peek throws exception when stack is empty*/
            Queue<int> s2 = new Queue<int>(s1);
            QueueEqualityComparer eq = new QueueEqualityComparer();
            //PexAssume.IsTrue(s1.Count > 0);

            AssumePrecondition.IsTrue(true);

            PexObserve.ValueForViewing("$input_q1.Count", s1.Count);



            int c1 = -1, p1 = -2;
            int c2 = -1, p2 = -2;
            bool first = false;
            bool second = false;

            // First test
            try
            {
                c1 = s1.Count;
                p1 = s1.Peek();
            }
            catch (InvalidOperationException )
            {
                first = true;
            }

            // Second test 
            try
            {
                p2 = s2.Peek();
                c2 = s2.Count;
            }
            catch (InvalidOperationException )
            {
                second = true;
            }


            //NotpAssume.IsTrue((first && second) || ((!first && !second) && c1 == c2 && p1 == p2 && eq.Equals(s1, s2)));
            PexAssert.IsTrue((first && second) || ((!first && !second) && c1 == c2 && p1 == p2 && eq.Equals(s1, s2)));
        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativitySizeDequeue([PexAssumeUnderTest]DataStructures.Queue<int> s1)
        {
            /* Pop throws exception when stack is empty*/
            Queue<int> s2 = new Queue<int>(s1);
            QueueEqualityComparer eq = new QueueEqualityComparer();
            
            AssumePrecondition.IsTrue( ((( s1.Count <= 0 )) && (true)) ||  (!(( s1.Count <= 0 )) && (false)) );
            PexObserve.ValueForViewing("$input_q1.Count", s1.Count);

            bool first = false;
            bool second = false;
            int c1 = -1, c2 = -1;
            int p1 = -1, p2 = -1;

            try
            {
                // First test 
                c1 = s1.Count;
                p1 = s1.Dequeue();
            }
            catch (InvalidOperationException )
            {
                first = true;
            }

            try
            {
                // Second test 
                p2 = s2.Dequeue();
                c2 = s2.Count;
            }
            catch (InvalidOperationException)
            {
                second = true;
            }


            //NotpAssume.IsTrue((first && second) || ((!first && !second) && c1 == c2 && p1 == p2 && eq.Equals(s1, s2)));
            PexAssert.IsTrue((first && second) || ((!first && !second) && c1 == c2 && p1 == p2 && eq.Equals(s1, s2)));
        }


        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativitySizeEnqueue([PexAssumeUnderTest]DataStructures.Queue<int> s1, int x)
        {

            Queue<int> s2 = new Queue<int>(s1);
            QueueEqualityComparer eq = new QueueEqualityComparer();

            AssumePrecondition.IsTrue(false);

            PexObserve.ValueForViewing("$input_q1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);

            int c1 = -1, c2 = -1;
            // First test
            c1 = s1.Count;
            s1.Enqueue(x);
            // Second test 
            s2.Enqueue(x);
            c2 = s2.Count;

            //NotpAssume.IsTrue(c1 == c2 && eq.Equals(s1, s2));
            PexAssert.IsTrue(c1 == c2 && eq.Equals(s1, s2));

        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativitySizeSize([PexAssumeUnderTest]DataStructures.Queue<int> s1)
        {

            Queue<int> s2 = new Queue<int>(s1);
            QueueEqualityComparer eq = new QueueEqualityComparer();

            AssumePrecondition.IsTrue(true);

            PexObserve.ValueForViewing("$input_q1.Count", s1.Count);

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
