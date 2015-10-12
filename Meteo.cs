using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TipuriPrimitive
{
    [TestClass]
    public class Meteo
    {
        public struct DailyValues
        {
            public float minTemp;
            public float maxTemp;
            public int dayOfTheMonth;
        }
        public List<DailyValues> listOfDailyValues = new List<DailyValues>();

        public List<float> minTemparature = new List<float> { 12.5F, 15.5F, 13.6F };
        public List<float> maxTemparature = new List<float> { 22.5F, 25.5F, 23.6F };
        public List<DateTime> dailyList = new List<DateTime> { new DateTime(2015, 10, 1, 0, 0, 0), new DateTime(2015, 10, 2, 0, 0, 0), new DateTime(2015, 10, 3, 0, 0, 0), };


        [TestMethod]
        public void MoreWarmDayOfTheMonth()
        {
            var expectedMaxTemperature = maxTemparature.Max();
            var expectedWarmDay = new DateTime(2015, 10, 1, 0, 0, 0).Day;
            int foundWarmDay = 0;

            GetListOfMonthlyValues();
            var calculateMaxTemperature = GetMaxTemperatureOfTheMonth(listOfDailyValues, out foundWarmDay);

            Assert.IsFalse(listOfDailyValues.Count==0,"Some input information are missing!");
            Assert.IsTrue(listOfDailyValues.Count <= 31, "Too much information for a month !");
            Assert.AreEqual(expectedMaxTemperature, calculateMaxTemperature);
            Assert.AreEqual(expectedWarmDay, foundWarmDay);

        }

        private float GetMaxTemperatureOfTheMonth(List<DailyValues> listOfDailyValues, out int dayNumber)
        {
            float maxValue = 0F;
            int index = 0;
            for (int i = 0; i < listOfDailyValues.Count; i++)
            {
                if (listOfDailyValues[i].maxTemp > maxValue)
                {
                    maxValue = listOfDailyValues[i].maxTemp;
                    index = i;
                }
            }
            dayNumber = index;
            return maxValue;
        }

        private void GetListOfMonthlyValues()
        {
            if ((minTemparature.Count ==maxTemparature.Count)&&((minTemparature.Count == dailyList.Count)))
            {
                for (int i = 0; i < minTemparature.Count; i++)
                {
                    DailyValues node = new DailyValues();

                    node.minTemp = minTemparature[i];
                    node.maxTemp = maxTemparature[i];
                    node.dayOfTheMonth = dailyList[i].Day;

                    listOfDailyValues.Add(node);
                }
            }
        }
    }
}

