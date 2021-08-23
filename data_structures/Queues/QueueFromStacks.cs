using data_structures.interfaces;
using System;


namespace data_structures
{
    public class QueueFromStacks<T> : IQueue<T>
    {
        private ArrayStack<T> _stack;
        private ArrayStack<T> _tempStack;

        public int Size{ get; private set; }

        public bool IsEmpty 
        { 
            get 
            {
                return _stack.IsEmpty && _tempStack.IsEmpty;
            }
        }

        public void Enqueue(T element)
        {
            try
            {
                _stack.Push(element);
            }
            catch (Exception ex)
            {
                if(ex.Message.Equals("Stack OverFlow", StringComparison.OrdinalIgnoreCase))
                    throw new Exception("Queue OverFlow");
                throw ex;
            }
        }

        public T Dequeue()
        {
            if(_stack.IsEmpty)
                throw new Exception("Queue UnderFlow");
            
            T removed = _stack.Pop();
            while(!_stack.IsEmpty)
            {
                _tempStack.Push(removed);
                removed = _stack.Pop();
            }

            while(!_tempStack.IsEmpty)
            {
                _stack.Push(_tempStack.Pop());
            }

            return removed;
        }

        public QueueFromStacks(int size)
        {
            if(size <= 0)
            {
                throw new ArgumentException("Should Be Positive", nameof(size));
            }

            Size = size;
            _stack = new ArrayStack<T>(Size);
            _tempStack = new ArrayStack<T>(Size);
        }

    }
}