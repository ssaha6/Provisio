// <copyright file="Guard.cs" company="Data Structures and Algorithms">
//   Copyright (C) Data Structures and Algorithms Team.
// </copyright>
// <summary>
//   Series of static methods to enforce pre-conditions of algorithms.
// </summary>
using System;

namespace Dsa.Utility
{
    /// <summary>
    /// A series of guard methods to check inputs to algorithms.
    /// </summary>
    public static class Guard
    {
        /// <summary>
        /// Guards against a null object reference.
        /// </summary>
        /// <param name="value">Object to verify is not null.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <exception cref="ArgumentNullException"><strong>value</strong> -- or -- <strong>parameterName</strong> are <strong>null</strong>.</exception>
        public static void ArgumentNull(object value, string parameterName)
        {
            if (parameterName == null)
            {
                throw new ArgumentNullException("parameterName");
            }

            if (value == null)
            {
                throw new ArgumentNullException(parameterName);
            }
        }

        /// <summary>
        /// Guards against a condition that should yield an <see cref="InvalidOperationException"/>.
        /// </summary>
        /// <param name="condition">Condition to satisfy when system is in an invalid state.</param>
        /// <param name="message">Message explanation for the invalid state.</param>
        /// <exception cref="ArgumentNullException"><strong>message</strong> is <strong>null</strong>.</exception>
        /// <exception cref="InvalidOperationException"><strong>condition</strong> is <strong>true</strong>.</exception>
        public static void InvalidOperation(bool condition, string message)
        {
            ArgumentNull(message, "message");

            if (condition)
            {
                throw new InvalidOperationException(message);
            }
        }

        /// <summary>
        /// Guards against a condition that is outside the valid range the algorithm expects.
        /// </summary>
        /// <param name="condition">Condition to satisty when the input is outside the valid range.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="message">Message explanation why the value is out of range.</param>
        /// <exception cref="ArgumentNullException"><strong>parameterName</strong> -- or -- <strong>message</strong> is <strong>null</strong>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><strong>condition</strong> is <strong>true</strong>.</exception>
        public static void OutOfRange(bool condition, string parameterName, string message)
        {
            ArgumentNull(parameterName, "parameterName");
            ArgumentNull(message, "message");

            if (condition)
            {
                throw new ArgumentOutOfRangeException(parameterName, message);
            }
        }
    }
}
