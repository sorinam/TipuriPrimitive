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
            public DateTime dayOfTheMonth;
        }
        public List<DailyValues> listOfDailyValues = new List<DailyValues>();

        public List<float> minTemparature = new List<float> { 12.5F, 15.5F, 13.6F };
        public List<float> maxTemparature = new List<float> { 22.5F, 25.5F, 23.6F };
        public List<DateTime> dailyList = new List<DateTime> { new DateTime(2015, 10, 1), new DateTime(2015, 10, 2 ), new DateTime(2015, 10, 3), };


        [TestMethod]
        public void MoreWarmDayOfTheMonth()
        {
            var expectedMaxTemperature = maxTemparature.Max();
            var expectedWarmDay = new DateTime(2015, 10, 2);
            DateTime foundWarmDay;

            GetListOfMonthlyValues();
            var calculateMaxTemperature = GetMaxTemperatureOfTheMonth(listOfDailyValues, out foundWarmDay);

            Assert.IsFalse(listOfDailyValues.Count==0,"Some input information are missing!");
            Assert.IsTrue(listOfDailyValues.Count <= 31, "Too much information for a month !");
            Assert.AreEqual(expectedMaxTemperature, calculateMaxTemperature);
            Assert.AreEqual(expectedWarmDay, foundWarmDay);
        }

        [TestMethod]
        public void MoreColdDayOfTheMonth()
        {
            var expectedMinTemperature = minTemparature.Min();
            var expectedWarmDay = new DateTime(2015, 10, 1);
            DateTime foundColdDay;

            GetListOfMonthlyValues();
            var calculateMinTemperature = GetMinTemperatureOfTheMonth(listOfDailyValues, out foundColdDay);

            Assert.IsFalse(listOfDailyValues.Count == 0, "Some input information are missing!");
            Assert.IsTrue(listOfDailyValues.Count <= 31, "Too much information for a month !");
            Assert.AreEqual(expectedMinTemperature, calculateMinTemperature);
            Assert.AreEqual(expectedWarmDay, foundColdDay);
        }

        [TestMethod]
        public void AverageTemperatureOfTheMonth()
        {
            var expectedTemperature = 23.86F;
            
            GetListOfMonthlyValues();
            var calculateTemperature = GetAverageTemperatureOfTheMonth(listOfDailyValues);

            Assert.IsFalse(listOfDailyValues.Count == 0, "Some input information are missing!");
            Assert.IsTrue(listOfDailyValues.Count <= 31, "Too much information for a month !");
            Assert.AreEqual(expectedTemperature, calculateTemperature);
         
        }

        private float GetAverageTemperatureOfTheMonth(List<DailyValues> listOfDailyValues)
        {
            
            if (listOfDailyValues.Count == 0)
            {
                return 0F;
            }
            else
            {
                float sum = 0;
                for (int i = 0; i < listOfDailyValues.Count; i++)
                {
                    sum += listOfDailyValues[i].maxTemp;
                }
                return sum / listOfDailyValues.Count;
            }
            
       }

        private float GetMaxTemperatureOfTheMonth(List<DailyValues> listOfDailyValues, out DateTime dayNumber)
        {
            float maxValue = 0F;
            DateTime index = new DateTime();
            for (int i = 0; i < listOfDailyValues.Count; i++)
            {
                if (listOfDailyValues[i].maxTemp > maxValue)
                {
                    maxValue = listOfDailyValues[i].maxTemp;
                    index = listOfDailyValues[i].dayOfTheMonth;
                }
            }
            dayNumber = index;
            return maxValue;
        }

        private float GetMinTemperatureOfTheMonth(List<DailyValues> listOfDailyValues, out DateTime dayNumber)
        {
            float minValue =50F;
            DateTime index = new DateTime();
            for (int i = 0; i < listOfDailyValues.Count; i++)
            {
                if (listOfDailyValues[i].minTemp < minValue)
                {
                    minValue = listOfDailyValues[i].minTemp;
                    index = listOfDailyValues[i].dayOfTheMonth;
                }
            }
            dayNumber = index;
            return minValue;
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
                    node.dayOfTheMonth = dailyList[i].Date;

                    listOfDailyValues.Add(node);
                }
            }
        }
    }
}

