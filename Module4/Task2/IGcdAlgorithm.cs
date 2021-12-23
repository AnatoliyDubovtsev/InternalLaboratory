namespace Module4.Task2
{
    public interface IGcdAlgorithm
    {
        public int FindGcd(out double elapsedMilliseconds, params int[] numbers);
    }
}
