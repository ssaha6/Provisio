// <copyright file="CommonBinaryTreeTNodeTValueTest.cs"></copyright>
using System;
using System.Collections.Generic;
using Dsa.DataStructures;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dsa.DataStructures
{
    [PexClass(typeof(CommonBinaryTree<, >))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class CommonBinaryTreeTNodeTValueTest
    {
        [PexMethod]
        public void Clear<TNode,TValue>([PexAssumeNotNull]CommonBinaryTree<TNode, TValue> target)
            where TNode : class, ICommonBinaryTreeNode<TNode, TValue>
            where TValue : IComparable<TValue>
        {
            target.Clear();
        }

        [PexMethod]
        public bool Contains<TNode,TValue>([PexAssumeNotNull]CommonBinaryTree<TNode, TValue> target, TValue item)
            where TNode : class, ICommonBinaryTreeNode<TNode, TValue>
            where TValue : IComparable<TValue>
        {
            bool result = target.Contains(item);
            return result;
        }

        [PexMethod]
        public TValue FindMax<TNode,TValue>([PexAssumeNotNull]CommonBinaryTree<TNode, TValue> target)
            where TNode : class, ICommonBinaryTreeNode<TNode, TValue>
            where TValue : IComparable<TValue>
        {
            TValue result = target.FindMax();
            return result;
        }

        [PexMethod]
        public TValue FindMin<TNode,TValue>([PexAssumeNotNull]CommonBinaryTree<TNode, TValue> target)
            where TNode : class, ICommonBinaryTreeNode<TNode, TValue>
            where TValue : IComparable<TValue>
        {
            TValue result = target.FindMin();
            return result;
        }

        [PexMethod]
        public TNode FindNode<TNode,TValue>([PexAssumeNotNull]CommonBinaryTree<TNode, TValue> target, TValue value)
            where TNode : class, ICommonBinaryTreeNode<TNode, TValue>
            where TValue : IComparable<TValue>
        {
            TNode result = target.FindNode(value);
            return result;
        }

        [PexMethod]
        public TNode FindParent<TNode,TValue>([PexAssumeNotNull]CommonBinaryTree<TNode, TValue> target, TValue value)
            where TNode : class, ICommonBinaryTreeNode<TNode, TValue>
            where TValue : IComparable<TValue>
        {
            TNode result = target.FindParent(value);
            return result;
        }

        [PexMethod]
        public IEnumerable<TValue> GetBreadthFirstEnumerator<TNode,TValue>([PexAssumeNotNull]CommonBinaryTree<TNode, TValue> target)
            where TNode : class, ICommonBinaryTreeNode<TNode, TValue>
            where TValue : IComparable<TValue>
        {
            IEnumerable<TValue> result = target.GetBreadthFirstEnumerator();
            return result;
        }

        [PexMethod]
        public IEnumerator<TValue> GetEnumerator<TNode,TValue>([PexAssumeNotNull]CommonBinaryTree<TNode, TValue> target)
            where TNode : class, ICommonBinaryTreeNode<TNode, TValue>
            where TValue : IComparable<TValue>
        {
            IEnumerator<TValue> result = target.GetEnumerator();
            return result;
        }

        [PexMethod]
        public IEnumerable<TValue> GetInorderEnumerator<TNode,TValue>([PexAssumeNotNull]CommonBinaryTree<TNode, TValue> target)
            where TNode : class, ICommonBinaryTreeNode<TNode, TValue>
            where TValue : IComparable<TValue>
        {
            IEnumerable<TValue> result = target.GetInorderEnumerator();
            return result;
        }

        [PexMethod]
        public IEnumerable<TValue> GetPostorderEnumerator<TNode,TValue>([PexAssumeNotNull]CommonBinaryTree<TNode, TValue> target)
            where TNode : class, ICommonBinaryTreeNode<TNode, TValue>
            where TValue : IComparable<TValue>
        {
            IEnumerable<TValue> result = target.GetPostorderEnumerator();
            return result;
        }

        [PexMethod]
        public TNode RootGet<TNode,TValue>([PexAssumeNotNull]CommonBinaryTree<TNode, TValue> target)
            where TNode : class, ICommonBinaryTreeNode<TNode, TValue>
            where TValue : IComparable<TValue>
        {
            TNode result = target.Root;
            return result;
        }

        [PexMethod]
        public TValue[] ToArray<TNode,TValue>([PexAssumeNotNull]CommonBinaryTree<TNode, TValue> target)
            where TNode : class, ICommonBinaryTreeNode<TNode, TValue>
            where TValue : IComparable<TValue>
        {
            TValue[] result = target.ToArray();
            return result;
        }
    }
}
