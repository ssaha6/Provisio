using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickGraph.Utility;
using QuickGraph.Interfaces;

namespace QuickGraph
{
    [Serializable]
    public class PriorityQueue<TVertex, TDistance> :
        IQueue<TVertex>
    {
        private readonly IDictionary<TVertex, TDistance> distances;
        private BinaryHeap<TDistance, TVertex> heap;

        public PriorityQueue(
            IDictionary<TVertex, TDistance> distances
            )
            : this(distances, Comparer<TDistance>.Default.Compare)
        { }

        public PriorityQueue(
            IDictionary<TVertex, TDistance> distances,
            Comparison<TDistance> distanceComparison
            )
        {
            if (distances == null)
                throw new ArgumentNullException("distances");
            if (distanceComparison == null)
                throw new ArgumentNullException("distanceComparison");

            this.distances = distances;
            this.heap = new BinaryHeap<TDistance, TVertex>(distanceComparison);
        }

        public void Update(TVertex v)
        {
            this.heap.Update(this.distances[v], v);
        }

        public int Count
        {
            get { return this.heap.Count; }
        }

        public bool Contains(TVertex value)
        {
            return this.heap.IndexOf(value) > -1;
        }

        public void Enqueue(TVertex value)
        {
            //GraphContracts.AssumeNotNull(value, "value");
            //GraphContracts.Assume(this.distances.ContainsKey(value), "this.distances.ContainsKey(value)");
            this.heap.Add(this.distances[value], value);
        }

        public TVertex Dequeue()
        {
            return this.heap.RemoveMinimum().Value;
        }

        public TVertex Peek()
        {
            return this.heap.Minimum().Value;
        }

        // Shiyu's code
        public virtual Object Clone()
        {
            var pq = new PriorityQueue<TVertex, TDistance>(this.distances, this.heap.PriorityComparison);
            //foreach (KeyValuePair<TDistance, TVertex> pair in this.heap)
            //{
            //    pq.Enqueue(pair.Value);
            //}
            pq.heap = (BinaryHeap<TDistance, TVertex>)this.heap.Clone();
            return pq;
        }

        public string ToStringForInts()
        {
            string ret = "{";
            ret += this.heap.ToStringForInts();
            return ret + "}";
        }

        public BinaryHeap<TDistance, TVertex> Heap
        {
            get { return this.heap; }
        }
    }
}
