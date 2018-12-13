using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickGraph.Utility
{
    public class PriorityQueueEqualityComparer : EqualityComparer<PriorityQueue<int, int>>
    {
        public override bool Equals(QuickGraph.PriorityQueue<int, int> pq1, QuickGraph.PriorityQueue<int, int> pq2)
        {
            if (pq1 == null && pq2 == null)
            {
                return true;
            }
            else if (pq1 == null || pq2 == null)
            {
                return false;
            }
            return pq1.ToStringForInts().Equals(pq2.ToStringForInts());
        }

        public override int GetHashCode(PriorityQueue<int, int> pq)
        {
            int hash = 0;

            foreach (KeyValuePair<int, int> pair in pq.Heap)
            {
                hash += pair.Key * pair.Value;
            }

            return hash;
        }
    }
}
