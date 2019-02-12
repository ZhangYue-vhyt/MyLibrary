using System.Numerics;

namespace MyLibrary.Mathematics.NumberTheorem
{
    public class Prime
    {
        /// <summary>
        /// Use ASK algorithm to check if a number is prime.
        /// Reference:<see href="https://www.wikiwand.com/zh/AKS%E8%B3%AA%E6%95%B8%E6%B8%AC%E8%A9%A6">ASK Algorithm</see>
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool ASK(BigInteger n)
        {
            for (double i = 2; i <= BigInteger.Log(n, 2); i++)
            {
            }
            return false;
        }

        // public static bool IsCoprime(int n) { }

        // public static IList<int> PrimeLessThan(int n) { }
    }
}