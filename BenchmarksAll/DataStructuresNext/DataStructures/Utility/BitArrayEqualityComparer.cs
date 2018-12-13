using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.Utility
{
    public class BitArrayEqualityComparer : EqualityComparer<BitArray>
    {

        public override bool Equals(DataStructures.BitArray q1, DataStructures.BitArray q2)
        {
            if (q1 == null || q2 == null)
                return false;
            else if (q1.Count != q2.Count)
                return false;

            foreach (var item in q1)
            {

            }
            return true;
        }

        public override int GetHashCode(DataStructures.BitArray q)
        {
            int hash = 0;
            
            return hash;

        }


    }
}
