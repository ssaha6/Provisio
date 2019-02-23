// <copyright file="UndirectedGraphFactory001.cs">Copyright ? 2018</copyright>

using System;
using Microsoft.Pex.Framework;
using QuickGraph;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickGraphTest.Factories
{
    /// <summary>A factory for QuickGraph.UndirectedGraph`2[System.String,QuickGraph.Edge`1[System.String]] instances</summary>
    public static partial class UndirectedGraphFactory
    {
        [PexFactoryMethod(typeof(QuickGraph.UndirectedGraph<int, Edge<int>>))]
        public static UndirectedGraph<int, Edge<int>> CreateEmptyGraph()
        {
            UndirectedGraph<int, Edge<int>> g = new UndirectedGraph<int, Edge<int>>(false);

            return g;

        }
        /*1. Add one Vertex*/
        [PexFactoryMethod(typeof(QuickGraph.UndirectedGraph<int, Edge<int>>))]
        public static UndirectedGraph<int, Edge<int>> CreateGraphOneNode(int node1)
        {
            UndirectedGraph<int, Edge<int>> g = new UndirectedGraph<int, Edge<int>>(false);
            g.AddVertex(node1);
            return g;

        }

        /*2. Add array of vertex (no edges) - check distinct elements and not zero */
        /*[PexFactoryMethod(typeof(QuickGraph.UndirectedGraph<int, Edge<int>>))]
        public static UndirectedGraph<int, Edge<int>> CreateGraphArrayOfNodes([PexAssumeNotNull]int[] nodes)
        {
            //PexAssume.IsTrue(nodes.Length < 12);
            PexAssume.AreDistinctValues(nodes);
            PexAssume.TrueForAll(nodes, e => e != 0);
            UndirectedGraph<int, Edge<int>> g = new UndirectedGraph<int, Edge<int>>(false);
            foreach (int ele in nodes)
                g.AddVertex(ele);
            return g;
        }*/

        [PexFactoryMethod(typeof(QuickGraph.UndirectedGraph<int, Edge<int>>))]
        public static UndirectedGraph<int, Edge<int>> CreateGraphArrayOfNodesAndEdges([PexAssumeNotNull]int[] nodes,
            [PexAssumeNotNull] bool[] edges)
        {
            PexAssume.IsTrue(edges.Length <= nodes.Length);
            PexAssume.AreDistinctValues(nodes);
            PexAssume.TrueForAll(nodes, e => e != 0);

            UndirectedGraph<int, Edge<int>> g = new UndirectedGraph<int, Edge<int>>(false);
            foreach (int ele in nodes)
            {
                g.AddVertex(ele);
            }

            for (int i = 0; i < edges.Length; i++)
            {
                int source = PexChoose.IndexValue("indexed value", nodes);
                if (edges[i] == false)
                    g.AddEdge(new Edge<int>(nodes[source], nodes[i]));
            }
            return g;
        }

        [PexFactoryMethod(typeof(QuickGraph.UndirectedGraph<int, Edge<int>>))]
        public static UndirectedGraph<int, Edge<int>> CreateGraphArrayOfNodesAndEdgesAssume([PexAssumeNotNull]int[] nodes,
            [PexAssumeNotNull] bool[] edges)
        {
            //PexAssume.IsTrue(nodes.Length <= 7 || nodes.Length > 7);
            PexAssume.IsTrue(edges.Length <= 6 || nodes.Length > 6);
            PexAssume.IsTrue(edges.Length <= nodes.Length);
            PexAssume.AreDistinctValues(nodes);
            //PexAssume.TrueForAll(nodes, e => e != 0);

            UndirectedGraph<int, Edge<int>> g = new UndirectedGraph<int, Edge<int>>(false);
            foreach (int ele in nodes)
            {
                g.AddVertex(ele);
            }

            int source = PexChoose.IndexValue("indexed value", nodes);

            for (int i = 0; i < edges.Length; i++)
            {

                if (edges[i] == false)
                    g.AddEdge(new Edge<int>(nodes[source], nodes[i]));
            }
            return g;
        }

        /*/// <summary>A factory for QuickGraph.UndirectedGraph`2[System.String,QuickGraph.Edge`1[System.String]] instances</summary>
        [PexFactoryMethod(typeof(QuickGraph.UndirectedGraph<int, Edge<int>>))]
        public static UndirectedGraph<int, Edge<int>> CreateGraphGeneral(int[] nodes, bool parallel)
        {            
            var g = new UndirectedGraph<int, Edge<int>>(parallel);
            foreach (var node in nodes)
            {
                if(!g.ContainsVertex(node))
                    g.AddVertex(node);
            }
            for (int i = 0; i < nodes.Count()-1; i++)
            {
                g.AddEdge(new Edge<int>(nodes[i],nodes[i+1]));
            }

            return g;
        }*/

       /*[PexFactoryMethod(typeof(QuickGraph.UndirectedGraph<int, Edge<int>>))]
        public static UndirectedGraph<int, Edge<int>> CreateGraphGeneralWithEdges(Edge<int>[] edges, bool parallel)
        {
            var g = new UndirectedGraph<int, Edge<int>>(parallel);
            
            foreach (var edge in edges)
            {
                if (!g.ContainsVertex(edge.Source))
                    g.AddVertex(edge.Source);

                if (!g.ContainsVertex(edge.Target))
                    g.AddVertex(edge.Target);

                g.AddEdge(edge);
            }
            

            return g;
        }*/

      /* public static List<Edge<int>> createPairWiseEdges(int[] sources, int[] target)
        {
            var edges = new List<Edge<int>>(); 

            foreach (var l in sources){
                foreach (var r in target){
                    edges.Add(new Edge<int>(l,r));
                }
            }
            return edges;
        }

        [PexFactoryMethod(typeof(QuickGraph.UndirectedGraph<int, Edge<int>>))]
        public static UndirectedGraph<int, Edge<int>> CreateGraphGeneralWithEdgesOnly([PexAssumeNotNull]int[] left, [PexAssumeNotNull]int[] right)
        {
            
            PexSymbolicValue.Minimize(left.Length);
            PexSymbolicValue.Minimize(right.Length);
            //PexAssume.TrueForAll(0, left.Length, _i => -11 < left[_i] )

            var g = new UndirectedGraph<int, Edge<int>>(false);
            foreach (int node in left)
            {
                if (!g.ContainsVertex(node))
                    g.AddVertex(node);
            }

            foreach (int noder in right)
            {

                if (!g.ContainsVertex(noder))
                    g.AddVertex(noder);
            }

            g.AddEdgeRange(createPairWiseEdges(left, right));

            return g;

        }*/
        
        /*public static bool allDistinct(int[] arr)
        {
            
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (arr[i] == arr[j])
                        return false;
                }
            }
            return true;
        }
        public static bool allLessThan(int[] arr, int bound)
        {

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (arr[i] >= bound)
                        return false;
                }
            }
            return true;
        }
       [PexFactoryMethod(typeof(QuickGraph.UndirectedGraph<int, Edge<int>>))]
        public static UndirectedGraph<int, Edge<int>> CreateGraphGeneraKeyVal([PexAssumeNotNull]KeyValuePair<int, int[]>[] pairs)
        {
            PexAssume.IsTrue(pairs.Length < 11);
            //PexAssume.TrueForAll(pairs, p => p.Value != null && allLessThan(p.Value, 11));
            //PexAssume.TrueForAll(pairs, p => p.Key > -11 && p.Key < 11);
            UndirectedGraph<int, Edge<int>> g = new UndirectedGraph<int, Edge<int>>(false);

            for (int i = 0; i < pairs.Length; i++)
            {
                if (!g.ContainsVertex(pairs[i].Key))
                {
                    g.AddVertex(pairs[i].Key);
                }

                for (int j = 0; j < pairs[i].Value.Length; j++)
                {
                    if (!g.ContainsVertex(pairs[i].Value[j]))
                    {
                        g.AddVertex(pairs[i].Value[j]);
                    }
                    g.AddEdge(new Edge<int>(pairs[i].Key, pairs[i].Value[j]));
                }
            }
            return g;

        }
        [PexFactoryMethod(typeof(QuickGraph.UndirectedGraph<int, Edge<int>>))]
        public static UndirectedGraph<int, Edge<int>> CreateGraphFixed(int a, int b)
        {   

            //PexAssume.TrueForAll(pairs, p => p.Key > -11 && p.Key < 11);
            
            UndirectedGraph<int, Edge<int>> g = new UndirectedGraph<int, Edge<int>>(false);
            g.AddVertex(0);
            g.AddVertex(6);
            //g.AddVertex(7);
            //g.AddVertex(8);
            //g.AddVertex(9);

            g.AddEdge(new Edge<int>(0, 0));
            //g.AddEdge(new Edge<int>(5, 7));
            //g.AddEdge(new Edge<int>(7, 8));
            return g;

        }*/

        /*[PexFactoryMethod(typeof(QuickGraph.UndirectedGraph<int, Edge<int>>))]
         public static UndirectedGraph<int, Edge<int>> CreateGraphGeneralWithEdgesNodes(Edge<int>[] edges, int[] nodes)
         {
             var g = new UndirectedGraph<int, Edge<int>>(false);

             foreach (var node in nodes){
                 if (!g.ContainsVertex(node))
                     g.AddVertex(node);
             }

             foreach (var edge in edges)
             {
                 if (!g.ContainsVertex(edge.Source))
                 {
                     g.AddVertex(edge.Source);
                 }
                 if (!g.ContainsVertex(edge.Target))
                 {
                     g.AddVertex(edge.Target);
                 }
                 if (!g.ContainsEdge(edge.Source, edge.Target))
                 {
                     g.AddEdge(edge);
                 }
             }
            

             return g;
         }*/

        /*[PexFactoryMethod(typeof(QuickGraph.UndirectedGraph<int, Edge<int>>))]
        public static UndirectedGraph<int, Edge<int>> CreateGraphGeneralWithEdgesTwoNodes([PexAssumeNotNull]Edge<int>[] edges, int node1, int node2,int node3)
        {
            var g = new UndirectedGraph<int, Edge<int>>(false);

            if (!g.ContainsVertex(node1))
                    g.AddVertex(node1);
            if (!g.ContainsVertex(node2))
                g.AddVertex(node2);
            if (!g.ContainsVertex(node3))
                g.AddVertex(node3);

            foreach (var edge in edges)
            {
                if (edge == null)
                    continue;

                if (!g.ContainsVertex(edge.Source))
                    g.AddVertex(edge.Source);

                if (!g.ContainsVertex(edge.Target))
                    g.AddVertex(edge.Target);

                g.AddEdge(edge);
            }


            return g;
        }*/
        

       /* [PexFactoryMethod(typeof(QuickGraph.UndirectedGraph<int, Edge<int>>))]
        public static UndirectedGraph<int, Edge<int>> CreateGraph(int[]nodes, Edge<int>[] edges)
        {
            
            var g = new UndirectedGraph<int, Edge<int>>(false);
            foreach (var node in nodes)
            {
                g.AddVertex(node);
            }
            
            foreach (var edge in edges)
            {
                if (g.ContainsVertex(edge.Source) && g.ContainsVertex(edge.Target))
                    g.AddEdge(edge);

            }
            
            return g;
        }*/
        /*[PexFactoryMethod(typeof(QuickGraph.UndirectedGraph<int, Edge<int>>))]
        public static UndirectedGraph<int, Edge<int>> CreateFixedGraph(int a, int b, int c)
        {

            var g = new UndirectedGraph<int, Edge<int>>(false);
           
            g.AddVertex(a);
            if(! g.ContainsVertex(b))
                g.AddVertex(b);
            if (!g.ContainsVertex(c))
                g.AddVertex(c);
            g.AddEdge(new Edge<int>(a, b));
            g.AddEdge(new Edge<int>(a, c));
            return g;

            return g;
        }*/
    }
}
