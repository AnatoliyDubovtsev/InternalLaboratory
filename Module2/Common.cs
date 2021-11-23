namespace Module2
{
    public static class Common
    {
        public static void SwapElements<T>(ref T left, ref T right)
        {
            T temp = left;
            left = right;
            right = temp;
        }
    }
}
