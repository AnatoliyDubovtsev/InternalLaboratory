namespace Module4
{
    public static class Task3
    {
        public static bool IsNull<T>(this T? item) where T : struct
            => item == null;

        public static bool IsNull(this string item)
            => item == null;
    }
}
