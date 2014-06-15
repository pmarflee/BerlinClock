using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BerlinClock.Core;
using Xunit;
using Xunit.Extensions;

namespace BerlinClock.Tests
{
    public class SecondLampTests
    {
        [Theory, ClassData(typeof (SecondLampTestData))]
        public void SecondLampTest(Core.BerlinClock.ClockTime time, Lamp.LampState expected)
        {
            var lamp = new SecondLamp(1);
            lamp.Set(time);
            Assert.Equal(expected, lamp.State);
        }

        private class SecondLampTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                return Enumerable.Range(0, 60)
                    .Select(s => new object[] {new Core.BerlinClock.ClockTime(String.Format("00:00:{0:00}", s)), s%2 == 0 ? 'Y' : 'O'})
                    .ToList()
                    .GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
