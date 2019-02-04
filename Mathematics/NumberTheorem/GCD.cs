namespace MyLibrary.Mathematics.NumberTheorem
{
    public class GCD
    {
        public int Value { get; set; }
        public GCD(int a, int b)
        {
            Value = EuclideanAlgorithm(a, b);
        }
        public static int EuclideanAlgorithm(int a, int b)
        {
            if (b == 0) return a;
            return EuclideanAlgorithm(b, a % b);
        }
        public static(int, int, int) ExtendedEuclideanAlgorithm(int a, int b)
        {
            if (b == 0) return (1, 0, a);
            var(x, y, gcd) = ExtendedEuclideanAlgorithm(b, a % b);
            (x, y) = (y, x - (a / b) * y);
            return (x, y, gcd);
        }
    }
}