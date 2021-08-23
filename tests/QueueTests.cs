using NUnit.Framework;
using data_structures;
using System;
using System.Collections.Generic;
using System.Linq;
using data_structures.interfaces;

namespace tests
{
    [TestFixture]
    public class QueueTests
    {
        private IQueue<object> CreateNewQueue(int size)
        {
            IQueue<object> queue = new QueueFromStacks<object>(size);
            return queue;
        }

        private IQueue<object> CreateNewQueue(IEnumerable<object> elements,int size = 0)
        {
            IQueue<object> queue = size == 0 
                                        ? new QueueFromStacks<object>(elements.Count()) 
                                        : new QueueFromStacks<object>(size);
            foreach(var element in elements)
            {
                queue.Enqueue(element);
            }
            return queue;
        }

        //private Queue<object>

        [TestCase(1)]
        [TestCase(1435)]
        [TestCase(40)]
        public void SizeGetsSetViaConstructor(int size)
        {
            var queue = CreateNewQueue(size);

            Assert.AreEqual(size, queue.Size);
        }

        [TestCase(-1)]
        [TestCase(-45)]
        [TestCase(0)]
        public void ThrowsException_WhenSizeIsNotPositive(int size)
        {
            var ex = Assert.Throws<ArgumentException>(() => { CreateNewQueue(size); });

            Assert.IsTrue(ex.Message.StartsWith("Should Be Positive"));
            Assert.IsTrue(ex.ParamName.Equals("size", StringComparison.OrdinalIgnoreCase));
        }

        [Test]
        public void IsEmpty_IsTrueWhenQueueIsEmpty()
        {
            var queue = CreateNewQueue(10);

            Assert.IsTrue(queue.IsEmpty);

            queue.Enqueue(13);
            queue.Enqueue(13);
            queue.Dequeue();
            queue.Dequeue();

            Assert.IsTrue(queue.IsEmpty);
        }

        [Test]
        public void IsEmpty_IsFalseWhenQueueIsNotEmpty()
        {
            var queue = CreateNewQueue(1);
            queue.Enqueue(14);

            Assert.IsFalse(queue.IsEmpty);
        }

        [Test]
        public void Enqueue_ThrowsErrorWhenQueueIsFull()
        {
            var elements = new object[]{1, 2, 3, 4, 5};
            var queue = CreateNewQueue(elements);
            
            var ex = Assert.Throws<Exception>(() => { queue.Enqueue(10); });
            Assert.IsTrue(ex.Message.Equals("Queue OverFlow", StringComparison.OrdinalIgnoreCase));
        }

        [Test]
        public void Dequeue_ThrowsErrorWhenQueueIsEmpty()
        {
            var queue = CreateNewQueue(5);
            var ex = Assert.Throws<Exception>(() => { queue.Dequeue(); });

            Assert.IsTrue(ex.Message.Equals("Queue UnderFlow", StringComparison.OrdinalIgnoreCase));
        }
        
        [Test]
        public void InsertingMoreElementsAfterDeletingSome_TailWrapsAround()
        {
            var queue = CreateNewQueue(new object[] {1, 2, 3, 4});

            queue.Dequeue();
            queue.Dequeue(); 
            queue.Enqueue(5);
            queue.Enqueue(6);

            // will throw OverFlow Error
            // queue.Enqueue(7);
        }

        [Test]
        public void Dequeue_RemovesTheElemenPresentForTheLongestTime()
        {
            var queue = CreateNewQueue(new object[] {1, 2, 3, 4});

            for(int i = 1; i <= 4; i++)
            {
                Assert.AreEqual(i, queue.Dequeue());
            }
        }
    }
}