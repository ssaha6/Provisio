using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleList
{
    public class List
    {
        public List next;
        public int value;

        public List(int setValue)
        {
            value = setValue;
        }

        public int Count()
        {
            int count = 0;

            List current = this;
            while (current != null)
            {
                count++;
                current = current.next;
            }
            return count;
        }

        public void addToEnd(int newValue)
        {
            List current = this;
            if (current.next == null)
            {
                current.next = new List(newValue);
            }
            current = current.next;
        }
    }
}
