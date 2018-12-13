// <copyright file="EdgeFactory.cs">Copyright ? 2018</copyright>

using System;
using Microsoft.Pex.Framework;
using QuickGraph;

namespace QuickGraphTest.Factories
{
    /// <summary>A factory for QuickGraph.Edge`1[System.String] instances</summary>
    public static partial class EdgeFactory
    {
       
        /// <summary>A factory for QuickGraph.Edge`1[System.Int32] instances</summary>
        [PexFactoryMethod(typeof(Edge<int>))]
        public static Edge<int> Create(int source_i, int target_i1)
        {
            PexAssume.IsTrue(source_i != target_i1);

            Edge<int> edge = new Edge<int>(source_i, target_i1);
            return edge;

            // TODO: Edit factory method of Edge`1<Int32>
            // This method should be able to configure the object in all possible ways.
            // Add as many parameters as needed,
            // and assign their values to each field by using the API.
        }
    }
}
