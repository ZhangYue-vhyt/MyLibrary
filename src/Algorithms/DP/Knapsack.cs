using System;
using System.Collections.Generic;
using System.Linq;

namespace MyLibrary.Algorithms.DP
{
    /// <summary>
    /// Problem: Given n objects with their respective weights and profits, 
    /// and a knapsack of limited capacity C, choose the objects to maximize the total profit,
    /// given the constraint that their total weights cannot exceed the knapsack capacity.
    /// 
    /// Assuming the vectors p and w, of size n each, we construct a “dynamic table” P 
    /// with n rows and C columns, where an entry P[i,j] represents the maximum 
    /// profit, using objects 1.. i, in a bag of capacity j. 
    /// </summary>
    public class Knapsack
    {
        /// <summary>
        /// The result of picked objects.
        /// The index is the same as the index of objects.
        /// The value 1 is picked, 0 is unpicked.
        /// </summary>
        /// <value></value>
        public int[] Result { get; private set; }
        public int MaxProfit { get; private set; }
        public int[, ] Matrix { get; private set; }
        private IEnumerable<int> Weights { get; set; }
        private IEnumerable<int> Profits { get; set; }
        public int Capacity { get; private set; }

        /// <summary>
        /// Constractor
        /// </summary>
        /// <param name="capacity">Capacity</param>
        /// <param name="pairs">A collection of (weight, profit).</param>
        /// <returns></returns>
        public Knapsack(int capacity, IEnumerable < (int, int) > pairs)
        {
            if (capacity > 0 && pairs.All(p => p.Item1 > 0))
            {
                Capacity = capacity;
                Weights = pairs.Select(p => p.Item1);
                Profits = pairs.Select(p => p.Item2);
                BuildMatrix();
                BuildResult();
                MaxProfit = Matrix[Weights.Count(), Capacity];
            }
            else
            {
                MaxProfit = 0;
                Result = null;
            }
        }

        /// <summary>
        /// The transition function is
        ///     P[i,j] = max (P[i-1, j], pi + P[i-1, j-wi]) 
        /// </summary>
        private void BuildMatrix()
        {
            var row = Weights.Count() + 1;
            var col = Capacity + 1;
            Matrix = new int[row, col];
            for (int i = 0; i < row; i++)
                Matrix[i, 0] = 0;
            for (int j = 0; j < col; j++)
                Matrix[0, j] = 0;
            for (int i = 1; i < row; i++)
            {
                for (int j = 1; j < col; j++)
                {
                    Matrix[i, j] = j < Weights.ElementAt(i - 1) ?
                        Matrix[i - 1, j] :
                        Math.Max(Matrix[i - 1, j], Profits.ElementAt(i - 1) + Matrix[i - 1, j - Weights.ElementAt(i - 1)]);
                }
            }
        }
        
        private void BuildResult()
        {
            Result = new int[Weights.Count()];
            var i = Weights.Count();
            var j = Capacity;
            while (i > 0 && j > 0)
            {
                if (j < Weights.ElementAt(i - 1));
                else if (Matrix[i, j] == Matrix[i - 1, j]);
                else if (Matrix[i, j] == Profits.ElementAt(i - 1) + Matrix[i - 1, j - Weights.ElementAt(i - 1)])
                {
                    j -= Weights.ElementAt(i - 1);
                    Result[i - 1]++;
                }
                i--;
            }
        }
    }
}