using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickGraph.Interfaces
{
    public interface IEdge<TVertex>
    {
        TVertex Source { get; }
        TVertex Target { get; }
    }
}
