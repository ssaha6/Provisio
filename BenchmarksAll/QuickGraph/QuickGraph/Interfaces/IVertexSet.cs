using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickGraph.Interfaces
{
    public interface IVertexSet<TVertex>
    {
        bool IsVerticesEmpty { get; }
        int VertexCount { get; }
        IEnumerable<TVertex> Vertices { get; }
        bool ContainsVertex(TVertex vertex);
    }
}
