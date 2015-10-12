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

        [TestMethod]
        public void MoreWarmDayOfTheMonth()
        {
            List<float> minTemparature = new List<float> { 12.5F, 15.5F, 13.6F, 10.2F };
            List<float> maxTemparature = new List<float> { 22.5F, 25.5F, 23.6F, 26.5F };
            List<DateTime> dailyList = new List<DateTime> { new DateTime(2015, 10, 1), new DateTime(2015, 10, 2), new DateTime(2015, 10, 3), new DateTime(2015, 10, 4) };
            var expectedMaxTemperature = 26.5F;
            List<DateTime> expectedWarmDay = new List<DateTime> { new DateTime(2015, 10, 4) };
            List<DateTime> foundWarmDay;

            GetListOfMonthlyValues(minTemparature, maxTemparature, dailyList);
            var calculateMaxTemperature = GetMaxTemperatureOfTheMonth(listOfDailyValues, out foundWarmDay);

            Assert.IsFalse(listOfDailyValues.Count == 0, "Some input information are missing!");
            Assert.IsTrue(listOfDailyValues.Count <= 31, "Too much information for a month !");
            Assert.AreEqual(expectedMaxTemperature, calculateMaxTemperature);
            CollectionAssert.AreEqual(expectedWarmDay, foundWarmDay);
        }

        public void GetListOfMonthlyValues(List<float> minTemparature, List<float> maxTemparature, List<DateTime> dailyList)
        {
            if ((minTemparature.Count == maxTemparature.Count) && ((minTemparature.Count == dailyList.Count)))
            {
                DailyValues node = new DailyValues();
                for (int i = 0; i < minTemparature.Count; i++)
                {
                    node.minTemp = minTemparature[i];
                    node.maxTemp = maxTemparature[i];
                    node.dayOfTheMonth = dailyList[i].Date;
                    listOfDailyValues.Add(node);
                }
            }
        }

        [TestMethod]
        public void MoreWarmDaysOfTheMonth()
        {
            List<float> minTemparature = new List<float> { 12.5F, 15.5F, 13.6F, 10.2F };
            List<float> maxTemparature = new List<float> { 22.5F, 25.5F, 23.6F, 25.5F };
            List<DateTime> dailyList = new List<DateTime> { new DateTime(2015, 10, 1), new DateTime(2015, 10, 2), new DateTime(2015, 10, 3), new DateTime(2015, 10, 4) };
            var expectedMaxTemperature = 25.5F;
            List<DateTime> expectedWarmDay = new List<DateTime>
            {
                new DateTime(2015, 10, 2),
                new DateTime(2015, 10, 4)
            };
            List<DateTime> foundWarmDay;

            GetListOfMonthlyValues(minTemparature, maxTemparature, dailyList);
            var calculateMaxTemperature = GetMaxTemperatureOfTheMonth(listOfDailyValues, out foundWarmDay);

            Assert.IsFalse(listOfDailyValues.Count == 0, "Some input information are missing!");
            Assert.IsTrue(listOfDailyValues.Count <= 31, "Too much information for a month !");
            Assert.AreEqual(expectedMaxTemperature, calculateMaxTemperature);
            CollectionAssert.AreEqual(expectedWarmDay, foundWarmDay);
        }

        [TestMethod]
        public void MoreColdDayOfTheMonth()
        {
            List<float> minTemparature = new List<float> { 12.5F, 15.5F, 13.6F, 10.2F };
            List<float> maxTemparature = new List<float> { 22.5F, 25.5F, 23.6F, 25.5F };
            List<DateTime> dailyList = new List<DateTime> { new DateTime(2015, 10, 1), new DateTime(2015, 10, 2), new DateTime(2015, 10, 3), new DateTime(2015, 10, 4) };
            var expectedMinTemperature = 10.2F;
            var expectedColdDay = new List<DateTime> { new DateTime(2015, 10, 4) };
            List <DateTime> foundColdDay;

            GetListOfMonthlyValues(minTemparature, maxTemparature, dailyList);
            var calculateMinTemperature = GetMinTemperatureOfTheMonth(listOfDailyValues, out foundColdDay);

            Assert.IsFalse(listOfDailyValues.Count == 0, "Some input information are missing!");
            Assert.IsTrue(listOfDailyValues.Count <= 31, "Too much information for a month !");
            Assert.AreEqual(expectedMinTemperature, calculateMinTemperature);
            CollectionAssert.AreEqual(expectedColdDay, foundColdDay);
        }

        [TestMethod]
        public void MoreColdDaysOfTheMonth()
        {
            List<float> minTemparature = new List<float> { 10.2F, 15.5F, 13.6F, 10.2F };
            List<float> maxTemparature = new List<float> { 22.5F, 25.5F, 23.6F, 25.5F };
            List<DateTime> dailyList = new List<DateTime> { new DateTime(2015, 10, 1), new DateTime(2015, 10, 2), new DateTime(2015, 10, 3), new DateTime(2015, 10, 4) };
            var expectedMinTemperature = 10.2F;
            List<DateTime> expectedColdDays = new List<DateTime>
            { new DateTime(2015, 10, 1), new DateTime(2015, 10, 4)};
            List<DateTime> foundColdDay;

            GetListOfMonthlyValues(minTemparature, maxTemparature, dailyList);
            var calculateMinTemperature = GetMinTemperatureOfTheMonth(listOfDailyValues, out foundColdDay);

            Assert.IsFalse(listOfDailyValues.Count == 0, "Some input information are missing!");
            Assert.IsTrue(listOfDailyValues.Count <= 31, "Too much information for a month !");
            Assert.AreEqual(expectedMinTemperature, calculateMinTemperature);
            CollectionAssert.AreEqual(expectedColdDays, foundColdDay);
        }

        [TestMethod]
        public void AverageTemperatureOfTheMonth()
        {
            List<float> minTemparature = new List<float> { 12.5F, 15.5F, 13.6F, 10.2F };
            List<float> maxTemparature = new List<float> { 22.5F, 25.5F, 23.6F, 25.5F };
            List<DateTime> dailyList = new List<DateTime> { new DateTime(2015, 10, 1), new DateTime(2015, 10, 2), new DateTime(2015, 10, 3), new DateTime(2015, 10, 4) };
            var expectedTemperature = 24.275F;

            GetListOfMonthlyValues(minTemparature, maxTemparature, dailyList);
            var calculateTemperature = GetAverageTemperatureOfTheMonth(listOfDailyValues);

            Assert.IsFalse(listOfDailyValues.Count == 0, "Some input information are missing!");
            Assert.IsTrue(listOfDailyValues.Count <= 31, "Too much information for a month !");
            Assert.AreEqual(expectedTemperature, calculateTemperature);

        }

        [TestMethod]
        public void MaximumDifferenceOfMinMaxTemperature()
        {
            List<float> minTemparature = new List<float> { 12.5F, 15.5F, 13.6F, 10.2F };
            List<float> maxTemparature = new List<float> { 22.5F, 25.5F, 23.6F, 25.5F };
            List<DateTime> dailyList = new List<DateTime> { new DateTime(2015, 10, 1), new DateTime(2015, 10, 2), new DateTime(2015, 10, 3), new DateTime(2015, 10, 4) };
            var expectedDifTemperature = 15.3F;
            var expectedDifDay =new List<DateTime> { new DateTime(2015, 10, 4)};
            List<DateTime> foundDifDay;

            GetListOfMonthlyValues(minTemparature, maxTemparature, dailyList);
            var calculateDifTemperature = GetDifTemperatureOfTheMonth(listOfDailyValues, out foundDifDay);

            Assert.IsFalse(listOfDailyValues.Count == 0, "Some input information are missing!");
            Assert.IsTrue(listOfDailyValues.Count <= 31, "Too much information for a month !");
            Assert.AreEqual(expectedDifTemperature, calculateDifTemperature);
            CollectionAssert.AreEqual(expectedDifDay, foundDifDay);
        }

        private float GetDifTemperatureOfTheMonth(List<DailyValues> listOfDailyValues, out List<DateTime> foundDifDay)
        {
            float maxValue = 0F;
            List<DateTime> days = new List<DateTime>();
            for (int i = 0; i < listOfDailyValues.Count; i++)
            {
                if ((listOfDailyValues[i].maxTemp - listOfDailyValues[i].minTemp) > maxValue)
                {
                    maxValue = listOfDailyValues[i].maxTemp - listOfDailyValues[i].minTemp;
                 }
            }
            var daysNo = listOfDailyValues.FindAll(day => (day.maxTemp-day.minTemp) == maxValue);
            foundDifDay = ExtractDayFieldFromStructData(daysNo); 
            return maxValue;
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

        private float GetMaxTemperatureOfTheMonth(List<DailyValues> listOfDailyValues, out List<DateTime> dayNumber)
        {
            float maxValue = 0F;
            List<DateTime> days = new List<DateTime>();
            for (int i = 0; i < listOfDailyValues.Count; i++)
            {
                if (listOfDailyValues[i].maxTemp > maxValue)
                {
                    maxValue = listOfDailyValues[i].maxTemp;
                }
            }
            var daysNo = listOfDailyValues.FindAll(day => day.maxTemp == maxValue);
            dayNumber = ExtractDayFieldFromStructData(daysNo);
            return maxValue;
        }

        private float GetMinTemperatureOfTheMonth(List<DailyValues> listOfDailyValues, out List<DateTime> dayNumber)
        {
            float minValue = 50F;
            List<DateTime> days = new List<DateTime>();
            for (int i = 0; i < listOfDailyValues.Count; i++)
            {
                if (listOfDailyValues[i].minTemp < minValue)
                {
                    minValue = listOfDailyValues[i].minTemp;
                }
            }
            var daysNo = listOfDailyValues.FindAll(day => day.minTemp == minValue);
            dayNumber = ExtractDayFieldFromStructData(daysNo);
            return minValue;
        }
        private List<DateTime> ExtractDayFieldFromStructData(List<DailyValues> daysNo)
        {
            List<DateTime> days = new List<DateTime>();
            for (int i = 0; i < daysNo.Count; i++)
            {
                days.Add(daysNo[i].dayOfTheMonth);
            }
            return days;
        }
    }
}

