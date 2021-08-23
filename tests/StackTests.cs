using data_structures.interfaces;
using System;
using data_structures;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace tests
{
    [TestFixture]
    public class StackTests
    {
        private IStack<object> CreateNewStack(int size)
        {
            return new ArrayStack<object>(size);
        }

        private IStack<object> CreateNewStack(IEnumerable<object> elements, int size = 0)
        {
            var stack = size == 0 ? 
                            new ArrayStack<object>(elements.Count()) :
                            new ArrayStack<object>(size);

            foreach(var element in elements)
            {
                stack.Push(element);
            }

            return stack;
        }

        [TestCase(1)]
        [TestCase(123)]
        [TestCase(105)]
        public void Size_Gets_Set_Via_Constructor(int size)
        {
            // Arrange
            var stack = CreateNewStack(size);

            // Assert
            Assert.AreEqual(size, stack.Size);
        }
        
        [TestCase(0)]
        [TestCase(-10)]
        public void Throws_Exception_WhenSizeIsNotPositive(int size)
        {
            // Assert
            ArgumentException ex = Assert.Throws<ArgumentException>(() => CreateNewStack(size));
            Assert.IsTrue(ex.Message.StartsWith("Should be positive"));
            Assert.AreEqual("size", ex.ParamName);
        }

        [Test]
        public void IsEmpty_ReturnsTrueForEmptyStack()
        {
            // Arrange
            var stack = CreateNewStack(1);

            // Assert
            Assert.IsTrue(stack.IsEmpty);
        }

        [Test]
        public void IsEmpty_ReturnsFalseForNonEmptyStack()
        {
            // Arrange
            var stack = CreateNewStack(1);

            // Act
            stack.Push(1);

            // Assert
            Assert.IsFalse(stack.IsEmpty);
        }

        [TestCase(1)]
        [TestCase(222)]
        [TestCase(101)]
        public void Pop_ReturnsTheElementPushedMostRecently(int element)
        {
            // Arrange
            var stack = CreateNewStack(2);

            // Act
            stack.Push(1);
            stack.Push(element);

            // Assert
            Assert.AreEqual(element, stack.Pop());
        }

        [Test]
        public void Pop_ThrowsUnderflowExceptionIfStackIsEmpty()
        {
            // Arrange
            var stack = CreateNewStack(1);

            // Assert
            var ex = Assert.Throws<Exception>(() => { stack.Pop(); });
            Assert.AreEqual("Stack UnderFlow", ex.Message);
        }

        [Test]
        public void Pop_RemovesElementsInReverseOrderOfInsertion()
        {
            // Arrange
            var elements = new object[]{1, 34, 653, 12, 0, 10};
            var stack = CreateNewStack((IEnumerable<object>)elements, size : elements.Count());

            // Act and Assert
            for(int i = elements.Length - 1; i >= 0; i--)
            {
                Assert.AreEqual(elements[i], stack.Pop());
            }
        }

        [Test]
        public void Pop_AfterPoppingAllElementsStackBecomesEmpty()
        {
            // Arrange
            var elements = new object[]{1, 34, 653, 12, 0, 10};
            var stack = CreateNewStack((IEnumerable<object>)elements);

            // Act
            for(int i = 0; i < elements.Length; i++) stack.Pop();

            // Assert
            Assert.IsTrue(stack.IsEmpty);
        }

        [Test]
        public void Push_PushingWhenStackIsFullThrowException()
        {
            // Arrange
            var elements = new object[]{1, 34, 653, 12, 0, 10};
            var stack = CreateNewStack((IEnumerable<object>)elements);

            // Assert
            var ex = Assert.Throws<Exception>(() => { stack.Push(1); });
            Assert.IsTrue(ex.Message.Equals("Stack OverFlow", StringComparison.OrdinalIgnoreCase));
        }
    }
}
