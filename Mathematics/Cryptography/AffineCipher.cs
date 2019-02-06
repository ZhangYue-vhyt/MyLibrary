using System;
using System.Collections.Generic;
using System.Linq;
using MyLibrary.Mathematics.NumberTheorem;

namespace MyLibrary.Mathematics.Cryptography
{
    public class AffineCipher
    {
        private int Modulo { get; set; }
        private(int, int) Key { get; set; }
        public AffineCipher((int, int) key, int mod = 26)
        {
            Key = key;
            Modulo = mod;
        }
        public AffineCipher(int mod = 26)
        {
            Modulo = mod;
        }

        /// <summary>
        /// Key = (a,b)
        /// Modulo = m
        /// E(x) = (a + b) mod m
        /// </summary>
        /// <param name="plaintext"></param>
        /// <returns>Ciphertext</returns>
        public string Encryption(string plaintext) =>
            new String(plaintext.ToCharArray().Select(c =>
                Convert.ToChar(('A' + ((Key.Item1 * c + Key.Item2)) % Modulo))).ToArray());

        /// <summary>
        /// Key = (a,b)
        /// Modulo = m
        /// D(y) = Inverse(a,m) * (y - b) mod m
        /// </summary>
        /// <param name="ciphertext"></param>
        /// <returns></returns>
        public string Decryption(string ciphertext) =>
            new String(ciphertext.ToCharArray().Select(c =>
                    Convert.ToChar((NumberTheorem.ModularArithmetic.Inverse(Key.Item1, Modulo) *
                        PositiveMod(c - 'A' - Key.Item2)) % Modulo + 'A'))
                .ToArray());

        public int PositiveMod(int mod) => mod >= 0 ? mod : mod + Modulo;

        /// <summary>
        /// Return the possible solutions of 
        ///     a * x1 + b mod m = y1
        ///     a * x2 + b mod m = y2
        /// </summary>
        /// <param name="pair1">(x1,y1)</param>
        /// <param name="pair2">(x2,y2)</param>
        /// <returns>A list of possible Keys (a,b,isValid)</returns>
        public(int, int, bool) GuessKey((int, int) pair1, (int, int) pair2)
        {
            if (ModularArithmetic.HasInverse(PositiveMod(pair2.Item1 - pair1.Item1), Modulo))
            {
                var a = ModularArithmetic.Inverse(PositiveMod(pair2.Item1 - pair1.Item1), Modulo) * (PositiveMod(pair2.Item2 - pair1.Item2)) % Modulo;
                var b = PositiveMod((pair1.Item2 - a * pair1.Item1) % Modulo);
                return (a, b, true);
            }
            return (0, 0, false);
        }
    }
}