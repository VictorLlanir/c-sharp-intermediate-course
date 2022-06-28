namespace Inheritance.Module.StackContext
{
    public class Stack<T>
    {
        private T[] _stack;
        public Stack()
        {
            _stack = Array.Empty<T>();
        }


        public void Push(T item)
        {
            if (item is null)
            {
                throw new InvalidOperationException("Cannot Push a null item to the Stack.");
            }

            _stack = _stack.Append(item).ToArray();
        }

        public T Pop()
        {
            if (_stack.IsEmpty())
            {
                throw new InvalidOperationException("Cannot Pop item from an empty Stack.");
            }

            var lastItem = _stack.Last();
            _stack = _stack.Take(_stack.Length - 1).ToArray();

            return lastItem;
        }

        public void Clear()
        {
            _stack = Array.Empty<T>();
        }

        public bool IsEmpty()
        {
            return _stack.IsEmpty();
        }
    }
}
