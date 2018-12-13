using System;

namespace Dsa.Test.Utility
{
    internal sealed class Person : IComparable<Person>
    {
        internal string FirstName { get; set; }
        internal string LastName { get; set; }

        public int CompareTo(Person other)
        {
            if (FirstName.ToUpper() == other.FirstName.ToUpper() && LastName.ToUpper() == other.LastName.ToUpper())
            {
                return 0;
            }
            return -1;
        }
    }
}
