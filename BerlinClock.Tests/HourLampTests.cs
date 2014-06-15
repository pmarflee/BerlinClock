using System;
using System.Collections.Generic;
using System.Linq;
using BerlinClock.Core;
using Xunit;
using Xunit.Extensions;

namespace BerlinClock.Tests
{
    public class HourLampTests
    {
        [Theory, ClassData(typeof (FiveHourLampTestData))]
        public void FiveHourLampTest(int number, Core.BerlinClock.ClockTime time, Lamp.LampState expected)
        {
            LampTest(time, expected, new FiveHourLamp(number));
        }

        [Theory, ClassData(typeof (OneHourLampTestData))]
        public void OneHourLampTest(int number, Core.BerlinClock.ClockTime time, Lamp.LampState expected)
        {
            LampTest(time, expected, new OneHourLamp(number));
        }

// ReSharper disable once UnusedParameter.Local
        private static void LampTest(Core.BerlinClock.ClockTime time, Lamp.LampState expected, Lamp lamp)
        {
            lamp.Set(time);

            Assert.Equal(expected, lamp.State);
        }

        private abstract class HourLampTestData : TestData
        {
            public override IEnumerator<object[]> GetEnumerator()
            {
                return (from number in Enumerable.Range(0, 4)
                    from hour in Enumerable.Range(0, 24)
                    let time = new Core.BerlinClock.ClockTime(String.Format("{0:00}:00:00", hour))
                    select
                        new object[]
                        {number, time, GetExpected(number, time)})
                    .ToList()
                    .GetEnumerator();
            }
        }

        private class OneHourLampTestData : HourLampTestData
        {
            protected override Lamp.LampState GetExpected(int number, Core.BerlinClock.ClockTime time)
            {
                return time.Hours % 5 < number + 1 ? Lamp.LampState.Off : Lamp.LampState.Red;
            }
        }

        private class FiveHourLampTestData : HourLampTestData
        {
            protected override Lamp.LampState GetExpected(int number, Core.BerlinClock.ClockTime time)
            {
                return time.Hours < (number + 1) * 5 ? Lamp.LampState.Off : Lamp.LampState.Red;
            }
        }
    }
}