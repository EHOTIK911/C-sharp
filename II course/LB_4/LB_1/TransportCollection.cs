using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB_1
{
    public class TransportElements
    {
        public string type;
        public int year;
        public int weight;
        public string color;
        public double speed;
        public int horsePower;
        public int carriages;
        public double bodyLength;
        public double wingLength;
        public TransportElements(string type, int year, int weight, string color, double speed, int horsePower)
        {
            this.type = type;
            this.year = year;
            this.weight = weight;
            this.color = color;
            this.speed = speed;
            this.horsePower = horsePower;
        }
        public TransportElements(string type, int year, int weight, string color, int сarriages)
        {
            this.type = type;
            this.year = year;
            this.weight = weight;
            this.color = color;
            this.carriages = сarriages;

        }
        public TransportElements(string type, int year, int weight, string color, double wingLength)
        {
            this.type = type;
            this.year = year;
            this.weight = weight;
            this.color = color;
            this.wingLength = wingLength;

        }
        public TransportElements(string type, int year, int weight, string color, double speed, double bodyLength)
        {
            this.type = type;
            this.year = year;
            this.weight = weight;
            this.color = color;
            this.speed = speed;
            this.bodyLength = bodyLength;
        }

        public override bool Equals(object obj) => Equals(obj as TransportElements);

        public bool Equals(TransportElements te)
        {
            if(te is null)
            {
                return false;
            }
            if (ReferenceEquals(this, te))
            {
                return true;
            }
            if(GetType() != te.GetType())
            {
                return false;
            }
            return (type == te.type) && (year == te.year) && (weight == te.weight) && (color == te.color) && 
                (speed == te.speed) && (horsePower == te.horsePower) && (bodyLength == te.bodyLength) && 
                (wingLength == te.wingLength) && (carriages == te.carriages);
        }
        public static bool operator ==(TransportElements lTE, TransportElements rTE)
        {
            if(lTE is null)
            {
                if(rTE is null)
                {
                    return true;
                }
                return false;
            }
            return lTE.Equals(rTE);
        }
        public static bool operator !=(TransportElements lTE, TransportElements rTE) => !(lTE == rTE);

    }

    public class TransportList : IEnumerable, IEnumerator, IList
    {
        readonly List<TransportElements> elements = new List<TransportElements>();

        public TransportElements this[int index]
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

        public bool IsReadOnly => throw new NotImplementedException();

        public bool IsFixedSize => throw new NotImplementedException();

        public int Count => elements.Count;

        public object SyncRoot => throw new NotImplementedException();

        public bool IsSynchronized => throw new NotImplementedException();

        object IList.this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        IEnumerator IEnumerable.GetEnumerator() => (IEnumerator)this;

        public int Add(object value)
        {
            for(int i = 0; i < elements.Count; i++)
            {
                if (elements[i] == null)
                {
                    elements[i] = value as TransportElements;
                    return i;
                }
            }
            return -1;
        }

        public bool Contains(object value)
        {
            TransportElements val = value as TransportElements;
            for(int i = 0; i < elements.Count; i++)
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
            for(int i = 0; i < elements.Count; i++)
            {
                elements[i] = null;
            }
        }

        public int IndexOf(object value)
        {
            int index = -1;
            for(int i = 0; i < elements.Count; i++)
            {
                if(elements[i] == value as TransportElements)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        public void Insert(int index, object value)
        {
            elements[index] = value as TransportElements;
        }

        public void Remove(object value)
        {
            int index = -1;
            for(int i = 0; i < elements.Count; i++)
            {
                if (elements[i] == value as TransportElements)
                {
                    index = i;
                    break;
                }
            }
            if (index != -1)
                elements[index] = null;
        }

        public void RemoveAt(int index)
        {
            elements[index] = null;
        }

        public void CopyTo(Array array, int index)
        {
            array.SetValue(this, index);
        }

        // Реализация интерфейсов Ilist

        
    }
}
