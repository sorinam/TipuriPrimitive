﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TipuriPrimitive
{
    [TestClass]
    public class Bank_LastRate
    {
        [TestMethod]
        public void Bank_CalculateLastRate()
        {
            Bank_CalculateRate bank_CalculateRate = new Bank_CalculateRate();
            //initial sum
            int sum = 40000;
            //period
            int period = 20;
            //interest
            float anual_interest = 7.57f;
            //interested monthly number
            int monthly_number = 240;
            float result_rate = 0;
            result_rate = bank_CalculateRate.MonthlyBankRate(sum, period, anual_interest, monthly_number);
            float expected_rate = 167.718f;
            Assert.AreEqual(expected_rate.ToString(), result_rate.ToString());
        }
    }
}
