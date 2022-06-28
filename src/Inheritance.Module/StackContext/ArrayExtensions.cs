namespace Inheritance.Module.StackContext
{
    public static class ArrayExtensions
    {
        public static bool IsEmpty<T>(this T[] array)
        {
            return array == null || array.Length == 0;
        }
    }
}
