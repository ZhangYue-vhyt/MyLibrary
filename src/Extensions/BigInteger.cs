using System;
using System.Numerics;
using System.Security.Cryptography;

namespace MyLibrary.Extensions
{
    public static class BigIntegerExtensions
    {
        /// <summary>
        /// Generate a random BigInteger less than the instance.
        /// </summary>
        /// <param name="upperBound">Upper Bound</param>
        /// <returns></returns>
        public static BigInteger Random(this BigInteger upperBound)
        {
            if (upperBound < 1) throw new ArgumentOutOfRangeException("The upper bound has to be greater or equal than 1.");
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

        /// <summary>
        /// Generate a random BigInteger greater or equal than the instance and less than the input argument.
        /// </summary>
        /// <param name="lowerBound">Lower Bound</param>
        /// <param name="upperBound">Upper Bound</param>
        /// <returns></returns>
        public static BigInteger Random(this BigInteger lowerBound, BigInteger upperBound)
        {
            if (upperBound <= lowerBound)
                throw new ArgumentOutOfRangeException("The upper bound has to be greater than the lower bound.");
            var interval = upperBound - lowerBound;
            return lowerBound + interval.Random();
        }
    }
}