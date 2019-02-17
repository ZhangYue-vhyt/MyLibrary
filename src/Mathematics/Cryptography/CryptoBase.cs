using System.Collections.Generic;
using System.Numerics;

namespace MyLibrary.Mathematics.Cryptography
{
    public abstract class CryptoBase
    {
        public IEnumerable<BigInteger> PublicKey { get; set; }
        protected IEnumerable<BigInteger> PrivateKey { get; set; }

        public abstract string Encryption(string plaintext, int start = 0);
        public abstract string Decryption(string ciphertext, int start = 0);
    }
}