using System;
using System.Numerics;
using MyLibrary.Extensions;

namespace MyLibrary.Mathematics.NumberTheorem
{
    public class Prime
    {
        public BigInteger Input { get; set; }
        // public bool IsPrime { get; }
        public bool IsProbablyPrime
        {
            get
            {
                if (Input < 2) return false;
                for (int i = 0; i < 100; i++)
                {
                    var a = BigIntegerExtensions.Random(2, Input);
                    if (!MillerRabin(a)) return false;
                }
                return true;
            }
        }

        public Prime(BigInteger input)
        {
            Input = input;
        }

        /// <summary>
        /// Euler Criterion Formula
        ///     a^((p-1)/2) mod p
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [Obsolete]
        private int EulerCriterion(BigInteger a) =>
            (int) BigInteger.ModPow(a, (Input - 1) / 2, Input);

        [Obsolete]
        private int JacobiSymbol(BigInteger a, BigInteger n)
        {
            if (a == 1) return 1;
            if (a == -1) return -1;
            if (new GCD(a, n).Value != 1) return 0;
            if (a > n) return JacobiSymbol(n % a, n);
            var b = a / 2;
            var mod8 = BigInteger.Abs(n % 8);
            if (a == 2 && mod8 == 1) return 1;
            if (a == 2 && mod8 == 3) return -1;
            if (a.IsEven) return JacobiSymbol(2, n) * JacobiSymbol(b, n);
            if (a % 4 == 3 && n % 4 == 3) return -JacobiSymbol(n, a);
            return JacobiSymbol(n, a);
        }

        [Obsolete]
        private bool SolovayStrassen()
        {
            if (Input.IsEven || Input < 2) return false;
            for (int i = 0; i < 100; i++)
            {
                var a = new BigInteger(1).Random(Input);
                if (JacobiSymbol(a, Input) != EulerCriterion(a))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Miller–Rabin primality test. The result is not 100% correct.
        /// If you need an accurate primality test, please use AKS test.
        /// References: <see href="https://crypto.stanford.edu/pbc/notes/numbertheory/millerrabin.html">Stanford</see>
        /// </summary>
        /// <returns></returns>
        private bool MillerRabin(BigInteger a)
        {
            var m = Input - 1;
            var k = 0;
            while ((m & 1) == 0)
            {
                k++;
                m >>= 1;
            }
            var b = BigInteger.ModPow(a, m, Input);
            for (int i = 0; i < k; i++)
            {
                if (b + 1 % Input == 0) return true;
                b = BigInteger.ModPow(b, 2, Input);
            }
            return true;
        }

        // public bool AKS() => new AKS(Input).IsPrime;

        // public bool IsCoprime(BigInteger another) { }
        // public IEnumerable<int> PrimeLessThan() { }
        // public IEnumerable<int> PrimeBetween(BigInteger another) { }
        // public BigInteger Next();
        // public IEnumerable<BigInteger> PrimesAfter(int count);
    }
}