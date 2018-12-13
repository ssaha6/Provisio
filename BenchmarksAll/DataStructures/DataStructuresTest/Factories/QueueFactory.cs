using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Pex.Framework;


namespace DataStructures.Test.Factories
{
    
    public static class QueueFactory
    {
        [PexFactoryMethod(typeof(DataStructures.Queue<int>))]
        public static DataStructures.Queue<int> Create(int[] elems, int n)
        {

            PexAssume.IsTrue(elems != null && elems.Length < 11);
            PexAssume.TrueForAll(0, elems.Length, _i => elems[_i] > -11 && elems[_i] < 11);
            DataStructures.Queue<int> ret = new DataStructures.Queue<int>(elems.Length + 2);// DataStructure has big enough capacity for Commutativity Test
            for (int i = 0; i < elems.Length; i++)
            {
                //if(!ret.Contains(elems[i]))
                    ret.Enqueue(elems[i]);
            }
            return ret;

        }

    }
}
