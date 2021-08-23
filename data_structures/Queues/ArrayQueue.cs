using System;
using data_structures.interfaces;

namespace data_structures
{
    public class ArrayQueue<T> : IQueue<T>
    {
        public int Size { get; private set; }

        public bool IsEmpty
        {
            get
            {
                return _head == _tail;
            }
        }

        private T[] _queue;
        private int _head;
        private int _tail;

        public void Enqueue(T element)
        {
            if((_tail + 1) % _queue.Length == _head)
                throw new Exception("Queue OverFlow");

            _queue[_tail] = element;
            _tail = (_tail + 1) % _queue.Length;
        }
        
        public T Dequeue()
        {
            if(IsEmpty)
                throw new Exception("Queue UnderFlow");
            return _queue[_head++];
        }

        public ArrayQueue(int size)
        {
            if(size <= 0)
            {
                throw new ArgumentException("Should Be Positive", nameof(size));
            }
            Size = size;
            _head = 0;
            _tail = 0;
            _queue = new T[size + 1];
        }
    }
}