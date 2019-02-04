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
        public string Encryption(string plaintext) => new String(plaintext.ToCharArray().Select(c => Convert.ToChar(('A' + ((Key.Item1 * c + Key.Item2)) % Modulo))).ToArray());

        /// <summary>
        /// Key = (a,b)
        /// Modulo = m
        /// D(y) = Inverse(a,m) * (y - b) mod m
        /// </summary>
        /// <param name="ciphertext"></param>
        /// <returns></returns>
        public string Decryption(string ciphertext) => new String(ciphertext.ToCharArray().Select(c => Convert.ToChar((NumberTheorem.ModularArithmetic.Inverse(Key.Item1, Modulo) * PositiveMod(c-'A' - Key.Item2)) % Modulo + 'A')).ToArray());

        public int PositiveMod(int mod) => mod >= 0 ? mod : mod + Modulo;

        /// <summary>
        /// Return the possible solutions of 
        ///     a * x1 + b mod m = y1
        ///     a * x2 + b mod m = y2
        /// </summary>
        /// <param name="pair1">(x1,y1)</param>
        /// <param name="pair2">(x2,y2)</param>
        /// <returns>A list of possible Keys (a,b,isValid)</returns>
        public IList < (int, int, bool) > GuessKey((int, int) pair1, (int, int) pair2)
        {
            var x1 = pair1.Item1;
            var y1 = pair1.Item2;
            var x2 = pair2.Item1;
            var y2 = pair2.Item2;
            var a = -1;
            var b = -1;
            var c = false;
            var result = new List < (int, int, bool) > ();
            for (int i = 0; i < Modulo; i++)
            {
                if ((((x2 - x1) * i) % Modulo == ((y2 - y1)) % Modulo) || (((x2 - x1) * i + Modulo) % Modulo == ((y2 - y1) + Modulo) % Modulo))
                {
                    a = i;
                    c = GCD.EuclideanAlgorithm(i, Modulo) == 1;
                    for (int j = 0; j < Modulo; j++)
                    {
                        if ((x1 * a + j) % Modulo == y1 && (x2 * a + j) % Modulo == y2)
                        {
                            b = j;
                        }
                    }
                    result.Add((a, b, c));
                }
            }
            return result;
        }

        /// <summary>
        /// Count the occurrences of each English letters in a string.
        /// </summary>
        /// <param name="ciphertext"></param>
        /// <returns>int[26]</returns>
        public int[] Occurrences(string ciphertext)
        {
            var result = new int[26];
            ciphertext.ToUpper()
                .Trim().Replace(" ", String.Empty)
                .ToCharArray().ToList()
                .ForEach(e => result[e - 'A']++);
            return result;
        }
        public void PrintOccurrences(string ciphertext)
        {
            var occurrences = Occurrences(ciphertext);
            for (int i = 0; i < occurrences.Length; i++)
            {
                System.Console.WriteLine("The occurrence of {0} = {1}",
                    Convert.ToChar(i + 'A'), occurrences[i]);
            }
        }
    }
}