using System;

using System.Text;
using Microsoft.Pex.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.Test.Factories
{
    
    public static class ArrayListFactory
    {
        [PexFactoryMethod(typeof(DataStructures.ArrayList))]
        public static DataStructures.ArrayList Create(int[] elems)
        {
            PexAssume.IsTrue(elems != null && elems.Length < 50);
            //PexAssume.TrueForAll(0, elems.Length, _i => elems[_i] > -101 && elems[_i] < 101);
            DataStructures.ArrayList ret = new DataStructures.ArrayList();

            
            for (int i = 0; i < elems.Length; i++)
            {
                //if (!ret.Contains(elems[i]))
                    ret.Add(elems[i]);
            }
            
            return ret;

        }
    }
}
