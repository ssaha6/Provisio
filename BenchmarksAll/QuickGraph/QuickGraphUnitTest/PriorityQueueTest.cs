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
    public partial class PriorityQueueTest
    {
        [PexMethod]
        public void PUT_Update([PexAssumeUnderTest] QuickGraph.PriorityQueue<int, int> pq, int value)
        {
            PexObserve.ValueForViewing("$input_Value", value);
            PexObserve.ValueForViewing("$input_Count", pq.Count);
            PexObserve.ValueForViewing("$input_ContainsValue", pq.Contains(value));

            pq.Update(value);
        }

        [PexMethod]
        public void PUT_Contains([PexAssumeUnderTest] QuickGraph.PriorityQueue<int, int> pq, int value)
        {
            PexObserve.ValueForViewing("$input_Value", value);
            PexObserve.ValueForViewing("$input_Count", pq.Count);
            PexObserve.ValueForViewing("$input_ContainsValue", pq.Contains(value));

            bool c = pq.Contains(value);
        }

        [PexMethod]
        public void PUT_Enqueue([PexAssumeUnderTest] QuickGraph.PriorityQueue<int, int> pq, int value)
        {
            PexObserve.ValueForViewing("$input_Value", value);
            PexObserve.ValueForViewing("$input_Count", pq.Count);
            PexObserve.ValueForViewing("$input_ContainsValue", pq.Contains(value));

            pq.Enqueue(value);
        }

        [PexMethod]
        public void PUT_Dequeue([PexAssumeUnderTest] QuickGraph.PriorityQueue<int, int> pq)
        {
            PexObserve.ValueForViewing("$input_Count", pq.Count);

            int d = pq.Dequeue();
        }

        [PexMethod]
        public void PUT_Peek([PexAssumeUnderTest] QuickGraph.PriorityQueue<int, int> pq)
        {
            PexObserve.ValueForViewing("$input_Count", pq.Count);

            int p = pq.Peek();
        }
    }
}
