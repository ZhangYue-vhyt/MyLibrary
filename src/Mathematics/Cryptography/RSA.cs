using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using MyLibrary.Mathematics.NumberTheorem;

namespace MyLibrary.Mathematics.Cryptography
{
    public class RSA : CryptoBase
    {
        public RSA()
        {
            BuildKeys();
        }

        /// <summary>
        /// Public key = {n,b}
        /// Private key = {p,q,a}
        /// </summary>
        private void BuildKeys()
        {

        }

        /// <summary>
        /// D(y) = y^a mod n
        /// </summary>
        /// <param name="plaintext"></param>
        /// <returns></returns>
        public override string Encryption(string plaintext, int start = 0) =>
            new String(plaintext.ToCharArray().Select(x => Convert.ToChar(
                BigInteger.ModPow(x - start, PublicKey.ElementAt(1), PublicKey.ElementAt(0))
            )).ToArray());

        /// <summary>
        /// E(x) = x^b mod n
        /// </summary>
        /// <param name="ciphertext"></param>
        /// <returns></returns>
        public override string Decryption(string ciphertext, int start = 0) =>
            new String(ciphertext.ToCharArray().Select(y => Convert.ToChar(
                start + BigInteger.ModPow(y-start, PrivateKey.ElementAt(2), PublicKey.ElementAt(0))
            )).ToArray());

    }
}