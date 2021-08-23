using System;
using data_structures.interfaces;

namespace data_structures
{
    public class ListNode<K> //: IListNode<K>
    {
        public K Key { get; private set; }

        public ListNode<K> Prev { get; set; }

        public ListNode<K> Next { get; set; }

        public ListNode(K key)
        {
            Key = key;
        }
    }
}