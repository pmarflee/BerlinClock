using System;
using System.Linq;
using System.Text;

namespace BerlinClock.Core
{
    public class LampLine
    {
        private readonly Lamp[] _lamps;

        private LampLine(Lamp[] lamps)
        {
            _lamps = lamps;
        }

        public override string ToString()
        {
            return _lamps.Aggregate(new StringBuilder(), (builder, lamp) => builder.Append(new string((char)lamp.State, 1)),
                builder => builder.ToString());
        }

        public static LampLine CreateLampLine(int number, Func<int, Lamp> createLampFunc)
        {
            var lamps = new Lamp[number];
            for (int i = 0; i < number; i++)
            {
                lamps[i] = createLampFunc(i);
            }

            return new LampLine(lamps);
        }

        public void Set(BerlinClock.ClockTime time)
        {
            foreach (Lamp lamp in _lamps)
            {
                lamp.Set(time);
            }
        }
    }
}