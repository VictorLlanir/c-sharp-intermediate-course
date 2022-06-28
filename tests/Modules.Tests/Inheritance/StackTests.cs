using Inheritance.Module.StackContext;
using System;
using Xunit;

namespace Modules.Tests.Inheritance
{
    public class StackTests
    {
        [Fact(DisplayName = "Should throw InvalidOperationException when Pushing null item to the Stack")]
        public void PushNullItem()
        {
            var stack = new Stack<string>();

            Assert.Throws<InvalidOperationException>(() => stack.Push(null));
        }

        [Fact(DisplayName = "Should throw InvalidOperationException when Poping empty Stack")]
        public void PopEmptyStack()
        {
            var stack = new Stack<string>();

            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [Fact(DisplayName = "Should Pop the correct Pushed item")]
        public void PopPushedItem()
        {
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);

            Assert.Equal(4, stack.Pop());
            Assert.Equal(3, stack.Pop());
            Assert.Equal(2, stack.Pop());
            Assert.Equal(1, stack.Pop());
        }

        [Fact(DisplayName = "Should clear stack")]
        public void ClearStack()
        {
            var stack = new Stack<int>();
            
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);

            stack.Clear();

            Assert.True(stack.IsEmpty());
        }
    }
}
