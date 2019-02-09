using System;
using System.Numerics;

namespace MyLibrary.Mathematics.NumberTheorem
{
    public class ModularArithmetic
    {
        public static int PositiveMod(BigInteger n, BigInteger m) =>
            n % m < 0 ? Int32.Parse((n % m + m).ToString()) : Int32.Parse((n % m).ToString());

        /// <summary>
        /// The inverse of a module can be used to find a key in cryptograph.
        /// If gcd(a,m)==1 then the inverse is exist and
        ///     ax + my = 1
        ///     inverse = (x + m) % m
        /// <see href="https://www.wikiwand.com/en/Modular_multiplicative_inverse">Reference</see>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="m"></param>
        /// <returns>(The inverse of 'a' under modulo 'm', hasInverse) </returns>
        public static(BigInteger, bool) Inverse(BigInteger a, BigInteger m) =>
            ((GCD.ExtendedEuclideanAlgorithm(a, m).Item1 + m) % m,
                GCD.EuclideanAlgorithm(a, m) == 1);
    }
}