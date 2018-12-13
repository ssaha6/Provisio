using System;
using System.Text;
using System.Collections.Generic;
using DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.UnitTest
{
    /// <summary>
    /// Summary description for Dictionary
    /// </summary>
    [TestClass]
    public class DictionaryTest
    {
        public DictionaryTest()
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
        public void Add_addOneKey_ContainsKeyTrue()
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            dict.Add(1,3);

            Assert.IsTrue(dict.ContainsKey(1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_twoIdenticalKeys_Exception()
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            dict.Add(1, 3);
            dict.Add(1, 4);
            
        }

        [TestMethod]
        public void Remove_OneExistingEntry_SizeOne()
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            dict.Add(1, 3);
            dict.Add(2, 3);
            dict.Remove(1);
            
            Assert.IsTrue(dict.Count == 1);

        }
    }
}
