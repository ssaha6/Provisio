using System;
using System.Text;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures.Utility;
using System.Collections.Generic;
using DataStructures;

namespace DataStructures.UnitTest
{
    /// <summary>
    /// Summary description for HashSetTest
    /// </summary>
    [TestClass]
    public class HashSetTest
    {
        public HashSetTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

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
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

       [TestMethod]
        public void Add_TwoIdenticalItems_SizeOne()
        {
            HashSet<int> s1 = new HashSet<int>(2);
            s1.Add(2);
            s1.Add(2);

            Assert.AreEqual(1, s1.Count);

        }

       [TestMethod]
       public void Add_FourDistinctlItems_SizeFour()
       {
           HashSet<int> s1 = new HashSet<int>(2);
           
           s1.Add(2);
           s1.Add(5);
           s1.Add(7);
           s1.Add(8);
           Assert.AreEqual(4, s1.Count);

       }

       [TestMethod]
       public void Remove_oneItemInSet_Size1()
       {
           HashSet<int> s1 = new HashSet<int>(4);

           s1.Add(2);
           s1.Add(5);
           s1.Remove(5);
           
           Assert.AreEqual(1, s1.Count );

       }

       [TestMethod]
       public void Contains_ItemInSet_True()
       {
           HashSet<int> s1 = new HashSet<int>(4);

           s1.Add(2);
           Assert.IsTrue(s1.Contains(2));

       }
        
        
    }
}
