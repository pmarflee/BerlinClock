using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using Xunit.Extensions;

namespace BerlinClock.Tests
{
    public class BerlinClockTests
    {
        [Theory, ClassData(typeof (TestData))]
        public void TestClock(Core.BerlinClock.ClockTime time, string expected)
        {
            var clock = new Core.BerlinClock();
            clock.Set(time);
            Assert.Equal(expected, clock.ToString());
        }

        public class TestData : IEnumerable<object[]>
        {
            private readonly List<object[]> _list = new List<object[]>
            {
                new object[]
                {
                    new Core.BerlinClock.ClockTime("00:00:00"),
                    String.Join(Environment.NewLine, new[]
                    {
                        "Y",
                        "OOOO",
                        "OOOO",
                        "OOOOOOOOOOO",
                        "OOOO"
                    })
                },
                new object[]
                {
                    new Core.BerlinClock.ClockTime("13:17:01"),
                    String.Join(Environment.NewLine, new[]
                    {
                        "O",
                        "RROO",
                        "RRRO",
                        "YYROOOOOOOO",
                        "YYOO"
                    })
                },
                new object[]
                {
                    new Core.BerlinClock.ClockTime("23:59:59"),
                    String.Join(Environment.NewLine, new[]
                    {
                        "O",
                        "RRRR",
                        "RRRO",
                        "YYRYYRYYRYY",
                        "YYYY"
                    })
                },
                new object[]
                {
                    new Core.BerlinClock.ClockTime("24:00:00"),
                    String.Join(Environment.NewLine, new[]
                    {
                        "Y",
                        "RRRR",
                        "RRRR",
                        "OOOOOOOOOOO",
                        "OOOO"
                    })
                },
            };

            public IEnumerator<object[]> GetEnumerator()
            {
                return _list.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}