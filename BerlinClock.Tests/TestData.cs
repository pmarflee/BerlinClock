using System;
using System.Collections;
using System.Collections.Generic;
using BerlinClock.Core;

namespace BerlinClock.Tests
{
    public abstract class TestData : IEnumerable<object[]>
    {
        public abstract IEnumerator<object[]> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        protected abstract Lamp.LampState GetExpected(int number, Core.BerlinClock.ClockTime time);
    }
}