using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace MyLibrary.Mathematics.NumberTheorem
{
    public class ModularArithmetic
    {
        public BigInteger Modulo { get; set; }
        
        public ModularArithmetic(BigInteger modulo) => Modulo = modulo;

        public BigInteger PositiveMod(BigInteger number) =>
            number % Modulo < 0 ? number % Modulo + Modulo : number % Modulo;

        public bool HasInverse(BigInteger number) =>
            new GCD(number, Modulo).Value == 1;

        /// <summary>
        /// The inverse of a module can be used to find a key in cryptograph.
        /// If gcd(a,m)==1 then the inverse is exist and
        ///     ax + my = 1
        ///     inverse = (x + m) % m
        /// else throw an ArgumentException.
        /// <see href="https://www.wikiwand.com/en/Modular_multiplicative_inverse">Reference</see>
        /// </summary>
        /// <param name="number">a</param>
        /// <returns>The inverse of 'a' under the modulo 'm', hasInverse</returns>
        public BigInteger Inverse(BigInteger number)
        {
            var gcd = new GCD(number, Modulo);
            if (gcd.Value == 1)
                return (gcd.EEA.Item1 + Modulo) % Modulo;
            throw new ArgumentException($"{number} does not have an inverse under the modulo ${Modulo}.");
        }

        /// <summary>
        /// Chinese Remainder Theorem is a method to solve the modular equation system.
        /// Reference:<see href="https://www.wikiwand.com/en/Chinese_remainder_theorem">Wikipedia</see>
        /// </summary>
        /// <param name="coefficients">list of (a,m)</param>
        /// <returns></returns>
        public BigInteger ChineseRemainderTheorem(IEnumerable < (BigInteger, BigInteger) > coefficients)
        {
            var M = coefficients.Aggregate(new BigInteger(1), (seed, item) => seed * item.Item2);
            return coefficients.Aggregate(new BigInteger(0), (seed, item) =>
            {
                var ai = item.Item1;
                var mi = new ModularArithmetic(item.Item2);
                var Mi = M / item.Item2;
                var ti = mi.PositiveMod(mi.Inverse(Mi));
                return seed + ai * Mi * ti;
            }) % M;
        }
    }
}