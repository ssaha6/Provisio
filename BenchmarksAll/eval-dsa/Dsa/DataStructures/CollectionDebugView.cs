// <copyright file="CollectionDebugView.cs" company="Data Structures and Algorithms">
//   Copyright (C) Data Structures and Algorithms Team.
// </copyright>
// <summary>
//   Used to show a simpler view of collections rather than dumping a Raw view on the user
//   by default when debugging.
// </summary>
using System.Collections.Generic;
using System.Diagnostics;
using Dsa.Utility;

namespace Dsa.DataStructures
{
    /// <summary>
    /// Provides a simpler alternative to Raw view in the debugger.
    /// </summary>
    /// <typeparam name="T">Type of the CollectionDebugView.</typeparam>
    internal sealed class CollectionDebugView<T>
    {
        private readonly ICollection<T> m_collection;

        public CollectionDebugView(ICollection<T> collection)
        {
            Guard.ArgumentNull(collection, "collection");
            
            m_collection = collection;
        }

        /// <summary>
        /// Gets all the items in the collection as an array. By making the RootHidden the debugger doesn't display the items as
        /// elements of the property Items, rather just items of the array.
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public T[] Items
        {
            get
            {
                T[] items = new T[m_collection.Count];
                m_collection.CopyTo(items, 0);
                return items;
            }
        }
    }
}
