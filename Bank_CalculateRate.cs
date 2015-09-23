using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipuriPrimitive
{
    class Bank_CalculateRate
    {
        public float MonthlyBankRate(float sum, int period, float anual_interest, int monthly_number)
        {//calculate pricipal
            float principal = sum / (period * 12);
            //calculate lunar interest
            float lunar_interest = anual_interest / 12/100;
            //calculate amount
            float amount = sum - (monthly_number - 1) * principal;
            //calculate interest of amount
            float interest = lunar_interest * amount;
            //calculate Rate
            float rate = principal +interest;
            return rate;
        }
    }
}
