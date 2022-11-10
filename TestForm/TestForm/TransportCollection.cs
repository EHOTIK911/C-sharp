using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB_1
{


    public class TransportList : IEnumerable, IEnumerator, IList
    {
        private List<Transport> elements = new List<Transport>();

        //public void Sort() => elements.Sort();
         

        public Transport this[int index]
        {
            get { return elements[index]; }
            set { elements[index] = value; }
        }
        int position = -1;

        bool IEnumerator.MoveNext()
        {
            if(position < elements.Count - 1)
            {
                position++;
                return true;
            }
            return false;
        }
        void IEnumerator.Reset() => position = -1;

        object IEnumerator.Current
        {
            get { return elements[position]; }
        }

        public bool IsReadOnly => elements.ToArray().IsReadOnly;

        public bool IsFixedSize => elements.ToArray().IsFixedSize;

        public int Count => elements.Count;

        public object SyncRoot => elements.ToArray().SyncRoot;

        public bool IsSynchronized => elements.ToArray().IsSynchronized;

        object IList.this[int index]
        {
            get { return elements[index]; }
            set { elements[index] = value as Transport; }
        }

        IEnumerator IEnumerable.GetEnumerator() => this;

        public int Add(object value)
        {
            elements.Add(value as Transport);
            /*for(int i = 0; i < elements.Count; i++)
            {
                if (elements[i] == null)
                {
                    elements[i] = value as Transport;
                    return i;
                }
            }*/
            return -1;
        }

        public bool Contains(object value)
        {
            Transport val = value as Transport;
            for (int i = 0; i < elements.Count; i++)
            {
                if (elements[i] == val)
                {
                    return true;
                }
            }
            return false;
        }

        public void Clear()
        {
            for (int i = 0; i < elements.Count; i++)
            {
                elements[i] = null;
            }
        }

        public int IndexOf(object value)
        {
            int index = -1;
            for (int i = 0; i < elements.Count; i++)
            {
                if (elements[i] == value as Transport)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        public void Insert(int index, object value)
        {
            elements[index] = value as Transport;
        }

        public void Remove(object value)
        {
            elements.Remove(value as Transport);
            /*int index = -1;
            for (int i = 0; i < elements.Count; i++)
            {
                if (elements[i] == value as Transport)
                {
                    index = i;
                    break;
                }
            }
            if (index != -1)
                elements[index] = null;*/
        }

        public void RemoveAt(int index)
        {
            elements.RemoveAt(index);
            //elements[index] = null;
        }

        public void CopyTo(Array array, int index)
        {
            array.SetValue(this, index);
           
        }

        public void Sort(IComparer<Transport> comparer = null)
        {
            var temp = elements.ToList();
            temp.Sort(comparer);
            Console.WriteLine($"{elements.Count} Sorted temp count: {temp.Count}");
            for (int i = 0; i < elements.Count; i++)
                this[i] = temp[i];
        }
    }
}
