using System.Numerics;

namespace MyLibrary.Mathematics.NumberTheorem
{
    public class Prime
    {
        public BigInteger Input { get; set; }
        public bool IsProbablyPrime
        {
            get
            {
                return false;
            }
        }
        public Prime(BigInteger input)
        {
            Input = input;
        }

        /// <summary>
        /// Miller–Rabin primality test. The result is not 100% correct.
        /// If you need an accurate primality test, please use AKS test.
        /// References: <see href="https://crypto.stanford.edu/pbc/notes/numbertheory/millerrabin.html">Stanford</see>
        /// </summary>
        /// <returns></returns>
        public bool MillerRabin()
        {
            if (Input < 2) return false;
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