using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TipuriPrimitive
{
    [TestClass]
    public class Bank_NRate
    {
        [TestMethod]
        public void Bank_CalculateRateN()
        {
            Bank_CalculateRate bank_CalculateRate = new Bank_CalculateRate();
            //initial sum
            int sum = 40000;
            //period
            int period = 20;
            //interest
            float anual_interest = 7.57f;
            //interested monthly number =39 march in the 4 year
            int monthly_number = 39;
            float result_rate = 0;
            result_rate = bank_CalculateRate.MonthlyBankRate(sum, period, anual_interest, monthly_number);
            float expected_rate = 379.0472f;
            Assert.AreEqual(expected_rate.ToString(), result_rate.ToString());
        }
    }
}
