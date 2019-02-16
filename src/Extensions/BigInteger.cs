using System;
using System.Numerics;
using System.Security.Cryptography;

namespace MyLibrary.Extensions
{
    public static class BigIntegerExtensions
    {
        /// <summary>
        /// Generate a random BigInteger less than the input.
        /// </summary>
        /// <param name="upperBound"></param>
        /// <returns></returns>
        public static BigInteger Random(this BigInteger upperBound)
        {
            var bytes = upperBound.ToByteArray();
            var result = new BigInteger();
            var random = new Random();
            do
            {
                random.NextBytes(bytes);
                bytes[bytes.Length - 1] &= (byte) 0x7F; //force sign bit to positive
                result = new BigInteger(bytes);
            } while (result >= upperBound);

            return result;
        }
    }
}