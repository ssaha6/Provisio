using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickGraph;

using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Settings;
using Microsoft.Pex.Framework.Exceptions;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PexAPIWrapper;
using QuickGraph.Interfaces;
using QuickGraph.Utility;
using Microsoft.ExtendedReflection.Interpretation.Interpreter;
using QuickGraphTest.Factories;
namespace QuickGraphTest
{
    [PexClass(typeof(QuickGraph.UndirectedGraph<int, Edge<int>>))]
    [TestClass]
    public partial class UndirectedGraphCommuteTest
    {
        [PexMethod]
        public void PUT_CommutativityAddVertexAddVertexComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node1, int node2)
        {
            PexSymbolicValue.Minimize(node1);
            PexSymbolicValue.Minimize(node2);

            UndirectedGraph<int, Edge<int>> g2 = g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();
            
            PexAssume.IsTrue(node1 > -11 && node1 < 11);
            PexAssume.IsTrue(node2 > -11 && node2 < 11);
            
            PexObserve.ValueForViewing("$input_Node1", node1);
            PexObserve.ValueForViewing("$input_Node2", node2);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_ContainsNode1", g1.ContainsVertex(node1));
            PexObserve.ValueForViewing("$input_ContainsNode2", g1.ContainsVertex(node2));
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);

            AssumePrecondition.IsTrue(true);
            g1.AddVertex(node1);
            g1.AddVertex(node2);

            g2.AddVertex(node2);
            g2.AddVertex(node1);

