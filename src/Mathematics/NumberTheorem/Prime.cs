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

        /// <summary>
        /// Random prime and primality tests.
        /// References:<a href="http://zoo.cs.yale.edu/classes/cs467/2010s/lectures/ln14.pdf">Yale</a>
        /// </summary>
        public Prime(BigInteger input)
        {
            this.Input = input;
        }

        /// <summary>
        /// Euler Criterion Formula
        ///     a^((p-1)/2) mod p
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        private int EulerCriterion(BigInteger a) =>
            (int) BigInteger.ModPow(a, (Input - 1) / 2, Input);

        /// <summary>
        /// Given an odd integer n, test for a random b whether
        /// EulerCriterion(b) == Jacobi(b, n)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool EulerTest()
        {
            var a = Input.Random();
            return EulerCriterion(a) == Jacobi(a, Input);
        }

        public bool EulerTest(BigInteger a) => EulerCriterion(a) == Jacobi(a, Input);

        public int Jacobi(BigInteger a, BigInteger n)
        {
            if (a.IsZero) return n.IsOne ? 1 : 0;
            if (a == 2)
            {
                switch ((int) (n + 8) % 8)
                {
                    case 1:
                    case 7:
                        return 1;
                    case 3:
                    case 5:
                        return -1;
                }
            }
            if (a >= n) return Jacobi(a % n, n);
            if (a.IsEven) return Jacobi(2, n) * Jacobi(a / 2, n);
            return ((a + 4) % 4 == 3 && (n + 4) % 4 == 3) ? -Jacobi(n, a) : Jacobi(n, a);
        }

        [Obsolete]
        private bool SolovayStrassen()
        {
            if ((Input.IsEven && Input != 2) || Input < 2) return false;
            for (int i = 0; i < 100; i++)
            {
                var a = new BigInteger(1).Random(Input);
                var x = Jacobi(a, Input);
                var y = EulerCriterion(a);
                if (x == 0 || (x + Input) % Input != (y + Input) % Input) return false;
            }
            return true;
        }

        private bool MillerRabin(BigInteger a)
        {
            var m = Input - 1;
            var k = 0;
            while (!m.IsEven)
            {
                k++;
                m >>= 1;
            }
            var b = BigInteger.ModPow(a, m, Input);
            if (b % Input == 1) return true;
            for (int i = 0; i < k; i++)
            {
                if ((b + 1) % Input == 0) return true;
                b = BigInteger.ModPow(b, 2, Input);
            }
            return false;
        }

        // public bool AKS() => new AKS(Input).IsPrime;

        // public bool IsCoprime(BigInteger another) { }
        // public IEnumerable<int> PrimeLessThan() { }
        // public IEnumerable<int> PrimeBetween(BigInteger another) { }
        // public BigInteger Next();
        // public IEnumerable<BigInteger> PrimesAfter(int count);
    }
}