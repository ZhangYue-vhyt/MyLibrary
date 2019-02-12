using System;
using System.Collections.Generic;
using System.Linq;
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

        /// <summary>
        /// Chinese Remainder Theorem is a method to solve the modular equation system.
        /// Reference:<see href="https://www.wikiwand.com/en/Chinese_remainder_theorem">Wikipedia</see>
        /// </summary>
        /// <param name="coefficients">list of (a,m)</param>
        /// <returns></returns>
        public static BigInteger ChineseRemainderTheorem(IEnumerable < (BigInteger, BigInteger) > coefficients)
        {
            var M = coefficients.Aggregate(new BigInteger(1), (seed, item) => seed * item.Item2);
            return coefficients.Aggregate(new BigInteger(0), (seed, item) => seed + item.Item1 * M / item.Item2 * PositiveMod(Inverse(M / item.Item2, item.Item2).Item1, item.Item2)) % M;
        }
    }
}