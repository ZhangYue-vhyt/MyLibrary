using System.Numerics;

namespace MyLibrary.Mathematics.NumberTheorem
{
    public class GCD
    {
        public BigInteger Value { get; }
        public(BigInteger, BigInteger, BigInteger) EEA { get; }
        public GCD(BigInteger a, BigInteger b)
        {
            Value = EuclideanAlgorithm(a, b);
            EEA = ExtendedEuclideanAlgorithm(a, b);
        }
        public BigInteger EuclideanAlgorithm(BigInteger a, BigInteger b)
        {
            if (b == 0) return a;
            return EuclideanAlgorithm(b, a % b);
        }
        public(BigInteger, BigInteger, BigInteger) ExtendedEuclideanAlgorithm(BigInteger a, BigInteger b)
        {
            if (b == 0) return (1, 0, a);
            var(x, y, gcd) = ExtendedEuclideanAlgorithm(b, a % b);
            (x, y) = (y, x - (a / b) * y);
            return (x, y, gcd);
        }
    }
}