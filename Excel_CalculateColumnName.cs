﻿using System;
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
            string calc_result = "";
            if (column > 0)
            {//valid column number
                int number = column;
                int Cat;
                int rest;
                Cat = (number / 26);
                rest = number % 26;
                calc_result += ConvertNumberToLetter(rest);
            }
            else
            {//invalid column number -less or equal 0
                calc_result += "-1";
            }
                return calc_result;
        }
        public char ConvertNumberToLetter(int number)
        {
            char[] Letters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            char result;
            result = Letters[number - 1];
            return result;
        }
    }
}