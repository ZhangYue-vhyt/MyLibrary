using System;
using System.Collections.Generic;
using System.Linq;
using MyLibrary.Mathematics.NumberTheorem;

namespace MyLibrary.Mathematics.Cryptography
{
    public class VigenereCipher : CryptoBase
    {
        private IEnumerable<int> PrivateKey { get; set; }
        public VigenereCipher(string keyString) =>
            PrivateKey = keyString.ToCharArray().Select(c => c - 'A');

        public override string Encryption(string plaintext, int start = 'A')
        {
            var result = plaintext.ToCharArray().Select(c => c - 'A').ToArray();
            for (int i = 0; i < result.Length; i++)
            {
                var modKey = new ModularArithmetic(PrivateKey.Count());
                var mod26 = new ModularArithmetic(26);
                result[i] = (int) mod26.PositiveMod(result[i] + PrivateKey.ElementAt((int) modKey.PositiveMod(i)));
            }
            return new String(result.Select(num => Convert.ToChar(num + start)).ToArray());
        }

        public override string Decryption(string ciphertext, int start = 'A')
        {
            var result = ciphertext.ToCharArray().Select(c => c - 'A').ToArray();
            for (int i = 0; i < result.Length; i++)
            {
                var modKey = new ModularArithmetic(PrivateKey.Count());
                var mod26 = new ModularArithmetic(26);
                result[i] = (int) mod26.PositiveMod(result[i] - PrivateKey.ElementAt((int) modKey.PositiveMod(i)));
            }
            return new String(result.Select(num => Convert.ToChar(num + start)).ToArray());
        }
    }
}