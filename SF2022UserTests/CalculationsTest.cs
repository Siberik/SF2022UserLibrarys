using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SF2022UserLibrary;

namespace SF2022UserTests
{
    [TestClass]
    public class CalculationsTest
    {
        [TestMethod]
        public void AvailablePeriods_StringEmpty_ReturnedEmpty()
        {
            TimeSpan[] startTime = { };
            int[] durations = { };
            TimeSpan beginWorkingTime = new TimeSpan();
            TimeSpan endWorkingTime = new TimeSpan();
            int consultationTime = 0;

            string[] expected = { };
            Calculations obj = new Calculations();

            string[] actual = obj.AvailablePeriods(startTime, durations, beginWorkingTime, endWorkingTime, consultationTime);

            Assert.AreEqual(expected, actual);
        }
    }
}
