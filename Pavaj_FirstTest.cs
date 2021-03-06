﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TipuriPrimitive
{
    [TestClass]
    public class Pavaj_FirstTest
    {
        [TestMethod]
        public void Pavaj_SimpleCase()
        {
            // length%a = 0 and high%a=0
            int lung_p = 6;
            int lat_p = 8;
            int a = 2;
            int expected_result = 12;
            CalculateDale classCalculate = new CalculateDale();
            int result = classCalculate.CalculDale(lung_p, lat_p, a);
            Assert.AreEqual(expected_result, result);
        }
    }
}
