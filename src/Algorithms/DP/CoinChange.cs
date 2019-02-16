using System;
using System.Collections.Generic;
using System.Linq;

namespace MyLibrary.Algorithms.DP
{
    /// <summary>
    /// Given a value N, if we want to make change for N cents, 
    /// and we have infinite supply of each of S = { S1, S2, .. , Sm} valued coins, 
    /// how many  ways can we make the change? The order of coins doesn’t matter.
    /// The transition function is 
    ///     C[i,j] = Min(C[i-1,j], 1+C[i,j-Si])
    /// </summary>
    public class CoinChange
    {
        /// <summary>
        /// Return how many ways the change can be made.
        /// </summary>
        /// <value>0 means impossible.</value>
        public int Result { get; set; }

        /// <summary>
        /// Return a dictionary whose keys are Coins,
        /// values are the count of each coin.
        /// </summary>
        /// <value></value>
        public IDictionary<int, int> Counts { get; set; }
        private int Money { get; set; }
        private ISet<int> Coins { get; set; }
        public int[, ] Matrix { get; set; }
        public CoinChange(int money, IEnumerable<int> coins)
        {
            if (money > 0 && coins.All(coin => coin >= 0))
            {
                Money = money;
                Coins = new SortedSet<int>(coins);
                Coins.Remove(0);
                BuildMatrix();
                BuildCounts();
                Result = Matrix[Coins.Count, Money];
            }
            else
            {
                Result = 0;
            }
        }

        private void BuildMatrix()
        {
            var row = Coins.Count + 1;
            var col = Money + 1;
            Matrix = new int[row, col];

            for (int i = 0; i < col; i++)
                Matrix[0, i] = Money + 1;
            for (int i = 0; i < row; i++)
                Matrix[i, 0] = 0;

            for (int i = 1; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Matrix[i, j] = j < Coins.ElementAt(i - 1) ?
                        Matrix[i - 1, j] :
                        Math.Min(Matrix[i - 1, j], 1 + Matrix[i, j - Coins.ElementAt(i - 1)]);
                }
            }

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (Matrix[i, j] > Money)
                        Matrix[i, j] = 0;
                }
            }
        }

        private void BuildCounts()
        {
            Counts = new SortedList<int, int>(Coins.Count);
            
            foreach (var item in Coins)
            {
                Counts.TryAdd(item, 0);
            }

            var i = Coins.Count;
            var j = Money;
            while (i > 0 && j > 0)
            {
                if (Matrix[i, j] == Matrix[i - 1, j]) i--;
                else if (Matrix[i, j] == Matrix[i, j - Coins.ElementAt(i - 1)] + 1)
                {
                    j -= Coins.ElementAt(i - 1);
                    Counts[Coins.ElementAt(i - 1)]++;
                }
            }
        }
    }
}