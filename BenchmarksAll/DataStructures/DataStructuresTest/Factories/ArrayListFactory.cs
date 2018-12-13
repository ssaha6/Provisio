using System;

using System.Text;
using Microsoft.Pex.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.Test.Factories
{
    
    public static class ArrayListFactory
    {
        [PexFactoryMethod(typeof(DataStructures.ArrayList))]
        public static DataStructures.ArrayList Create([PexAssumeNotNull]int[] elems)
        {
            PexAssume.IsTrue( elems.Length < 11);
            PexAssume.TrueForAll(0, elems.Length, _i => elems[_i] > -11 && elems[_i] < 11);
            DataStructures.ArrayList ret = new DataStructures.ArrayList(elems.Length+2);

            
            for (int i = 0; i < elems.Length; i++)
            {
                //if (!ret.Contains(elems[i]))
                    ret.Add(elems[i]);
            }
            
            return ret;

        }
    }
}
