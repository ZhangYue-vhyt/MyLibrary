using System.Collections.Generic;
using System.Numerics;

namespace MyLibrary.Mathematics.Cryptography
{
    public abstract class CryptoBase
    {
        public IEnumerable<BigInteger> PublicKey { get; set; }
        protected IEnumerable<BigInteger> PrivateKey { get; set; }

        public abstract string Encryption(string plaintext);
        public abstract string Decryption(string ciphertext);
    }
}