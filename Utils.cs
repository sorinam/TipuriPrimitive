using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipuriPrimitive
{
    class Utils
    {
        public double ChancetoWin(ulong TotalNumbers, ulong Numbers)
        {
            ulong FavorabilCases = Combinations(6, Numbers) * Combinations(TotalNumbers - Numbers, 6 - Numbers);
            ulong TotalCases = Combinations(TotalNumbers, 6);
            return ((double)FavorabilCases / (double)TotalCases);
        }
        public ulong Combinations(ulong n, ulong k)
        {//works only for numbers less than 20
         // return (k > n) ? 0 : Factorial(n) / (Factorial(k) * Factorial(n - k));
         return (k < n / 2) ? CalculateCombinations(n, k) : CalculateCombinations(n, n - k);
        }
        private ulong Factorial(ulong i)
        {
            return (i <= 1) ? 1 : i * Factorial(i - 1);
        }
        private ulong CalculateCombinations(ulong n, ulong k)
        {
            ulong result_intermediar = this.CalculateCombinationsNPerCombinanationsk(n, k);
            return result_intermediar / Factorial(k);
        }
        private ulong CalculateCombinationsNPerCombinanationsk(ulong n, ulong k)
        {
            ulong result = 1;
            for (ulong i = n - k + 1; i <= n; i++)
                result = result * i;
            return result;
        }
       
    }
}
