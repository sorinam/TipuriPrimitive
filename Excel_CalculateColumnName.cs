using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipuriPrimitive
{
    class Excel_CalculateColumnName
    {
        public string ColumnName(int column)
        {
            string def_results = "";
            string calc_result = "";
            if (column > 0)
            {//valid column number
                int number = column;
                int Cat;
                int rest;
                do
                {
                    Cat = (number / 26);
                    rest = number % 26;
                    if ((rest) == 0)
                    { number = (Cat - 1); }
                    else
                    { number = Cat; }
                    calc_result += ConvertNumberToLetter(rest);
                } while (number > 0);

                for (int i = calc_result.Length - 1; i >= 0; i--)
                { def_results += calc_result[i]; }
            }
        
            else
            {//invalid column number -less or equal 0
                def_results += "-1";
            }
                return def_results;
        }
        public char ConvertNumberToLetter(int number)
        {
            char[] Letters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            char result;
            if (number != 0)
            {//not Z
                result = Letters[number - 1];
            }
            else
            {//is Z
                result = 'Z';
            }
            return result;
        }
    }
}
