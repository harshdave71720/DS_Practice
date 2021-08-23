namespace data_structures.interfaces
{
    public interface ILinkedList<K>
    {
        int Count { get; }

        void Insert(K key);

        ListNode<K> Search(K key);

        ListNode<K> Delete(K Key);

        ListNode<K> Delete(ListNode<K> node);

        bool Contains(K key);
    }
}