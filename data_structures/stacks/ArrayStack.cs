using data_structures.interfaces;
using System;

namespace data_structures
{
    public class ArrayStack<T> : IStack<T>
    {
        public int Size { get; private set;}
        public bool IsEmpty
        {
            get { return _top == -1; }
        }

        private int _top;

        private T[] _stack;

        public void Push(T element)
        {
            if(_top == Size - 1)
            {
                throw new Exception("Stack OverFlow");
            }

            _stack[++_top] = element;
        }

        public T Pop()
        {
            if(IsEmpty)
                throw new Exception("Stack UnderFlow");      
            
            _top--;
            return _stack[_top + 1];
        }

        public ArrayStack(int size)
        {
            if(size <= 0)
            {
                throw new ArgumentException("Should be positive", nameof(size));
            }                    

            Size = size;
            _top = -1;
            _stack = new T[size];
        }
    }
}
