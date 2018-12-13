
using System.Text;
using DataStructures;
using Microsoft.Pex.Framework;

namespace DataStructures.Test.Factories
{
    public static class DictionaryFactory
    {
        [PexFactoryMethod(typeof(DataStructures.Dictionary<int,int>))]
        public static Dictionary<int, int> Create(int[] keys, int[] values)
        {

            PexAssume.IsTrue(keys != null && values!=null && keys.Length < 50 && keys.Length == values.Length);
            DataStructures.Dictionary<int, int> ret = new DataStructures.Dictionary<int, int>(keys.Length);// DataStructure has big enough capacity for Commutativity Test
            for (int i = 0; i < keys.Length; i++)
            {
                PexAssume.IsTrue(keys[i] > -101 && keys[i] < 101);
                PexAssume.IsTrue(values[i] > -101 && values[i] < 101);
                // For stack, add any element. 
                if (!ret.ContainsKey(keys[i]))
                    ret.Add(keys[i], values[i]);
            }
            return ret;

        }

    }
}