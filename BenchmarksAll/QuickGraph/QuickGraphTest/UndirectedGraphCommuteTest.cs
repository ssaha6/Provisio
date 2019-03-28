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

            AssumePrecondition.IsTrue(!(true));
            g1.AddVertex(node1);
            g1.AddVertex(node2);

            g2.AddVertex(node2);
            g2.AddVertex(node1);

            NotpAssume.IsTrue(eq.Equals(g1, g2));
            try{PexAssert.IsTrue(false);}catch{return;}
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
    }
}