            //NotpAssume.IsTrue(eq.Equals(g1, g2));
            //try{PexAssert.IsTrue(false);}catch{return;}
            PexAssert.IsTrue(eq.Equals(g1, g2));

        }

        [PexMethod]
        public void PUT_CommutativityAddVertexRemoveVertexComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node1, int node2)
        {
            UndirectedGraph<int, Edge<int>> g2 = g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();
            
            PexAssume.IsTrue(node1 > -11 && node1 < 11);
            PexAssume.IsTrue(node2 > -11 && node2 < 11);

            PexObserve.ValueForViewing("$input_Node1", node1);
            PexObserve.ValueForViewing("$input_Node2", node2);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode1", g1.ContainsVertex(node1));
            PexObserve.ValueForViewing("$input_ContainsNode2", g1.ContainsVertex(node2));

            
            AssumePrecondition.IsTrue( (g1.ContainsVertex(node2) && (((!(g1.ContainsVertex(node1))))))  );

            bool rv1 = true, rv2 = true;

            g1.AddVertex(node1);
            rv1 = g1.RemoveVertex(node2);

            rv2 = g2.RemoveVertex(node2);
            g2.AddVertex(node1);

            NotpAssume.IsTrue(rv1 == rv2 && eq.Equals(g1, g2));
            try{PexAssert.IsTrue(false);}catch{return;}
            PexAssert.IsTrue(rv1 == rv2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityAddVertexClearAdjacentEdgesComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node1, int node2)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();
            PexAssume.IsTrue(node1 > -11 && node1 < 11);
            PexAssume.IsTrue(node2 > -11 && node2 < 11);

            PexObserve.ValueForViewing("$input_Node1", node1);
            PexObserve.ValueForViewing("$input_Node2", node2);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode1", g1.ContainsVertex(node1));
            PexObserve.ValueForViewing("$input_ContainsNode2", g1.ContainsVertex(node2));

            
            //try
            //{
            AssumePrecondition.IsTrue( (g1.ContainsVertex(node2) && (((!(g1.ContainsVertex(node1))))))  );
            //}
            //catch { throw new PexAssumeFailedException(); }
            g1.AddVertex(node1);
            g1.ClearAdjacentEdges(node2);
            
            g2.ClearAdjacentEdges(node2);
            g2.AddVertex(node1);
            
            NotpAssume.IsTrue(eq.Equals(g1, g2));
            try{PexAssert.IsTrue(false);}catch{return;}
            PexAssert.IsTrue(eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityAddVertexContainsEdgeComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node, [PexAssumeNotNull]Edge<int> e)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();
            PexAssume.IsTrue(node > -11 && node < 11);
            PexAssume.IsTrue(e.Source > -11 && e.Source < 11);
            PexAssume.IsTrue(e.Target > -11 && e.Target < 11);
            
            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_SourceNode", e.Source);
            PexObserve.ValueForViewing("$input_TargetNode", e.Target);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));
            PexObserve.ValueForViewing("$input_ContainsNodeSrc", g1.ContainsVertex(e.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar", g1.ContainsVertex(e.Target));
            PexObserve.ValueForViewing("$input_ContainsEdge", g1.ContainsVertex(e.Source) && g1.ContainsVertex(e.Target) ? g1.ContainsEdge(e.Source, e.Target) : false);
            //try
            //{
               AssumePrecondition.IsTrue( (g1.ContainsVertex(e.Source) && (((!(g1.ContainsVertex(node))))))  );
            //}
            //catch { throw new PexAssumeFailedException(); }
            
            bool ce1 = true, ce2 = true;

            g1.AddVertex(node);
            ce1 = g1.ContainsEdge(e.Source, e.Target);

            ce2 = g2.ContainsEdge(e.Source, e.Target);
            g2.AddVertex(node);

            NotpAssume.IsTrue(ce1 == ce2 && eq.Equals(g1, g2));
            try{PexAssert.IsTrue(false);}catch{return;}
            PexAssert.IsTrue(ce1 == ce2 && eq.Equals(g1, g2));
        }
      

        //[PexMethod(TestEmissionFilter= PexTestEmissionFilter.All)]
        [PexMethod] // All failures
        public void PUT_CommutativityAddVertexAdjacentEdgeComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1/*, [PexAssumeNotNull]QuickGraph.UndirectedGraph<int, Edge<int>> g2*/, int node1, int node2, int index)
        {
            //PexSymbolicValue.Minimize(node1);
            PexAssume.IsTrue(node1 > -11 &&  node1 < 11);
            PexAssume.IsTrue(node2 > -11 && node2 < 11);
            PexAssume.IsTrue(index >= 0 && index <= 11);
            UndirectedGraph<int, Edge<int>> g2 = g1.Clone();
            UndirectedGraphEqualityComparer eq1 = new UndirectedGraphEqualityComparer();
            //PexAssume.IsTrue(eq1.Equals(g1, g2) && !PexAssume.ReferenceEquals(g1,g2));
            EdgeEqualityComparer eqc2 = new EdgeEqualityComparer();
            //PexAssume.IsTrue(node1 > -11 && node1 < 11);
            

            PexObserve.ValueForViewing("$input_Node1", node1);
            PexObserve.ValueForViewing("$input_Node2", node2);
            PexObserve.ValueForViewing("$input_Index", index);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode1", g1.ContainsVertex(node1));
            PexObserve.ValueForViewing("$input_ContainsNode2", g1.ContainsVertex(node2));
            
            //AssumePrecondition.IsTrue(true);
            AssumePrecondition.IsTrue(true);
            
            
            g1.AddVertex(node1);
            Edge<int> ae1 = g1.AdjacentEdge(node2, index);

            Edge<int> ae2 = g2.AdjacentEdge(node2, index);
            g2.AddVertex(node1);

            //NotpAssume.IsTrue(eqc2.Equals(ae1, ae2) && eq1.Equals(g1, g2));
            //try{PexAssert.IsTrue(false);}catch{return;}
            PexAssert.IsTrue(eqc2.Equals(ae1,ae2) && eq1.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityAddVertexIsVerticesEmptyComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node)
        {
            UndirectedGraph<int, Edge<int>> g2 = g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();
            PexAssume.IsTrue(node > -101 && node < 101);

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));
            //try
            //{
                AssumePrecondition.IsTrue(true);
            //}
            //catch { throw new PexAssumeFailedException(); }
            bool ive1 = true, ive2 = true;

            g1.AddVertex(node);
            ive1 = g1.IsVerticesEmpty;

            ive2 = g2.IsVerticesEmpty;
            g2.AddVertex(node);

            //NotpAssume.IsTrue(ive1 == ive2 && eq.Equals(g1, g2));
            //try{PexAssert.IsTrue(false);}catch{return;}
            PexAssert.IsTrue(ive1 == ive2 && eq.Equals(g1, g2));
        }

        [PexMethod] // All exceptions
        public void PUT_CommutativityAddVertexVertexCountComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));
            //try
            //{
                AssumePrecondition.IsTrue(  false);
            //}
            //catch { throw new PexAssumeFailedException(); }
            int vc1 = 0, vc2 = 0;

            g1.AddVertex(node);
            vc1 = g1.VertexCount;

            vc2 = g2.VertexCount;
            g2.AddVertex(node);

            NotpAssume.IsTrue(vc1 == vc2 && eq.Equals(g1, g2));
            try{PexAssert.IsTrue(false);}catch{return;}
            PexAssert.IsTrue(vc1 == vc2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityAddVertexContainsVertexComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node1, int node2)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();
            //PexAssume.IsTrue(node1 > -11 && node1 < 11);
            //PexAssume.IsTrue(node2 > -11 && node2 < 11);

            PexObserve.ValueForViewing("$input_Node1", node1);
            PexObserve.ValueForViewing("$input_Node2", node2);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode1", g1.ContainsVertex(node1));
            PexObserve.ValueForViewing("$input_ContainsNode2", g1.ContainsVertex(node2));
            //try
            //{
                AssumePrecondition.IsTrue(  ((!(node1 == node2))) );
            //}
            //catch { throw new PexAssumeFailedException(); }
            bool cv1 = true, cv2 = true;

            g1.AddVertex(node1);
            cv1 = g1.ContainsVertex(node2);

            cv2 = g2.ContainsVertex(node2);
            g2.AddVertex(node1);

            NotpAssume.IsTrue(cv1 == cv2 && eq.Equals(g1, g2));
            try{PexAssert.IsTrue(false);}catch{return;}
            PexAssert.IsTrue(cv1 == cv2 && eq.Equals(g1, g2));
        }

        [PexMethod] 
        public void PUT_CommutativityAddVertexAddEdgeComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node, int src, int tar/*, [PexAssumeNotNull]Edge<int> e*/)
        {
            Edge<int> e = new Edge<int>(src, tar);
            UndirectedGraph<int, Edge<int>> g2 = g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();
            PexAssume.IsTrue(node > -11 && node < 11);
            PexAssume.IsTrue(e.Source > -11 && e.Source < 11);
            PexAssume.IsTrue(e.Target > -11 && e.Target < 11);

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_SourceNode", e.Source);
            PexObserve.ValueForViewing("$input_TargetNode", e.Target);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));
            PexObserve.ValueForViewing("$input_ContainsNodeSrc", g1.ContainsVertex(e.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar", g1.ContainsVertex(e.Target));
            PexObserve.ValueForViewing("$input_ContainsEdge", g1.ContainsVertex(e.Source) && g1.ContainsVertex(e.Target) ? g1.ContainsEdge(e.Source, e.Target) : false);
            //try
            //{
                AssumePrecondition.IsTrue( (g1.ContainsEdge(e) && (((!(g1.ContainsVertex(node))))))  );
            //}
            //catch { throw new PexAssumeFailedException(); }
            bool ae1 = true, ae2 = true;

            ae1 = g1.AddEdge(e);
            g1.AddVertex(node);

            g2.AddVertex(node);
            ae2 = g2.AddEdge(e);

            NotpAssume.IsTrue(ae1 == ae2 && eq.Equals(g1, g2));
            try{PexAssert.IsTrue(false);}catch{return;}
            PexAssert.IsTrue(ae1 == ae2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityAddVertexAddEdgeRangeComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node, [PexAssumeNotNull]int[] srcs, [PexAssumeNotNull]int[] tars)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexAssume.IsTrue(srcs.Length == tars.Length && srcs.Length < 11);

            List<Edge<int>> edges = new List<Edge<int>>();
            for (int i = 0; i < srcs.Length; i++)
            {
                edges.Add(new Edge<int>(srcs[i], tars[i]));
            }

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AddEdgesCount", srcs.Length);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));
            PexObserve.ValueForViewing("$input_EdgeContainsNode", srcs.Contains(node) | tars.Contains(node));
            //try
            //{
                AssumePrecondition.IsTrue(!(true));
            //}
            //catch { throw new PexAssumeFailedException(); }
            g1.AddVertex(node);
            g1.AddEdgeRange(edges);

            g2.AddEdgeRange(edges);
            g2.AddVertex(node);

            NotpAssume.IsTrue(eq.Equals(g1, g2));
            try{PexAssert.IsTrue(false);}catch{return;}
            PexAssert.IsTrue(eq.Equals(g1, g2));
        }


        [PexMethod]
        public void PUT_CommutativityAddVertexRemoveEdgeComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node, int src, int tar)
        {
            Edge<int> e = new Edge<int>(src, tar);
            UndirectedGraph<int, Edge<int>> g2 = g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();
            PexAssume.IsTrue(node > -11 && node < 11);
            PexAssume.IsTrue(e.Source > -11 && e.Source < 11);
            PexAssume.IsTrue(e.Target > -11 && e.Target < 11);

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_SourceNode", e.Source);
            PexObserve.ValueForViewing("$input_TargetNode", e.Target);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));
            PexObserve.ValueForViewing("$input_ContainsNodeSrc", g1.ContainsVertex(e.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar", g1.ContainsVertex(e.Target));
            PexObserve.ValueForViewing("$input_ContainsEdge", g1.ContainsVertex(e.Source) && g1.ContainsVertex(e.Target) ? g1.ContainsEdge(e.Source, e.Target) : false);
            
            AssumePrecondition.IsTrue(true);

            bool re1 = true, re2 = true;

            g1.AddVertex(node);
            re1 = g1.RemoveEdge(e);

            re2 = g2.RemoveEdge(e);
            g2.AddVertex(node);

            NotpAssume.IsTrue(re1 == re2 && eq.Equals(g1, g2));
            try{PexAssert.IsTrue(false);}catch{return;}
            PexAssert.IsTrue(re1 == re2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityAddVertexRemoveEdgesComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node, [PexAssumeNotNull]int[] srcs, [PexAssumeNotNull]int[] tars)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexAssume.IsTrue(srcs.Length == tars.Length && srcs.Length < 11);

            List<Edge<int>> edges = new List<Edge<int>>();
            for (int i = 0; i < srcs.Length; i++)
            {
                edges.Add(new Edge<int>(srcs[i], tars[i]));
            }

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_RemoveEdgesCount", srcs.Length);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));
            PexObserve.ValueForViewing("$input_EdgeContainsNode", srcs.Contains(node) | tars.Contains(node));

            AssumePrecondition.IsTrue(!(true));

            int re1 = 0, re2 = 0;

            g1.AddVertex(node);
            re1 = g1.RemoveEdges(edges);

            re2 = g2.RemoveEdges(edges);
            g2.AddVertex(node);

            NotpAssume.IsTrue(re1 == re2 && eq.Equals(g1,g2));
            try{PexAssert.IsTrue(false);}catch{return;}
            PexAssert.IsTrue(re1 == re2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityAddVertexIsEdgesEmptyComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));

            AssumePrecondition.IsTrue(  ((!(g1.ContainsVertex(node)))) );

            bool iee1 = true, iee2 = true;

            g1.AddVertex(node);
            iee1 = g1.IsEdgesEmpty;

            iee2 = g2.IsEdgesEmpty;
            g2.AddVertex(node);

            NotpAssume.IsTrue(iee1 == iee2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(iee1 == iee2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityAddVertexEdgeCountComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));

            AssumePrecondition.IsTrue(  ((!(g1.ContainsVertex(node)))) );

            int ec1 = 0, ec2 = 0;

            g1.AddVertex(node);
            ec1 = g1.EdgeCount;

            ec2 = g2.EdgeCount;
            g2.AddVertex(node);

            NotpAssume.IsTrue(ec1 == ec2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(ec1 == ec2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityAddVertexAdjacentEdgesComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node1, int node2)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node1", node1);
            PexObserve.ValueForViewing("$input_Node2", node2);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode1", g1.ContainsVertex(node1));
            PexObserve.ValueForViewing("$input_ContainsNode2", g1.ContainsVertex(node2));


            AssumePrecondition.IsTrue( (g1.ContainsVertex(node2) && (((!(g1.ContainsVertex(node1))))))  );

            g1.AddVertex(node1);
            var ae1 = g1.AdjacentEdges(node2);

            var ae2 = g2.AdjacentEdges(node2);
            g2.AddVertex(node1);

            bool equal = true;

            if (ae1.Count() != ae2.Count())
            {
                equal = false;
            }

            for (int i = 0; i < ae1.Count(); i++)
            {
                if (ae1.ElementAt(i).Source != ae2.ElementAt(i).Source || ae1.ElementAt(i).Source != ae2.ElementAt(i).Source)
                {
                    equal = false;
                }
            }

            NotpAssume.IsTrue(equal && eq.Equals(g1, g2));
            PexAssert.IsTrue(equal && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityAddVertexAdjacentDegreeComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node1, int node2)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node1", node1);
            PexObserve.ValueForViewing("$input_Node2", node2);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode1", g1.ContainsVertex(node1));
            PexObserve.ValueForViewing("$input_ContainsNode2", g1.ContainsVertex(node2));
           

            AssumePrecondition.IsTrue( (g1.ContainsVertex(node2) && (((!(g1.ContainsVertex(node1))))))  );

            int ad1 = 0, ad2 = 0;

            g1.AddVertex(node1);
            ad1 = g1.AdjacentDegree(node2);

            ad2 = g2.AdjacentDegree(node2);
            g2.AddVertex(node1);

            NotpAssume.IsTrue(ad1 == ad2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(ad1 == ad2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityAddVertexIsAdjacentEdgesEmptyComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node1, int node2)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node1", node1);
            PexObserve.ValueForViewing("$input_Node2", node2);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode1", g1.ContainsVertex(node1));
            PexObserve.ValueForViewing("$input_ContainsNode2", g1.ContainsVertex(node2));


            AssumePrecondition.IsTrue( (g1.ContainsVertex(node2) && (((!(g1.ContainsVertex(node1))))))  );

            bool iaee1 = true, iaee2 = true;

            g1.AddVertex(node1);
            iaee1 = g1.IsAdjacentEdgesEmpty(node2);

            iaee2 = g2.IsAdjacentEdgesEmpty(node2);
            g2.AddVertex(node1);

            NotpAssume.IsTrue(iaee1 == iaee2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(iaee1 == iaee2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityRemoveVertexRemoveVertexComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node1, int node2)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node1", node1);
            PexObserve.ValueForViewing("$input_Node2", node2);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode1", g1.ContainsVertex(node1));
            PexObserve.ValueForViewing("$input_ContainsNode2", g1.ContainsVertex(node2));

            AssumePrecondition.IsTrue(  ((!(node1 == node2)) && ((g1.ContainsVertex(node1) && ((g1.ContainsVertex(node2)))))) );

            bool rv11 = true, rv12 = true, rv21 = true, rv22 = true;

            rv11 = g1.RemoveVertex(node1);
            rv12 = g1.RemoveVertex(node2);
            
            rv22 = g2.RemoveVertex(node2);
            rv21 = g2.RemoveVertex(node1);

            NotpAssume.IsTrue(rv11 == rv21 && rv12 == rv22 && eq.Equals(g1, g2));
            PexAssert.IsTrue(rv11 == rv21 && rv12 == rv22 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityRemoveVertexClearAdjacentEdgesComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node1, int node2)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node1", node1);
            PexObserve.ValueForViewing("$input_Node2", node2);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode1", g1.ContainsVertex(node1));
            PexObserve.ValueForViewing("$input_ContainsNode2", g1.ContainsVertex(node2));

            AssumePrecondition.IsTrue(  false);

            bool rv1 = true, rv2 = true;

            rv1 = g1.RemoveVertex(node1);
            g1.ClearAdjacentEdges(node2);
            
            g2.ClearAdjacentEdges(node2);
            rv2 = g2.RemoveVertex(node1);

            NotpAssume.IsTrue(rv1 == rv2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(rv1 == rv2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityRemoveVertexContainsEdgeComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node, [PexAssumeNotNull]Edge<int> e)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_SourceNode", e.Source);
            PexObserve.ValueForViewing("$input_TargetNode", e.Target);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));
            PexObserve.ValueForViewing("$input_ContainsNodeSrc", g1.ContainsVertex(e.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar", g1.ContainsVertex(e.Target));
            PexObserve.ValueForViewing("$input_ContainsEdge", g1.ContainsVertex(e.Source) && g1.ContainsVertex(e.Target) ? g1.ContainsEdge(e.Source, e.Target) : false);

            AssumePrecondition.IsTrue(true);

            bool rv1 = true, rv2 = true, ce1 = true, ce2 = true;

            rv1 = g1.RemoveVertex(node);
            ce1 = g1.ContainsEdge(e.Source, e.Target);
            
            ce2 = g2.ContainsEdge(e.Source, e.Target);
            rv2 = g2.RemoveVertex(node);

            //NotpAssume.IsTrue(rv1 == rv2 && ce1 == ce2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(rv1 == rv2 && ce1 == ce2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityRemoveVertexAdjacentEdgeComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node1, int node2, int index)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq1 = new UndirectedGraphEqualityComparer();
            EdgeEqualityComparer eq2 = new EdgeEqualityComparer();

            PexObserve.ValueForViewing("$input_Node1", node1);
            PexObserve.ValueForViewing("$input_Node2", node2);
            PexObserve.ValueForViewing("$input_Index", index);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount); 
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode1", g1.ContainsVertex(node1));
            PexObserve.ValueForViewing("$input_ContainsNode2", g1.ContainsVertex(node2));
           

            AssumePrecondition.IsTrue(  false);

            bool rv1 = true, rv2 = true;

            rv1 = g1.RemoveVertex(node1);
            var ae1 = g1.AdjacentEdge(node2, index);

            var ae2 = g2.AdjacentEdge(node2, index);
            rv2 = g2.RemoveVertex(node1);

            NotpAssume.IsTrue(rv1 == rv2 && eq2.Equals(ae1, ae2) && eq1.Equals(g1, g2));
            PexAssert.IsTrue(rv1 == rv2 && eq2.Equals(ae1, ae2) && eq1.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityRemoveVertexIsVerticesEmptyComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));

            AssumePrecondition.IsTrue(  false);

            bool rv1 = true, rv2 = true, ive1 = true, ive2 = true;

            rv1 = g1.RemoveVertex(node);
            ive1 = g1.IsVerticesEmpty;

            ive2 = g2.IsVerticesEmpty;
            rv2 = g2.RemoveVertex(node);

            NotpAssume.IsTrue(rv1 == rv2 && ive1 == ive2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(rv1 == rv2 && ive1 == ive2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityRemoveVertexVertexCountComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));

            AssumePrecondition.IsTrue(  false);

            bool rv1 = true, rv2 = true;
            int vc1 = 0, vc2 = 0;

            rv1 = g1.RemoveVertex(node);
            vc1 = g1.VertexCount;

            vc2 = g2.VertexCount;
            rv2 = g2.RemoveVertex(node);

            NotpAssume.IsTrue(rv1 == rv2 && vc1 == vc2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(rv1 == rv2 && vc1 == vc2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityRemoveVertexContainsVertexComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node1, int node2)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node1", node1);
            PexObserve.ValueForViewing("$input_Node2", node2);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode1", g1.ContainsVertex(node1));
            PexObserve.ValueForViewing("$input_ContainsNode2", g1.ContainsVertex(node2));

            AssumePrecondition.IsTrue( (g1.IsEdgesEmpty && (((!(node1 == node2)))))  );

            bool rv1 = true, rv2 = true, cv1 = true, cv2 = true;

            rv1 = g1.RemoveVertex(node1);
            cv1 = g1.ContainsVertex(node2);
            
            cv2 = g2.ContainsVertex(node2);
            rv2 = g2.RemoveVertex(node1);

            NotpAssume.IsTrue(rv1 == rv2 && cv1 == cv2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(rv1 == rv2 && cv1 == cv2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityRemoveVertexAddEdgeComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node, [PexAssumeNotNull]Edge<int> e)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_SourceNode", e.Source);
            PexObserve.ValueForViewing("$input_TargetNode", e.Target);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));
            PexObserve.ValueForViewing("$input_ContainsNodeSrc", g1.ContainsVertex(e.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar", g1.ContainsVertex(e.Target));
            PexObserve.ValueForViewing("$input_ContainsEdge", g1.ContainsVertex(e.Source) && g1.ContainsVertex(e.Target) ? g1.ContainsEdge(e.Source, e.Target) : false);

            AssumePrecondition.IsTrue(  false);

            bool rv1 = true, rv2 = true, ae1 = true, ae2 = true;

            rv1 = g1.RemoveVertex(node);
            ae1 = g1.AddEdge(e);
            
            ae2 = g2.AddEdge(e);
            rv2 = g2.RemoveVertex(node);

            NotpAssume.IsTrue(rv1 == rv2 && ae1 == ae2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(rv1 == rv2 && ae1 == ae2 && eq.Equals(g1, g2));
        }


        [PexMethod]
        public void PUT_CommutativityRemoveVertexAddEdgeRangeComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node, [PexAssumeNotNull]int[] srcs, [PexAssumeNotNull]int[] tars)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexAssume.IsTrue(srcs.Length == tars.Length && srcs.Length < 11);

            List<Edge<int>> edges = new List<Edge<int>>();
            for (int i = 0; i < srcs.Length; i++)
            {
                edges.Add(new Edge<int>(srcs[i], tars[i]));
            }

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AddEdgesCount", srcs.Length);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));
            PexObserve.ValueForViewing("$input_EdgeContainsNode", srcs.Contains(node) | tars.Contains(node));

            AssumePrecondition.IsTrue(!(true));

            bool rv1 = true, rv2 = true;

            rv1 = g1.RemoveVertex(node);
            g1.AddEdgeRange(edges);
            g2.AddEdgeRange(edges);
            rv2 = g2.RemoveVertex(node);

            NotpAssume.IsTrue(rv1 == rv2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(rv1 == rv2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityRemoveVertexRemoveEdgeComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node, [PexAssumeNotNull]Edge<int> e)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_SourceNode", e.Source);
            PexObserve.ValueForViewing("$input_TargetNode", e.Target);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));
            PexObserve.ValueForViewing("$input_ContainsNodeSrc", g1.ContainsVertex(e.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar", g1.ContainsVertex(e.Target));
            PexObserve.ValueForViewing("$input_ContainsEdge", g1.ContainsVertex(e.Source) && g1.ContainsVertex(e.Target) ? g1.ContainsEdge(e.Source, e.Target) : false);

            AssumePrecondition.IsTrue(  false);

            bool rv1 = true, rv2 = true, re1 = true, re2 = true;

            rv1 = g1.RemoveVertex(node);
            re1 = g1.RemoveEdge(e);
            
            re2 = g2.RemoveEdge(e);
            rv2 = g2.RemoveVertex(node);

            NotpAssume.IsTrue(rv1 == rv2 && re1 == re2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(rv1 == rv2 && re1 == re2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityRemoveVertexRemoveEdgesComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node, [PexAssumeNotNull]int[] srcs, [PexAssumeNotNull]int[] tars)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexAssume.IsTrue(srcs.Length == tars.Length && srcs.Length < 11);

            List<Edge<int>> edges = new List<Edge<int>>();
            for (int i = 0; i < srcs.Length; i++)
            {
                edges.Add(new Edge<int>(srcs[i], tars[i]));
            }

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_RemoveEdgesCount", srcs.Length);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_EdgeContainsNode", srcs.Contains(node) | tars.Contains(node));

            AssumePrecondition.IsTrue(!(true));

            bool rv1 = true, rv2 = true;
            int re1 = 0, re2 = 0;

            rv1 = g1.RemoveVertex(node);
            re1 = g1.RemoveEdges(edges);

            re2 = g2.RemoveEdges(edges);
            rv2 = g2.RemoveVertex(node);

            NotpAssume.IsTrue(eq.Equals(g1, g2));
            PexAssert.IsTrue(rv1 == rv2 && re1 == re2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityRemoveVertexIsEdgesEmptyComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));

            AssumePrecondition.IsTrue( (g1.IsEdgesEmpty && (((!(g1.IsVerticesEmpty)))))  );

            bool rv1 = true, rv2 = true, iee1 = true, iee2 = true;

            rv1 = g1.RemoveVertex(node);
            iee1 = g1.IsEdgesEmpty;

            iee2 = g2.IsEdgesEmpty;
            rv2 = g2.RemoveVertex(node);

            NotpAssume.IsTrue(rv1 == rv2 && iee1 == iee2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(rv1 == rv2 && iee1 == iee2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityRemoveVertexEdgeCountComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree", g1.ContainsVertex(node) ? g1.AdjacentDegree(node) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));

            AssumePrecondition.IsTrue( (g1.IsEdgesEmpty && ((g1.ContainsVertex(node))))  );

            bool rv1 = true, rv2 = true;
            int ec1 = 0, ec2 = 0;

            rv1 = g1.RemoveVertex(node);
            ec1 = g1.EdgeCount;
            
            ec2 = g2.EdgeCount;
            rv2 = g2.RemoveVertex(node);

            NotpAssume.IsTrue(rv1 == rv2 && ec1 == ec2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(rv1 == rv2 && ec1 == ec2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityRemoveVertexAdjacentEdgesComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node1, int node2)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node1", node1);
            PexObserve.ValueForViewing("$input_Node2", node2);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree1", g1.ContainsVertex(node1) ? g1.AdjacentDegree(node1) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegree2", g1.ContainsVertex(node2) ? g1.AdjacentDegree(node2) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode1", g1.ContainsVertex(node1));
            PexObserve.ValueForViewing("$input_ContainsNode2", g1.ContainsVertex(node2));

            AssumePrecondition.IsTrue(  false);

            bool rv1 = true, rv2 = true;

            rv1 = g1.RemoveVertex(node1);
            var ae1 = g1.AdjacentEdges(node2);
            
            var ae2 = g2.AdjacentEdges(node2);
            rv2 = g2.RemoveVertex(node1);

            bool equal = true;

            if (ae1.Count() != ae2.Count())
            {
                equal = false;
            }

            for (int i = 0; i < ae1.Count(); i++)
            {
                if (ae1.ElementAt(i).Source != ae2.ElementAt(i).Source || ae1.ElementAt(i).Source != ae2.ElementAt(i).Source)
                {
                    equal = false;
                }
            }

            NotpAssume.IsTrue(rv1 == rv2 && equal && eq.Equals(g1, g2));
            PexAssert.IsTrue(rv1 == rv2 && equal && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityRemoveVertexAdjacentDegreeComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node1, int node2)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node1", node1);
            PexObserve.ValueForViewing("$input_Node2", node2);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree1", g1.ContainsVertex(node1) ? g1.AdjacentDegree(node1) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegree2", g1.ContainsVertex(node2) ? g1.AdjacentDegree(node2) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode1", g1.ContainsVertex(node1));
            PexObserve.ValueForViewing("$input_ContainsNode2", g1.ContainsVertex(node2));

            AssumePrecondition.IsTrue(  false);

            bool rv1 = true, rv2 = true;
            int ad1 = 0, ad2 = 0;

            rv1 = g1.RemoveVertex(node1);
            ad1 = g1.AdjacentDegree(node2);
            ad2 = g2.AdjacentDegree(node2);
            rv2 = g2.RemoveVertex(node1);

            NotpAssume.IsTrue(rv1 == rv2 && ad1 == ad2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(rv1 == rv2 && ad1 == ad2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityRemoveVertexIsAdjacentEdgesEmptyComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node1, int node2)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node1", node1);
            PexObserve.ValueForViewing("$input_Node2", node2);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree1", g1.ContainsVertex(node1) ? g1.AdjacentDegree(node1) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegree2", g1.ContainsVertex(node2) ? g1.AdjacentDegree(node2) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode1", g1.ContainsVertex(node1));
            PexObserve.ValueForViewing("$input_ContainsNode2", g1.ContainsVertex(node2));

            AssumePrecondition.IsTrue(  false);

            bool rv1 = true, rv2 = true, iaee1 = true, iaee2 = true;

            rv1 = g1.RemoveVertex(node1);
            iaee1 = g1.IsAdjacentEdgesEmpty(node2);
            iaee2 = g2.IsAdjacentEdgesEmpty(node2);
            rv2 = g2.RemoveVertex(node1);

            NotpAssume.IsTrue(rv1 ==rv2 && iaee1 == iaee2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(rv1 ==rv2 && iaee1 == iaee2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityClearAdjacentEdgesClearAdjacentEdgesComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node1, int node2)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node1", node1);
            PexObserve.ValueForViewing("$input_Node2", node2);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree1", g1.ContainsVertex(node1) ? g1.AdjacentDegree(node1) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegree2", g1.ContainsVertex(node2) ? g1.AdjacentDegree(node2) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode1", g1.ContainsVertex(node1));
            PexObserve.ValueForViewing("$input_ContainsNode2", g1.ContainsVertex(node2));

            AssumePrecondition.IsTrue( (g1.IsEdgesEmpty && (((!(g1.IsVerticesEmpty)))))  );

            g1.ClearAdjacentEdges(node1);
            g1.ClearAdjacentEdges(node2);

            g2.ClearAdjacentEdges(node2);
            g2.ClearAdjacentEdges(node1);

            NotpAssume.IsTrue(eq.Equals(g1, g2));
            PexAssert.IsTrue(eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityClearAdjacentEdgesContainsEdgeComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node, [PexAssumeNotNull]Edge<int> e)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_SourceNode", e.Source);
            PexObserve.ValueForViewing("$input_TargetNode", e.Target);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNode", g1.ContainsVertex(node) ? g1.AdjacentDegree(node) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeSrc", g1.ContainsVertex(e.Source) ? g1.AdjacentDegree(e.Source) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeTar", g1.ContainsVertex(e.Target) ? g1.AdjacentDegree(e.Target) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));
            PexObserve.ValueForViewing("$input_ContainsNodeSrc", g1.ContainsVertex(e.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar", g1.ContainsVertex(e.Target));
            PexObserve.ValueForViewing("$input_ContainsEdge", g1.ContainsVertex(e.Source) && g1.ContainsVertex(e.Target) ? g1.ContainsEdge(e.Source, e.Target) : false);

            AssumePrecondition.IsTrue(true);

            bool ce1 = true, ce2 = true;

            g1.ClearAdjacentEdges(node);
            ce1 = g1.ContainsEdge(e.Source, e.Target);

            ce2 = g2.ContainsEdge(e.Source, e.Target);
            g2.ClearAdjacentEdges(node);

            //NotpAssume.IsTrue(ce1 == ce2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(ce1 == ce2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityClearAdjacentEdgesAdjacentEdgeComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node1, int node2, int index)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq1 = new UndirectedGraphEqualityComparer();
            EdgeEqualityComparer eq2 = new EdgeEqualityComparer();

            PexObserve.ValueForViewing("$input_Node1", node1);
            PexObserve.ValueForViewing("$input_Node2", node2);
            PexObserve.ValueForViewing("$input_Index", index);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree1", g1.ContainsVertex(node1) ? g1.AdjacentDegree(node1) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegree2", g1.ContainsVertex(node2) ? g1.AdjacentDegree(node2) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode1", g1.ContainsVertex(node1));
            PexObserve.ValueForViewing("$input_ContainsNode2", g1.ContainsVertex(node2));

            AssumePrecondition.IsTrue(true);

            g1.ClearAdjacentEdges(node1);
            var ae1 = g1.AdjacentEdge(node2, index);

            var ae2 = g2.AdjacentEdge(node2, index);
            g2.ClearAdjacentEdges(node1);

            //NotpAssume.IsTrue(eq2.Equals(ae1, ae2) && eq1.Equals(g1, g2));
            PexAssert.IsTrue(eq2.Equals(ae1, ae2) && eq1.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityClearAdjacentEdgesIsVerticesEmptyComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree", g1.ContainsVertex(node) ? g1.AdjacentDegree(node) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));

            AssumePrecondition.IsTrue(true);

            bool ive1 = true, ive2 = true;

            g1.ClearAdjacentEdges(node);
            ive1 = g1.IsVerticesEmpty;

            ive2 = g2.IsVerticesEmpty;
            g2.ClearAdjacentEdges(node);

            //NotpAssume.IsTrue(ive1 == ive2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(ive1 == ive2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityClearAdjacentEdgesVertexCountComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree", g1.ContainsVertex(node) ? g1.AdjacentDegree(node) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));

            AssumePrecondition.IsTrue(true);
            
            int vc1 = 0, vc2 = 0;

            g1.ClearAdjacentEdges(node);
            vc1 = g1.VertexCount;
            vc2 = g2.VertexCount;
            g2.ClearAdjacentEdges(node);

            //NotpAssume.IsTrue(vc1 == vc2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(vc1 == vc2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityClearAdjacentEdgesContainsVertexComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node1, int node2)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node1", node1);
            PexObserve.ValueForViewing("$input_Node2", node2);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree1", g1.ContainsVertex(node1) ? g1.AdjacentDegree(node1) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegree2", g1.ContainsVertex(node2) ? g1.AdjacentDegree(node2) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode1", g1.ContainsVertex(node1));
            PexObserve.ValueForViewing("$input_ContainsNode2", g1.ContainsVertex(node2));

            AssumePrecondition.IsTrue(true);

            bool cv1 = true, cv2 = true;

            g1.ClearAdjacentEdges(node1);
            cv1 = g1.ContainsVertex(node2);
            cv2 = g2.ContainsVertex(node2);
            g2.ClearAdjacentEdges(node1);

            //NotpAssume.IsTrue(cv1 == cv2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(cv1 == cv2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityClearAdjacentEdgesAddEdgeComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node, [PexAssumeNotNull]Edge<int> e)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_SourceNode", e.Source);
            PexObserve.ValueForViewing("$input_TargetNode", e.Target);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNode", g1.ContainsVertex(node) ? g1.AdjacentDegree(node) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeSrc", g1.ContainsVertex(e.Source) ? g1.AdjacentDegree(e.Source) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeTar", g1.ContainsVertex(e.Target) ? g1.AdjacentDegree(e.Target) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));
            PexObserve.ValueForViewing("$input_ContainsNodeSrc", g1.ContainsVertex(e.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar", g1.ContainsVertex(e.Target));
            PexObserve.ValueForViewing("$input_ContainsEdge", g1.ContainsVertex(e.Source) && g1.ContainsVertex(e.Target) ? g1.ContainsEdge(e.Source, e.Target) : false);

            AssumePrecondition.IsTrue(true);

            bool ae1 = true, ae2 = true;

            g1.ClearAdjacentEdges(node);
            ae1 = g1.AddEdge(e);

            ae2 = g2.AddEdge(e);
            g2.ClearAdjacentEdges(node);

            //NotpAssume.IsTrue(ae1 == ae2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(ae1 == ae2 && eq.Equals(g1, g2));
        }


        [PexMethod]
        public void PUT_CommutativityClearAdjacentEdgesAddEdgeRangeComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node, [PexAssumeNotNull]int[] srcs, [PexAssumeNotNull]int[] tars)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexAssume.IsTrue(srcs.Length == tars.Length && srcs.Length < 11);

            List<Edge<int>> edges = new List<Edge<int>>();
            for (int i = 0; i < srcs.Length; i++)
            {
                edges.Add(new Edge<int>(srcs[i], tars[i]));
            }

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree", g1.ContainsVertex(node) ? g1.AdjacentDegree(node) : 0);
            PexObserve.ValueForViewing("$input_AddEdgesCount", srcs.Length);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));
            PexObserve.ValueForViewing("$input_EdgeContainsNode", srcs.Contains(node) | tars.Contains(node));

            AssumePrecondition.IsTrue(true);

            g1.ClearAdjacentEdges(node);
            g1.AddEdgeRange(edges);

            g2.AddEdgeRange(edges);
            g2.ClearAdjacentEdges(node);

            //NotpAssume.IsTrue(eq.Equals(g1, g2));
            PexAssert.IsTrue(eq.Equals(g1, g2));
        }


        [PexMethod]
        public void PUT_CommutativityClearAdjacentEdgesRemoveEdgeComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node, [PexAssumeNotNull]Edge<int> e)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_SourceNode", e.Source);
            PexObserve.ValueForViewing("$input_TargetNode", e.Target);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNode", g1.ContainsVertex(node) ? g1.AdjacentDegree(node) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeSrc", g1.ContainsVertex(e.Source) ? g1.AdjacentDegree(e.Source) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeTar", g1.ContainsVertex(e.Target) ? g1.AdjacentDegree(e.Target) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));
            PexObserve.ValueForViewing("$input_ContainsNodeSrc", g1.ContainsVertex(e.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar", g1.ContainsVertex(e.Target));
            PexObserve.ValueForViewing("$input_ContainsEdge", g1.ContainsVertex(e.Source) && g1.ContainsVertex(e.Target) ? g1.ContainsEdge(e.Source, e.Target) : false);

            AssumePrecondition.IsTrue(true);

            bool re1 = true, re2 = true;

            g1.ClearAdjacentEdges(node);
            re1 = g1.RemoveEdge(e);

            re2 = g2.RemoveEdge(e);
            g2.ClearAdjacentEdges(node);

            //NotpAssume.IsTrue(re1 == re2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(re1 == re2 && eq.Equals(g1, g2));
        }


        [PexMethod]
        public void PUT_CommutativityClearAdjacentEdgesRemoveEdgesComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node, [PexAssumeNotNull]int[] srcs, [PexAssumeNotNull]int[] tars)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexAssume.IsTrue(srcs.Length == tars.Length && srcs.Length < 11);

            List<Edge<int>> edges = new List<Edge<int>>();
            for (int i = 0; i < srcs.Length; i++)
            {
                edges.Add(new Edge<int>(srcs[i], tars[i]));
            }

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_RemoveEdgesCount", srcs.Length);
            PexObserve.ValueForViewing("$input_AdjacentDegree", g1.ContainsVertex(node) ? g1.AdjacentDegree(node) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));
            PexObserve.ValueForViewing("$input_EdgeContainsNode", srcs.Contains(node) | tars.Contains(node));

            AssumePrecondition.IsTrue(true);

            int re1 = 0, re2 = 0;

            g1.ClearAdjacentEdges(node);
            re1 = g1.RemoveEdges(edges);

            re2 = g2.RemoveEdges(edges);
            g2.ClearAdjacentEdges(node);

            //NotpAssume.IsTrue(re1 == re2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(re1 == re2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityClearAdjacentEdgesIsEdgesEmptyComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree", g1.ContainsVertex(node) ? g1.AdjacentDegree(node) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));

            AssumePrecondition.IsTrue(true);

            bool iee1 = true, iee2 = true;

            g1.ClearAdjacentEdges(node);
            iee1 = g1.IsEdgesEmpty;

            iee2 = g2.IsEdgesEmpty;
            g2.ClearAdjacentEdges(node);

            //NotpAssume.IsTrue(iee1 == iee2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(iee1 == iee2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityClearAdjacentEdgesEdgeCountComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree", g1.ContainsVertex(node) ? g1.AdjacentDegree(node) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));

            AssumePrecondition.IsTrue(true);

            int ec1 = 0, ec2 = 0;

            g1.ClearAdjacentEdges(node);
            ec1 = g1.EdgeCount;

            ec2 = g2.EdgeCount;
            g2.ClearAdjacentEdges(node);

            //NotpAssume.IsTrue(ec1 == ec2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(ec1 == ec2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityClearAdjacentEdgesAdjacentEdgesComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node1, int node2)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node1", node1);
            PexObserve.ValueForViewing("$input_Node2", node2);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree1", g1.ContainsVertex(node1) ? g1.AdjacentDegree(node1) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegree2", g1.ContainsVertex(node2) ? g1.AdjacentDegree(node2) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode1", g1.ContainsVertex(node1));
            PexObserve.ValueForViewing("$input_ContainsNode2", g1.ContainsVertex(node2));

            AssumePrecondition.IsTrue(true);

            g1.ClearAdjacentEdges(node1);
            var ae1 = g1.AdjacentEdges(node2);

            var ae2 = g2.AdjacentEdges(node2);
            g2.ClearAdjacentEdges(node1);

            bool equal = true;

            if (ae1.Count() != ae2.Count())
            {
                equal = false;
            }

            for (int i = 0; i < ae1.Count(); i++)
            {
                if (ae1.ElementAt(i).Source != ae2.ElementAt(i).Source || ae1.ElementAt(i).Source != ae2.ElementAt(i).Source)
                {
                    equal = false;
                }
            }

            //NotpAssume.IsTrue(equal && eq.Equals(g1, g2));
            PexAssert.IsTrue(equal && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityClearAdjacentEdgesAdjacentDegreeComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node1, int node2)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node1", node1);
            PexObserve.ValueForViewing("$input_Node2", node2);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree1", g1.ContainsVertex(node1) ? g1.AdjacentDegree(node1) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegree2", g1.ContainsVertex(node2) ? g1.AdjacentDegree(node2) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode1", g1.ContainsVertex(node1));
            PexObserve.ValueForViewing("$input_ContainsNode2", g1.ContainsVertex(node2));

            AssumePrecondition.IsTrue(true);

            int ad1 = 0, ad2 = 0;

            g1.ClearAdjacentEdges(node1);
            ad1 = g1.AdjacentDegree(node2);
            
            ad2 = g2.AdjacentDegree(node2);
            g2.ClearAdjacentEdges(node1);

            //NotpAssume.IsTrue(ad1 == ad2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(ad1 == ad2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityClearAdjacentEdgesIsAdjacentEdgesEmptyComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node1, int node2)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node1", node1);
            PexObserve.ValueForViewing("$input_Node2", node2);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree1", g1.ContainsVertex(node1) ? g1.AdjacentDegree(node1) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegree2", g1.ContainsVertex(node2) ? g1.AdjacentDegree(node2) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode1", g1.ContainsVertex(node1));
            PexObserve.ValueForViewing("$input_ContainsNode2", g1.ContainsVertex(node2));

            AssumePrecondition.IsTrue(true);

            bool iaee1 = true, iaee2 = true;

            g1.ClearAdjacentEdges(node1);
            iaee1 = g1.IsAdjacentEdgesEmpty(node2);
            
            iaee2 = g2.IsAdjacentEdgesEmpty(node2);
            g2.ClearAdjacentEdges(node1);

            //NotpAssume.IsTrue(iaee1 == iaee2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(iaee1 == iaee2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityContainsEdgeContainsEdgeComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, [PexAssumeNotNull]Edge<int> e1, [PexAssumeNotNull]Edge<int> e2)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_SourceNode1", e1.Source);
            PexObserve.ValueForViewing("$input_TargetNode1", e1.Target);
            PexObserve.ValueForViewing("$input_SourceNode2", e2.Source);
            PexObserve.ValueForViewing("$input_TargetNode2", e2.Target);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeSrc1", g1.ContainsVertex(e1.Source) ? g1.AdjacentDegree(e1.Source) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeTar1", g1.ContainsVertex(e1.Target) ? g1.AdjacentDegree(e1.Target) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeSrc2", g1.ContainsVertex(e2.Source) ? g1.AdjacentDegree(e2.Source) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeTar2", g1.ContainsVertex(e2.Target) ? g1.AdjacentDegree(e2.Target) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNodeSrc1", g1.ContainsVertex(e1.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar1", g1.ContainsVertex(e1.Target));
            PexObserve.ValueForViewing("$input_ContainsNodeSrc2", g1.ContainsVertex(e2.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar2", g1.ContainsVertex(e2.Target));
            PexObserve.ValueForViewing("$input_ContainsEdge1", g1.ContainsVertex(e1.Source) && g1.ContainsVertex(e1.Target) ? g1.ContainsEdge(e1.Source, e1.Target) : false);
            PexObserve.ValueForViewing("$input_ContainsEdge2", g1.ContainsVertex(e2.Source) && g1.ContainsVertex(e2.Target) ? g1.ContainsEdge(e2.Source, e2.Target) : false);

            AssumePrecondition.IsTrue(true);

            bool ce11 = true, ce12 = true, ce21 = true, ce22 = true;

            ce11 = g1.ContainsEdge(e1.Source, e1.Target);
            ce12 = g1.ContainsEdge(e2.Source, e2.Target);

            ce22 = g2.ContainsEdge(e2.Source, e2.Target);
            ce21 = g2.ContainsEdge(e1.Source, e2.Target);

            //NotpAssume.IsTrue(ce11 == ce21 && ce12 == ce22 && eq.Equals(g1, g2));
            PexAssert.IsTrue(ce11 == ce21 && ce12 == ce22 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityContainsEdgeAdjacentEdgeComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, [PexAssumeNotNull]Edge<int> e, int node, int index)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq1 = new UndirectedGraphEqualityComparer();
            EdgeEqualityComparer eq2 = new EdgeEqualityComparer();

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_SourceNode", e.Source);
            PexObserve.ValueForViewing("$input_TargetNode", e.Target);
            PexObserve.ValueForViewing("$input_Index", index);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNode", g1.ContainsVertex(node) ? g1.AdjacentDegree(node) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeSrc", g1.ContainsVertex(e.Source) ? g1.AdjacentDegree(e.Source) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeTar", g1.ContainsVertex(e.Target) ? g1.AdjacentDegree(e.Target) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode1", g1.ContainsVertex(node));
            PexObserve.ValueForViewing("$input_ContainsNodeSrc", g1.ContainsVertex(e.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar", g1.ContainsVertex(e.Target));
            PexObserve.ValueForViewing("$input_ContainsEdge", g1.ContainsVertex(e.Source) && g1.ContainsVertex(e.Target) ? g1.ContainsEdge(e.Source, e.Target) : false);

            AssumePrecondition.IsTrue(true);

            bool ce1 = true, ce2 = true;

            ce1 = g1.ContainsEdge(e.Source, e.Target);
            var ae1 = g1.AdjacentEdge(node, index);

            var ae2 = g2.AdjacentEdge(node, index);
            ce2 = g2.ContainsEdge(e.Source, e.Target);

            //NotpAssume.IsTrue(eq2.Equals(ae1, ae2) && eq1.Equals(g1, g2)));
            PexAssert.IsTrue(eq2.Equals(ae1, ae2) && eq1.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityContainsEdgeIsVerticesEmptyComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, [PexAssumeNotNull]Edge<int> e)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_SourceNode", e.Source);
            PexObserve.ValueForViewing("$input_TargetNode", e.Target);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeSrc", g1.ContainsVertex(e.Source) ? g1.AdjacentDegree(e.Source) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeTar", g1.ContainsVertex(e.Target) ? g1.AdjacentDegree(e.Target) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNodeSrc", g1.ContainsVertex(e.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar", g1.ContainsVertex(e.Target));
            PexObserve.ValueForViewing("$input_ContainsEdge", g1.ContainsVertex(e.Source) && g1.ContainsVertex(e.Target) ? g1.ContainsEdge(e.Source, e.Target) : false);

            AssumePrecondition.IsTrue(true);

            bool ce1 = true, ce2 = true, ive1 = true, ive2 = true;

            ce1 = g1.ContainsEdge(e.Source, e.Target);
            ive1 = g1.IsVerticesEmpty;

            ive2 = g2.IsVerticesEmpty;
            ce2 = g2.ContainsEdge(e.Source, e.Target);

            //NotpAssume.IsTrue(ce1 == ce2 && ive1 == ive2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(ce1 == ce2 && ive1 == ive2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityContainsEdgeVertexCountComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, [PexAssumeNotNull]Edge<int> e)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_SourceNode", e.Source);
            PexObserve.ValueForViewing("$input_TargetNode", e.Target);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeSrc", g1.ContainsVertex(e.Source) ? g1.AdjacentDegree(e.Source) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeTar", g1.ContainsVertex(e.Target) ? g1.AdjacentDegree(e.Target) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNodeSrc", g1.ContainsVertex(e.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar", g1.ContainsVertex(e.Target));
            PexObserve.ValueForViewing("$input_ContainsEdge", g1.ContainsVertex(e.Source) && g1.ContainsVertex(e.Target) ? g1.ContainsEdge(e.Source, e.Target) : false);

            AssumePrecondition.IsTrue(true);

            bool ce1 = true, ce2 = true;
            int vc1 = 0, vc2 = 0;

            ce1 = g1.ContainsEdge(e.Source, e.Target);
            vc1 = g1.VertexCount;

            vc2 = g2.VertexCount;
            ce2 = g2.ContainsEdge(e.Source, e.Target);

            //NotpAssume.IsTrue(ce1 == ce2 && vc1 == vc2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(ce1 == ce2 && vc1 == vc2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityContainsEdgeContainsVertexComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, [PexAssumeNotNull]Edge<int> e, int node)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_SourceNode", e.Source);
            PexObserve.ValueForViewing("$input_TargetNode", e.Target);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNode", g1.ContainsVertex(node) ? g1.AdjacentDegree(node) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeSrc", g1.ContainsVertex(e.Source) ? g1.AdjacentDegree(e.Source) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeTar", g1.ContainsVertex(e.Target) ? g1.AdjacentDegree(e.Target) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));
            PexObserve.ValueForViewing("$input_ContainsNodeSrc", g1.ContainsVertex(e.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar", g1.ContainsVertex(e.Target));
            PexObserve.ValueForViewing("$input_ContainsEdge", g1.ContainsVertex(e.Source) && g1.ContainsVertex(e.Target) ? g1.ContainsEdge(e.Source, e.Target) : false);

            AssumePrecondition.IsTrue(true);

            bool ce1 = true, ce2 = true, cv1 = true, cv2 = true;

            ce1 = g1.ContainsEdge(e.Source, e.Target);
            cv1 = g1.ContainsVertex(node);

            cv2 = g2.ContainsVertex(node);
            ce2 = g2.ContainsEdge(e.Source, e.Target);

            //NotpAssume.IsTrue(ce1 == ce2 && cv1 == cv2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(ce1 == ce2 && cv1 == cv2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityContainsEdgeAddEdgeComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, [PexAssumeNotNull]Edge<int> e1, [PexAssumeNotNull]Edge<int> e2)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_SourceNode1", e1.Source);
            PexObserve.ValueForViewing("$input_TargetNode1", e1.Target);
            PexObserve.ValueForViewing("$input_SourceNode2", e2.Source);
            PexObserve.ValueForViewing("$input_TargetNode2", e2.Target);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeSrc1", g1.ContainsVertex(e1.Source) ? g1.AdjacentDegree(e1.Source) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeTar1", g1.ContainsVertex(e1.Target) ? g1.AdjacentDegree(e1.Target) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeSrc2", g1.ContainsVertex(e2.Source) ? g1.AdjacentDegree(e2.Source) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeTar2", g1.ContainsVertex(e2.Target) ? g1.AdjacentDegree(e2.Target) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNodeSrc1", g1.ContainsVertex(e1.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar1", g1.ContainsVertex(e1.Target));
            PexObserve.ValueForViewing("$input_ContainsNodeSrc2", g1.ContainsVertex(e2.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar2", g1.ContainsVertex(e2.Target));
            PexObserve.ValueForViewing("$input_ContainsEdge1", g1.ContainsVertex(e1.Source) && g1.ContainsVertex(e1.Target) ? g1.ContainsEdge(e1.Source, e1.Target) : false);
            PexObserve.ValueForViewing("$input_ContainsEdge2", g1.ContainsVertex(e2.Source) && g1.ContainsVertex(e2.Target) ? g1.ContainsEdge(e2.Source, e2.Target) : false);

            AssumePrecondition.IsTrue(true);

            bool ce1 = true, ce2 = true, ae1 = true, ae2 = true;

            ce1 = g1.ContainsEdge(e1.Source, e1.Target);
            ae1 = g1.AddEdge(e2);

            ae2 = g2.AddEdge(e2);
            ce2 = g2.ContainsEdge(e1.Source, e1.Target);

            //NotpAssume.IsTrue(ce1 == ce2 && ae1 == ae2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(ce1 == ce2 && ae1 == ae2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityContainsEdgeAddEdgeRangeComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, [PexAssumeNotNull]Edge<int> e, [PexAssumeNotNull]int[] srcs, [PexAssumeNotNull]int[] tars)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexAssume.IsTrue(srcs.Length == tars.Length && srcs.Length < 11);

            List<Edge<int>> edges = new List<Edge<int>>();
            for (int i = 0; i < srcs.Length; i++)
            {
                edges.Add(new Edge<int>(srcs[i], tars[i]));
            }

            PexObserve.ValueForViewing("$input_SourceNode", e.Source);
            PexObserve.ValueForViewing("$input_TargetNode", e.Target);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AddEdgesCount", srcs.Length);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeSrc", g1.ContainsVertex(e.Source) ? g1.AdjacentDegree(e.Source) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeTar", g1.ContainsVertex(e.Target) ? g1.AdjacentDegree(e.Target) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNodeSrc", g1.ContainsVertex(e.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar", g1.ContainsVertex(e.Target));
            PexObserve.ValueForViewing("$input_ContainsEdge", g1.ContainsVertex(e.Source) && g1.ContainsVertex(e.Target) ? g1.ContainsEdge(e.Source, e.Target) : false);

            AssumePrecondition.IsTrue(true);

            bool ce1 = true, ce2 = true;

            ce1 = g1.ContainsEdge(e.Source, e.Target);
            g1.AddEdgeRange(edges);

            g2.AddEdgeRange(edges);
            ce2 = g2.ContainsEdge(e.Source, e.Target);

            //NotpAssume.IsTrue(ce1 == ce2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(ce1 == ce2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityContainsEdgeRemoveEdgeComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, [PexAssumeNotNull]Edge<int> e1, [PexAssumeNotNull]Edge<int> e2)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_SourceNode1", e1.Source);
            PexObserve.ValueForViewing("$input_TargetNode1", e1.Target);
            PexObserve.ValueForViewing("$input_SourceNode2", e2.Source);
            PexObserve.ValueForViewing("$input_TargetNode2", e2.Target);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeSrc1", g1.ContainsVertex(e1.Source) ? g1.AdjacentDegree(e1.Source) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeTar1", g1.ContainsVertex(e1.Target) ? g1.AdjacentDegree(e1.Target) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeSrc2", g1.ContainsVertex(e2.Source) ? g1.AdjacentDegree(e2.Source) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeTar2", g1.ContainsVertex(e2.Target) ? g1.AdjacentDegree(e2.Target) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNodeSrc1", g1.ContainsVertex(e1.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar1", g1.ContainsVertex(e1.Target));
            PexObserve.ValueForViewing("$input_ContainsNodeSrc2", g1.ContainsVertex(e2.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar2", g1.ContainsVertex(e2.Target));
            PexObserve.ValueForViewing("$input_ContainsEdge1", g1.ContainsVertex(e1.Source) && g1.ContainsVertex(e1.Target) ? g1.ContainsEdge(e1.Source, e1.Target) : false);
            PexObserve.ValueForViewing("$input_ContainsEdge2", g1.ContainsVertex(e2.Source) && g1.ContainsVertex(e2.Target) ? g1.ContainsEdge(e2.Source, e2.Target) : false);

            AssumePrecondition.IsTrue(true);

            bool ce1 = true, ce2 = true, re1 = true, re2 = true;

            ce1 = g1.ContainsEdge(e1.Source, e1.Target);
            re1 = g1.RemoveEdge(e2);

            re2 = g2.RemoveEdge(e2);
            ce2 = g2.ContainsEdge(e1.Source, e1.Target);

            //NotpAssume.IsTrue(ce1 == ce2 && re1 == re2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(ce1 == ce2 && re1 == re2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityContainsEdgeRemoveEdgesComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, [PexAssumeNotNull]Edge<int> e, [PexAssumeNotNull]int[] srcs, [PexAssumeNotNull]int[] tars)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexAssume.IsTrue(srcs.Length == tars.Length && srcs.Length < 11);

            List<Edge<int>> edges = new List<Edge<int>>();
            for (int i = 0; i < srcs.Length; i++)
            {
                edges.Add(new Edge<int>(srcs[i], tars[i]));
            }

            PexObserve.ValueForViewing("$input_SourceNode", e.Source);
            PexObserve.ValueForViewing("$input_TargetNode", e.Target);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_RemoveEdgesCount", srcs.Length);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeSrc", g1.ContainsVertex(e.Source) ? g1.AdjacentDegree(e.Source) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeTar", g1.ContainsVertex(e.Target) ? g1.AdjacentDegree(e.Target) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNodeSrc", g1.ContainsVertex(e.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar", g1.ContainsVertex(e.Target));
            PexObserve.ValueForViewing("$input_ContainsEdge", g1.ContainsVertex(e.Source) && g1.ContainsVertex(e.Target) ? g1.ContainsEdge(e.Source, e.Target) : false);

            AssumePrecondition.IsTrue(true);

            bool ce1 = true, ce2 = true;
            int re1 = 0, re2 = 0;

            ce1 = g1.ContainsEdge(e.Source, e.Target);
            re1 = g1.RemoveEdges(edges);

            re2 = g2.RemoveEdges(edges);
            ce2 = g2.ContainsEdge(e.Source, e.Target);

            //NotpAssume.IsTrue(ce1 == ce2 && re1 == re2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(ce1 == ce2 && re1 == re2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityContainsEdgeIsEdgesEmptyComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, [PexAssumeNotNull]Edge<int> e)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_SourceNode", e.Source);
            PexObserve.ValueForViewing("$input_TargetNode", e.Target);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeSrc", g1.ContainsVertex(e.Source) ? g1.AdjacentDegree(e.Source) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeTar", g1.ContainsVertex(e.Target) ? g1.AdjacentDegree(e.Target) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNodeSrc", g1.ContainsVertex(e.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar", g1.ContainsVertex(e.Target));
            PexObserve.ValueForViewing("$input_ContainsEdge", g1.ContainsVertex(e.Source) && g1.ContainsVertex(e.Target) ? g1.ContainsEdge(e.Source, e.Target) : false);

            AssumePrecondition.IsTrue(true);

            bool ce1 = true, ce2 = true, iee1 = true, iee2 = true;

            ce1 = g1.ContainsEdge(e.Source, e.Target);
            iee1 = g1.IsEdgesEmpty;

            iee2 = g2.IsEdgesEmpty;
            ce2 = g2.ContainsEdge(e.Source, e.Target);

            //NotpAssume.IsTrue(ce1 == ce2 && iee1 == iee2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(ce1 == ce2 && iee1 == iee2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityContainsEdgeEdgeCountComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, [PexAssumeNotNull]Edge<int> e)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_SourceNode", e.Source);
            PexObserve.ValueForViewing("$input_TargetNode", e.Target);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeSrc", g1.ContainsVertex(e.Source) ? g1.AdjacentDegree(e.Source) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeTar", g1.ContainsVertex(e.Target) ? g1.AdjacentDegree(e.Target) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNodeSrc", g1.ContainsVertex(e.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar", g1.ContainsVertex(e.Target));
            PexObserve.ValueForViewing("$input_ContainsEdge", g1.ContainsVertex(e.Source) && g1.ContainsVertex(e.Target) ? g1.ContainsEdge(e.Source, e.Target) : false);

            AssumePrecondition.IsTrue(true);

            bool ce1 = true, ce2 = true;
            int ec1 = 0, ec2 = 0;

            ce1 = g1.ContainsEdge(e.Source, e.Target);
            ec1 = g1.EdgeCount;

            ec2 = g2.EdgeCount;
            ce2 = g2.ContainsEdge(e.Source, e.Target);

            //NotpAssume.IsTrue(ce1 == ce2 && ec1 == ec2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(ce1 == ce2 && ec1 == ec2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityContainsEdgeAdjacentEdgesComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, [PexAssumeNotNull]Edge<int> e, int node)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_SourceNode", e.Source);
            PexObserve.ValueForViewing("$input_TargetNode", e.Target);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNode", g1.ContainsVertex(node) ? g1.AdjacentDegree(node) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeSrc", g1.ContainsVertex(e.Source) ? g1.AdjacentDegree(e.Source) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeTar", g1.ContainsVertex(e.Target) ? g1.AdjacentDegree(e.Target) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));
            PexObserve.ValueForViewing("$input_ContainsNodeSrc", g1.ContainsVertex(e.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar", g1.ContainsVertex(e.Target));
            PexObserve.ValueForViewing("$input_ContainsEdge", g1.ContainsVertex(e.Source) && g1.ContainsVertex(e.Target) ? g1.ContainsEdge(e.Source, e.Target) : false);

            AssumePrecondition.IsTrue(true);

            bool ce1 = true, ce2 = true;

            ce1 = g1.ContainsEdge(e.Source, e.Target);
            var ae1 = g1.AdjacentEdges(node);

            var ae2 = g2.AdjacentEdges(node);
            ce2 = g2.ContainsEdge(e.Source, e.Target);

            bool equal = true;

            if (ae1.Count() != ae2.Count())
            {
                equal = false;
            }

            for (int i = 0; i < ae1.Count(); i++)
            {
                if (ae1.ElementAt(i).Source != ae2.ElementAt(i).Source || ae1.ElementAt(i).Source != ae2.ElementAt(i).Source)
                {
                    equal = false;
                }
            }

            //NotpAssume.IsTrue(ce1 == ce2 && equal && eq.Equals(g1, g2));
            PexAssert.IsTrue(ce1 == ce2 && equal && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityContainsEdgeAdjacentDegreeComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, [PexAssumeNotNull]Edge<int> e, int node)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_SourceNode", e.Source);
            PexObserve.ValueForViewing("$input_TargetNode", e.Target);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNode", g1.ContainsVertex(node) ? g1.AdjacentDegree(node) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeSrc", g1.ContainsVertex(e.Source) ? g1.AdjacentDegree(e.Source) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeTar", g1.ContainsVertex(e.Target) ? g1.AdjacentDegree(e.Target) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));
            PexObserve.ValueForViewing("$input_ContainsNodeSrc", g1.ContainsVertex(e.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar", g1.ContainsVertex(e.Target));
            PexObserve.ValueForViewing("$input_ContainsEdge", g1.ContainsVertex(e.Source) && g1.ContainsVertex(e.Target) ? g1.ContainsEdge(e.Source, e.Target) : false);

            AssumePrecondition.IsTrue(true);

            bool ce1 = true, ce2 = true;
            int ad1 = 0, ad2 = 0;

            ce1 = g1.ContainsEdge(e.Source, e.Target);
            ad1 = g1.AdjacentDegree(node);

            ad2 = g2.AdjacentDegree(node);
            ce2 = g2.ContainsEdge(e.Source, e.Target);

            //NotpAssume.IsTrue(ce1 == ce2 && ad1 == ad2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(ce1 == ce2 && ad1 == ad2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityContainsEdgeIsAdjacentEdgesEmptyComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, [PexAssumeNotNull]Edge<int> e, int node)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_SourceNode", e.Source);
            PexObserve.ValueForViewing("$input_TargetNode", e.Target);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNode", g1.ContainsVertex(node) ? g1.AdjacentDegree(node) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeSrc", g1.ContainsVertex(e.Source) ? g1.AdjacentDegree(e.Source) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeTar", g1.ContainsVertex(e.Target) ? g1.AdjacentDegree(e.Target) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));
            PexObserve.ValueForViewing("$input_ContainsNodeSrc", g1.ContainsVertex(e.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar", g1.ContainsVertex(e.Target));
            PexObserve.ValueForViewing("$input_ContainsEdge", g1.ContainsVertex(e.Source) && g1.ContainsVertex(e.Target) ? g1.ContainsEdge(e.Source, e.Target) : false);

            AssumePrecondition.IsTrue(true);

            bool ce1 = true, ce2 = true, iaee1 = true, iaee2 = true;

            ce1 = g1.ContainsEdge(e.Source, e.Target);
            iaee1 = g1.IsAdjacentEdgesEmpty(node);

            iaee2 = g2.IsAdjacentEdgesEmpty(node);
            ce2 = g2.ContainsEdge(e.Source, e.Target);

            //NotpAssume.IsTrue(ce1 == ce2 && iaee1 == iaee2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(ce1 == ce2 && iaee1 == iaee2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityAdjacentEdgeAdjacentEdgeComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node1, int index1, int node2, int index2)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq1 = new UndirectedGraphEqualityComparer();
            EdgeEqualityComparer eq2 = new EdgeEqualityComparer();
            EdgeEqualityComparer eq3 = new EdgeEqualityComparer();

            PexObserve.ValueForViewing("$input_Node2", node1);
            PexObserve.ValueForViewing("$input_Node2", node2);
            PexObserve.ValueForViewing("$input_Index1", index1);
            PexObserve.ValueForViewing("$input_Index2", index2);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree1", g1.ContainsVertex(node1) ? g1.AdjacentDegree(node1) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegree2", g1.ContainsVertex(node2) ? g1.AdjacentDegree(node2) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode1", g1.ContainsVertex(node1));
            PexObserve.ValueForViewing("$input_ContainsNode2", g1.ContainsVertex(node2));

            AssumePrecondition.IsTrue(true);

            var ae11 = g1.AdjacentEdge(node1, index1);
            var ae12 = g1.AdjacentEdge(node2, index2);

            var ae22 = g2.AdjacentEdge(node2, index2);
            var ae21 = g2.AdjacentEdge(node1, index1);

            //NotpAssume.IsTrue(eq2.Equals(ae11, ae21) && eq2.Equals(ae21, ae22) && eq1.Equals(g1, g2));
            PexAssert.IsTrue(eq2.Equals(ae11, ae21) && eq2.Equals(ae21, ae22) && eq1.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityAdjacentEdgeIsVerticesEmptyComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node, int index)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq1 = new UndirectedGraphEqualityComparer();
            EdgeEqualityComparer eq2 = new EdgeEqualityComparer();

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_Index", index);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree", g1.ContainsVertex(node) ? g1.AdjacentDegree(node) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));

            AssumePrecondition.IsTrue(true);

            bool ive1 = true, ive2 = true;

            var ae1 = g1.AdjacentEdge(node, index);
            ive1 = g1.IsVerticesEmpty;

            ive2 = g2.IsVerticesEmpty;
            var ae2 = g2.AdjacentEdge(node, index);

            //NotpAssume.IsTrue(eq2.Equals(ae1, ae2) && eq1.Equals(g1, g2));
            PexAssert.IsTrue(eq2.Equals(ae1, ae2) && eq1.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityAdjacentEdgeVertexCountComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node, int index)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq1 = new UndirectedGraphEqualityComparer();
            EdgeEqualityComparer eq2 = new EdgeEqualityComparer();

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_Index", index);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree", g1.ContainsVertex(node) ? g1.AdjacentDegree(node) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));

            AssumePrecondition.IsTrue(true);

            int vc1 = 0, vc2 = 0; 

            var ae1 = g1.AdjacentEdge(node, index);
            vc1 = g1.VertexCount;

            vc2 = g2.VertexCount;
            var ae2 = g2.AdjacentEdge(node, index);

            //NotpAssume.IsTrue(eq2.Equals(ae1, ae2) && vc1 == vc2 && eq1.Equals(g1, g2));
            PexAssert.IsTrue(eq2.Equals(ae1, ae2) && vc1 == vc2 && eq1.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityAdjacentEdgeContainsVertexComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node1, int index, int node2)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq1 = new UndirectedGraphEqualityComparer();
            EdgeEqualityComparer eq2 = new EdgeEqualityComparer();

            PexObserve.ValueForViewing("$input_Node1", node1);
            PexObserve.ValueForViewing("$input_Node2", node2);
            PexObserve.ValueForViewing("$input_Index", index);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree1", g1.ContainsVertex(node1) ? g1.AdjacentDegree(node1) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegree2", g1.ContainsVertex(node2) ? g1.AdjacentDegree(node2) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode1", g1.ContainsVertex(node1));
            PexObserve.ValueForViewing("$input_ContainsNode2", g1.ContainsVertex(node2));

            AssumePrecondition.IsTrue(true);

            bool cv1 = true, cv2 = true;

            var ae1 = g1.AdjacentEdge(node1, index);
            cv1 = g1.ContainsVertex(node2);

            cv2 = g2.ContainsVertex(node2);
            var ae2 = g2.AdjacentEdge(node1, index);

            //NotpAssume.IsTrue(eq2.Equals(ae1, ae2) && cv1 == cv2 && eq1.Equals(g1, g2));
            PexAssert.IsTrue(eq2.Equals(ae1, ae2) && cv1 == cv2 && eq1.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityAdjacentEdgeAddEdgeComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node, int index, [PexAssumeNotNull]Edge<int> e)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq1 = new UndirectedGraphEqualityComparer();
            EdgeEqualityComparer eq2 = new EdgeEqualityComparer();

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_SourceNode", e.Source);
            PexObserve.ValueForViewing("$input_TargetNode", e.Target);
            PexObserve.ValueForViewing("$input_Index", index);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNode", g1.ContainsVertex(node) ? g1.AdjacentDegree(node) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeSrc", g1.ContainsVertex(e.Source) ? g1.AdjacentDegree(e.Source) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeTar", g1.ContainsVertex(e.Target) ? g1.AdjacentDegree(e.Target) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode1", g1.ContainsVertex(node));
            PexObserve.ValueForViewing("$input_ContainsNodeSrc", g1.ContainsVertex(e.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar", g1.ContainsVertex(e.Target));
            PexObserve.ValueForViewing("$input_ContainsEdge", g1.ContainsVertex(e.Source) && g1.ContainsVertex(e.Target) ? g1.ContainsEdge(e.Source, e.Target) : false);

            AssumePrecondition.IsTrue(true);

            bool ae12 = true, ae22 = true;

            var ae11 = g1.AdjacentEdge(node, index);
            ae12 = g1.AddEdge(e);

            ae22 = g2.AddEdge(e);
            var ae21 = g2.AdjacentEdge(node, index);

            //NotpAssume.IsTrue(eq2.Equals(ae11, ae21) && ae12 == ae22 && eq1.Equals(g1, g2));
            PexAssert.IsTrue(eq2.Equals(ae11, ae21) && ae12 == ae22 && eq1.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityAdjacentEdgeAddEdgeRangeComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node, int index, [PexAssumeNotNull]int[] srcs, [PexAssumeNotNull]int[] tars)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq1 = new UndirectedGraphEqualityComparer();
            EdgeEqualityComparer eq2 = new EdgeEqualityComparer();

            PexAssume.IsTrue(srcs.Length == tars.Length && srcs.Length < 11);

            List<Edge<int>> edges = new List<Edge<int>>();
            for (int i = 0; i < srcs.Length; i++)
            {
                edges.Add(new Edge<int>(srcs[i], tars[i]));
            }

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_Index", index);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree", g1.ContainsVertex(node) ? g1.AdjacentDegree(node) : 0);
            PexObserve.ValueForViewing("$input_AddEdgesCount", srcs.Length);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));

            AssumePrecondition.IsTrue(true);

            var ae1 = g1.AdjacentEdge(node, index);
            g1.AddEdgeRange(edges);

            g2.AddEdgeRange(edges);
            var ae2 = g2.AdjacentEdge(node, index);

            //NotpAssume.IsTrue(eq2.Equals(ae1, ae2) && eq1.Equals(g1, g2));
            PexAssert.IsTrue(eq2.Equals(ae1, ae2) && eq1.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityAdjacentEdgeRemoveEdgeComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node, int index, [PexAssumeNotNull]Edge<int> e)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq1 = new UndirectedGraphEqualityComparer();
            EdgeEqualityComparer eq2 = new EdgeEqualityComparer();

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_SourceNode", e.Source);
            PexObserve.ValueForViewing("$input_TargetNode", e.Target);
            PexObserve.ValueForViewing("$input_Index", index);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNode", g1.ContainsVertex(node) ? g1.AdjacentDegree(node) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeSrc", g1.ContainsVertex(e.Source) ? g1.AdjacentDegree(e.Source) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeTar", g1.ContainsVertex(e.Target) ? g1.AdjacentDegree(e.Target) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode1", g1.ContainsVertex(node));
            PexObserve.ValueForViewing("$input_ContainsNodeSrc", g1.ContainsVertex(e.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar", g1.ContainsVertex(e.Target));
            PexObserve.ValueForViewing("$input_ContainsEdge", g1.ContainsVertex(e.Source) && g1.ContainsVertex(e.Target) ? g1.ContainsEdge(e.Source, e.Target) : false);

            AssumePrecondition.IsTrue(true);

            bool re1 = true, re2 = true;

            var ae1 = g1.AdjacentEdge(node, index);
            re1 = g1.RemoveEdge(e);

            re2 = g2.RemoveEdge(e);
            var ae2 = g2.AdjacentEdge(node, index);

            //NotpAssume.IsTrue(eq2.Equals(ae11, ae21) && re1 == re2 && eq1.Equals(g1, g2));
            PexAssert.IsTrue(eq2.Equals(ae1, ae2) && re1 == re2 && eq1.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityAdjacentEdgeRemoveEdgesComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node, int index, [PexAssumeNotNull]int[] srcs, [PexAssumeNotNull]int[] tars)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq1 = new UndirectedGraphEqualityComparer();
            EdgeEqualityComparer eq2 = new EdgeEqualityComparer();

            PexAssume.IsTrue(srcs.Length == tars.Length && srcs.Length < 11);

            List<Edge<int>> edges = new List<Edge<int>>();
            for (int i = 0; i < srcs.Length; i++)
            {
                edges.Add(new Edge<int>(srcs[i], tars[i]));
            }

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_Index", index);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree", g1.ContainsVertex(node) ? g1.AdjacentDegree(node) : 0);
            PexObserve.ValueForViewing("$input_RemoveEdgesCount", srcs.Length);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));

            AssumePrecondition.IsTrue(true);

            int re1 = 0, re2 = 0;

            var ae1 = g1.AdjacentEdge(node, index);
            re1 = g1.RemoveEdges(edges);

            re2 = g2.RemoveEdges(edges);
            var ae2 = g2.AdjacentEdge(node, index);

            //NotpAssume.IsTrue(eq2.Equals(ae1, ae2) && re1 == re2 && eq1.Equals(g1, g2));
            PexAssert.IsTrue(eq2.Equals(ae1, ae2) && re1 == re2 && eq1.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityAdjacentEdgeIsEdgesEmptyComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node, int index)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq1 = new UndirectedGraphEqualityComparer();
            EdgeEqualityComparer eq2 = new EdgeEqualityComparer();

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_Index", index);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree", g1.ContainsVertex(node) ? g1.AdjacentDegree(node) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));

            AssumePrecondition.IsTrue(true);

            bool iee1 = true, iee2 = true;

            var ae1 = g1.AdjacentEdge(node, index);
            iee1 = g1.IsEdgesEmpty;

            iee2 = g2.IsEdgesEmpty;
            var ae2 = g2.AdjacentEdge(node, index);

            //NotpAssume.IsTrue(eq2.Equals(ae1, ae2) && iee1 == iee2 && eq1.Equals(g1, g2));
            PexAssert.IsTrue(eq2.Equals(ae1, ae2) && iee1 == iee2 && eq1.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityAdjacentEdgeEdgeCountComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node, int index)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq1 = new UndirectedGraphEqualityComparer();
            EdgeEqualityComparer eq2 = new EdgeEqualityComparer();

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_Index", index);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree", g1.ContainsVertex(node) ? g1.AdjacentDegree(node) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));

            AssumePrecondition.IsTrue(true);

            int ec1 = 0, ec2 = 0;

            var ae1 = g1.AdjacentEdge(node, index);
            ec1 = g1.EdgeCount;

            ec2 = g2.EdgeCount;
            var ae2 = g2.AdjacentEdge(node, index);

            //NotpAssume.IsTrue(eq2.Equals(ae1, ae2) && ec1 == ec2 && eq1.Equals(g1, g2));
            PexAssert.IsTrue(eq2.Equals(ae1, ae2) && ec1 == ec2 && eq1.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityAdjacentEdgeAdjacentEdgesComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node1, int index, int node2)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq1 = new UndirectedGraphEqualityComparer();
            EdgeEqualityComparer eq2 = new EdgeEqualityComparer();

            PexObserve.ValueForViewing("$input_Node1", node1);
            PexObserve.ValueForViewing("$input_Node2", node2);
            PexObserve.ValueForViewing("$input_Index", index);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree1", g1.ContainsVertex(node1) ? g1.AdjacentDegree(node1) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegree2", g1.ContainsVertex(node2) ? g1.AdjacentDegree(node2) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode1", g1.ContainsVertex(node1));
            PexObserve.ValueForViewing("$input_ContainsNode2", g1.ContainsVertex(node2));

            AssumePrecondition.IsTrue(true);

            var ae11 = g1.AdjacentEdge(node1, index);
            var ae12 = g1.AdjacentEdges(node2);

            var ae22 = g2.AdjacentEdges(node2);
            var ae21 = g2.AdjacentEdge(node1, index);

            bool equal = true;

            if (ae12.Count() != ae22.Count())
            {
                equal = false;
            }

            for (int i = 0; i < ae12.Count(); i++)
            {
                if (ae12.ElementAt(i).Source != ae22.ElementAt(i).Source || ae12.ElementAt(i).Source != ae22.ElementAt(i).Source)
                {
                    equal = false;
                }
            }

            //NotpAssume.IsTrue(eq2.Equals(ae11, ae21) && equal && eq1.Equals(g1, g2));
            PexAssert.IsTrue(eq2.Equals(ae11, ae21) && equal && eq1.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityAdjacentEdgeAdjacentDegreeComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node1, int index, int node2)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq1 = new UndirectedGraphEqualityComparer();
            EdgeEqualityComparer eq2 = new EdgeEqualityComparer();

            PexObserve.ValueForViewing("$input_Node1", node1);
            PexObserve.ValueForViewing("$input_Node2", node2);
            PexObserve.ValueForViewing("$input_Index", index);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree1", g1.ContainsVertex(node1) ? g1.AdjacentDegree(node1) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegree2", g1.ContainsVertex(node2) ? g1.AdjacentDegree(node2) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode1", g1.ContainsVertex(node1));
            PexObserve.ValueForViewing("$input_ContainsNode2", g1.ContainsVertex(node2));

            AssumePrecondition.IsTrue(true);

            int ad1 = 0, ad2 = 0;

            var ae1 = g1.AdjacentEdge(node1, index);
            ad1 = g1.AdjacentDegree(node2);

            ad2 = g2.AdjacentDegree(node2);
            var ae2 = g2.AdjacentEdge(node1, index);

            //NotpAssume.IsTrue(eq2.Equals(ae1, ae2) && ad1 == ad2 && eq1.Equals(g1, g2));
            PexAssert.IsTrue(eq2.Equals(ae1, ae2) && ad1 == ad2 && eq1.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityAdjacentEdgeIsAdjacentEdgesEmptyComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node1, int index, int node2)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq1 = new UndirectedGraphEqualityComparer();
            EdgeEqualityComparer eq2 = new EdgeEqualityComparer();

            PexObserve.ValueForViewing("$input_Node1", node1);
            PexObserve.ValueForViewing("$input_Node2", node2);
            PexObserve.ValueForViewing("$input_Index", index);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree1", g1.ContainsVertex(node1) ? g1.AdjacentDegree(node1) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegree2", g1.ContainsVertex(node2) ? g1.AdjacentDegree(node2) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode1", g1.ContainsVertex(node1));
            PexObserve.ValueForViewing("$input_ContainsNode2", g1.ContainsVertex(node2));

            AssumePrecondition.IsTrue(true);

            bool iaee1 = true, iaee2 = true;

            var ae1 = g1.AdjacentEdge(node1, index);
            iaee1 = g1.IsAdjacentEdgesEmpty(node2);

            iaee2 = g2.IsAdjacentEdgesEmpty(node2);
            var ae2 = g2.AdjacentEdge(node1, index);

            //NotpAssume.IsTrue(eq2.Equals(ae1, ae2) && iaee1 == iaee2 && eq1.Equals(g1, g2));
            PexAssert.IsTrue(eq2.Equals(ae1, ae2) && iaee1 == iaee2 && eq1.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityIsVerticesEmptyIsVerticesEmptyComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);

            AssumePrecondition.IsTrue(true);

            bool ive11 = true, ive12 = true, ive21 = true, ive22 = true;

            ive11 = g1.IsVerticesEmpty;
            ive12 = g1.IsVerticesEmpty;

            ive22 = g2.IsVerticesEmpty;
            ive21 = g2.IsVerticesEmpty;

            //NotpAssume.IsTrue(ive11 == ive21 && ive12 == ive22 && eq.Equals(g1, g2));
            PexAssert.IsTrue(ive11 == ive21 && ive12 == ive22 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityIsVerticesEmptyVertexCountComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);

            AssumePrecondition.IsTrue(true);

            bool ive1 = true, ive2 = true;
            int vc1 = 0, vc2 = 0;

            ive1 = g1.IsVerticesEmpty;
            vc1 = g1.VertexCount;

            vc2 = g2.VertexCount;
            ive2 = g2.IsVerticesEmpty;

            //NotpAssume.IsTrue(ive1 == ive2 && vc1 == vc2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(ive1 == ive2 && vc1 == vc2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityIsVerticesEmptyContainsVertexComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree", g1.ContainsVertex(node) ? g1.AdjacentDegree(node) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));

            AssumePrecondition.IsTrue(true);

            bool ive1 = true, ive2 = true, cv1 = true, cv2 = true;

            ive1 = g1.IsVerticesEmpty;
            cv1 = g1.ContainsVertex(node);

            cv2 = g2.ContainsVertex(node);
            ive2 = g2.IsVerticesEmpty;

            //NotpAssume.IsTrue(ive1 == ive2 && cv1 == cv2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(ive1 == ive2 && cv1 == cv2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityIsVerticesEmptyAddEdgeComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, [PexAssumeNotNull]Edge<int> e)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_SourceNode", e.Source);
            PexObserve.ValueForViewing("$input_TargetNode", e.Target);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeSrc", g1.ContainsVertex(e.Source) ? g1.AdjacentDegree(e.Source) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeTar", g1.ContainsVertex(e.Target) ? g1.AdjacentDegree(e.Target) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNodeSrc", g1.ContainsVertex(e.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar", g1.ContainsVertex(e.Target));
            PexObserve.ValueForViewing("$input_ContainsEdge", g1.ContainsVertex(e.Source) && g1.ContainsVertex(e.Target) ? g1.ContainsEdge(e.Source, e.Target) : false);

            AssumePrecondition.IsTrue(true);

            bool ive1 = true, ive2 = true, ae1 = true, ae2 = true;

            ive1 = g1.IsVerticesEmpty;
            ae1 = g1.AddEdge(e);

            ae2 = g2.AddEdge(e);
            ive2 = g2.IsVerticesEmpty;

            //NotpAssume.IsTrue(ive1 == ive2 && ae1 == ae2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(ive1 == ive2 && ae1 == ae2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityIsVerticesEmptyAddEdgeRangeComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, [PexAssumeNotNull]int[] srcs, [PexAssumeNotNull]int[] tars)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexAssume.IsTrue(srcs.Length == tars.Length && srcs.Length < 11);

            List<Edge<int>> edges = new List<Edge<int>>();
            for (int i = 0; i < srcs.Length; i++)
            {
                edges.Add(new Edge<int>(srcs[i], tars[i]));
            }

            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AddEdgesCount", srcs.Length);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);

            AssumePrecondition.IsTrue(true);

            bool ive1 = true, ive2 = true;

            ive1 = g1.IsVerticesEmpty;
            g1.AddEdgeRange(edges);

            g2.AddEdgeRange(edges);
            ive2 = g2.IsVerticesEmpty;

            //NotpAssume.IsTrue(ive1 == ive2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(ive1 == ive2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityIsVerticesEmptyRemoveEdgeComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, [PexAssumeNotNull]Edge<int> e)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_SourceNode", e.Source);
            PexObserve.ValueForViewing("$input_TargetNode", e.Target);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeSrc", g1.ContainsVertex(e.Source) ? g1.AdjacentDegree(e.Source) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeTar", g1.ContainsVertex(e.Target) ? g1.AdjacentDegree(e.Target) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNodeSrc", g1.ContainsVertex(e.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar", g1.ContainsVertex(e.Target));
            PexObserve.ValueForViewing("$input_ContainsEdge", g1.ContainsVertex(e.Source) && g1.ContainsVertex(e.Target) ? g1.ContainsEdge(e.Source, e.Target) : false);

            AssumePrecondition.IsTrue(true);

            bool ive1 = true, ive2 = true, re1 = true, re2 = true;

            ive1 = g1.IsVerticesEmpty;
            re1 = g1.RemoveEdge(e);

            re2 = g2.RemoveEdge(e);
            ive2 = g2.IsVerticesEmpty;

            //NotpAssume.IsTrue(ive1 == ive2 && re1 == re2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(ive1 == ive2 && re1 == re2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityIsVerticesEmptyRemoveEdgesComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, [PexAssumeNotNull]int[] srcs, [PexAssumeNotNull]int[] tars)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexAssume.IsTrue(srcs.Length == tars.Length && srcs.Length < 11);

            List<Edge<int>> edges = new List<Edge<int>>();
            for (int i = 0; i < srcs.Length; i++)
            {
                edges.Add(new Edge<int>(srcs[i], tars[i]));
            }

            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_RemoveEdgesCount", srcs.Length);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);

            AssumePrecondition.IsTrue(true);

            bool ive1 = true, ive2 = true;
            int re1 = 0, re2 = 0;

            ive1 = g1.IsVerticesEmpty;
            re1 = g1.RemoveEdges(edges);

            re2 = g2.RemoveEdges(edges);
            ive2 = g2.IsVerticesEmpty;

            //NotpAssume.IsTrue(ive1 == ive2 && re1 == re2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(ive1 == ive2 && re1 == re2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityIsVerticesEmptyIsEdgesEmptyComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);

            AssumePrecondition.IsTrue(true);

            bool ive1 = true, ive2 = true, iee1 = true, iee2 = true;

            ive1 = g1.IsVerticesEmpty;
            iee1 = g1.IsEdgesEmpty;

            iee2 = g2.IsEdgesEmpty;
            ive2 = g2.IsVerticesEmpty;

            //NotpAssume.IsTrue(ive1 == ive2 && iee1 == iee2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(ive1 == ive2 && iee1 == iee2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityIsVerticesEmptyEdgeCountComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);

            AssumePrecondition.IsTrue(true);

            bool ive1 = true, ive2 = true;
            int ec1 = 0, ec2 = 0;

            ive1 = g1.IsVerticesEmpty;
            ec1 = g1.EdgeCount;

            ec2 = g2.EdgeCount;
            ive2 = g2.IsVerticesEmpty;

            //NotpAssume.IsTrue(ive1 == ive2 && ec1 == ec2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(ive1 == ive2 && ec1 == ec2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityIsVerticesEmptyAdjacentEdgesComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree", g1.ContainsVertex(node) ? g1.AdjacentDegree(node) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));

            AssumePrecondition.IsTrue(true);

            bool ive1 = true, ive2 = true;

            ive1 = g1.IsVerticesEmpty;
            var ae1 = g1.AdjacentEdges(node);

            var ae2 = g2.AdjacentEdges(node);
            ive2 = g2.IsVerticesEmpty;

            bool equal = true;

            if (ae1.Count() != ae2.Count())
            {
                equal = false;
            }

            for (int i = 0; i < ae1.Count(); i++)
            {
                if (ae1.ElementAt(i).Source != ae2.ElementAt(i).Source || ae1.ElementAt(i).Source != ae2.ElementAt(i).Source)
                {
                    equal = false;
                }
            }

            //NotpAssume.IsTrue(ive1 == ive2 && equal && eq.Equals(g1, g2));
            PexAssert.IsTrue(ive1 == ive2 && equal && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityIsVerticesEmptyAdjacentDegreeComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree", g1.ContainsVertex(node) ? g1.AdjacentDegree(node) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));

            AssumePrecondition.IsTrue(true);

            bool ive1 = true, ive2 = true;
            int ad1 = 0, ad2 = 0;

            ive1 = g1.IsVerticesEmpty;
            ad1 = g1.AdjacentDegree(node);

            ad2 = g2.AdjacentDegree(node);
            ive2 = g2.IsVerticesEmpty;

            //NotpAssume.IsTrue(ive1 == ive2 && ad1 == ad2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(ive1 == ive2 && ad1 == ad2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityIsVerticesEmptyIsAdjacentEdgesEmptyComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree", g1.ContainsVertex(node) ? g1.AdjacentDegree(node) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));

            AssumePrecondition.IsTrue(true);

            bool ive1 = true, ive2 = true, iaee1 = true, iaee2 = true;

            ive1 = g1.IsVerticesEmpty;
            iaee1 = g1.IsAdjacentEdgesEmpty(node);

            iaee2 = g2.IsAdjacentEdgesEmpty(node);
            ive2 = g2.IsVerticesEmpty;

            //NotpAssume.IsTrue(ive1 == ive2 && iaee1 == iaee2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(ive1 == ive2 && iaee1 == iaee2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityVertexCountVertexCountComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);

            AssumePrecondition.IsTrue(true);

            int vc11 = 0, vc12 = 0, vc21 = 0, vc22 = 0;

            vc11 = g1.VertexCount;
            vc12 = g1.VertexCount;

            vc22 = g2.VertexCount;
            vc21 = g2.VertexCount;

            //NotpAssume.IsTrue(vc11 == vc21 && vc12 == vc22 && eq.Equals(g1, g2));
            PexAssert.IsTrue(vc11 == vc21 && vc12 == vc22 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityVertexCountContainsVertexComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree", g1.ContainsVertex(node) ? g1.AdjacentDegree(node) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));

            AssumePrecondition.IsTrue(true);

            int vc1 = 0, vc2 = 0;
            bool cv1 = true, cv2 = true;

            vc1 = g1.VertexCount;
            cv1 = g1.ContainsVertex(node);

            cv2 = g2.ContainsVertex(node);
            vc2 = g2.VertexCount;

            //NotpAssume.IsTrue(vc1 == vc2 && cv1 == cv2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(vc1 == vc2 && cv1 == cv2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityVertexCountAddEdgeComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, [PexAssumeNotNull]Edge<int> e)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_SourceNode", e.Source);
            PexObserve.ValueForViewing("$input_TargetNode", e.Target);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeSrc", g1.ContainsVertex(e.Source) ? g1.AdjacentDegree(e.Source) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeTar", g1.ContainsVertex(e.Target) ? g1.AdjacentDegree(e.Target) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNodeSrc", g1.ContainsVertex(e.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar", g1.ContainsVertex(e.Target));
            PexObserve.ValueForViewing("$input_ContainsEdge", g1.ContainsVertex(e.Source) && g1.ContainsVertex(e.Target) ? g1.ContainsEdge(e.Source, e.Target) : false);

            AssumePrecondition.IsTrue(true);

            int vc1 = 0, vc2 = 0;
            bool ae1 = true, ae2 = true;

            vc1 = g1.VertexCount;
            ae1 = g1.AddEdge(e);

            ae2 = g2.AddEdge(e);
            vc2 = g2.VertexCount;

            //NotpAssume.IsTrue(vc1 == vc2 && ae1 == ae2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(vc1 == vc2 && ae1 == ae2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityVertexCountAddEdgeRangeComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, [PexAssumeNotNull]int[] srcs, [PexAssumeNotNull]int[] tars)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexAssume.IsTrue(srcs.Length == tars.Length && srcs.Length < 11);

            List<Edge<int>> edges = new List<Edge<int>>();
            for (int i = 0; i < srcs.Length; i++)
            {
                edges.Add(new Edge<int>(srcs[i], tars[i]));
            }

            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AddEdgesCount", srcs.Length);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);

            AssumePrecondition.IsTrue(true);

            int vc1 = 0, vc2 = 0;

            vc1 = g1.VertexCount;
            g1.AddEdgeRange(edges);

            g2.AddEdgeRange(edges);
            vc2 = g2.VertexCount;

            //NotpAssume.IsTrue(vc1 == vc2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(vc1 == vc2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityVertexCountRemoveEdgeComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, [PexAssumeNotNull]Edge<int> e)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_SourceNode", e.Source);
            PexObserve.ValueForViewing("$input_TargetNode", e.Target);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeSrc", g1.ContainsVertex(e.Source) ? g1.AdjacentDegree(e.Source) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeTar", g1.ContainsVertex(e.Target) ? g1.AdjacentDegree(e.Target) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNodeSrc", g1.ContainsVertex(e.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar", g1.ContainsVertex(e.Target));
            PexObserve.ValueForViewing("$input_ContainsEdge", g1.ContainsVertex(e.Source) && g1.ContainsVertex(e.Target) ? g1.ContainsEdge(e.Source, e.Target) : false);

            AssumePrecondition.IsTrue(true);

            int vc1 = 0, vc2 = 0;
            bool re1 = true, re2 = true;

            vc1 = g1.VertexCount;
            re1 = g1.RemoveEdge(e);

            re2 = g2.RemoveEdge(e);
            vc2 = g2.VertexCount;

            //NotpAssume.IsTrue(vc1 == vc2 && re1 == re2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(vc1 == vc2 && re1 == re2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityVertexCountRemoveEdgesComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, [PexAssumeNotNull]int[] srcs, [PexAssumeNotNull]int[] tars)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexAssume.IsTrue(srcs.Length == tars.Length && srcs.Length < 11);

            List<Edge<int>> edges = new List<Edge<int>>();
            for (int i = 0; i < srcs.Length; i++)
            {
                edges.Add(new Edge<int>(srcs[i], tars[i]));
            }

            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_RemoveEdgesCount", srcs.Length);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);

            AssumePrecondition.IsTrue(true);

            int vc1 = 0, vc2 = 0, re1 = 0, re2 = 0;

            vc1 = g1.VertexCount;
            re1 = g1.RemoveEdges(edges);

            re2 = g2.RemoveEdges(edges);
            vc2 = g2.VertexCount;

            //NotpAssume.IsTrue(vc1 == vc2 && re1 == re2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(vc1 == vc2 && re1 == re2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityVertexCountIsEdgesEmptyComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);

            AssumePrecondition.IsTrue(true);

            int vc1 = 0, vc2 = 0;
            bool iee1 = true, iee2 = true;

            vc1 = g1.VertexCount;
            iee1 = g1.IsEdgesEmpty;

            iee2 = g2.IsEdgesEmpty;
            vc2 = g2.VertexCount;

            //NotpAssume.IsTrue(vc1 == vc2 && iee1 == iee2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(vc1 == vc2 && iee1 == iee2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityVertexCountEdgeCountComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);

            AssumePrecondition.IsTrue(true);

            int vc1 = 0, vc2 = 0, ec1 = 0, ec2 = 0;

            vc1 = g1.VertexCount;
            ec1 = g1.EdgeCount;

            ec2 = g2.EdgeCount;
            vc2 = g2.VertexCount;

            //NotpAssume.IsTrue(vc1 == vc2 && ec1 == ec2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(vc1 == vc2 && ec1 == ec2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityVertexCountAdjacentEdgesComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree", g1.ContainsVertex(node) ? g1.AdjacentDegree(node) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));

            AssumePrecondition.IsTrue(true);

            int vc1 = 0, vc2 = 0;

            vc1 = g1.VertexCount;
            var ae1 = g1.AdjacentEdges(node);

            var ae2 = g2.AdjacentEdges(node);
            vc2 = g2.VertexCount;

            bool equal = true;

            if (ae1.Count() != ae2.Count())
            {
                equal = false;
            }

            for (int i = 0; i < ae1.Count(); i++)
            {
                if (ae1.ElementAt(i).Source != ae2.ElementAt(i).Source || ae1.ElementAt(i).Source != ae2.ElementAt(i).Source)
                {
                    equal = false;
                }
            }

            //NotpAssume.IsTrue(vc1 == vc2 && equal && eq.Equals(g1, g2));
            PexAssert.IsTrue(vc1 == vc2 && equal && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityVertexCountAdjacentDegreeComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree", g1.ContainsVertex(node) ? g1.AdjacentDegree(node) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));

            AssumePrecondition.IsTrue(true);

            int vc1 = 0, vc2 = 0, ad1 = 0, ad2 = 0;

            vc1 = g1.VertexCount;
            ad1 = g1.AdjacentDegree(node);

            ad2 = g2.AdjacentDegree(node);
            vc2 = g2.VertexCount;

            //NotpAssume.IsTrue(vc1 == vc2 && ad1 == ad2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(vc1 == vc2 && ad1 == ad2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityVertexCountIsAdjacentEdgesEmptyComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree", g1.ContainsVertex(node) ? g1.AdjacentDegree(node) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));

            AssumePrecondition.IsTrue(true);

            int vc1 = 0, vc2 = 0;
            bool iaee1 = true, iaee2 = true;

            vc1 = g1.VertexCount;
            iaee1 = g1.IsAdjacentEdgesEmpty(node);

            iaee2 = g2.IsAdjacentEdgesEmpty(node);
            vc2 = g2.VertexCount;

            //NotpAssume.IsTrue(vc1 == vc2 && iaee1 == iaee2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(vc1 == vc2 && iaee1 == iaee2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityContainsVertexContainsVertexComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node1, int node2)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node1", node1);
            PexObserve.ValueForViewing("$input_Node2", node2);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree1", g1.ContainsVertex(node1) ? g1.AdjacentDegree(node1) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegree2", g1.ContainsVertex(node2) ? g1.AdjacentDegree(node2) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode1", g1.ContainsVertex(node1));
            PexObserve.ValueForViewing("$input_ContainsNode2", g1.ContainsVertex(node2));

            AssumePrecondition.IsTrue(true);

            bool cv11 = true, cv12 = true, cv21 = true, cv22 = true;

            cv11 = g1.ContainsVertex(node1);
            cv12 = g1.ContainsVertex(node2);

            cv22 = g2.ContainsVertex(node2);
            cv21 = g2.ContainsVertex(node1);

            //NotpAssume.IsTrue(cv1 == cv2 && cv21 == cv22 && eq.Equals(g1, g2));
            PexAssert.IsTrue(cv11 == cv21 && cv21 == cv22 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityContainsVertexAddEdgeComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node, [PexAssumeNotNull]Edge<int> e)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_SourceNode", e.Source);
            PexObserve.ValueForViewing("$input_TargetNode", e.Target);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNode", g1.ContainsVertex(node) ? g1.AdjacentDegree(node) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeSrc", g1.ContainsVertex(e.Source) ? g1.AdjacentDegree(e.Source) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeTar", g1.ContainsVertex(e.Target) ? g1.AdjacentDegree(e.Target) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));
            PexObserve.ValueForViewing("$input_ContainsNodeSrc", g1.ContainsVertex(e.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar", g1.ContainsVertex(e.Target));
            PexObserve.ValueForViewing("$input_ContainsEdge", g1.ContainsVertex(e.Source) && g1.ContainsVertex(e.Target) ? g1.ContainsEdge(e.Source, e.Target) : false);

            AssumePrecondition.IsTrue(true);

            bool cv1 = true, cv2 = true, ae1 = true, ae2 = true;

            cv1 = g1.ContainsVertex(node);
            ae1 = g1.AddEdge(e);

            ae2 = g2.AddEdge(e);
            cv2 = g2.ContainsVertex(node);

            //NotpAssume.IsTrue(cv1 == cv2 && ae1 == ae2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(cv1 == cv2 && ae1 == ae2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityContainsVertexAddEdgeRangeComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node, [PexAssumeNotNull]int[] srcs, [PexAssumeNotNull]int[] tars)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexAssume.IsTrue(srcs.Length == tars.Length && srcs.Length < 11);

            List<Edge<int>> edges = new List<Edge<int>>();
            for (int i = 0; i < srcs.Length; i++)
            {
                edges.Add(new Edge<int>(srcs[i], tars[i]));
            }

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AddEdgesCount", srcs.Length);
            PexObserve.ValueForViewing("$input_AdjacentDegree", g1.ContainsVertex(node) ? g1.AdjacentDegree(node) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));

            AssumePrecondition.IsTrue(true);

            bool cv1 = true, cv2 = true;

            cv1 = g1.ContainsVertex(node);
            g1.AddEdgeRange(edges);

            g2.AddEdgeRange(edges);
            cv2 = g2.ContainsVertex(node);

            //NotpAssume.IsTrue(cv1 == cv2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(cv1 == cv2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityContainsVertexRemoveEdgeComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node, [PexAssumeNotNull]Edge<int> e)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_SourceNode", e.Source);
            PexObserve.ValueForViewing("$input_TargetNode", e.Target);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNode", g1.ContainsVertex(node) ? g1.AdjacentDegree(node) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeSrc", g1.ContainsVertex(e.Source) ? g1.AdjacentDegree(e.Source) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeTar", g1.ContainsVertex(e.Target) ? g1.AdjacentDegree(e.Target) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));
            PexObserve.ValueForViewing("$input_ContainsNodeSrc", g1.ContainsVertex(e.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar", g1.ContainsVertex(e.Target));
            PexObserve.ValueForViewing("$input_ContainsEdge", g1.ContainsVertex(e.Source) && g1.ContainsVertex(e.Target) ? g1.ContainsEdge(e.Source, e.Target) : false);

            AssumePrecondition.IsTrue(true);

            bool cv1 = true, cv2 = true, re1 = true, re2 = true;

            cv1 = g1.ContainsVertex(node);
            re1 = g1.RemoveEdge(e);

            re2 = g2.RemoveEdge(e);
            cv2 = g2.ContainsVertex(node);

            //NotpAssume.IsTrue(cv1 == cv2 && re1 == re2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(cv1 == cv2 && re1 == re2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityContainsVertexRemoveEdgesComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node, [PexAssumeNotNull]int[] srcs, [PexAssumeNotNull]int[] tars)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexAssume.IsTrue(srcs.Length == tars.Length && srcs.Length < 11);

            List<Edge<int>> edges = new List<Edge<int>>();
            for (int i = 0; i < srcs.Length; i++)
            {
                edges.Add(new Edge<int>(srcs[i], tars[i]));
            }

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_RemoveEdgesCount", srcs.Length);
            PexObserve.ValueForViewing("$input_AdjacentDegree", g1.ContainsVertex(node) ? g1.AdjacentDegree(node) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));

            AssumePrecondition.IsTrue(true);

            bool cv1 = true, cv2 = true;
            int re1 = 0, re2 = 0;

            cv1 = g1.ContainsVertex(node);
            re1 = g1.RemoveEdges(edges);

            re2 = g2.RemoveEdges(edges);
            cv2 = g2.ContainsVertex(node);

            //NotpAssume.IsTrue(cv1 == cv2 && re1 == re2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(cv1 == cv2 && re1 == re2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityContainsVertexIsEdgesEmptyComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree", g1.ContainsVertex(node) ? g1.AdjacentDegree(node) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));

            AssumePrecondition.IsTrue(true);

            bool cv1 = true, cv2 = true, iee1 = true, iee2 = true;

            cv1 = g1.ContainsVertex(node);
            iee1 = g1.IsEdgesEmpty;

            iee2 = g2.IsEdgesEmpty;
            cv2 = g2.ContainsVertex(node);

            //NotpAssume.IsTrue(cv1 == cv2 && iee1 == iee2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(cv1 == cv2 && iee1 == iee2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityContainsVertexEdgeCountComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree", g1.ContainsVertex(node) ? g1.AdjacentDegree(node) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));

            AssumePrecondition.IsTrue(true);

            bool cv1 = true, cv2 = true;
            int ec1 = 0, ec2 = 0;

            cv1 = g1.ContainsVertex(node);
            ec1 = g1.EdgeCount;

            ec2 = g2.EdgeCount;
            cv2 = g2.ContainsVertex(node);

            //NotpAssume.IsTrue(cv1 == cv2 && ec1 == ec2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(cv1 == cv2 && ec1 == ec2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityContainsVertexAdjacentEdgesComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node1, int node2)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node1", node1);
            PexObserve.ValueForViewing("$input_Node2", node2);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree1", g1.ContainsVertex(node1) ? g1.AdjacentDegree(node1) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegree2", g1.ContainsVertex(node2) ? g1.AdjacentDegree(node2) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode1", g1.ContainsVertex(node1));
            PexObserve.ValueForViewing("$input_ContainsNode2", g1.ContainsVertex(node2));

            AssumePrecondition.IsTrue(true);

            bool cv1 = true, cv2 = true;

            cv1 = g1.ContainsVertex(node1);
            var ae1 = g1.AdjacentEdges(node2);

            var ae2 = g2.AdjacentEdges(node2);
            cv2 = g2.ContainsVertex(node1);

            bool equal = true;

            if (ae1.Count() != ae2.Count())
            {
                equal = false;
            }

            for (int i = 0; i < ae1.Count(); i++)
            {
                if (ae1.ElementAt(i).Source != ae2.ElementAt(i).Source || ae1.ElementAt(i).Source != ae2.ElementAt(i).Source)
                {
                    equal = false;
                }
            }

            //NotpAssume.IsTrue(cv1 == cv2 && equal && eq.Equals(g1, g2));
            PexAssert.IsTrue(cv1 == cv2 && equal && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityContainsVertexAdjacentDegreeComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node1, int node2)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node1", node1);
            PexObserve.ValueForViewing("$input_Node2", node2);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree1", g1.ContainsVertex(node1) ? g1.AdjacentDegree(node1) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegree2", g1.ContainsVertex(node2) ? g1.AdjacentDegree(node2) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode1", g1.ContainsVertex(node1));
            PexObserve.ValueForViewing("$input_ContainsNode2", g1.ContainsVertex(node2));

            AssumePrecondition.IsTrue(true);

            bool cv1 = true, cv2 = true;
            int ad1 = 0, ad2 = 0;

            cv1 = g1.ContainsVertex(node1);
            ad1 = g1.AdjacentDegree(node2);

            ad2 = g2.AdjacentDegree(node2);
            cv2 = g2.ContainsVertex(node1);

            //NotpAssume.IsTrue(cv1 == cv2 && ad1 == ad2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(cv1 == cv2 && ad1 == ad2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityContainsVertexIsAdjacentEdgesEmptyComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node1, int node2)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node1", node1);
            PexObserve.ValueForViewing("$input_Node2", node2);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree1", g1.ContainsVertex(node1) ? g1.AdjacentDegree(node1) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegree2", g1.ContainsVertex(node2) ? g1.AdjacentDegree(node2) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode1", g1.ContainsVertex(node1));
            PexObserve.ValueForViewing("$input_ContainsNode2", g1.ContainsVertex(node2));

            AssumePrecondition.IsTrue(true);

            bool cv1 = true, cv2 = true, iaee1 = true, iaee2 = true;

            cv1 = g1.ContainsVertex(node1);
            iaee1 = g1.IsAdjacentEdgesEmpty(node2);

            iaee2 = g2.IsAdjacentEdgesEmpty(node2);
            cv2 = g2.ContainsVertex(node1);

            //NotpAssume.IsTrue(cv1 == cv2 && iaee1 == iaee2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(cv1 == cv2 && iaee1 == iaee2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityAddEdgeAddEdgeComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, [PexAssumeNotNull]Edge<int> e1, [PexAssumeNotNull]Edge<int> e2)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_SourceNode1", e1.Source);
            PexObserve.ValueForViewing("$input_TargetNode1", e1.Target);
            PexObserve.ValueForViewing("$input_SourceNode2", e2.Source);
            PexObserve.ValueForViewing("$input_TargetNode2", e2.Target);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeSrc1", g1.ContainsVertex(e1.Source) ? g1.AdjacentDegree(e1.Source) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeTar1", g1.ContainsVertex(e1.Target) ? g1.AdjacentDegree(e1.Target) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeSrc2", g1.ContainsVertex(e2.Source) ? g1.AdjacentDegree(e2.Source) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeTar2", g1.ContainsVertex(e2.Target) ? g1.AdjacentDegree(e2.Target) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNodeSrc1", g1.ContainsVertex(e1.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar1", g1.ContainsVertex(e1.Target));
            PexObserve.ValueForViewing("$input_ContainsNodeSrc2", g1.ContainsVertex(e2.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar2", g1.ContainsVertex(e2.Target));
            PexObserve.ValueForViewing("$input_ContainsEdge1", g1.ContainsVertex(e1.Source) && g1.ContainsVertex(e1.Target) ? g1.ContainsEdge(e1.Source, e1.Target) : false);
            PexObserve.ValueForViewing("$input_ContainsEdge2", g1.ContainsVertex(e2.Source) && g1.ContainsVertex(e2.Target) ? g1.ContainsEdge(e2.Source, e2.Target) : false);

            AssumePrecondition.IsTrue(true);

            bool ae11 = true, ae12 = true, ae21 = true, ae22 = true;

            ae11 = g1.AddEdge(e1);
            ae12 = g1.AddEdge(e2);

            ae22 = g2.AddEdge(e2);
            ae21 = g2.AddEdge(e1);

            //NotpAssume.IsTrue(ae11 == ae21 && ae12 == ae22 && eq.Equals(g1, g2));
            PexAssert.IsTrue(ae11 == ae21 && ae12 == ae22 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityAddEdgeAddEdgeRangeComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, [PexAssumeNotNull]Edge<int> e, [PexAssumeNotNull]int[] srcs, [PexAssumeNotNull]int[] tars)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexAssume.IsTrue(srcs.Length == tars.Length && srcs.Length < 11);

            List<Edge<int>> edges = new List<Edge<int>>();
            for (int i = 0; i < srcs.Length; i++)
            {
                edges.Add(new Edge<int>(srcs[i], tars[i]));
            }

            PexObserve.ValueForViewing("$input_SourceNode", e.Source);
            PexObserve.ValueForViewing("$input_TargetNode", e.Target);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AddEdgesCount", srcs.Length);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeSrc", g1.ContainsVertex(e.Source) ? g1.AdjacentDegree(e.Source) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeTar", g1.ContainsVertex(e.Target) ? g1.AdjacentDegree(e.Target) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNodeSrc", g1.ContainsVertex(e.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar", g1.ContainsVertex(e.Target));
            PexObserve.ValueForViewing("$input_ContainsEdge", g1.ContainsVertex(e.Source) && g1.ContainsVertex(e.Target) ? g1.ContainsEdge(e.Source, e.Target) : false);
            PexObserve.ValueForViewing("$input_EdgesContainEdge", edges.Contains(e));

            AssumePrecondition.IsTrue(true);

            bool ae1 = true, ae2 = true;

            ae1 = g1.AddEdge(e);
            g1.AddEdgeRange(edges);

            g2.AddEdgeRange(edges);
            ae2 = g2.AddEdge(e);

            //NotpAssume.IsTrue(ae1 == ae2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(ae1 == ae2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityAddEdgeRemoveEdgeComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, [PexAssumeNotNull]Edge<int> e1, [PexAssumeNotNull]Edge<int> e2)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_SourceNode1", e1.Source);
            PexObserve.ValueForViewing("$input_TargetNode1", e1.Target);
            PexObserve.ValueForViewing("$input_SourceNode2", e2.Source);
            PexObserve.ValueForViewing("$input_TargetNode2", e2.Target);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeSrc1", g1.ContainsVertex(e1.Source) ? g1.AdjacentDegree(e1.Source) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeTar1", g1.ContainsVertex(e1.Target) ? g1.AdjacentDegree(e1.Target) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeSrc2", g1.ContainsVertex(e2.Source) ? g1.AdjacentDegree(e2.Source) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeTar2", g1.ContainsVertex(e2.Target) ? g1.AdjacentDegree(e2.Target) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNodeSrc1", g1.ContainsVertex(e1.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar1", g1.ContainsVertex(e1.Target));
            PexObserve.ValueForViewing("$input_ContainsNodeSrc2", g1.ContainsVertex(e2.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar2", g1.ContainsVertex(e2.Target));
            PexObserve.ValueForViewing("$input_ContainsEdge1", g1.ContainsVertex(e1.Source) && g1.ContainsVertex(e1.Target) ? g1.ContainsEdge(e1.Source, e1.Target) : false);
            PexObserve.ValueForViewing("$input_ContainsEdge2", g1.ContainsVertex(e2.Source) && g1.ContainsVertex(e2.Target) ? g1.ContainsEdge(e2.Source, e2.Target) : false);

            AssumePrecondition.IsTrue(true);

            bool ae1 = true, ae2 = true, re1 = true, re2 = true;

            ae1 = g1.AddEdge(e1);
            re1 = g1.RemoveEdge(e2);

            re2 = g2.RemoveEdge(e2);
            ae2 = g2.AddEdge(e1);

            //NotpAssume.IsTrue(ae1 == ae2 && re1 == re2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(ae1 == ae2 && re1 == re2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityAddEdgeRemoveEdgesComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, [PexAssumeNotNull]Edge<int> e, [PexAssumeNotNull]int[] srcs, [PexAssumeNotNull]int[] tars)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexAssume.IsTrue(srcs.Length == tars.Length && srcs.Length < 11);

            List<Edge<int>> edges = new List<Edge<int>>();
            for (int i = 0; i < srcs.Length; i++)
            {
                edges.Add(new Edge<int>(srcs[i], tars[i]));
            }

            PexObserve.ValueForViewing("$input_SourceNode", e.Source);
            PexObserve.ValueForViewing("$input_TargetNode", e.Target);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_RemoveEdgesCount", srcs.Length);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeSrc", g1.ContainsVertex(e.Source) ? g1.AdjacentDegree(e.Source) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeTar", g1.ContainsVertex(e.Target) ? g1.AdjacentDegree(e.Target) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNodeSrc", g1.ContainsVertex(e.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar", g1.ContainsVertex(e.Target));
            PexObserve.ValueForViewing("$input_ContainsEdge", g1.ContainsVertex(e.Source) && g1.ContainsVertex(e.Target) ? g1.ContainsEdge(e.Source, e.Target) : false);
            PexObserve.ValueForViewing("$input_EdgesContainEdge", edges.Contains(e));

            AssumePrecondition.IsTrue(true);

            bool ae1 = true, ae2 = true;
            int re1 = 0, re2 = 0;

            ae1 = g1.AddEdge(e);
            re1 = g1.RemoveEdges(edges);

            re2 = g2.RemoveEdges(edges);
            ae2 = g2.AddEdge(e);

            //NotpAssume.IsTrue(ae1 == ae2 && re1 == re2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(ae1 == ae2 && re1 == re2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityAddEdgeIsEdgesEmptyComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, [PexAssumeNotNull]Edge<int> e)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_SourceNode", e.Source);
            PexObserve.ValueForViewing("$input_TargetNode", e.Target);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeSrc", g1.ContainsVertex(e.Source) ? g1.AdjacentDegree(e.Source) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeTar", g1.ContainsVertex(e.Target) ? g1.AdjacentDegree(e.Target) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNodeSrc", g1.ContainsVertex(e.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar", g1.ContainsVertex(e.Target));
            PexObserve.ValueForViewing("$input_ContainsEdge", g1.ContainsVertex(e.Source) && g1.ContainsVertex(e.Target) ? g1.ContainsEdge(e.Source, e.Target) : false);

            AssumePrecondition.IsTrue(true);

            bool ae1 = true, ae2 = true, iee1 = true, iee2 = true;

            ae1 = g1.AddEdge(e);
            iee1 = g1.IsEdgesEmpty;

            iee2 = g2.IsEdgesEmpty;
            ae2 = g2.AddEdge(e);

            //NotpAssume.IsTrue(ae1 == ae2 && iee1 == iee2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(ae1 == ae2 && iee1 == iee2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityAddEdgeEdgeCountComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, [PexAssumeNotNull]Edge<int> e)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_SourceNode", e.Source);
            PexObserve.ValueForViewing("$input_TargetNode", e.Target);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeSrc", g1.ContainsVertex(e.Source) ? g1.AdjacentDegree(e.Source) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeTar", g1.ContainsVertex(e.Target) ? g1.AdjacentDegree(e.Target) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNodeSrc", g1.ContainsVertex(e.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar", g1.ContainsVertex(e.Target));
            PexObserve.ValueForViewing("$input_ContainsEdge", g1.ContainsVertex(e.Source) && g1.ContainsVertex(e.Target) ? g1.ContainsEdge(e.Source, e.Target) : false);

            AssumePrecondition.IsTrue(true);

            bool ae1 = true, ae2 = true;
            int ec1 = 0, ec2 = 0;

            ae1 = g1.AddEdge(e);
            ec1 = g1.EdgeCount;

            ec2 = g2.EdgeCount;
            ae2 = g2.AddEdge(e);

            //NotpAssume.IsTrue(ae1 == ae2 && ec1 == ec2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(ae1 == ae2 && ec1 == ec2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityAddEdgeAdjacentEdgesComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, [PexAssumeNotNull]Edge<int> e, int node)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_SourceNode", e.Source);
            PexObserve.ValueForViewing("$input_TargetNode", e.Target);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNode", g1.ContainsVertex(node) ? g1.AdjacentDegree(node) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeSrc", g1.ContainsVertex(e.Source) ? g1.AdjacentDegree(e.Source) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeTar", g1.ContainsVertex(e.Target) ? g1.AdjacentDegree(e.Target) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));
            PexObserve.ValueForViewing("$input_ContainsNodeSrc", g1.ContainsVertex(e.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar", g1.ContainsVertex(e.Target));
            PexObserve.ValueForViewing("$input_ContainsEdge", g1.ContainsVertex(e.Source) && g1.ContainsVertex(e.Target) ? g1.ContainsEdge(e.Source, e.Target) : false);

            AssumePrecondition.IsTrue(true);

            bool ae11 = true, ae21 = true;

            ae11 = g1.AddEdge(e);
            var ae12 = g1.AdjacentEdges(node);

            var ae22 = g2.AdjacentEdges(node);
            ae21 = g2.AddEdge(e);

            bool equal = true;

            if (ae12.Count() != ae22.Count())
            {
                equal = false;
            }

            for (int i = 0; i < ae12.Count(); i++)
            {
                if (ae12.ElementAt(i).Source != ae22.ElementAt(i).Source || ae12.ElementAt(i).Source != ae22.ElementAt(i).Source)
                {
                    equal = false;
                }
            }

            //NotpAssume.IsTrue(ae1 == ae2 && equal && eq.Equals(g1, g2));
            PexAssert.IsTrue(ae11 == ae21 && equal && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityAddEdgeAdjacentDegreeComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, [PexAssumeNotNull]Edge<int> e, int node)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_SourceNode", e.Source);
            PexObserve.ValueForViewing("$input_TargetNode", e.Target);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNode", g1.ContainsVertex(node) ? g1.AdjacentDegree(node) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeSrc", g1.ContainsVertex(e.Source) ? g1.AdjacentDegree(e.Source) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeTar", g1.ContainsVertex(e.Target) ? g1.AdjacentDegree(e.Target) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));
            PexObserve.ValueForViewing("$input_ContainsNodeSrc", g1.ContainsVertex(e.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar", g1.ContainsVertex(e.Target));
            PexObserve.ValueForViewing("$input_ContainsEdge", g1.ContainsVertex(e.Source) && g1.ContainsVertex(e.Target) ? g1.ContainsEdge(e.Source, e.Target) : false);

            AssumePrecondition.IsTrue(true);

            bool ae1 = true, ae2 = true;
            int ad1 = 0, ad2 = 0;

            ae1 = g1.AddEdge(e);
            ad1 = g1.AdjacentDegree(node);

            ad2 = g2.AdjacentDegree(node);
            ae2 = g2.AddEdge(e);

            //NotpAssume.IsTrue(ae1 == ae2 && ad1 == ad2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(ae1 == ae2 && ad1 == ad2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityAddEdgeIsAdjacentEdgesEmptyComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, [PexAssumeNotNull]Edge<int> e, int node)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_SourceNode", e.Source);
            PexObserve.ValueForViewing("$input_TargetNode", e.Target);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNode", g1.ContainsVertex(node) ? g1.AdjacentDegree(node) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeSrc", g1.ContainsVertex(e.Source) ? g1.AdjacentDegree(e.Source) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeTar", g1.ContainsVertex(e.Target) ? g1.AdjacentDegree(e.Target) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));
            PexObserve.ValueForViewing("$input_ContainsNodeSrc", g1.ContainsVertex(e.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar", g1.ContainsVertex(e.Target));
            PexObserve.ValueForViewing("$input_ContainsEdge", g1.ContainsVertex(e.Source) && g1.ContainsVertex(e.Target) ? g1.ContainsEdge(e.Source, e.Target) : false);

            AssumePrecondition.IsTrue(true);

            bool ae1 = true, ae2 = true, iaee1 = true, iaee2 = true;

            ae1 = g1.AddEdge(e);
            iaee1 = g1.IsAdjacentEdgesEmpty(node);

            iaee2 = g2.IsAdjacentEdgesEmpty(node);
            ae2 = g2.AddEdge(e);

            //NotpAssume.IsTrue(ae1 == ae2 && iaee1 == iaee2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(ae1 == ae2 && iaee1 == iaee2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityAddEdgeRangeAddEdgeRangeComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, [PexAssumeNotNull]int[] srcs1, [PexAssumeNotNull]int[] tars1, [PexAssumeNotNull]int[] srcs2, [PexAssumeNotNull]int[] tars2)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexAssume.IsTrue(srcs1.Length == tars1.Length && srcs1.Length < 11 && srcs2.Length == tars2.Length && srcs2.Length < 11);

            List<Edge<int>> edges1 = new List<Edge<int>>();
            for (int i = 0; i < srcs1.Length; i++)
            {
                edges1.Add(new Edge<int>(srcs1[i], tars1[i]));
            }

            List<Edge<int>> edges2 = new List<Edge<int>>();
            for (int i = 0; i < srcs2.Length; i++)
            {
                edges2.Add(new Edge<int>(srcs2[i], tars2[i]));
            }

            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AddEdgesCount1", srcs1.Length);
            PexObserve.ValueForViewing("$input_AddEdgesCount2", srcs2.Length);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);

            AssumePrecondition.IsTrue(true);

            g1.AddEdgeRange(edges1);
            g1.AddEdgeRange(edges2);

            g2.AddEdgeRange(edges2);
            g2.AddEdgeRange(edges1);

            //NotpAssume.IsTrue(eq.Equals(g1, g2));
            PexAssert.IsTrue(eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityAddEdgeRangeRemoveEdgeComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, [PexAssumeNotNull]int[] srcs, [PexAssumeNotNull]int[] tars, [PexAssumeNotNull]Edge<int> e)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexAssume.IsTrue(srcs.Length == tars.Length && srcs.Length < 11);

            List<Edge<int>> edges = new List<Edge<int>>();
            for (int i = 0; i < srcs.Length; i++)
            {
                edges.Add(new Edge<int>(srcs[i], tars[i]));
            }

            PexObserve.ValueForViewing("$input_SourceNode", e.Source);
            PexObserve.ValueForViewing("$input_TargetNode", e.Target);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AddEdgesCount", srcs.Length);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeSrc", g1.ContainsVertex(e.Source) ? g1.AdjacentDegree(e.Source) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeTar", g1.ContainsVertex(e.Target) ? g1.AdjacentDegree(e.Target) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNodeSrc", g1.ContainsVertex(e.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar", g1.ContainsVertex(e.Target));
            PexObserve.ValueForViewing("$input_ContainsEdge", g1.ContainsVertex(e.Source) && g1.ContainsVertex(e.Target) ? g1.ContainsEdge(e.Source, e.Target) : false);
            PexObserve.ValueForViewing("$input_EdgesContainEdge", edges.Contains(e));

            AssumePrecondition.IsTrue(true);

            bool re1 = true, re2 = true;

            g1.AddEdgeRange(edges);
            re1 = g1.RemoveEdge(e);

            re2 = g2.RemoveEdge(e);
            g2.AddEdgeRange(edges);

            //NotpAssume.IsTrue(re1 == re2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(re1 == re2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityAddEdgeRangeRemoveEdgesComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, [PexAssumeNotNull]int[] srcs1, [PexAssumeNotNull]int[] tars1, [PexAssumeNotNull]int[] srcs2, [PexAssumeNotNull]int[] tars2)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexAssume.IsTrue(srcs1.Length == tars1.Length && srcs1.Length < 11 && srcs2.Length == tars2.Length && srcs2.Length < 11);

            List<Edge<int>> edges1 = new List<Edge<int>>();
            for (int i = 0; i < srcs1.Length; i++)
            {
                edges1.Add(new Edge<int>(srcs1[i], tars1[i]));
            }

            List<Edge<int>> edges2 = new List<Edge<int>>();
            for (int i = 0; i < srcs2.Length; i++)
            {
                edges2.Add(new Edge<int>(srcs2[i], tars2[i]));
            }

            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AddEdgesCount1", srcs1.Length);
            PexObserve.ValueForViewing("$input_AddEdgesCount2", srcs2.Length);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);

            AssumePrecondition.IsTrue(true);

            int re1 = 0, re2 = 0;

            g1.AddEdgeRange(edges1);
            re1 = g1.RemoveEdges(edges2);

            re2 = g2.RemoveEdges(edges2);
            g2.AddEdgeRange(edges1);

            //NotpAssume.IsTrue(re1 == re2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(re1 == re2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityAddEdgeRangeIsEdgesEmptyComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, [PexAssumeNotNull]int[] srcs, [PexAssumeNotNull]int[] tars)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexAssume.IsTrue(srcs.Length == tars.Length && srcs.Length < 11);

            List<Edge<int>> edges = new List<Edge<int>>();
            for (int i = 0; i < srcs.Length; i++)
            {
                edges.Add(new Edge<int>(srcs[i], tars[i]));
            }

            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AddEdgesCount", srcs.Length);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);

            AssumePrecondition.IsTrue(true);

            bool iee1 = true, iee2 = true;

            g1.AddEdgeRange(edges);
            iee1 = g1.IsEdgesEmpty;

            iee2 = g2.IsEdgesEmpty;
            g2.AddEdgeRange(edges);

            //NotpAssume.IsTrue(iee1 == iee2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(iee1 == iee2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityAddEdgeRangeEdgeCountComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, [PexAssumeNotNull]int[] srcs, [PexAssumeNotNull]int[] tars)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexAssume.IsTrue(srcs.Length == tars.Length && srcs.Length < 11);

            List<Edge<int>> edges = new List<Edge<int>>();
            for (int i = 0; i < srcs.Length; i++)
            {
                edges.Add(new Edge<int>(srcs[i], tars[i]));
            }

            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AddEdgesCount", srcs.Length);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);

            AssumePrecondition.IsTrue(true);

            int ec1 = 0, ec2 = 0;

            g1.AddEdgeRange(edges);
            ec1 = g1.EdgeCount;

            ec2 = g2.EdgeCount;
            g2.AddEdgeRange(edges);

            //NotpAssume.IsTrue(ec1 == ec2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(ec1 == ec2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityAddEdgeRangeAdjacentEdgesComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, [PexAssumeNotNull]int[] srcs, [PexAssumeNotNull]int[] tars, int node)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexAssume.IsTrue(srcs.Length == tars.Length && srcs.Length < 11);

            List<Edge<int>> edges = new List<Edge<int>>();
            for (int i = 0; i < srcs.Length; i++)
            {
                edges.Add(new Edge<int>(srcs[i], tars[i]));
            }

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree", g1.ContainsVertex(node) ? g1.AdjacentDegree(node) : 0);
            PexObserve.ValueForViewing("$input_AddEdgesCount", srcs.Length);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));

            AssumePrecondition.IsTrue(true);

            g1.AddEdgeRange(edges);
            var ae1 = g1.AdjacentEdges(node);

            var ae2 = g2.AdjacentEdges(node);
            g2.AddEdgeRange(edges);

            bool equal = true;

            if (ae1.Count() != ae2.Count())
            {
                equal = false;
            }

            for (int i = 0; i < ae1.Count(); i++)
            {
                if (ae1.ElementAt(i).Source != ae2.ElementAt(i).Source || ae1.ElementAt(i).Source != ae2.ElementAt(i).Source)
                {
                    equal = false;
                }
            }

            //NotpAssume.IsTrue(equal && eq.Equals(g1, g2));
            PexAssert.IsTrue(equal && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityAddEdgeRangeAdjacentDegreeComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, [PexAssumeNotNull]int[] srcs, [PexAssumeNotNull]int[] tars, int node)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexAssume.IsTrue(srcs.Length == tars.Length && srcs.Length < 11);

            List<Edge<int>> edges = new List<Edge<int>>();
            for (int i = 0; i < srcs.Length; i++)
            {
                edges.Add(new Edge<int>(srcs[i], tars[i]));
            }

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree", g1.ContainsVertex(node) ? g1.AdjacentDegree(node) : 0);
            PexObserve.ValueForViewing("$input_AddEdgesCount", srcs.Length);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));

            AssumePrecondition.IsTrue(true);

            int ad1 = 0, ad2 = 0;

            g1.AddEdgeRange(edges);
            ad1 = g1.AdjacentDegree(node);

            ad2 = g2.AdjacentDegree(node);
            g2.AddEdgeRange(edges);

            //NotpAssume.IsTrue(ad1 == ad2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(ad1 == ad2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityAddEdgeRangeIsAdjacentEdgesEmptyComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, [PexAssumeNotNull]int[] srcs, [PexAssumeNotNull]int[] tars, int node)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexAssume.IsTrue(srcs.Length == tars.Length && srcs.Length < 11);

            List<Edge<int>> edges = new List<Edge<int>>();
            for (int i = 0; i < srcs.Length; i++)
            {
                edges.Add(new Edge<int>(srcs[i], tars[i]));
            }

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree", g1.ContainsVertex(node) ? g1.AdjacentDegree(node) : 0);
            PexObserve.ValueForViewing("$input_AddEdgesCount", srcs.Length);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));

            AssumePrecondition.IsTrue(true);

            bool iaee1 = true, iaee2 = true;

            g1.AddEdgeRange(edges);
            iaee1 = g1.IsAdjacentEdgesEmpty(node);

            iaee2 = g2.IsAdjacentEdgesEmpty(node);
            g2.AddEdgeRange(edges);

            //NotpAssume.IsTrue(iaee1 == iaee2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(iaee1 == iaee2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityRemoveEdgeRemoveEdgeComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, [PexAssumeNotNull]Edge<int> e1, [PexAssumeNotNull]Edge<int> e2)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_SourceNode1", e1.Source);
            PexObserve.ValueForViewing("$input_TargetNode1", e1.Target);
            PexObserve.ValueForViewing("$input_SourceNode2", e2.Source);
            PexObserve.ValueForViewing("$input_TargetNode2", e2.Target);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeSrc1", g1.ContainsVertex(e1.Source) ? g1.AdjacentDegree(e1.Source) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeTar1", g1.ContainsVertex(e1.Target) ? g1.AdjacentDegree(e1.Target) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeSrc2", g1.ContainsVertex(e2.Source) ? g1.AdjacentDegree(e2.Source) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeTar2", g1.ContainsVertex(e2.Target) ? g1.AdjacentDegree(e2.Target) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNodeSrc1", g1.ContainsVertex(e1.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar1", g1.ContainsVertex(e1.Target));
            PexObserve.ValueForViewing("$input_ContainsNodeSrc2", g1.ContainsVertex(e2.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar2", g1.ContainsVertex(e2.Target));
            PexObserve.ValueForViewing("$input_ContainsEdge1", g1.ContainsVertex(e1.Source) && g1.ContainsVertex(e1.Target) ? g1.ContainsEdge(e1.Source, e1.Target) : false);
            PexObserve.ValueForViewing("$input_ContainsEdge2", g1.ContainsVertex(e2.Source) && g1.ContainsVertex(e2.Target) ? g1.ContainsEdge(e2.Source, e2.Target) : false);

            AssumePrecondition.IsTrue(true);

            bool re11 = true, re12 = true, re21 = true, re22 = true;

            re11 = g1.RemoveEdge(e1);
            re12 = g1.RemoveEdge(e2);

            re22 = g2.RemoveEdge(e2);
            re21 = g2.RemoveEdge(e1);

            //NotpAssume.IsTrue(re11 == re21 && re12 == re22 && eq.Equals(g1, g2));
            PexAssert.IsTrue(re11 == re21 && re12 == re22 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityRemoveEdgeRemoveEdgesComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, [PexAssumeNotNull]Edge<int> e, [PexAssumeNotNull]int[] srcs, [PexAssumeNotNull]int[] tars)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexAssume.IsTrue(srcs.Length == tars.Length && srcs.Length < 11);

            List<Edge<int>> edges = new List<Edge<int>>();
            for (int i = 0; i < srcs.Length; i++)
            {
                edges.Add(new Edge<int>(srcs[i], tars[i]));
            }

            PexObserve.ValueForViewing("$input_SourceNode", e.Source);
            PexObserve.ValueForViewing("$input_TargetNode", e.Target);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeSrc", g1.ContainsVertex(e.Source) ? g1.AdjacentDegree(e.Source) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeTar", g1.ContainsVertex(e.Target) ? g1.AdjacentDegree(e.Target) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNodeSrc", g1.ContainsVertex(e.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar", g1.ContainsVertex(e.Target));
            PexObserve.ValueForViewing("$input_ContainsEdge", g1.ContainsVertex(e.Source) && g1.ContainsVertex(e.Target) ? g1.ContainsEdge(e.Source, e.Target) : false);
            PexObserve.ValueForViewing("$input_EdgesContainEdge", edges.Contains(e));

            AssumePrecondition.IsTrue(true);

            bool re11 = true, re21 = true;
            int re12 = 0, re22 = 0;

            re11 = g1.RemoveEdge(e);
            re12 = g1.RemoveEdges(edges);

            re22 = g2.RemoveEdges(edges);
            re21 = g2.RemoveEdge(e);

            //NotpAssume.IsTrue(re11 == re21 && re12 == re22 && eq.Equals(g1, g2));
            PexAssert.IsTrue(re11 == re21 && re12 == re22 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityRemoveEdgeIsEdgesEmptyComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, [PexAssumeNotNull]Edge<int> e)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_SourceNode", e.Source);
            PexObserve.ValueForViewing("$input_TargetNode", e.Target);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeSrc", g1.ContainsVertex(e.Source) ? g1.AdjacentDegree(e.Source) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeTar", g1.ContainsVertex(e.Target) ? g1.AdjacentDegree(e.Target) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNodeSrc", g1.ContainsVertex(e.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar", g1.ContainsVertex(e.Target));
            PexObserve.ValueForViewing("$input_ContainsEdge", g1.ContainsVertex(e.Source) && g1.ContainsVertex(e.Target) ? g1.ContainsEdge(e.Source, e.Target) : false);

            AssumePrecondition.IsTrue(true);

            bool re1 = true, re2 = true, iee1 = true, iee2 = true;

            re1 = g1.RemoveEdge(e);
            iee1 = g1.IsEdgesEmpty;

            iee2 = g2.IsEdgesEmpty;
            re2 = g2.RemoveEdge(e);

            //NotpAssume.IsTrue(re1 == re2 && iee1 == iee2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(re1 == re2 && iee1 == iee2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityRemoveEdgeEdgeCountComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, [PexAssumeNotNull]Edge<int> e)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_SourceNode", e.Source);
            PexObserve.ValueForViewing("$input_TargetNode", e.Target);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeSrc", g1.ContainsVertex(e.Source) ? g1.AdjacentDegree(e.Source) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeTar", g1.ContainsVertex(e.Target) ? g1.AdjacentDegree(e.Target) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNodeSrc", g1.ContainsVertex(e.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar", g1.ContainsVertex(e.Target));
            PexObserve.ValueForViewing("$input_ContainsEdge", g1.ContainsVertex(e.Source) && g1.ContainsVertex(e.Target) ? g1.ContainsEdge(e.Source, e.Target) : false);

            AssumePrecondition.IsTrue(true);

            bool re1 = true, re2 = true;
            int ec1 = 0, ec2 = 0;

            re1 = g1.RemoveEdge(e);
            ec1 = g1.EdgeCount;

            ec2 = g2.EdgeCount;
            re2 = g2.RemoveEdge(e);

            //NotpAssume.IsTrue(re1 == re2 && ec1 == ec2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(re1 == re2 && ec1 == ec2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityRemoveEdgeAdjacentEdgesComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, [PexAssumeNotNull]Edge<int> e, int node)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_SourceNode", e.Source);
            PexObserve.ValueForViewing("$input_TargetNode", e.Target);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNode", g1.ContainsVertex(node) ? g1.AdjacentDegree(node) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeSrc", g1.ContainsVertex(e.Source) ? g1.AdjacentDegree(e.Source) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeTar", g1.ContainsVertex(e.Target) ? g1.AdjacentDegree(e.Target) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));
            PexObserve.ValueForViewing("$input_ContainsNodeSrc", g1.ContainsVertex(e.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar", g1.ContainsVertex(e.Target));
            PexObserve.ValueForViewing("$input_ContainsEdge", g1.ContainsVertex(e.Source) && g1.ContainsVertex(e.Target) ? g1.ContainsEdge(e.Source, e.Target) : false);

            AssumePrecondition.IsTrue(true);

            bool re1 = true, re2 = true;

            re1 = g1.RemoveEdge(e);
            var ae1 = g1.AdjacentEdges(node);

            var ae2 = g2.AdjacentEdges(node);
            re2 = g2.RemoveEdge(e);

            bool equal = true;

            if (ae1.Count() != ae2.Count())
            {
                equal = false;
            }

            for (int i = 0; i < ae1.Count(); i++)
            {
                if (ae1.ElementAt(i).Source != ae2.ElementAt(i).Source || ae1.ElementAt(i).Source != ae2.ElementAt(i).Source)
                {
                    equal = false;
                }
            }

            //NotpAssume.IsTrue(re1 == re2 && equal && eq.Equals(g1, g2));
            PexAssert.IsTrue(re1 == re2 && equal && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityRemoveEdgeAdjacentDegreeComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, [PexAssumeNotNull]Edge<int> e, int node)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_SourceNode", e.Source);
            PexObserve.ValueForViewing("$input_TargetNode", e.Target);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNode", g1.ContainsVertex(node) ? g1.AdjacentDegree(node) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeSrc", g1.ContainsVertex(e.Source) ? g1.AdjacentDegree(e.Source) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeTar", g1.ContainsVertex(e.Target) ? g1.AdjacentDegree(e.Target) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));
            PexObserve.ValueForViewing("$input_ContainsNodeSrc", g1.ContainsVertex(e.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar", g1.ContainsVertex(e.Target));
            PexObserve.ValueForViewing("$input_ContainsEdge", g1.ContainsVertex(e.Source) && g1.ContainsVertex(e.Target) ? g1.ContainsEdge(e.Source, e.Target) : false);

            AssumePrecondition.IsTrue(true);

            bool re1 = true, re2 = true;
            int ad1 = 0, ad2 = 0;

            re1 = g1.RemoveEdge(e);
            ad1 = g1.AdjacentDegree(node);

            ad2 = g2.AdjacentDegree(node);
            re2 = g2.RemoveEdge(e);

            //NotpAssume.IsTrue(re1 == re2 && ad1 == ad2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(re1 == re2 && ad1 == ad2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityRemoveEdgeIsAdjacentEdgesEmptyComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, [PexAssumeNotNull]Edge<int> e, int node)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_SourceNode", e.Source);
            PexObserve.ValueForViewing("$input_TargetNode", e.Target);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNode", g1.ContainsVertex(node) ? g1.AdjacentDegree(node) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeSrc", g1.ContainsVertex(e.Source) ? g1.AdjacentDegree(e.Source) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegreeNodeTar", g1.ContainsVertex(e.Target) ? g1.AdjacentDegree(e.Target) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));
            PexObserve.ValueForViewing("$input_ContainsNodeSrc", g1.ContainsVertex(e.Source));
            PexObserve.ValueForViewing("$input_ContainsNodeTar", g1.ContainsVertex(e.Target));
            PexObserve.ValueForViewing("$input_ContainsEdge", g1.ContainsVertex(e.Source) && g1.ContainsVertex(e.Target) ? g1.ContainsEdge(e.Source, e.Target) : false);

            AssumePrecondition.IsTrue(true);

            bool re1 = true, re2 = true, iaee1 = true, iaee2 = true;

            re1 = g1.RemoveEdge(e);
            iaee1 = g1.IsAdjacentEdgesEmpty(node);

            iaee2 = g2.IsAdjacentEdgesEmpty(node);
            re2 = g2.RemoveEdge(e);

            //NotpAssume.IsTrue(re1 == re2 && iaee1 == iaee2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(re1 == re2 && iaee1 == iaee2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityRemoveEdgesRemoveEdgesComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, [PexAssumeNotNull]int[] srcs1, [PexAssumeNotNull]int[] tars1, [PexAssumeNotNull]int[] srcs2, [PexAssumeNotNull]int[] tars2)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexAssume.IsTrue(srcs1.Length == tars1.Length && srcs1.Length < 11 && srcs2.Length == tars2.Length && srcs2.Length < 11);

            List<Edge<int>> edges1 = new List<Edge<int>>();
            for (int i = 0; i < srcs1.Length; i++)
            {
                edges1.Add(new Edge<int>(srcs1[i], tars1[i]));
            }

            List<Edge<int>> edges2 = new List<Edge<int>>();
            for (int i = 0; i < srcs2.Length; i++)
            {
                edges2.Add(new Edge<int>(srcs2[i], tars2[i]));
            }

            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AddEdgesCount1", srcs1.Length);
            PexObserve.ValueForViewing("$input_AddEdgesCount2", srcs2.Length);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);

            AssumePrecondition.IsTrue(true);

            int re11 = 0, re12 = 0, re21 = 0, re22 = 0;

            re11 = g1.RemoveEdges(edges1);
            re12 = g1.RemoveEdges(edges2);

            re22 = g2.RemoveEdges(edges2);
            re21 = g2.RemoveEdges(edges1);

            //NotpAssume.IsTrue(re11 == re21 && re12 == re22 && eq.Equals(g1, g2));
            PexAssert.IsTrue(re11 == re21 && re12 == re22 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityRemoveEdgesIsEdgesEmptyComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, [PexAssumeNotNull]int[] srcs, [PexAssumeNotNull]int[] tars)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexAssume.IsTrue(srcs.Length == tars.Length && srcs.Length < 11);

            List<Edge<int>> edges = new List<Edge<int>>();
            for (int i = 0; i < srcs.Length; i++)
            {
                edges.Add(new Edge<int>(srcs[i], tars[i]));
            }

            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AddEdgesCount", srcs.Length);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);

            AssumePrecondition.IsTrue(true);

            int re1 = 0, re2 = 0;
            bool iee1 = true, iee2 = true;

            re1 = g1.RemoveEdges(edges);
            iee1 = g1.IsEdgesEmpty;

            iee2 = g2.IsEdgesEmpty;
            re2 = g2.RemoveEdges(edges);

            //NotpAssume.IsTrue(re1 == re2 && iee1 == iee2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(re1 == re2 && iee1 == iee2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityRemoveEdgesEdgeCountComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, [PexAssumeNotNull]int[] srcs, [PexAssumeNotNull]int[] tars)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexAssume.IsTrue(srcs.Length == tars.Length && srcs.Length < 11);

            List<Edge<int>> edges = new List<Edge<int>>();
            for (int i = 0; i < srcs.Length; i++)
            {
                edges.Add(new Edge<int>(srcs[i], tars[i]));
            }

            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AddEdgesCount", srcs.Length);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);

            AssumePrecondition.IsTrue(true);

            int re1 = 0, re2 = 0, ec1 = 0, ec2 = 0;

            re1 = g1.RemoveEdges(edges);
            ec1 = g1.EdgeCount;

            ec2 = g2.EdgeCount;
            re2 = g2.RemoveEdges(edges);

            //NotpAssume.IsTrue(re1 == re2 && ec1 == ec2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(re1 == re2 && ec1 == ec2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityRemoveEdgesAdjacentEdgesComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, [PexAssumeNotNull]int[] srcs, [PexAssumeNotNull]int[] tars, int node)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexAssume.IsTrue(srcs.Length == tars.Length && srcs.Length < 11);

            List<Edge<int>> edges = new List<Edge<int>>();
            for (int i = 0; i < srcs.Length; i++)
            {
                edges.Add(new Edge<int>(srcs[i], tars[i]));
            }

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree", g1.ContainsVertex(node) ? g1.AdjacentDegree(node) : 0);
            PexObserve.ValueForViewing("$input_AddEdgesCount", srcs.Length);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));

            AssumePrecondition.IsTrue(true);

            int re1 = 0, re2 = 0;

            re1 = g1.RemoveEdges(edges);
            var ae1 = g1.AdjacentEdges(node);

            var ae2 = g2.AdjacentEdges(node);
            re2 = g2.RemoveEdges(edges);

            bool equal = true;

            if (ae1.Count() != ae2.Count())
            {
                equal = false;
            }

            for (int i = 0; i < ae1.Count(); i++)
            {
                if (ae1.ElementAt(i).Source != ae2.ElementAt(i).Source || ae1.ElementAt(i).Source != ae2.ElementAt(i).Source)
                {
                    equal = false;
                }
            }

            //NotpAssume.IsTrue(re1 == re2 && equal && eq.Equals(g1, g2));
            PexAssert.IsTrue(re1 == re2 && equal && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityRemoveEdgesAdjacentDegreeComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, [PexAssumeNotNull]int[] srcs, [PexAssumeNotNull]int[] tars, int node)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexAssume.IsTrue(srcs.Length == tars.Length && srcs.Length < 11);

            List<Edge<int>> edges = new List<Edge<int>>();
            for (int i = 0; i < srcs.Length; i++)
            {
                edges.Add(new Edge<int>(srcs[i], tars[i]));
            }

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree", g1.ContainsVertex(node) ? g1.AdjacentDegree(node) : 0);
            PexObserve.ValueForViewing("$input_AddEdgesCount", srcs.Length);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));

            AssumePrecondition.IsTrue(true);

            int re1 = 0, re2 = 0, ad1 = 0, ad2 = 0;

            re1 = g1.RemoveEdges(edges);
            ad1 = g1.AdjacentDegree(node);

            ad2 = g2.AdjacentDegree(node);
            re2 = g2.RemoveEdges(edges);

            //NotpAssume.IsTrue(re1 == re2 && ad1 == ad2 &&  eq.Equals(g1, g2));
            PexAssert.IsTrue(re1 == re2 && ad1 == ad2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityRemoveEdgesIsAdjacentEdgesEmptyComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, [PexAssumeNotNull]int[] srcs, [PexAssumeNotNull]int[] tars, int node)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexAssume.IsTrue(srcs.Length == tars.Length && srcs.Length < 11);

            List<Edge<int>> edges = new List<Edge<int>>();
            for (int i = 0; i < srcs.Length; i++)
            {
                edges.Add(new Edge<int>(srcs[i], tars[i]));
            }

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree", g1.ContainsVertex(node) ? g1.AdjacentDegree(node) : 0);
            PexObserve.ValueForViewing("$input_AddEdgesCount", srcs.Length);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));

            AssumePrecondition.IsTrue(true);

            int re1 = 0, re2 = 0;
            bool iaee1 = true, iaee2 = true;

            re1 = g1.RemoveEdges(edges);
            iaee1 = g1.IsAdjacentEdgesEmpty(node);

            iaee2 = g2.IsAdjacentEdgesEmpty(node);
            re2 = g2.RemoveEdges(edges);

            //NotpAssume.IsTrue(re1 == re2 && iaee1 == iaee2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(re1 == re2 && iaee1 == iaee2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityIsEdgesEmptyIsEdgesEmptyComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);

            AssumePrecondition.IsTrue(true);

            bool iee11 = true, iee12 = true, iee21 = true, iee22 = true;

            iee11 = g1.IsEdgesEmpty;
            iee12 = g1.IsEdgesEmpty;

            iee22 = g2.IsEdgesEmpty;
            iee21 = g2.IsEdgesEmpty;

            //NotpAssume.IsTrue(iee11 == iee21 && iee12 == iee22 && eq.Equals(g1, g2));
            PexAssert.IsTrue(iee11 == iee21 && iee12 == iee22 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityIsEdgesEmptyEdgeCountComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);

            AssumePrecondition.IsTrue(true);

            bool iee1 = true, iee2 = true;
            int ec1 = 0, ec2 = 0;

            iee1 = g1.IsEdgesEmpty;
            ec1 = g1.EdgeCount;

            ec2 = g2.EdgeCount;
            iee2 = g2.IsEdgesEmpty;

            //NotpAssume.IsTrue(iee1 == iee2 && ec1 == ec2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(iee1 == iee2 && ec1 == ec2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityIsEdgesEmptyAdjacentEdgesComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree", g1.ContainsVertex(node) ? g1.AdjacentDegree(node) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));

            AssumePrecondition.IsTrue(true);

            bool iee1 = true, iee2 = true;

            iee1 = g1.IsEdgesEmpty;
            var ae1 = g1.AdjacentEdges(node);

            var ae2 = g2.AdjacentEdges(node);
            iee2 = g2.IsEdgesEmpty;

            bool equal = true;

            if (ae1.Count() != ae2.Count())
            {
                equal = false;
            }

            for (int i = 0; i < ae1.Count(); i++)
            {
                if (ae1.ElementAt(i).Source != ae2.ElementAt(i).Source || ae1.ElementAt(i).Source != ae2.ElementAt(i).Source)
                {
                    equal = false;
                }
            }

            //NotpAssume.IsTrue(iee1 == iee2 && equal && eq.Equals(g1, g2));
            PexAssert.IsTrue(iee1 == iee2 && equal && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityIsEdgesEmptyAdjacentDegreeComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree", g1.ContainsVertex(node) ? g1.AdjacentDegree(node) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));

            AssumePrecondition.IsTrue(true);

            bool iee1 = true, iee2 = true;
            int ad1 = 0, ad2 = 0;

            iee1 = g1.IsEdgesEmpty;
            ad1 = g1.AdjacentDegree(node);

            ad2 = g2.AdjacentDegree(node);
            iee2 = g2.IsEdgesEmpty;

            //NotpAssume.IsTrue(iee1 == iee2 && ad1 == ad2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(iee1 == iee2 && ad1 == ad2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityIsEdgesEmptyIsAdjacentEdgesEmptyComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree", g1.ContainsVertex(node) ? g1.AdjacentDegree(node) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));

            AssumePrecondition.IsTrue(true);

            bool iee1 = true, iee2 = true, iaee1 = true, iaee2 = true;

            iee1 = g1.IsEdgesEmpty;
            iaee1 = g1.IsAdjacentEdgesEmpty(node);

            iaee2 = g2.IsAdjacentEdgesEmpty(node);
            iee2 = g2.IsEdgesEmpty;

            //NotpAssume.IsTrue(iee1 == iee2 && iaee1 == iaee2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(iee1 == iee2 && iaee1 == iaee2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityEdgeCountEdgeCountComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);

            AssumePrecondition.IsTrue(true);

            int ec11 = 0, ec12 = 0, ec21 = 0, ec22 = 0;

            ec11 = g1.EdgeCount;
            ec12 = g1.EdgeCount;

            ec22 = g2.EdgeCount;
            ec21 = g2.EdgeCount;

            //NotpAssume.IsTrue(ec11 == ec21 && ec12 == ec22 && eq.Equals(g1, g2));
            PexAssert.IsTrue(ec11 == ec21 && ec12 == ec22 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityEdgeCountAdjacentEdgesComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree", g1.ContainsVertex(node) ? g1.AdjacentDegree(node) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));

            AssumePrecondition.IsTrue(true);

            int ec1 = 0, ec2 = 0;

            ec1 = g1.EdgeCount;
            var ae1 = g1.AdjacentEdges(node);

            var ae2 = g2.AdjacentEdges(node);
            ec2 = g2.EdgeCount;

            bool equal = true;

            if (ae1.Count() != ae2.Count())
            {
                equal = false;
            }

            for (int i = 0; i < ae1.Count(); i++)
            {
                if (ae1.ElementAt(i).Source != ae2.ElementAt(i).Source || ae1.ElementAt(i).Source != ae2.ElementAt(i).Source)
                {
                    equal = false;
                }
            }

            //NotpAssume.IsTrue(ec1 == ec2 && equal && eq.Equals(g1, g2));
            PexAssert.IsTrue(ec1 == ec2 && equal && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityEdgeCountAdjacentDegreeComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree", g1.ContainsVertex(node) ? g1.AdjacentDegree(node) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));

            AssumePrecondition.IsTrue(true);

            int ec1 = 0, ec2 = 0, ad1 = 0, ad2 = 0;

            ec1 = g1.EdgeCount;
            ad1 = g1.AdjacentDegree(node);

            ad2 = g2.AdjacentDegree(node);
            ec2 = g2.EdgeCount;

            //NotpAssume.IsTrue(ec1 == ec2 && ad1 == ad2 && q.Equals(g1, g2));
            PexAssert.IsTrue(ec1 == ec2 && ad1 == ad2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityEdgeCountIsAdjacentEdgesEmptyComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node", node);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree", g1.ContainsVertex(node) ? g1.AdjacentDegree(node) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode", g1.ContainsVertex(node));

            AssumePrecondition.IsTrue(true);

            int ec1 = 0, ec2 = 0;
            bool iaee1 = true, iaee2 = true;

            ec1 = g1.EdgeCount;
            iaee1 = g1.IsAdjacentEdgesEmpty(node);

            iaee2 = g2.IsAdjacentEdgesEmpty(node);
            ec2 = g2.EdgeCount;

            //NotpAssume.IsTrue(ec1 == ec2 && iaee1 == iaee2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(ec1 == ec2 && iaee1 == iaee2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityAdjacentEdgesAdjacentEdgesComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node1, int node2)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node1", node1);
            PexObserve.ValueForViewing("$input_Node2", node2);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree1", g1.ContainsVertex(node1) ? g1.AdjacentDegree(node1) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegree2", g1.ContainsVertex(node2) ? g1.AdjacentDegree(node2) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode1", g1.ContainsVertex(node1));
            PexObserve.ValueForViewing("$input_ContainsNode2", g1.ContainsVertex(node2));

            AssumePrecondition.IsTrue(true);

            var ae11 = g1.AdjacentEdges(node1);
            var ae12 = g1.AdjacentEdges(node2);

            var ae22 = g2.AdjacentEdges(node2);
            var ae21 = g2.AdjacentEdges(node1);

            bool equal1 = true;

            if (ae11.Count() != ae21.Count())
            {
                equal1 = false;
            }

            for (int i = 0; i < ae11.Count(); i++)
            {
                if (ae11.ElementAt(i).Source != ae21.ElementAt(i).Source || ae11.ElementAt(i).Source != ae21.ElementAt(i).Source)
                {
                    equal1 = false;
                }
            }

            bool equal2 = true;

            if (ae12.Count() != ae22.Count())
            {
                equal2 = false;
            }

            for (int i = 0; i < ae11.Count(); i++)
            {
                if (ae12.ElementAt(i).Source != ae22.ElementAt(i).Source || ae12.ElementAt(i).Source != ae22.ElementAt(i).Source)
                {
                    equal2 = false;
                }
            }

            //NotpAssume.IsTrue(equal && equal2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(equal1 && equal2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityAdjacentEdgesAdjacentDegreeComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node1, int node2)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node1", node1);
            PexObserve.ValueForViewing("$input_Node2", node2);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree1", g1.ContainsVertex(node1) ? g1.AdjacentDegree(node1) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegree2", g1.ContainsVertex(node2) ? g1.AdjacentDegree(node2) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode1", g1.ContainsVertex(node1));
            PexObserve.ValueForViewing("$input_ContainsNode2", g1.ContainsVertex(node2));

            AssumePrecondition.IsTrue(true);

            int ad1 = 0, ad2 = 0;

            var ae1 = g1.AdjacentEdges(node1);
            ad1 = g1.AdjacentDegree(node2);

            ad2 = g2.AdjacentDegree(node2);
            var ae2 = g2.AdjacentEdges(node1);

            bool equal = true;

            if (ae1.Count() != ae2.Count())
            {
                equal = false;
            }

            for (int i = 0; i < ae1.Count(); i++)
            {
                if (ae1.ElementAt(i).Source != ae2.ElementAt(i).Source || ae1.ElementAt(i).Source != ae2.ElementAt(i).Source)
                {
                    equal = false;
                }
            }

            //NotpAssume.IsTrue(equal && ad1 == ad2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(equal && ad1 == ad2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityAdjacentEdgesIsAdjacentEdgesEmptyComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node1, int node2)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node1", node1);
            PexObserve.ValueForViewing("$input_Node2", node2);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree1", g1.ContainsVertex(node1) ? g1.AdjacentDegree(node1) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegree2", g1.ContainsVertex(node2) ? g1.AdjacentDegree(node2) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode1", g1.ContainsVertex(node1));
            PexObserve.ValueForViewing("$input_ContainsNode2", g1.ContainsVertex(node2));

            AssumePrecondition.IsTrue(true);

            bool iaee1 = true, iaee2 = true;

            var ae1 = g1.AdjacentEdges(node1);
            iaee1 = g1.IsAdjacentEdgesEmpty(node2);

            iaee2 = g2.IsAdjacentEdgesEmpty(node2);
            var ae2 = g2.AdjacentEdges(node1);

            bool equal = true;

            if (ae1.Count() != ae2.Count())
            {
                equal = false;
            }

            for (int i = 0; i < ae1.Count(); i++)
            {
                if (ae1.ElementAt(i).Source != ae2.ElementAt(i).Source || ae1.ElementAt(i).Source != ae2.ElementAt(i).Source)
                {
                    equal = false;
                }
            }

            //NotpAssume.IsTrue(equal && iaee1 == iaee2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(equal && iaee1 == iaee2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityAdjacentDegreeAdjacentDegreeComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node1, int node2)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node1", node1);
            PexObserve.ValueForViewing("$input_Node2", node2);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree1", g1.ContainsVertex(node1) ? g1.AdjacentDegree(node1) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegree2", g1.ContainsVertex(node2) ? g1.AdjacentDegree(node2) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode1", g1.ContainsVertex(node1));
            PexObserve.ValueForViewing("$input_ContainsNode2", g1.ContainsVertex(node2));

            AssumePrecondition.IsTrue(true);

            int ad11 = 0, ad12 = 0, ad21 = 0, ad22 = 0;

            ad11 = g1.AdjacentDegree(node1);
            ad12 = g1.AdjacentDegree(node2);

            ad22 = g2.AdjacentDegree(node2);
            ad21 = g2.AdjacentDegree(node1);

            //NotpAssume.IsTrue(ad11 == ad21 && ad12 == ad22 && eq.Equals(g1, g2));
            PexAssert.IsTrue(ad11 == ad21 && ad12 == ad22 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityAdjacentDegreeIsAdjacentEdgesEmptyComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node1, int node2)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node1", node1);
            PexObserve.ValueForViewing("$input_Node2", node2);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree1", g1.ContainsVertex(node1) ? g1.AdjacentDegree(node1) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegree2", g1.ContainsVertex(node2) ? g1.AdjacentDegree(node2) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode1", g1.ContainsVertex(node1));
            PexObserve.ValueForViewing("$input_ContainsNode2", g1.ContainsVertex(node2));

            AssumePrecondition.IsTrue(true);

            int ad1 = 0, ad2 = 0;
            bool iaee1 = true, iaee2 = true;

            ad1 = g1.AdjacentDegree(node1);
            iaee1 = g1.IsAdjacentEdgesEmpty(node2);

            iaee2 = g2.IsAdjacentEdgesEmpty(node2);
            ad2 = g2.AdjacentDegree(node1);

            //NotpAssume.IsTrue(ad1 == ad2 && iaee1 == iaee2 && eq.Equals(g1, g2));
            PexAssert.IsTrue(ad1 == ad2 && iaee1 == iaee2 && eq.Equals(g1, g2));
        }

        [PexMethod]
        public void PUT_CommutativityIsAdjacentEdgesEmptyIsAdjacentEdgesEmptyComm([PexAssumeUnderTest] QuickGraph.UndirectedGraph<int, Edge<int>> g1, int node1, int node2)
        {
            UndirectedGraph<int, Edge<int>> g2 = (UndirectedGraph<int, Edge<int>>)g1.Clone();
            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();

            PexObserve.ValueForViewing("$input_Node1", node1);
            PexObserve.ValueForViewing("$input_Node2", node2);
            PexObserve.ValueForViewing("$input_VertexCount", g1.VertexCount);
            PexObserve.ValueForViewing("$input_EdgeCount", g1.EdgeCount);
            PexObserve.ValueForViewing("$input_AdjacentDegree1", g1.ContainsVertex(node1) ? g1.AdjacentDegree(node1) : 0);
            PexObserve.ValueForViewing("$input_AdjacentDegree2", g1.ContainsVertex(node2) ? g1.AdjacentDegree(node2) : 0);
            PexObserve.ValueForViewing("$input_IsVerticesEmpty", g1.IsVerticesEmpty);
            PexObserve.ValueForViewing("$input_IsEdgesEmpty", g1.IsEdgesEmpty);
            PexObserve.ValueForViewing("$input_AllowParallelEdges", g1.AllowParallelEdges);
            PexObserve.ValueForViewing("$input_ContainsNode1", g1.ContainsVertex(node1));
            PexObserve.ValueForViewing("$input_ContainsNode2", g1.ContainsVertex(node2));

            AssumePrecondition.IsTrue(true);

            bool iaee11 = true, iaee12 = true, iaee21 = true, iaee22 = true;

            iaee11 = g1.IsAdjacentEdgesEmpty(node1);
            iaee12 = g1.IsAdjacentEdgesEmpty(node2);

            iaee22 = g2.IsAdjacentEdgesEmpty(node2);
            iaee21 = g2.IsAdjacentEdgesEmpty(node1);

            //NotpAssume.IsTrue(iaee11 == iaee21 && iaee12 == iaee22 && eq.Equals(g1, g2));
            PexAssert.IsTrue(iaee11 == iaee21 && iaee12 == iaee22 && eq.Equals(g1, g2));
        }
    }
}
