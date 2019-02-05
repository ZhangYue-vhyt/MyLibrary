using System;

namespace MyLibrary.Mathematics.NumberTheorem
{
    public class ModularArithmetic
    {
        /// <summary>
        /// If gcd(a,m)==1 then a is invertible mod m.
        /// </summary>
        /// <param name="a">Integer</param>
        /// <param name="m">Modulo</param>
        /// <returns></returns>
        public static bool HasInverse(int a, int m) =>
            GCD.ExtendedEuclideanAlgorithm(a, m).Item3 == 1;

        /// <summary>
        /// The inverse of a module can be used to find a key in cryptograph.
        /// If gcd(a,m)==1 then the inverse is exist and
        ///     ax + my = 1
        ///     inverse = (x + m) % m  
        /// </summary>
        /// <param name="a"></param>
        /// <param name="m"></param>
        /// <returns>The inverse of 'a' under modulo 'm' </returns>
        public static int Inverse(int a, int m)
        {
            var eea = GCD.ExtendedEuclideanAlgorithm(a, m);
            if (!HasInverse(a, m))
                throw new ArgumentException(String.Format("{0} does not have an inverse under the modulo {1}", a, m));
            return (eea.Item1+m) % m;
        }
    }
}