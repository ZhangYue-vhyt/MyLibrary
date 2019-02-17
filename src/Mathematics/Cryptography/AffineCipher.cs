using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using MyLibrary.Mathematics.NumberTheorem;

namespace MyLibrary.Mathematics.Cryptography
{
    public class AffineCipher : CryptoBase
    {
        private ModularArithmetic Mod { get; set; }

        public AffineCipher(IEnumerable<BigInteger> key = null)
        {
            PrivateKey = key;
            Mod = new ModularArithmetic(26);
        }

        /// <summary>
        /// Key = (a,b)
        /// Modulo = m
        /// E(x) = (a + b) mod m
        /// </summary>
        /// <param name="plaintext"></param>
        /// <returns>Ciphertext</returns>
        public override string Encryption(string plaintext) =>
            new String(plaintext.ToCharArray().Select(x =>
                Convert.ToChar(('A' + ((PrivateKey.ElementAt(0) * x + PrivateKey.ElementAt(1))) % Mod.Modulo))).ToArray());

        /// <summary>
        /// Key = (a,b)
        /// Modulo = m
        /// D(y) = Inverse(a,m) * (y - b) mod m
        /// </summary>
        /// <param name="ciphertext"></param>
        /// <returns></returns>
        public override string Decryption(string ciphertext)
        {
            return new String(ciphertext.ToCharArray().Select(y =>
                    Convert.ToChar((Mod.Inverse(PrivateKey.ElementAt(0)) *
                        Mod.PositiveMod(y - 'A' - PrivateKey.ElementAt(1)) + 'A')))
                .ToArray());
        }

        /// <summary>
        /// Return the possible solutions of 
        ///     a * x1 + b mod m = y1
        ///     a * x2 + b mod m = y2
        /// </summary>
        /// <param name="pair1">(x1,y1)</param>
        /// <param name="pair2">(x2,y2)</param>
        /// <returns>A list of possible Keys (a,b,isValid)</returns>
        public(BigInteger, BigInteger, bool) GuessKey((BigInteger, BigInteger) pair1, (BigInteger, BigInteger) pair2)
        {
            if (Mod.HasInverse(Mod.PositiveMod(pair2.Item1 - pair1.Item1)))
            {
                var a = Mod.Inverse(Mod.PositiveMod(pair2.Item1 - pair1.Item1)) * (Mod.PositiveMod(pair2.Item2 - pair1.Item2)) % Mod.Modulo;
                var b = Mod.PositiveMod(pair1.Item2 - a * pair1.Item1);
                return (a, b, true);
            }
            return (0, 0, false);
        }
    }
}