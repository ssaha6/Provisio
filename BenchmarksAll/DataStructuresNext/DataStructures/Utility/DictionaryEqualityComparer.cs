using System;
using System.Collections.Generic;

namespace DataStructures.Utility
{
    /*This only works if TValue is not a collection*/
    public class DictionaryEqualityComparer<TKey, TValue> : IEqualityComparer<Dictionary<TKey, TValue>>
    {
        private readonly IEqualityComparer<TKey> mkey_comparer;
        private readonly IEqualityComparer<TValue> mval_comparer;

        public DictionaryEqualityComparer()
        {
            mkey_comparer = EqualityComparer<TKey>.Default;
            mval_comparer = EqualityComparer<TValue>.Default;
        }

        // using m_comparer to keep equals properties in tact; don't want to choose one of the comparers
        public bool Equals(Dictionary<TKey, TValue> x, Dictionary<TKey, TValue> y)
        {
            // handle null cases first
            if (x == null)
            {
                return (y == null);
            }
            else if (y == null)
            {
                // set1 != null
                return false;
            }

            if (x.Count != y.Count)
                return false;

            foreach (KeyValuePair<TKey, TValue> p in x)
            {
                if (!y.ContainsKey(p.Key))
                {
                    return false;
                }
                else
                {
                    //y.ContainsKey(p.Key)
                    if (!y[p.Key].Equals( p.Value))
                        return false;
                }


            }

            return true;
        }

        public int GetHashCode(Dictionary<TKey, TValue> obj)
        {
            int hashCode = 0;
            if (obj != null)
            {
                foreach (KeyValuePair<TKey, TValue> t in obj)
                {
                    hashCode = hashCode ^ (mkey_comparer.GetHashCode(t.Key) ^ mval_comparer.GetHashCode(t.Value) &0x7FFFFFFF);
                }
            } // else returns hashcode of 0 for null hashsets
            return hashCode;
        }

        // Equals method for the comparer itself. 
        public override bool Equals(object obj)
        {
            DictionaryEqualityComparer<TKey, TValue> comparer = obj as DictionaryEqualityComparer<TKey, TValue>;
            if (comparer == null)
            {
                return false;
            }
            return (mkey_comparer == comparer.mkey_comparer && mval_comparer == comparer.mval_comparer);
        }

        public override int GetHashCode()
        {
            return mkey_comparer.GetHashCode()^ mval_comparer.GetHashCode();
        }

    }
}
