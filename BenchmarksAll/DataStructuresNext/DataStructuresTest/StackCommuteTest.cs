using System;
using System.Text;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Settings;
using Microsoft.Pex.Framework.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures;
using DataStructures.Utility;
using PexAPIWrapper;

namespace DataStructures.Comm.Test
{
    [PexClass(typeof(DataStructures.Stack<int>))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class StackCommuteTest
    {
        public int global = -7;
        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityPeekPeekComm([PexAssumeUnderTest]DataStructures.Stack<int> s1)
        {
            /* Peek throws exception when stack is empty*/
            Stack<int> s2 = (Stack<int>)s1.Clone();
            StackEqualityComparer eq = new StackEqualityComparer();
            int dummy =-1;
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_s1.Peek", s1.TryPeek(out dummy) ? s1.Peek() : global--);
            AssumePrecondition.IsTrue( (( s1.Count <= 0 ) && (false)) ||  ((!( s1.Count <= 0 )) && (true)) );


            int p1 = -1, p2 = -1;
            int pp1 = -1, pp2 = -1;

            // First test 
            p1 = s1.Peek();
            pp1 = s1.Peek();
            
            // Second test 
            pp2 = s2.Peek();
            p2 = s2.Peek();

            //NotpAssume.IsTrue(p1 == p2 && pp1 == pp2 && eq.Equals(s1, s2));
            PexAssert.IsTrue(p1 == p2 && pp1 == pp2 && eq.Equals(s1, s2));
        }


        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityPeekPopComm([PexAssumeUnderTest]DataStructures.Stack<int> s1)
        {
            /* Pop throws exception when stack is empty*/

            Stack<int> s2 = (Stack<int>)s1.Clone();
            StackEqualityComparer eq = new StackEqualityComparer();
            int dummy = -1;
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_s1.Peek", s1.TryPeek(out dummy) ? s1.Peek() : -102);
            try
            {
                AssumePrecondition.IsTrue(((s1.Count <= 2) && (((s1.Count <= 1) && (false)) || ((!(s1.Count <= 1)) && (((-1 * s1.Count + 1 * s1.Peek() <= 6) && (false)) || ((!(-1 * s1.Count + 1 * s1.Peek() <= 6)) && (((-1 * s1.Count + 1 * s1.Peek() <= 50) && (((-1 * s1.Count + 1 * s1.Peek() <= 16) && (true)) || ((!(-1 * s1.Count + 1 * s1.Peek() <= 16)) && (((1 * s1.Count + -1 * s1.Peek() <= -47) && (true)) || ((!(1 * s1.Count + -1 * s1.Peek() <= -47)) && (((1 * s1.Count + -1 * s1.Peek() <= -38) && (false)) || ((!(1 * s1.Count + -1 * s1.Peek() <= -38)) && (((-1 * s1.Count + 1 * s1.Peek() <= 33) && (false)) || ((!(-1 * s1.Count + 1 * s1.Peek() <= 33)) && (true)))))))))) || ((!(-1 * s1.Count + 1 * s1.Peek() <= 50)) && (false)))))))) || ((!(s1.Count <= 2)) && (true)));
            }
            catch (InvalidOperationException)
            {
                throw new PexAssumeFailedException();
            }
            int p1 = -1, p2 = -1;
            int pp1 = -1, pp2 = -1;

            // First test 
            //NotpAssume.IsTrue(s1.Count > 0);
            p1 = s1.Peek();
            pp1 = s1.Pop();
            
            // Second test 
            //NotpAssume.IsTrue(s1.Count > 2);
            pp2 = s2.Pop();
            p2 = s2.Peek();
            
            //NotpAssume.IsTrue( p1 == p2 && pp1 == pp2 && eq.Equals(s1, s2));
            PexAssert.IsTrue(p1 == p2 && pp1 == pp2 && eq.Equals(s1, s2));
        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityPopPopComm([PexAssumeUnderTest]DataStructures.Stack<int> s1)
        {
            /* Pop throws exception when stack is empty*/

            Stack<int> s2 = (Stack<int>)s1.Clone();
            StackEqualityComparer eq = new StackEqualityComparer();
            int dummy = -1;
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_s1.Peek", s1.TryPeek(out dummy) ? s1.Peek() : -102);
            AssumePrecondition.IsTrue(true);
            

            int p1 = -1, p2 = -1;
            int pp1 = -1, pp2 = -1;

            // First test 
            p1 = s1.Pop();
            pp1 = s1.Pop();
            
            // Second test 
            pp2 = s2.Pop();
            p2 = s2.Pop();
            
            //NotpAssume.IsTrue(p1 == p2 && pp1 == pp2 && eq.Equals(s1, s2));
            PexAssert.IsTrue(p1 == p2 && pp1 == pp2 && eq.Equals(s1, s2));
        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityPushPeekComm([PexAssumeUnderTest]DataStructures.Stack<int> s1, int x)
        {
            /* Peek throws exception when stack is empty*/
            Stack<int> s2 = (Stack<int>)s1.Clone();
            StackEqualityComparer eq = new StackEqualityComparer();

            PexAssume.IsTrue(x > -101 && x < 101);
            
            int dummy = -111;
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_s1.Peek", s1.TryPeek(out dummy) ? s1.Peek() : -102);
            PexObserve.ValueForViewing("$input_s1.Contains", s1.Contains(x));

            AssumePrecondition.IsTrue(true);
            int p1 = -1, p2 = -2;

            
            // First test 
            s1.Push(x);
            p1 = s1.Peek();
            
            
            // Second test 
            p2 = s2.Peek();
            s2.Push(x);

            //NotpAssume.IsTrue(p1 == p2 && eq.Equals(s1, s2));
            PexAssert.IsTrue(p1 == p2 && eq.Equals(s1, s2));
        }
        
        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityPushPopComm([PexAssumeUnderTest]DataStructures.Stack<int> s1, int x)
        {
            /* Pop throws exception when stack is empty*/

            Stack<int> s2 = (Stack<int>)s1.Clone();
            StackEqualityComparer eq = new StackEqualityComparer();
            PexAssume.IsTrue(x > -101 && x < 101);
            int dummy = -3;

            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_s1.Peek", s1.TryPeek(out dummy) ? s1.Peek() : -102);
            PexObserve.ValueForViewing("$input_s1.Contains", s1.Contains(x));
            
            
            //try
            //{
           AssumePrecondition.IsTrue( (( s1.Contains(x) ) && ((( 0*s1.Count + -1*x + 1*s1.Peek() <= -1 ) && (false)) ||  ((!( 0*s1.Count + -1*x + 1*s1.Peek() <= -1 )) && ((( 0*s1.Count + -1*x + 1*s1.Peek() <= 0 ) && (true)) ||  ((!( 0*s1.Count + -1*x + 1*s1.Peek() <= 0 )) && (false)))))) ||  ((!( s1.Contains(x) )) && (false)) );
            //}
            /*catch (InvalidOperationException)
            {
                //In case precondition throws exception.
            }*/
            int p1 = -1, p2 = -1;

            // First test 
            s1.Push(x);
            p1 = s1.Pop();
            
            // Second test 
            p2 = s2.Pop();
            s2.Push(x);

            //NotpAssume.IsTrue(p1 == p2 && eq.Equals(s1, s2));
            PexAssert.IsTrue( p1 == p2 && eq.Equals(s1, s2));
        }


        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityPushPushComm([PexAssumeUnderTest]DataStructures.Stack<int> s1, int x, int y)
        {

            Stack<int> s2 = (Stack<int>)s1.Clone();
            StackEqualityComparer eq = new StackEqualityComparer();

            PexAssume.IsTrue(x > -100 && x < 100);
            PexAssume.IsTrue(y > -100 && y < 100);
            int dummy = -1;
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_s1.Peek", s1.TryPeek(out dummy) ? s1.Peek() : -103);

            try
            {
                AssumePrecondition.IsTrue( (( 0*s1.Count + -1*x + 1*y + 0*s1.Peek() <= -1 ) && (false)) ||  ((!( 0*s1.Count + -1*x + 1*y + 0*s1.Peek() <= -1 )) && ((( 0*s1.Count + -1*x + 1*y + 0*s1.Peek() <= 0 ) && (true)) ||  ((!( 0*s1.Count + -1*x + 1*y + 0*s1.Peek() <= 0 )) && (false)))) );
            }
            catch (InvalidOperationException)
            {
                throw new PexAssumeFailedException();
            }
            

            // First test 
            s1.Push(x);
            s1.Push(y);
            
            // Second test 
            s2.Push(y);
            s2.Push(x);
            

            //NotpAssume.IsTrue(eq.Equals(s1, s2));
            PexAssert.IsTrue(eq.Equals(s1, s2));

        }
        
        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativitySizePeekComm([PexAssumeUnderTest]DataStructures.Stack<int> s1)
        {
            /* Peek throws exception when stack is empty*/
            Stack<int> s2 = (Stack<int>)s1.Clone();
            StackEqualityComparer eq = new StackEqualityComparer();
            int dummy = -1;
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            
            AssumePrecondition.IsTrue( (( s1.Count <= 0 ) && (false)) ||  ((!( s1.Count <= 0 )) && (true)) );

            int c1 = -1, p1 = -2;
            int c2 = -1, p2 = -2;

            // First test
            c1 = s1.Count;
            p1 = s1.Peek();
            
            // Second test
            p2 = s2.Peek();
            c2 = s2.Count;
            
            //NotpAssume.IsTrue( c1 == c2 && p1 == p2 && eq.Equals(s1, s2));
            PexAssert.IsTrue( c1 == c2 && p1 == p2 && eq.Equals(s1, s2));
        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativitySizePopComm([PexAssumeUnderTest]DataStructures.Stack<int> s1)
        {
            /* Pop throws exception when stack is empty*/
            Stack<int> s2 = (Stack<int>)s1.Clone();
            StackEqualityComparer eq = new StackEqualityComparer();
            int dummy = -1;
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            AssumePrecondition.IsTrue(  false);


            int c1 = -1, c2 = -1;
            int p1 = -1, p2 = -1;

            // First test 
            c1 = s1.Count;
            p1 = s1.Pop();


            // Second test 
            p2 = s2.Pop();
            c2 = s2.Count;

            //NotpAssume.IsTrue(c1 == c2 && p1 == p2 && eq.Equals(s1, s2));
            PexAssert.IsTrue(c1 == c2 && p1 == p2 && eq.Equals(s1, s2));
        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativitySizePushComm([PexAssumeUnderTest]DataStructures.Stack<int> s1, int x)
        {

            Stack<int> s2 = (Stack<int>)s1.Clone();
            StackEqualityComparer eq = new StackEqualityComparer();
            int dummy = -1;
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_s1.Peek", s1.TryPeek(out dummy) ? s1.Peek() : -102);
            AssumePrecondition.IsTrue(  false);
            
            int c1 = -1, c2 = -1;
            // First test
            c1 = s1.Count;
            s1.Push(x);
            // Second test 
            s2.Push(x);
            c2 = s2.Count;


            //NotpAssume.IsTrue(c1 == c2 && eq.Equals(s1, s2));
            PexAssert.IsTrue(c1 == c2 && eq.Equals(s1, s2));

        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativitySizeSizeComm([PexAssumeUnderTest]DataStructures.Stack<int> s1)
        {

            Stack<int> s2 = (Stack<int>)s1.Clone();
            StackEqualityComparer eq = new StackEqualityComparer();
            int dummy = -1;
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_s1.Peek", s1.TryPeek(out dummy) ? s1.Peek() : -102);
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
