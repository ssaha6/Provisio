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
    [PexClass(typeof(QuickGraph.BinaryHeap<int, int>))]
    [TestClass]
    public partial class BinaryHeapTest
    {
        [PexMethod]
        public void PUT_Add([PexAssumeUnderTest] QuickGraph.BinaryHeap<int, int> bh, int priority, int value)
        {
            PexAssume.IsTrue(priority > -11 && priority < 11);
            PexAssume.IsTrue(value > -11 && value < 11);

            PexObserve.ValueForViewing("$input_Priority", priority);
            PexObserve.ValueForViewing("$input_Value", value);
            PexObserve.ValueForViewing("$input_Count", bh.Count);
            PexObserve.ValueForViewing("$input_Capacity", bh.Capacity);
            PexObserve.ValueForViewing("$input_IndexOf", bh.IndexOf(value));

            AssumePrecondition.IsTrue(  true);
            
            bh.Add(priority, value);
        }

        [PexMethod]
        public void PUT_Minimum([PexAssumeUnderTest] QuickGraph.BinaryHeap<int, int> bh)
        {
            PexObserve.ValueForViewing("$input_Count", bh.Count);
            PexObserve.ValueForViewing("$input_Capacity", bh.Capacity);
            
            AssumePrecondition.IsTrue(  ((!(bh.Count <= 0))) );

            var m = bh.Minimum();
        }

        [PexMethod]
        public void PUT_RemoveMinimum([PexAssumeUnderTest] QuickGraph.BinaryHeap<int, int> bh)
        {
            PexObserve.ValueForViewing("$input_Count", bh.Count);
            PexObserve.ValueForViewing("$input_Capacity", bh.Capacity);
            
            AssumePrecondition.IsTrue(  ((!(bh.Count <= 0))) );

            var rm = bh.RemoveMinimum();
        }

        [PexMethod]
        public void PUT_RemoveAt([PexAssumeUnderTest] QuickGraph.BinaryHeap<int, int> bh, int index)
        {
            PexAssume.IsTrue(index > -11 && index < 11);

            PexObserve.ValueForViewing("$input_Index", index);
            PexObserve.ValueForViewing("$input_Count", bh.Count);
            PexObserve.ValueForViewing("$input_Capacity", bh.Capacity);

            AssumePrecondition.IsTrue(  ((!(-index + bh.Count <= 0)) && (((!(index <= -1))))) );

            var ra = bh.RemoveAt(index);
        }

        [PexMethod]
        public void PUT_IndexOf([PexAssumeUnderTest] QuickGraph.BinaryHeap<int, int> bh, int value)
        {
            PexAssume.IsTrue(value > -11 && value < 11);

            PexObserve.ValueForViewing("$input_Value", value);
            PexObserve.ValueForViewing("$input_Count", bh.Count);
            PexObserve.ValueForViewing("$input_Capacity", bh.Capacity);
            PexObserve.ValueForViewing("$input_IndexOf", bh.IndexOf(value));

            AssumePrecondition.IsTrue(  true);

            int io = bh.IndexOf(value);
        }
        [PexMethod]
        public void PUT_Update([PexAssumeUnderTest] QuickGraph.BinaryHeap<int, int> bh, int priority, int value)
        {
            PexAssume.IsTrue(priority > -11 && priority < 11);
            PexAssume.IsTrue(value > -11 && value < 11);

            PexObserve.ValueForViewing("$input_Priority", priority);
            PexObserve.ValueForViewing("$input_Value", value);
            PexObserve.ValueForViewing("$input_Count", bh.Count);
            PexObserve.ValueForViewing("$input_Capacity", bh.Capacity);
            PexObserve.ValueForViewing("$input_IndexOf", bh.IndexOf(value));

            AssumePrecondition.IsTrue(  ((!(bh.IndexOf(value) <= -1))) );

            bh.Update(priority, value);
        }

    }
}
