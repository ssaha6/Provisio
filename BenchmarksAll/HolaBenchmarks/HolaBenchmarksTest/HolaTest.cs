using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Settings;
using PexAPIWrapper;
using Microsoft.Pex.Framework.Exceptions;

namespace HolaBenchmarks.Test
{
    [PexClass(typeof(Hola))]
    [TestClass]
    public partial class HolaTest
    {
        ////[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_dig01([PexAssumeUnderTest]Hola target, int n)
        {
            /* 
             * Existing precondition: n > 0
             * Precondition to prevent overflow of y:  n < 31
             * 
             */
            PexAssume.IsTrue(n > -101 && n < 101);
            PexObserve.ValueForViewing("$input_n", n);
            
            AssumePrecondition.IsTrue(!(true));
            target.dig01(n);
        }

        
        

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_dig07([PexAssumeUnderTest]Hola target, int n, int u1)
        {
            /*
             * Existing Precondition: n >= 0 && u1 > 0
             */
            PexAssume.IsTrue(n > -101 && n < 101);
            PexAssume.IsTrue(u1 > -101 && u1 < 101);
            PexObserve.ValueForViewing("$input_n", n);
            PexObserve.ValueForViewing("$input_u1", u1);

            AssumePrecondition.IsTrue(!(true));
            
            target.dig07(n, u1);
        }


        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_dig14([PexAssumeUnderTest]Hola target, int m, int u4)
        {
            /*
             * Existing Precondition: m >0
             * Better Precondition: m > -1
             */
            PexAssume.IsTrue(m > -101 && m < 101);
            PexAssume.IsTrue(u4 > -101 && u4 < 101);
            PexObserve.ValueForViewing("$input_m", m);
            PexObserve.ValueForViewing("$input_u4", u4); 
            AssumePrecondition.IsTrue(!(true));
            
            
            target.dig14(m , u4);
        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_dig15([PexAssumeUnderTest]Hola target, int n, int k)
        {
            /*
             * Existing Precondition: n >0 && k >n
             * Better Precondition: //k > n-1 && n >= -k 
             */
            PexAssume.IsTrue(n > -101 && n < 101);
            PexAssume.IsTrue(k > -101 && k < 101);
            PexObserve.ValueForViewing("$input_n", n);
            PexObserve.ValueForViewing("$input_k", k);
            AssumePrecondition.IsTrue(!(true));
            
            target.dig15(n,k);
        }


        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_dig19([PexAssumeUnderTest]Hola target, int m, int n)
        {
            /* 
             * Existing Precondition: n >= 0 && m >=0 && m < n
             * 
             */
            PexAssume.IsTrue(m > -101 && m < 101);
            PexAssume.IsTrue(n > -101 && n < 101);
            PexObserve.ValueForViewing("$input_m", m);
            PexObserve.ValueForViewing("$input_n", n);
            AssumePrecondition.IsTrue(!(true));
            
            
            target.dig19(m,n);
        }


        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_dig21([PexAssumeUnderTest]Hola target, int n, int j, int v, int u4)
        {
            /* 
             * Existing Precondition: n > 0 & n < 100
             * Better Precondition: n >=0
             */
            PexAssume.IsTrue(n > -101 && n< 101);
            PexAssume.IsTrue(j > -101 && j < 101);
            PexAssume.IsTrue(v > -101 && v < 101);
            PexAssume.IsTrue(u4 > -101 && u4 < 101);
            PexObserve.ValueForViewing("$input_n", n);
            PexObserve.ValueForViewing("$input_j", j);
            PexObserve.ValueForViewing("$input_v", v);
            PexObserve.ValueForViewing("$input_u4", u4);
            //AssumePrecondition.IsTrue(!(true));
            
            target.dig21(n,j,v,u4);
        }


        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_dig31([PexAssumeUnderTest]Hola target, int m, int n, int u1)
        {
            /* 
             * Existing Precondition: m + 1 < n -> not good enough
             *  Better precondition:
             */
            PexAssume.IsTrue(m > -100000001 && m < 1000000001);
            PexAssume.IsTrue(n > -100000001 && n < 1000000001);
            PexAssume.IsTrue(u1 > -100000001 && u1 < 100000001);
            PexObserve.ValueForViewing("$input_m", m);
            PexObserve.ValueForViewing("$input_n", n);
            PexObserve.ValueForViewing("$input_u1", u1);
            try
            {
                AssumePrecondition.IsTrue(true);
            }
            catch (OverflowException)
            {
                throw new PexAssumeFailedException();
            }
            target.dig31(m,n,u1);
        }
        
        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_dig39([PexAssumeUnderTest]Hola target, int MAXPATHLEN, int u)
        {
            /* 
             * Existing Precondition:MAXPATHLEN > 0 -> Not good enough
             *  Better precondition: ???
             *  
             */
            PexAssume.IsTrue(MAXPATHLEN > -1000000 && MAXPATHLEN < 1000000);
            PexAssume.IsTrue(u > -1000000 && u < 1000000);
            PexObserve.ValueForViewing("$input_MAXPATHLEN", MAXPATHLEN);
            PexObserve.ValueForViewing("$input_u", u);

            AssumePrecondition.IsTrue(true);
            target.dig39(MAXPATHLEN, u);
        }


        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_dig41([PexAssumeUnderTest]Hola target, int n, int kt, int flag)
        {
            /* 
             * Existing Precondition:assert(n>=0) ->not good enough
             *  Better precondition: ???
             *  
             */
            PexAssume.IsTrue(n > -101 && n < 101);
            PexAssume.IsTrue(kt > -101 && kt < 101);
            PexAssume.IsTrue(flag > -101 && flag < 101);
            
            AssumePrecondition.IsTrue(true);

            PexObserve.ValueForViewing("$input_n", n);
            PexObserve.ValueForViewing("$input_kt", kt);
            PexObserve.ValueForViewing("$input_flag", flag);
            target.dig41(n, kt, flag);
        }



        [PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        //[PexMethod]
        public void PUT_dig43([PexAssumeUnderTest]Hola target, int x, int y, int u1)
        {
            /* 
             *  Existing Precondition:assert( u1 > 0 ) && x != y -> not good enough
             *  Better precondition: ???
             *  
             */
            PexAssume.IsTrue(x > -1075000000 && x < 1075000000);
            PexAssume.IsTrue(y > -1075000000 && y < 1075000000);
            //PexAssume.IsTrue(u1 > -101 && u1 < 101);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_y", y);
            PexObserve.ValueForViewing("$input_u1", u1);

            try
            {
                AssumePrecondition.IsTrue(true);
            }
            catch (OverflowException)
            {
                throw new PexAssumeFailedException();
            }
            target.dig43(x,y,u1);
        }
    }
}
