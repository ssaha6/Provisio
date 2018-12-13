using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickGraph.Interfaces
{
    public interface IEdgeListGraph<TVertex, TEdge> :
        IGraph<TVertex, TEdge>,
        IEdgeSet<TVertex, TEdge>
        where TEdge : IEdge<TVertex>
    {}
}
