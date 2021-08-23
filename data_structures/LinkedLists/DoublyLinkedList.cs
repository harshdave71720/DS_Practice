using System;
using data_structures.interfaces;

namespace data_structures
{
    public class DoublyLinkedList<K> : ILinkedList<K>
    {
        public int Count 
        { 
            get 
            {
                int count = 0;
                var start = _head;
                while(start != null)
                {
                    count++;
                    start = start.Next;
                }

                return count;
            }
        }

        private ListNode<K> _head;
        private ListNode<K> _tail;
        
        public void Insert(K key)
        {
            var node = new ListNode<K>(key);
            
            if(_tail == null)
            {
                _head = node;
                _tail = node;
                return;
            }

            _tail.Next = node;
            _tail = node;
        }

        public ListNode<K> Search(K key)
        {
            var start = _head;

            while(start != null && !start.Key.Equals(key))
            {
                start = start.Next;
            }

            return start;
        }

        public ListNode<K> Delete(K key)
        {
            var node = Search(key);
            
            Delete(node);
            return node;
        }

        public ListNode<K> Delete(ListNode<K> node)
        {
            if(node == null)
                return null;
            
            if(node.Prev == null)
            {
                _head = node.Next;
            } 
            else
            {
                node.Prev.Next = node.Next;
            }
            
            if(node.Next == null)
            {
                _tail = node.Prev;
            }
            else
            {
                node.Next.Prev = node.Prev;
            }

            return node;
        }

        public bool Contains(K key)
        {
            var start = _head;
            while(start != null && !start.Key.Equals(key))
            {
                start = start.Next;
            }

            return start == null ? false : true;
        }

        public DoublyLinkedList()
        {
            _head = null;
            _tail = null;
        }
    }
}