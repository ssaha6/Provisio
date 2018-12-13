using System;
//using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataStructures;
using Microsoft.Pex.Framework;

namespace DataStructures.Test.Factories
{
    public static class HashSetFactory
    {
        [PexFactoryMethod(typeof(DataStructures.HashSet<int>))]
        public static DataStructures.HashSet<int> Create(int[] elems)
        {
            
            PexAssume.IsTrue(elems != null && elems.Length < 50);
            DataStructures.HashSet<int> ret = new DataStructures.HashSet<int>(elems.Length + 2);// DataStructure has big enough capacity for Commutativity Test
            for (int i = 0; i < elems.Length; i++)
            {
                PexAssume.IsTrue(elems[i] > -101 && elems[i] < 101);

                // For stack, add any element. 
                if(!ret.Contains(elems[i]))
                    ret.Add(elems[i]);
            }
           
            return ret;

        }

    }
}