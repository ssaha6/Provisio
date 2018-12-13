using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Microsoft.Pex.Framework;
using PexAPIWrapper;
//using System.Diagnostics.Contracts;
namespace CodeContractBenchmark
{
    public class CodeContractBenchmark
    {
        public int[] GTZero(int x)
        {
            // Should infer x >= 0

            NotpAssume.IsTrue(x >= 0);

            return new int[x];
        }

        public int z; // dummy field to make the C# compiler happy

        public int[] GTZeroAfterCondition(bool b, int x)
        {
            // Should infer x >= 0
            // With Forward propagation we get x >= 0, and prove it is checked in each path
            if (b )
            {
                z = 122;
            }
            else
            {
                z = -123;
            }
            NotpAssume.IsTrue(x >= 0);

            return new int[x];
        }
        public int[] GTZeroInConditional(bool b, int x)
        {
            // Admissible preconditions are  x >= -1 or (b ==> x >= 0 && !b ==> x >= -1)
            // However, the preconditions all over the paths do not infer it (because it does syntactic propagation)
            if (b)
            {

                NotpAssume.IsTrue(x >=0);
                return new int[x];
            }
            else
            {
                NotpAssume.IsTrue(x >= -1 && x < int.MaxValue-1);

                return new int[x + 1];
            }
        }
        public void AssertInsideWhileLoop(int x)
        {
            // precondition should be Contract.Requires(x == 0 || x >= 0);
            // but this is out of scope of the preconditions all over the paths
            while (x != 0)
            {
                NotpAssume.IsTrue(x > 0);
                Debug.Assert(x > 0);
                x--;
            }
        }
        public int[] InsideWhileLoop(int x)
        {
            //Contract.Requires(x >= 0);
            // Should infer x <= 100, but this is out of the capabilities of the preconditions all over the paths
            int i;
            for (i = 0; i < x; i++)
            {
                //NotpAssume.IsTrue(i < 100);
                Debug.Assert(i < 100);
            }

            return null;
        }
        public void wrap(int xx, int zz)
        {
            AfterWhileLoop_ConditionAlwaysTrue(xx,zz);
        }
        public void AfterWhileLoop_ConditionAlwaysTrue(int x, int z)
        {
            // should infer x == 12, but this is out of the reach of the preconditions all over the paths
            // as it does not use the information from the numerical state that z != 0 is unreached
           //Contract.Requires( (z >= 0 && x ==12) );
            while (z > 0)
            {
                z--;
            }
            // here z == 0;
            //Contract.Assume(z <= 0);
            if (z == 0)
            {
                //NotpAssume.IsTrue(x == 12);
                Debug.Assert(x == 12);
                
            }
            
        }
        public int[] AfterWhileLoop_Symbolic(int x)
        {
            //Contract.Requires(x >= 0);
            // should infer x >= 1, but we do not use the numerical information
            int i;
            for (i = 0; i < x; i++)
            {
                // empty
            }
            NotpAssume.IsTrue(i == x);
            //here we know that i == x
            Debug.Assert(i == x);
            NotpAssume.IsTrue(i > 1);

            return new int[i - 1]; // cannot be read in pre-state immediately
        }
        static public void AssertGTZero(int x)
        {
            NotpAssume.IsTrue(x > 0);

            Debug.Assert(x > 0);
        }
        public static void AssertLTZero(int x)
        {
            NotpAssume.IsTrue(x < 0);

            Debug.Assert(x < 0);
        }
        public static void AssertGeqZero(int x)
        {
            NotpAssume.IsTrue(x >= 0);

            Debug.Assert(x >= 0);
        }
        public static void RepeatedPreconditionInference(int x, int z, int k)
        {
            if (x > 0)
            {
                NotpAssume.IsTrue(z >= k);

                Debug.Assert(z >= k);
            }
            else if (x == 0)
            {
                NotpAssume.IsTrue(z >= k);

                Debug.Assert(z >= k);
            }
            else
            {
                NotpAssume.IsTrue(z >= k);

                Debug.Assert(z >= k);
            }
        }
        public void Simplification1(int x)
        {
            int z = x + 1;
            
            NotpAssume.IsTrue(z + 1 > 0);

            Debug.Assert(z + 1 > 0);

            
        }
        public void Simplification2(int x)
        {
            int z = x + 1;
            
            NotpAssume.IsTrue(z - 1 > 0);
            Debug.Assert(z - 1 > 0);
        }
        public void Simplification3(int x)
        {
            int z = x - 1;
            
            NotpAssume.IsTrue(z + 1 > 0);

            Debug.Assert(z + 1 > 0);
        }
        public void Simplification4(int x)
        {
            int z = x - 1;
            
            NotpAssume.IsTrue(z - 1 > 0);

            Debug.Assert(z - 1 > 0);
        }


        public void RequiresAnInt(object s)
        {
            //NotpAssume.IsTrue(!(s is Int32));

            if ((s is Int32))
            {
                throw new ArgumentException();
            }
        }

        public void Loop(int input)
        {
            var j = 0;
            for (; j < input; j++)
            {
            }

            //NotpAssume.IsTrue(input == j);

            Debug.Assert(input == j); ////Contract.Assert(input == j);
        }
        public void Loop2(int x)
        {
            while (x != 0)
            {
                NotpAssume.IsTrue(x > 0);

                Debug.Assert(x > 0); ////Contract.Assert(x > 0);
                x--;
            }
        }
        public void Loop4(int m1, int f)
        {
            //Contract.Requires(m1 >= 0); // as we may have the equality, then we may never execute the loop
            int i = 0;
            while (i < m1)
            {
                NotpAssume.IsTrue(i < f);

                Debug.Assert(i < f); ////Contract.Assert(i < f);
                i++;
            }
        }

        public void SrivastavaGulwaniPLDI09(int x, int y)
        {
            while (x < 0)
            {
                x = x + y;
                y++;
            }

            NotpAssume.IsTrue(y > 0);
            
            Debug.Assert(y > 0); ////Contract.Assert(y > 0);
        }
        public void Shuvendu(int x, int t)
        {
            var i = x;
            var j = 0;
            while (i > 0)
            {
                
                i--;
                j++;
                if (i == t)
                    break;
            }
            NotpAssume.IsTrue(j == x);

            Debug.Assert(j == x);
        }

    }
}
