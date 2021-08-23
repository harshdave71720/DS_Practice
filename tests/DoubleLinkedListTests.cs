using NUnit.Framework;
using data_structures;
using data_structures.interfaces;

namespace tests
{
    [TestFixture]
    public class DoublyLinkedListTests
    {
        private ILinkedList<object> CreateNewList()
        {
            return new DoublyLinkedList<object>();
        } 

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(15)]
        [TestCase(6)]
        public void Count_ReturnsNumberOfElementsPresentInTheList(int elements)
        {
            var list = CreateNewList();
            for(int i = 0; i < elements; i++)
            {
                list.Insert(i);
            }

            // Assert
            Assert.AreEqual(elements, list.Count);
        }

        [TestCase(1)]
        [TestCase(-15)]
        [TestCase(101)]
        public void Insert_AddAnElementToTheList(int element)
        {
            var list = CreateNewList();
            list.Insert(element);

            Assert.IsTrue(list.Contains(element));
        }

        [TestCase(1)]
        [TestCase(-15)]
        [TestCase(101)]
        public void Delete_DeletesFirstNodeWithTheGivenKey(int element)
        {
            var list = CreateNewList();
            list.Insert(element);

            list.Delete(element);
            Assert.IsFalse(list.Contains(element));
        }

        [Test]
        public void Search_ReturnsNodeForAKeyIfExists()
        {
            var list = CreateNewList();
            for(int i = 0; i < 5; i++)
            {
                list.Insert(i);
            }

            for(int i =0; i < 5; i++)
            {
                Assert.IsNotNull(list.Search(i));
            }
        }

        [Test]
        public void Search_ReturnsNullWhenNoNodeForGivenKeyIsPresent()
        {
            var list = CreateNewList();
            for(int i = 0; i < 5; i++)
            {
                list.Insert(i);
            }

            for(int i =0; i < 5; i++)
            {
                list.Delete(i);
            }

            for(int i =0; i < 5; i++)
            {
                Assert.IsNull(list.Search(i));
            }
        }

        [Test]
        public void AddingFewElementsAndDeletingAllOfThemThenAddingsomeAgain()
        {
            var list = CreateNewList();
            for(int i = 0; i < 5; i++)
            {
                list.Insert(i);
            }

            for(int i =0; i < 5; i++)
            {
                list.Delete(i);
            }

            for(int i = 6; i < 11; i++)
            {
                list.Insert(i);
            }
                
            Assert.AreEqual(5, list.Count);
            for(int i = 6; i < 11; i++)
            {
                Assert.IsTrue(list.Contains(i));
            }
        }
    }
}