using System;
using System.Linq;
using System.Numerics;
using MyLibrary.Mathematics.NumberTheorem;

namespace MyLibrary.Mathematics.Cryptography
{
    public class RSA : ICryptography
    {
        /// <summary>
        /// The public key (n, b)
        /// </summary>
        /// <value></value>
        public(BigInteger, int) PublicKey { get; set; }

        /// <summary>
        /// The private key = (n, p, q, a, b)
        /// </summary>
        /// <value></value>
        private(BigInteger, BigInteger, BigInteger, int, int) PrivateKey { get; set; }
        public(BigInteger, int) ReceivedKey { get; set; }

        public RSA()
        {
            GeneratePrivateKey();
        }

        public RSA((int, int) receivedKey)
        {
            ReceivedKey = receivedKey;
            GeneratePrivateKey();
        }

        private void GeneratePrivateKey()
        {

        }

        public string Decryption(string ciphertext)
        {
            return new String(ciphertext.ToCharArray().Select(
                ch => Convert.ToChar(ModularArithmetic.PositiveMod(BigInteger.Pow(ch - 'A', PrivateKey.Item4), PrivateKey.Item1) + 'A')).ToArray());
        }

        public string Encryption(string plaintext)
        {
            throw new System.NotImplementedException();
        }
    }
}