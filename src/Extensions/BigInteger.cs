using System;
using System.Security.Cryptography;
using SBigInteger = System.Numerics.BigInteger;
namespace MyLibrary.Extensions
{
    public static class BigInteger
    {
        /// <summary>
        /// Generate a random BigInteger less than the input.
        /// </summary>
        /// <param name="upperBound"></param>
        /// <returns></returns>
        public static SBigInteger Random(this SBigInteger upperBound)
        {
            byte[] bytes = upperBound.ToByteArray();
            var result = new SBigInteger();
            var random = new Random();
            do
            {
                random.NextBytes(bytes);
                bytes[bytes.Length - 1] &= (byte) 0x7F; //force sign bit to positive
                result = new SBigInteger(bytes);
            } while (result >= upperBound);

            return result;
        }
    }
}