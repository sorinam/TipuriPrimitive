﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TipuriPrimitive
{
    [TestClass]
    public class OneDayQGoats
    {
        [TestMethod]
        public void O1DayQGoats()
        {
            int Xdays = 5;
            int Ygoats = 3;
            int Zkg = 10;
            int Wdays = 1;
            int Qgoats = 9;
            float result = 0;
            Goats goats = new Goats();
            float expected_result = 6;
            result = goats.CalculateCant(Xdays, Ygoats, Zkg, Wdays, Qgoats);
            Assert.AreEqual(expected_result, result);
        }
    }
}
