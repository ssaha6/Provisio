using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.Utility
{
    
    public class ArrayListEqualityComparer : EqualityComparer<ArrayList>
    {

        public override bool Equals(DataStructures.ArrayList q1, DataStructures.ArrayList q2)
        {
            if (q1 == null || q2 == null)
                return false;
            else if (q1.Count != q2.Count)
                return false;

            for (int i = 0; i < q1.Count; i++)
            {
                if ((int)q1[i] != (int)q2[i])
                    return false;

            }
            return true;
        }
        /* Angello's code: Only works for ints*/
        public override int GetHashCode(DataStructures.ArrayList q)
        {
            int hash = 0;
            for (int i = 0; i < q.Count; i++)
            {
                hash += i * (int)q[i];
            }

            return hash;

        }


    }
}
