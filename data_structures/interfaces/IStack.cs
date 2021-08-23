namespace data_structures.interfaces
{
    public interface IStack<T>
    {
        void Push(T element);

        T Pop();

        public int Size { get; }

        public bool IsEmpty { get; }
    }
}