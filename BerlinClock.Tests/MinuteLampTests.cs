using System;
using System.Collections.Generic;
using System.Linq;
using BerlinClock.Core;
using Xunit;
using Xunit.Extensions;

namespace BerlinClock.Tests
{
    public class MinuteLampTests
    {
        [Theory, ClassData(typeof (FiveMinuteLampTestData))]
        public void FiveMinuteLampTest(int number, Core.BerlinClock.ClockTime time, Lamp.LampState expected)
        {
            LampTest(time, expected, new FiveMinuteLamp(number));
        }

        [Theory, ClassData(typeof (OneMinuteLampTestData))]
        public void OneMinuteLampTest(int number, Core.BerlinClock.ClockTime time, Lamp.LampState expected)
        {
            LampTest(time, expected, new OneMinuteLamp(number));
        }

// ReSharper disable once UnusedParameter.Local
        private static void LampTest(Core.BerlinClock.ClockTime time, Lamp.LampState expected, Lamp lamp)
        {
            lamp.Set(time);

            Assert.Equal(expected, lamp.State);
        }

        private class FiveMinuteLampTestData : MinuteTestData
        {
            public FiveMinuteLampTestData() : base(11)
            {
            }

            protected override Lamp.LampState GetExpected(int number, Core.BerlinClock.ClockTime time)
            {
                int minute = (number + 1)*5;
                if (time.Minutes < minute) return Lamp.LampState.Off;
                if (minute%15 == 0) return Lamp.LampState.Red;
                return Lamp.LampState.Yellow;
            }
        }

        private abstract class MinuteTestData : TestData
        {
            private readonly int _numberOfLamps;

            protected MinuteTestData(int numberOfLamps)
            {
                _numberOfLamps = numberOfLamps;
            }

            public override IEnumerator<object[]> GetEnumerator()
            {
                return (from number in Enumerable.Range(0, _numberOfLamps)
                    from minute in Enumerable.Range(0, 60)
                    let time = new Core.BerlinClock.ClockTime(String.Format("00:{0:00}:00", minute))
                    select
                        new object[]
                        {number, time, GetExpected(number, time)})
                    .ToList()
                    .GetEnumerator();
            }
        }

        private class OneMinuteLampTestData : MinuteTestData
        {
            public OneMinuteLampTestData() : base(4)
            {
            }

            protected override Lamp.LampState GetExpected(int number, Core.BerlinClock.ClockTime time)
            {
                return time.Minutes%5 < number + 1 ? Lamp.LampState.Off : Lamp.LampState.Yellow;
            }
        }
    }
}