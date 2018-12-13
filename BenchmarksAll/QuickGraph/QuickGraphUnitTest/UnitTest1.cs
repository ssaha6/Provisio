using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuickGraph;
using QuickGraph.Utility;

namespace QuickGraphUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var g = new UndirectedGraph<int, Edge<int>>();
            g.AddVertex(1);
            g.AddVertex(2);
            g.AddEdge(new Edge<int>(1, 2));
            bool c = g.ContainsEdge(2, 1);
            Assert.AreEqual(true, c);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var g = new UndirectedGraph<int, Edge<int>>();
            g.AddVertex(1);
            g.AddVertex(2);
            g.AddEdge(new Edge<int>(1, 2));
            bool c = g.ContainsEdge(new Edge<int>(2, 1));
            Assert.AreEqual(true, c);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var g = new UndirectedGraph<int, Edge<int>>();
            g.AddVertex(1);
            g.AddVertex(2);
            var e = new Edge<int>(1, 2);
            g.AddEdge(e);
            var edges = g.Edges;

            foreach (Edge<int> edge in edges)
            {
                System.Console.Write("Source: {0}, Target: {1}\n", edge.Source, edge.Target);
            }

            bool c = g.ContainsEdge(e);
            Assert.AreEqual(true, c);
        }

        [TestMethod]
        public void TestMethod4()
        {
            UndirectedGraph<int, Edge<int>> g = new UndirectedGraph<int, Edge<int>>(false);
            g.AddVertex(1);
            g.AddVertex(2);
            g.AddVertex(3);
            g.AddVertex(4);
            var e1 = new Edge<int>(1, 2);
            var e2 = new Edge<int>(2, 3);
            var e3 = new Edge<int>(3, 4);
            g.AddEdge(e1);
            g.AddEdge(e2);
            g.AddEdge(e3);
            Assert.IsTrue(g.VertexCount == 4);
            Assert.IsTrue(g.EdgeCount == 3);

            UndirectedGraphEqualityComparer eq = new UndirectedGraphEqualityComparer();
            UndirectedGraph<int, Edge<int>> g2 = g.Clone();
            Assert.IsTrue(eq.Equals(g,g2));
            Assert.IsTrue(g != g2);
            var e4 = new Edge<int>(2, 4);
            g2.AddEdge(e4);
            Assert.IsTrue(!eq.Equals(g, g2));
            Assert.IsTrue(g2.EdgeCount == 4);
            Assert.IsTrue(g.EdgeCount == 3);

            g.AddVertex(5);
            Assert.IsTrue(g.VertexCount == 5);
            Assert.IsTrue(g2.VertexCount == 4);
            Assert.IsTrue(!g.ContainsEdge(e4));

            Assert.IsTrue(g2.ContainsEdge(e1));

            //removing
            g.RemoveEdge(e1);
            Assert.IsTrue(g2.EdgeCount == 4);
            Assert.IsTrue(g.EdgeCount == 2);
            g2.RemoveEdge(e2);

            Assert.IsTrue(g2.EdgeCount == 3);
            Assert.IsTrue(g.EdgeCount == 2);
        }

        [TestMethod]
        public void TestBinaryHeap()
        {
            BinaryHeap<int, int> bh = new BinaryHeap<int, int>();
            bh.Add(0, 5);
            bh.Add(0, 0);
            bh.Add(3, 6);
            //Assert.IsTrue(bh.items[0].Value == 0);
            //Assert.IsTrue(bh.items[1].Value == 5);
            //Assert.IsTrue(bh.items[2].Key == 3);
            bh.ObjectInvariant();

            Assert.IsTrue(bh.IndexOf(0) == 0);
            Assert.IsTrue(bh.Minimum().Key == 0);
           // Assert.IsTrue(bh.Count == 3);
           

           // Assert.IsTrue(bh.RemoveMinimum().Key == 0);
        
        }
    }
}
