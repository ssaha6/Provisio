using System;
//using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataStructures;
using Microsoft.Pex.Framework;

namespace DataStructures.Test.Factories
{
    public static class StackFactory
    {
        [PexFactoryMethod(typeof(DataStructures.Stack<int>))]
        public static DataStructures.Stack<int> Create(int[] elems)
        {
            
            PexAssume.IsTrue(elems != null && elems.Length < 50);
            PexAssume.TrueForAll(0, elems.Length, _i => elems[_i] > -101 && elems[_i] < 101);
            DataStructures.Stack<int> ret = new DataStructures.Stack<int>(elems.Length+2 );// DataStructure has big enough capacity for Commutativity Test
            for (int i = 0; i < elems.Length; i++)
            {
                 // For stack, add any element. 
                 ret.Push(elems[i]);
            }
            return ret;

        }

    }
}
