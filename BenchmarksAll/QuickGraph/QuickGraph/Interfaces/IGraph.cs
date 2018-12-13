using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickGraph.Interfaces
{
    public interface IGraph<TVertex, TEdge>
        where TEdge : IEdge<TVertex>
    {
        bool IsDirected { get; }
        bool AllowParallelEdges { get; }
    }
}
