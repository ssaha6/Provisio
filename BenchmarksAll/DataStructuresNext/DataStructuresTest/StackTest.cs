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
    [PexClass(typeof(DataStructures.Stack<int>))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class StackTest
    {
        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityPeekPeek([PexAssumeUnderTest]DataStructures.Stack<int> s1)
        {
            /* Peek throws exception when stack is empty*/

            Stack<int> s2 = (Stack<int>)s1.Clone();
            StackEqualityComparer eq = new StackEqualityComparer();

            AssumePrecondition.IsTrue(true);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);


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
            catch (InvalidOperationException)
            {
                first = true;
            }

            try
            {
                // Second test 
                pp2 = s2.Peek();
                p2 = s2.Peek();
            }
            catch (InvalidOperationException)
            {
                second = true;
            }

            //NotpAssume.IsTrue((first && second) || (!first && !second && p1 == p2 && pp1 == pp2 && eq.Equals(s1, s2)));
            PexAssert.IsTrue((first && second) || (!first && !second && p1 == p2 && pp1 == pp2 && eq.Equals(s1, s2)));
        }


        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityPeekPop([PexAssumeUnderTest]DataStructures.Stack<int> s1)
        {
            /* Pop throws exception when stack is empty*/
            
            Stack<int> s2 = (Stack<int>)s1.Clone();
            StackEqualityComparer eq = new StackEqualityComparer();
            //int dummy = -1;

            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);

            //try
            //{
                AssumePrecondition.IsTrue(true);
            //}
            //catch (InvalidOperationException)
            //{

            //}
            //PexObserve.ValueForViewing("$input_s1.Peek", s1.TryPeek(out dummy) ? s1.Peek() : -7 + dummy);


            bool first = false;
            bool second = false;
            int p1 = -1, p2 = -1;
            int pp1 = -1, pp2 = -1;

            try
            {
                // First test 
                p1 = s1.Peek();
                pp1 = s1.Pop();
            }
            catch (InvalidOperationException)
            {
                first = true;
            }

            try
            {
                // Second test 
                pp2 = s2.Pop();
                p2 = s2.Peek();
            }
            catch (InvalidOperationException)
            {
                second = true;
            }



            //NotpAssume.IsTrue((first && second) || (!first && !second && p1 == p2 && pp1 == pp2 && eq.Equals(s1, s2)));
            PexAssert.IsTrue((first && second) || (!first && !second && p1 == p2 && pp1 == pp2 && eq.Equals(s1, s2)));
        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityPopPop([PexAssumeUnderTest]DataStructures.Stack<int> s1)
        {
            /* Pop throws exception when stack is empty*/

            Stack<int> s2 = (Stack<int>)s1.Clone();
            StackEqualityComparer eq = new StackEqualityComparer();
            //int dummy = -1;
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            //PexObserve.ValueForViewing("$input_s1.Peek", s1.TryPeek(out dummy) ? s1.Peek() : dummy);
                
            //try
            //{
                AssumePrecondition.IsTrue(true);
            //}
            //catch (InvalidOperationException e)
            //{
               
                //throw e;
            //}

            bool first = false;
            bool second = false;
            int p1 = -1, p2 = -1;
            int pp1 = -1, pp2 = -1;

            // First test 
            try
            {
                p1 = s1.Pop();
                pp1 = s1.Pop();
            }
            catch (InvalidOperationException)
            {
                first = true;
            }

            // Second test 
            try
            {
                pp2 = s2.Pop();
                p2 = s2.Pop();
            }
            catch (InvalidOperationException)
            {
                second = true;
            }
            //NotpAssume.IsTrue((first && second) || (!first && !second && p1 == p2 && pp1 == pp2 && eq.Equals(s1, s2)));
            PexAssert.IsTrue((first && second) || (!first && !second && p1 == p2 && pp1 == pp2 && eq.Equals(s1, s2)));
        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityPushPeek([PexAssumeUnderTest]DataStructures.Stack<int> s1, int x)
        {
            /* Peek throws exception when stack is empty*/
            Stack<int> s2 = (Stack<int>)s1.Clone();
            StackEqualityComparer eq = new StackEqualityComparer();

            PexAssume.IsTrue(x > -101 && x < 101);
            int dummy = -111;
            try
            {
                AssumePrecondition.IsTrue(true);
            }
            catch (InvalidOperationException)
            {

            }
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_s1.Peek", s1.TryPeek(out dummy) ? s1.Peek() : -7 + x);
            PexObserve.ValueForViewing("$input_s1.Contains", s1.Contains(x));

            bool first = false;
            bool second = false;

            int p1 = -1, p2 = -2;

            try
            {
                // First test 
                s1.Push(x);
                p1 = s1.Peek();
            }
            catch (InvalidOperationException)
            {
                first = true;
            }

            try
            {
                // Second test 
                p2 = s2.Peek();
                s2.Push(x);
            }
            catch (InvalidOperationException)
            {
                second = true;
            }
            //NotpAssume.IsTrue((first && second) || (!first && !second && p1 == p2 && eq.Equals(s1, s2)));
            PexAssert.IsTrue((first && second) || (!first && !second && p1 == p2 && eq.Equals(s1, s2)));
        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityPushPop([PexAssumeUnderTest]DataStructures.Stack<int> s1, int x)
        {
            /* Pop throws exception when stack is empty*/

            Stack<int> s2 = (Stack<int>)s1.Clone();
            StackEqualityComparer eq = new StackEqualityComparer();
            PexAssume.IsTrue(x > -101 && x < 101);
            int dummy = -2;



            try
            {
                AssumePrecondition.IsTrue((((s1.Contains(x))) && ((((0 * s1.Count + -1 * x + 1 * s1.Peek() <= 0)) && ((((0 * s1.Count + -1 * x + 1 * s1.Peek() <= -1)) && (false)) || (!((0 * s1.Count + -1 * x + 1 * s1.Peek() <= -1)) && (true)))) || (!((0 * s1.Count + -1 * x + 1 * s1.Peek() <= 0)) && (false)))) || (!((s1.Contains(x))) && (false)));
            }
            catch (InvalidOperationException)
            {

            }
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_s1.Peek", s1.TryPeek(out dummy) ? s1.Peek() : -7 + x);
            PexObserve.ValueForViewing("$input_s1.Contains", s1.Contains(x));

            bool first = false;
            bool second = false;
            int p1 = -1, p2 = -1;

            // First test
            try
            {
                s1.Push(x);
                p1 = s1.Pop();
            }

            catch (InvalidOperationException)
            {
                first = true;
            }

            try
            {
                // Second test 
                p2 = s2.Pop();
                s2.Push(x);
            }
            catch (InvalidOperationException)
            {
                second = true;
            }
            //NotpAssume.IsTrue((first && second) || (!first && !second && p1 == p2 && eq.Equals(s1, s2)));
            PexAssert.IsTrue((first && second) || (!first && !second && p1 == p2 && eq.Equals(s1, s2)));
        }


        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativityPushPush([PexAssumeUnderTest]DataStructures.Stack<int> s1, int x, int y)
        {

            Stack<int> s2 = (Stack<int>)s1.Clone();
            StackEqualityComparer eq = new StackEqualityComparer();

            PexAssume.IsTrue(x > -100 && x < 100);
            PexAssume.IsTrue(y > -100 && y < 100);
            AssumePrecondition.IsTrue( ((( 0*s1.Count + -1*x + 1*y <= -1 )) && (false)) ||  (!(( 0*s1.Count + -1*x + 1*y <= -1 )) && (((( 0*s1.Count + -1*x + 1*y <= 0 )) && (true)) ||  (!(( 0*s1.Count + -1*x + 1*y <= 0 )) && (false)))) );

            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_y", y);
            // First test 
            s1.Push(x);
            s1.Push(y);
            // Second test 
            s2.Push(y);
            s2.Push(x);
            //PexObserve.ValueForViewing("After State S1: ", s1.ToString());SS
            //PexObserve.ValueForViewing("After State S2: ", s2.ToString());

            //NotpAssume.IsTrue(eq.Equals(s1, s2));
            PexAssert.IsTrue(eq.Equals(s1, s2));

        }
        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativitySizePeek([PexAssumeUnderTest]DataStructures.Stack<int> s1)
        {
            /* Peek throws exception when stack is empty*/
            Stack<int> s2 = (Stack<int>)s1.Clone();
            StackEqualityComparer eq = new StackEqualityComparer();
            //PexAssume.IsTrue(s1.Count > 0);

            AssumePrecondition.IsTrue(  true);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);



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
            catch (InvalidOperationException)
            {
                first = true;
            }

            // Second test 
            try
            {
                p2 = s2.Peek();
                c2 = s2.Count;
            }
            catch (InvalidOperationException)
            {
                second = true;
            }


            //NotpAssume.IsTrue((first && second) || ((!first && !second) && c1 == c2 && p1 == p2 && eq.Equals(s1, s2) ));
            PexAssert.IsTrue((first && second) || ((!first && !second) && c1 == c2 && p1 == p2 && eq.Equals(s1, s2)));
        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativitySizePop([PexAssumeUnderTest]DataStructures.Stack<int> s1)
        {
            /* Pop throws exception when stack is empty*/
            Stack<int> s2 = (Stack<int>)s1.Clone();
            StackEqualityComparer eq = new StackEqualityComparer();
            //PexAssume.IsTrue(s1.Count > 0);

            AssumePrecondition.IsTrue((((s1.Count <= 0)) && (true)) || (!((s1.Count <= 0)) && (false)));
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);



            bool first = false;
            bool second = false;
            int c1 = -1, c2 = -1;
            int p1 = -1, p2 = -1;

            try
            {
                // First test 
                c1 = s1.Count;
                p1 = s1.Pop();
            }
            catch (InvalidOperationException)
            {
                first = true;
            }

            try
            {
                // Second test 
                p2 = s2.Pop();
                c2 = s2.Count;
            }
            catch (InvalidOperationException)
            {
                second = true;
            }


            //NotpAssume.IsTrue((first && second) || ( (!first && !second) && c1 == c2 && p1 == p2 && eq.Equals(s1, s2) ) );
            PexAssert.IsTrue((first && second) || ((!first && !second) && c1 == c2 && p1 == p2 && eq.Equals(s1, s2)));
        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_CommutativitySizePush([PexAssumeUnderTest]DataStructures.Stack<int> s1, int x)
        {

            Stack<int> s2 = (Stack<int>)s1.Clone();
            StackEqualityComparer eq = new StackEqualityComparer();

            AssumePrecondition.IsTrue(false);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
            PexObserve.ValueForViewing("$input_x", x);

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
        public void PUT_CommutativitySizeSize([PexAssumeUnderTest]DataStructures.Stack<int> s1)
        {

            Stack<int> s2 = (Stack<int>)s1.Clone();
            StackEqualityComparer eq = new StackEqualityComparer();

            AssumePrecondition.IsTrue(  true);
            PexObserve.ValueForViewing("$input_s1.Count", s1.Count);
              
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
