// <copyright file="Strategy.cs" company="Data Structures and Algorithms">
//   Copyright (C) Data Structures and Algorithms Team.
// </copyright>
// <summary>
//   Used to describe the strategy of a collection that allows ordering on it's items.
// </summary>
namespace Dsa.DataStructures
{
    /// <summary>
    /// Defines the strategy of ordering for a collection.
    /// </summary>
    public enum Strategy
    {
        /// <summary>
        /// Min - objects with the lower value will have a higher priority within the collection.
        /// </summary>
        Min,

        /// <summary>
        /// Max - objects with the higher value will have a higher priority within the collection.
        /// </summary>
        Max
    }
}