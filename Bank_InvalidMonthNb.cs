using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TipuriPrimitive
{
    [TestClass]
    public class Bank_InvalidMonthNb
    {
        [TestMethod]
        public void Bank_InvalidMonthlyNumber()
        {
            Bank_CalculateRate bank_CalculateRate = new Bank_CalculateRate();
            //initial sum
            int sum = 40000;
            //period
            int period = 20;
            //interest
            float anual_interest = 7.57f;
            //interested monthly number
            int monthly_number = 1000;
            float result_rate = 0;
            result_rate = bank_CalculateRate.MonthlyBankRate(sum, period, anual_interest, monthly_number);
            float expected_rate =-1;
            Assert.AreEqual(expected_rate, result_rate);
        }
    }
}
