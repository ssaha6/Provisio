using System;
using Microsoft.Pex.Framework;
using QuickGraph;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickGraph
{
    public static partial class PriorityQueueFactory
    {
        [PexFactoryMethod(typeof(Tuple<PriorityQueue<int, int>, PriorityQueue<int, int>>))]
        public static Tuple<PriorityQueue<int, int>, PriorityQueue<int, int>> CreatePriorityQueueGeneral([PexAssumeNotNull] int[] values, [PexAssumeNotNull] int[] distances)
        {
            PexAssume.IsTrue(values.Length == distances.Length);
            //PexAssume.TrueForAll(0, values.Length, _i => values[_i] > -11 && values[_i] < 11);
            //PexAssume.TrueForAll(0, distances.Length, _i => distances[_i] > -11 && distances[_i] < 11);
            var d = new Dictionary<int, int>();

            for (int i = 0; i < values.Length; i++)
            {
                if (!d.ContainsKey(values[i]))
                {
                    d.Add(values[i], distances[i]);
                }
            }

            var pq1 = new PriorityQueue<int, int>(d);
            var pq2 = new PriorityQueue<int, int>(d);

            for (int i = 0; i < values.Length; i++)
            {
                if (d.ContainsKey(values[i]))
                {
                    pq1.Enqueue(values[i]);
                    pq2.Enqueue(values[i]);
                }
            }

            var ret = new Tuple<PriorityQueue<int, int>, PriorityQueue<int, int>>(pq1, pq2);

            return ret;
        }

        /*[PexFactoryMethod(typeof(QuickGraph.PriorityQueue<int, int>))]
        public static PriorityQueue<int, int> CreatePriorityQueueGeneral2(int Length)
        {
            PexAssume.IsTrue(Length < 11 && Length > 0);

            Random ro = new Random();
            int[] values = new int[Length];
            int[] distances = new int[Length];

            for (int i = 0; i < Length; i++)
            {
                values[i] = ro.Next() % 11;
            }

            for (int i = 0; i < Length; i++)
            {
                distances[i] = ro.Next() % 11;
            }

            var d = new Dictionary<int, int>();

            for (int i = 0; i < values.Length; i++)
            {
                if (!d.ContainsKey(values[i]))
                {
                    d.Add(values[i], distances[i]);
                }
            }

            var pq = new PriorityQueue<int, int>(d);

            for (int i = 0; i < values.Length; i++)
            {
                if (d.ContainsKey(values[i]))
                {
                    pq.Enqueue(values[i]);
                }
            }

            return pq;
        }*/
    }
}
