using System;

namespace BerlinClock.Core
{
    public abstract class Lamp
    {
        protected Lamp(int number)
        {
            Number = number;
        }

        public enum LampState
        {
            Yellow = 'Y',
            Red = 'R',
            Off = 'O'
        };

        public int Number { get; private set; }
        public LampState State { get; protected set; }
        public abstract void Set(BerlinClock.ClockTime time);
    }
}