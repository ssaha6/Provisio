using System;

using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Pex.Framework.Settings;
using PexAPIWrapper;

namespace CodeContractBenchmark.Test
{
    [PexClass(typeof(CodeContractBenchmark))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class CodeContractBenchmarkTest
    {

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_AfterWhileLoop_ConditionAlwaysTrue(
            [PexAssumeUnderTest] CodeContractBenchmark target,
            int x,
            int z
        )
        {
            PexAssume.IsTrue(x > -101 && x < 101);
            PexAssume.IsTrue(z > -101 && z < 101);
            AssumePrecondition.IsTrue( ((z <= -1)) ||  ((!(z <= -1)) && (((!(x <= 11)) && (((x <= 12)))))) );
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_z", z);
            target.AfterWhileLoop_ConditionAlwaysTrue(x, z);
        }


        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public  void PUT_AfterWhileLoop_Symbolic([PexAssumeUnderTest]CodeContractBenchmark target, int x)
        {
            PexAssume.IsTrue(x > -101 && x < 101);
            AssumePrecondition.IsTrue(  ((!(x <= 0))) );
            PexObserve.ValueForViewing("$input_x", x);
            int[] result = target.AfterWhileLoop_Symbolic(x);
            
        }


        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_AssertGeqZero(int x)
        {
            PexAssume.IsTrue(x > -101 && x < 101);
            AssumePrecondition.IsTrue(  ((!(x <= -1))) );
            PexObserve.ValueForViewing("$input_x", x);
            CodeContractBenchmark.AssertGeqZero(x);
        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_AssertGTZero(int x)
        {
            PexAssume.IsTrue(x > -101 && x < 101);
            AssumePrecondition.IsTrue(  ((!(x <= 0))) );
            PexObserve.ValueForViewing("$input_x", x);
            CodeContractBenchmark.AssertGTZero(x);
        }




        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_AssertInsideWhileLoop([PexAssumeUnderTest]CodeContractBenchmark target, int x)
        {
            PexAssume.IsTrue(x > -101 && x < 101);
            AssumePrecondition.IsTrue(  ((!(x <= -1))) );
            PexObserve.ValueForViewing("$input_x", x);
            target.AssertInsideWhileLoop(x);
        }


        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_AssertLTZero(int x)
        {
            PexAssume.IsTrue(x > -101 && x < 101);
            AssumePrecondition.IsTrue( ((x <= -1))  );
            PexObserve.ValueForViewing("$input_x", x);
            CodeContractBenchmark.AssertLTZero(x);
        }


        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public int[] PUT_GTZero([PexAssumeUnderTest]CodeContractBenchmark target, int x)
        {
            PexAssume.IsTrue(x > -101 && x < 101);
            AssumePrecondition.IsTrue(  ((!(x <= -1))) );
            PexObserve.ValueForViewing("$input_x", x);
            int[] result = target.GTZero(x);
            return result;
        }



        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public int[] PUT_GTZeroAfterCondition(
            [PexAssumeUnderTest]CodeContractBenchmark target,
            bool b,
            int x
        )
        {
            
            PexAssume.IsTrue(x > -101 && x < 101);
            AssumePrecondition.IsTrue(  ((!(x <= -1))) );
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_b", b);
            int[] result = target.GTZeroAfterCondition(b, x);
            return result;
        }


        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public int[] PUT_GTZeroInConditional(
            [PexAssumeUnderTest]CodeContractBenchmark target,
            bool b,
            int x
        )
        {
            PexAssume.IsTrue(x > -101 && x < 101);
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_b", b);
            AssumePrecondition.IsTrue(  ((!(x <= -2)) && ((b && (((!(x <= -1))))) ||  ((!(b))))) );
            int[] result = target.GTZeroInConditional(b, x);
            return result;
        }
        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public int[] PUT_InsideWhileLoop([PexAssumeUnderTest]CodeContractBenchmark target, int x)
        {
            PexAssume.IsTrue(x > -200 && x < 200);
            AssumePrecondition.IsTrue( (x <= 100)  );
            PexObserve.ValueForViewing("$input_x", x);
            int[] result = target.InsideWhileLoop(x);
            return result;
        }


        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_Loop([PexAssumeUnderTest]CodeContractBenchmark target, int input)
        {
            PexAssume.IsTrue(input > -101 && input < 101);
            AssumePrecondition.IsTrue(  ((!(input <= -1))) );
            PexObserve.ValueForViewing("$input_input", input);
            target.Loop(input);
        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_Loop2([PexAssumeUnderTest]CodeContractBenchmark target, int x)
        {
            PexAssume.IsTrue(x > -101 && x < 101);
            AssumePrecondition.IsTrue(  ((!(x <= -1))) );
            PexObserve.ValueForViewing("$input_x", x);
            target.Loop2(x);
        }


        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_Loop4(
            [PexAssumeUnderTest]CodeContractBenchmark target,
            int m1,
            int f
        )
        {
            PexAssume.IsTrue(m1 > -101 && m1 < 101);
            PexAssume.IsTrue(f > -101 && f < 101);
            // Best simplified precondition: (((f <= -1+m1)) && (((m1 <= 0)))) || (((f > -1+m1)))
            AssumePrecondition.IsTrue( (-m1 + f <= -1 && ((m1 <= 0))) ||  ((!(-m1 + f <= -1))) );
            PexObserve.ValueForViewing("$input_m1", m1);
            PexObserve.ValueForViewing("$input_f", f);
            target.Loop4(m1, f);
        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_RepeatedPreconditionInference(
            int x,
            int z,
            int k
        )
        {
            PexAssume.IsTrue(x > -101 && x < 101);
            PexAssume.IsTrue(z > -101 && z < 101);
            PexAssume.IsTrue(k > -101 && k < 101);
            // Best simplified precondition: (k <= z);
            AssumePrecondition.IsTrue( (-z + k <= 0)  );
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_z", z);
            PexObserve.ValueForViewing("$input_k", k);
            CodeContractBenchmark.RepeatedPreconditionInference(x, z, k);
        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_RequiresAnInt([PexAssumeUnderTest]CodeContractBenchmark target, object s)
        {
            AssumePrecondition.IsTrue(true);
            PexObserve.ValueForViewing("$input_s", s);
            target.RequiresAnInt(s);
        }


        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_Shuvendu(
            [PexAssumeUnderTest]CodeContractBenchmark target,
            int x,
            int t
        )
        {
            PexAssume.IsTrue(x > -101 && x < 101);
            PexAssume.IsTrue(t > -101 && t < 101);
            AssumePrecondition.IsTrue(  ((!(x <= -1)) && ((x == t) ||  ((!(x == t)) && ((-x + t <= 0 && ((t <= 0))) ||  ((!(-x + t <= 0))))))) );
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_t", t);
            target.Shuvendu(x, t);
        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_Simplification1([PexAssumeUnderTest]CodeContractBenchmark target, int x)
        {
            PexAssume.IsTrue(x > -101 && x < 101);
            AssumePrecondition.IsTrue(  ((!(x <= -2))) );
            PexObserve.ValueForViewing("$input_x", x);
            target.Simplification1(x);
        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_Simplification2([PexAssumeUnderTest]CodeContractBenchmark target, int x)
        {
            PexAssume.IsTrue(x > -101 && x < 101);
            AssumePrecondition.IsTrue(  ((!(x <= 0))) );
            PexObserve.ValueForViewing("$input_x", x);
            target.Simplification2(x);
        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_Simplification3([PexAssumeUnderTest]CodeContractBenchmark target, int x)
        {
            PexAssume.IsTrue(x > -101 && x < 101);
            AssumePrecondition.IsTrue(  ((!(x <= 0))) );
            PexObserve.ValueForViewing("$input_x", x);
            target.Simplification3(x);
        }

        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_Simplification4([PexAssumeUnderTest]CodeContractBenchmark target, int x)
        {
            PexAssume.IsTrue(x > -101 && x < 101);
            AssumePrecondition.IsTrue(  ((!(x <= 2))) );
            PexObserve.ValueForViewing("$input_x", x);
            target.Simplification4(x);
        }

        ////[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        [PexMethod]
        public void PUT_SrivastavaGulwaniPLDI09(
            [PexAssumeUnderTest]CodeContractBenchmark target,
            int x,
            int y
        )
        {
            
            PexAssume.IsTrue(x > -101 && x < 101);
            PexAssume.IsTrue(y > -101 && y < 101);
            AssumePrecondition.IsTrue( (x <= -1) ||  ((!(x <= -1)) && (((!(y <= 0))))) );
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_y", y);
            target.SrivastavaGulwaniPLDI09(x, y);
        }
    }
}
