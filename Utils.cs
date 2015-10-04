using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipuriPrimitive
{
    class Utils
    {
        public decimal ChancetoWin(uint TotalNumbers, uint Numbers)
        {
            ulong FavorabileCases = Combinations(6, Numbers) * Combinations(TotalNumbers - Numbers, 6 - Numbers);
            ulong TotalCases = Combinations(TotalNumbers, 6);
            var Result = (decimal)FavorabileCases / TotalCases;
            return decimal.Round(Result,15);
        }
        public ulong Combinations(uint n, uint k)
        {//works only for numbers less than 20
         // return (k > n) ? 0 : Factorial(n) / (Factorial(k) * Factorial(n - k));
            return (k < n / 2) ? CalculateCombinations(n, k) : CalculateCombinations(n, n - k);
        }
        private ulong CalculateCombinations(uint n, uint k)
        {
            ulong result_intermediar = this.CalculateCombinationsNPerCombinanationsk(n, k);
            return result_intermediar / Factorial(k);
        }
        private ulong CalculateCombinationsNPerCombinanationsk(uint n, uint k)
        {
            ulong result = 1;
            for (ulong i = n - k + 1; i <= n; i++)
                result = result * i;
            return result;
        }

        private ulong Factorial(ulong i)
        {
            return (i <= 1) ? 1 : i * Factorial(i - 1);
        }
       
    }
}
