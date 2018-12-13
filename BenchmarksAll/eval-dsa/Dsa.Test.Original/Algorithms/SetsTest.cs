using System;
using Dsa.Algorithms;
using Dsa.DataStructures;
using NUnit.Framework;

namespace Dsa.Test.Algorithms
{
    /// <summary>
    /// Tests for Set algorithms
    /// </summary>
    [TestFixture]
    public sealed class SetsTest
    {
        /// <summary>
        /// Check to see that the correct value is returned representing the number of permutations.
        /// </summary>
        [Test]
        public void PermutationTest()
        {
            OrderedSet<int> actual = new OrderedSet<int> { 10, 12, 45, 1 };

            Assert.AreEqual(12, actual.Permutations(2));
        }

        /// <summary>
        /// Check to see that the correct exception is raised when the set is null.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PermutationSetNullTest()
        {
            const OrderedSet<int> actual = null;

            actual.Permutations(2);
        }

        /// <summary>
        /// Check to see that the correct value is returned when trying to attain permutations for an empty set.
        /// </summary>
        [Test]
        public void PermutationsEmptySetTest()
        {
            OrderedSet<int> actual = new OrderedSet<int>();

            Assert.AreEqual(0, actual.Permutations(2));
        }

        /// <summary>
        /// Check to see that the correct exception is raised when the number of item permutations is 0.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PerumtationsEmptySetZeroItems()
        {
            OrderedSet<int> actual = new OrderedSet<int>();

            actual.Permutations(0);
        }
    }
}