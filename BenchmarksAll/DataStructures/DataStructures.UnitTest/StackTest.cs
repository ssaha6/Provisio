using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures;
using DataStructures.Utility;

namespace DataStructures.UnitTest
{
    [TestClass]
    public class StackTest
    {
        private TestContext testContextInstance;
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion
        [TestMethod]
        public void PushStackTest()
        {
            Stack<int> s = new Stack<int>(2);
            s.Push(5);
            Assert.AreEqual(1, s.Count);

        }

        [TestMethod]
        public void PopStackTest()
        {
            Stack<int> s = new Stack<int>(2);
            s.Push(5);
            s.Pop();
            Assert.AreEqual(0, s.Count);

        }
        [TestMethod]
        public void MultipleItemsPopStackTest()
        {
            Stack<int> s = new Stack<int>(2);
            s.Push(5);
            s.Push(4);
            s.Push(3);
            s.Pop();
            Assert.IsTrue(s.Contains(5) && s.Contains(4));
        }

        [TestMethod]
        public void TestEqualityComparerWhenEqual()
        {
            Stack<int> s1 = new Stack<int>(2);
            s1.Push(5);
            Stack<int> s2 = new Stack<int>(2);
            s2.Push(5);
            StackEqualityComparer comp = new StackEqualityComparer();
            Assert.IsTrue(comp.Equals(s1,s2));
        }

        [TestMethod]
        public void TestEqualityComparerWhenNotEqual()
        {
            Stack<int> s1 = new Stack<int>(2);
            s1.Push(3);
            Stack<int> s2 = new Stack<int>(2);
            s2.Push(5);
            StackEqualityComparer comp = new StackEqualityComparer();
            Assert.IsFalse(comp.Equals(s1, s2));
        }

        [TestMethod]
        public void TestEqualityComparerWhenEqualButDifferentSize()
        {
            Stack<int> s1 = new Stack<int>(3);
            s1.Push(5);
            Stack<int> s2 = new Stack<int>(2);
            s2.Push(5);
            StackEqualityComparer comp = new StackEqualityComparer();
            Assert.IsTrue(comp.Equals(s1, s2));
        }

    }
}
