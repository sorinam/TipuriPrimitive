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
        {
            float rate = 0;
            if(monthly_number<1 || monthly_number>period*12)
            {//invalid monthly number, it can't be negative or grater than period of contract
                rate = -1;
            }
                else
            {//correct monyhly_number
                //calculate pricipal
                float principal = sum / (period * 12);
                //calculate lunar interest
                float lunar_interest = anual_interest / 12 / 100;
                //calculate amount
                float amount = sum - (monthly_number - 1) * principal;
                //calculate interest of amount
                float interest = lunar_interest * amount;
                //calculate Rate
                rate = principal + interest; }
            return rate;
        }
    }
}
