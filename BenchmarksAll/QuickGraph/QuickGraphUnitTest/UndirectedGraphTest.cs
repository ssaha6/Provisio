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
    [PexClass(typeof(QuickGraph.UndirectedGraph<int, Edge<int>>))]
    [TestClass]
    public partial class UndirectedGraphTest
    {
        ///
        /*
        [PexMethod(MaxConstraintSolverTime=50, Timeout=240)]
        public void PUT_graphTwoEdges([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g)
        {
            PexObserve.ValueForViewing("$input_g.EdgeCount", g.EdgeCount);
            PexObserve.ValueForViewing("$input_g.VertexCount", g.VertexCount);
            if (g.ContainsVertex(3))
                Console.WriteLine("here3");
            if (g.ContainsVertex(4))
                Console.WriteLine("here3");

            if (g.ContainsVertex(5))
                Console.WriteLine("here3");

            try
            {
                AssumePrecondition.IsTrue(g.EdgeCount >= 0);
            }
            catch (InvalidCastException e)  // Just for fun
            {
                throw;
            }

            //int n1 = g.EdgeCount;
            //g.AddVertex("ShiyuWang1");
            //g.AddVertex("ShiyuWang2");
            //g.AddEdge(new Edge<string>("ShiyuWang1", "ShiyuWang2"));
            //PexAssert.IsTrue(n1 + 1 == g.EdgeCount);
            PexAssert.IsTrue(g.EdgeCount != 2 );
        }
        */
        private static bool VertexPredicate_Helper(int v)
        {
            return v > 0;
        }

        private static bool EdgePredicate_Helper(Edge<int> e)
        {
            return e.Source > 0 && e.Target > 0;
        }


        [PexMethod]
        public void PUT_AddVertex([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g, [PexAssumeNotNull]Edge<int> e)
        {
            PexObserve.ValueForViewing("$input_SourceNode", e.Source);
            PexObserve.ValueForViewing("$input_VertexCount", g.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g.EdgeCount);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_ContainsNode", g.ContainsVertex(e.Source));
            PexObserve.ValueForViewing("$input_ContainsEdge", g.ContainsVertex(e.Source) && g.ContainsVertex(e.Target) ? g.ContainsEdge(e.Source, e.Target) : false);
            
            //AssumePrecondition.IsTrue(!g.ContainsVertex(node));
            g.AddVertex(e.Source);
        }


        [PexMethod]
        public void PUT_RemoveVertex([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g, [PexAssumeNotNull]Edge<int> e)
        {
            PexObserve.ValueForViewing("$input_SourceNode", e.Source);
            PexObserve.ValueForViewing("$input_VertexCount", g.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g.EdgeCount);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_ContainsNode", g.ContainsVertex(e.Source));
            PexObserve.ValueForViewing("$input_ContainsEdge", g.ContainsVertex(e.Source) && g.ContainsVertex(e.Target) ? g.ContainsEdge(e.Source, e.Target) : false);
            bool r1 = g.RemoveVertex(e.Source);
        }

        

        [PexMethod]
        public void PUT_RemoveVertexIf([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g)
        {
            //Reference: https://docs.microsoft.com/en-us/dotnet/api/system.predicate-1?view=netframework-4.7.2
            
            PexObserve.ValueForViewing("$input_VertexCount", g.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g.EdgeCount);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g.IsEdgesEmpty);

            VertexPredicate<int> predicate = VertexPredicate_Helper;
            int r1 = g.RemoveVertexIf(predicate);
        }

        

        [PexMethod]
        public void PUT_RemoveAdjacentEdgeIf([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g, [PexAssumeNotNull]Edge<int> e)
        {
            PexObserve.ValueForViewing("$input_SourceNode", e.Source);
            PexObserve.ValueForViewing("$input_VertexCount", g.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g.EdgeCount);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_ContainsNode", g.ContainsVertex(e.Source));
            PexObserve.ValueForViewing("$input_ContainsEdge", g.ContainsVertex(e.Source) && g.ContainsVertex(e.Target) ? g.ContainsEdge(e.Source, e.Target) : false);

            EdgePredicate<int, Edge<int>> predicate = EdgePredicate_Helper;
            int r1 = g.RemoveAdjacentEdgeIf(e.Source, predicate);
        }

        [PexMethod]
        public void PUT_ClearAdjacentEdges([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g, [PexAssumeNotNull]Edge<int> e)
        {
            PexObserve.ValueForViewing("$input_SourceNode", e.Source);
            PexObserve.ValueForViewing("$input_VertexCount", g.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g.EdgeCount);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_ContainsNode", g.ContainsVertex(e.Source));
            PexObserve.ValueForViewing("$input_ContainsEdge", g.ContainsVertex(e.Source) && g.ContainsVertex(e.Target) ? g.ContainsEdge(e.Source, e.Target) : false);

            g.ClearAdjacentEdges(e.Source);
        }

        [PexMethod]
        public void PUT_ContainsEdge([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g, [PexAssumeNotNull]Edge<int> e)
        {
            PexObserve.ValueForViewing("$input_SourceNode", e.Source);
            PexObserve.ValueForViewing("$input_TargetNode", e.Target);
            PexObserve.ValueForViewing("$input_VertexCount", g.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g.EdgeCount);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_ContainsNodeSrc", g.ContainsVertex(e.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar", g.ContainsVertex(e.Target));
            PexObserve.ValueForViewing("$input_ContainsEdge", g.ContainsVertex(e.Source) && g.ContainsVertex(e.Target) ? g.ContainsEdge(e.Source, e.Target) : false);
            bool c1 = g.ContainsEdge(e.Source, e.Target);
        }

        [PexMethod]
        public void PUT_AdjacentEdge([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g, int node, int index)
        {
            // PexAssume.IsTrue(index >= 0);
            Edge<int> a1 = g.AdjacentEdge(node, index);
        }

        [PexMethod]
        public void PUT_ContainsVertex([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g, [PexAssumeNotNull]Edge<int> e)
        {
            PexObserve.ValueForViewing("$input_SourceNode", e.Source);
            PexObserve.ValueForViewing("$input_VertexCount", g.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g.EdgeCount);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_ContainsNode", g.ContainsVertex(e.Source));
            PexObserve.ValueForViewing("$input_ContainsEdge", g.ContainsVertex(e.Source) && g.ContainsVertex(e.Target) ? g.ContainsEdge(e.Source, e.Target) : false);

            bool c1 = g.ContainsVertex(e.Source);
        }

        [PexMethod]
        public void PUT_AddEdge([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g, [PexAssumeNotNull]Edge<int> e)
        {
            PexObserve.ValueForViewing("$input_SourceNode", e.Source);
            PexObserve.ValueForViewing("$input_TargetNode", e.Target);
            PexObserve.ValueForViewing("$input_VertexCount", g.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g.EdgeCount);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_ContainsNodeSrc", g.ContainsVertex(e.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar", g.ContainsVertex(e.Target));
            PexObserve.ValueForViewing("$input_ContainsEdge", g.ContainsVertex(e.Source) && g.ContainsVertex(e.Target) ? g.ContainsEdge(e.Source, e.Target) : false);

            bool a1 = g.AddEdge(new Edge<int>(e.Source, e.Target));
        }

        [PexMethod]
        public void PUT_AddEdgeRange([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g, int[] srcs, int[] tars)
        {
            PexAssume.IsTrue(srcs.Length == tars.Length);
            List<Edge<int>> edges = new List<Edge<int>>();
            for (int i = 0; i < srcs.Length; i++)
            {
                edges.Add(new Edge<int>(srcs[i], tars[i]));
            }
            g.AddEdgeRange(edges);
        }

        [PexMethod]
        public void PUT_RemoveEdge([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g, [PexAssumeNotNull]Edge<int> e /*int src, int tar*/)
        {
            PexObserve.ValueForViewing("$input_SourceNode", e.Source);
            PexObserve.ValueForViewing("$input_TargetNode", e.Target);
            PexObserve.ValueForViewing("$input_VertexCount", g.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g.EdgeCount);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty",g.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_ContainsNodeSrc", g.ContainsVertex(e.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar", g.ContainsVertex(e.Target));
            PexObserve.ValueForViewing("$input_ContainsEdge", g.ContainsVertex(e.Source) && g.ContainsVertex(e.Target) ? g.ContainsEdge(e.Source, e.Target) : false);
            
            bool r1 = g.RemoveEdge(e);
        }

        [PexMethod] //Hard to find failures
        public void PUT_RemoveEdgeIf([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g)
        {
            PexObserve.ValueForViewing("$input_VertexCount", g.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g.EdgeCount);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g.IsEdgesEmpty);

            EdgePredicate<int, Edge<int>> predicate = EdgePredicate_Helper;
            int r1 = g.RemoveEdgeIf(predicate);
        }

        [PexMethod]
        public void PUT_RemoveEdges([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g, int[] srcs, int[] tars)
        {
            PexAssume.IsTrue(srcs.Length == tars.Length);
            List<Edge<int>> edges = new List<Edge<int>>();
            for (int i = 0; i < srcs.Length; i++)
            {
                edges.Add(new Edge<int>(srcs[i], tars[i]));
            }

            int r1 = g.RemoveEdges(edges);
        }

        [PexMethod]
        public void PUT_AdjacentEdges([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g, [PexAssumeNotNull]Edge<int> e)
        {
            PexObserve.ValueForViewing("$input_SourceNode", e.Source);
            PexObserve.ValueForViewing("$input_VertexCount", g.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g.EdgeCount);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_ContainsNode", g.ContainsVertex(e.Source));
            PexObserve.ValueForViewing("$input_ContainsEdge", g.ContainsVertex(e.Source) && g.ContainsVertex(e.Target) ? g.ContainsEdge(e.Source, e.Target) : false);

            var edges = g.AdjacentEdges(e.Source);
        }

        [PexMethod]
        public void PUT_AdjacentDegree([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g, [PexAssumeNotNull]Edge<int> e)
        {
            PexObserve.ValueForViewing("$input_SourceNode", e.Source);
            PexObserve.ValueForViewing("$input_VertexCount", g.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g.EdgeCount);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_ContainsNode", g.ContainsVertex(e.Source));
            PexObserve.ValueForViewing("$input_ContainsEdge", g.ContainsVertex(e.Source) && g.ContainsVertex(e.Target) ? g.ContainsEdge(e.Source, e.Target) : false);

            int a1 = g.AdjacentDegree(e.Source);
        }

        [PexMethod]
        public void PUT_IsAdjacentEdgesEmpty([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g, [PexAssumeNotNull]Edge<int> e)
        {
            PexObserve.ValueForViewing("$input_SourceNode", e.Source);
            PexObserve.ValueForViewing("$input_VertexCount", g.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g.EdgeCount);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_ContainsNode", g.ContainsVertex(e.Source));
            PexObserve.ValueForViewing("$input_ContainsEdge", g.ContainsVertex(e.Source) && g.ContainsVertex(e.Target) ? g.ContainsEdge(e.Source, e.Target) : false);

            bool a1 = g.IsAdjacentEdgesEmpty(e.Source);
        }
    }
}
