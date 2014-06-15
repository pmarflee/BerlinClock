using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BerlinClock.Core
{
    public class BerlinClock
    {
        private readonly List<LampLine> _lines = new List<LampLine>
        {
            LampLine.CreateLampLine(1, i => new SecondLamp(i)),
            LampLine.CreateLampLine(4, i => new FiveHourLamp(i)),
            LampLine.CreateLampLine(4, i => new OneHourLamp(i)),
            LampLine.CreateLampLine(11, i => new FiveMinuteLamp(i)),
            LampLine.CreateLampLine(4, i => new OneMinuteLamp(i)),
        };

        public void Set(ClockTime time)
        {
            foreach (LampLine line in _lines)
            {
                line.Set(time);
            }
        }

        public override string ToString()
        {
            return String.Join("\r\n", _lines.Select(line => line.ToString()));
        }

        public class ClockTime
        {
            public ClockTime(string input)
            {
                var parser = new Regex(@"^(?<Hours>[0-9]|0[0-9]|1[0-9]|2[0-4]):(?<Minutes>[0-5][0-9]):(?<Seconds>[0-5][0-9])$");
                var match = parser.Match(input);

                if (!match.Success)
                {
                    throw new ArgumentException("Input is not in the correct format", "input");
                }

                Hours = int.Parse(match.Groups["Hours"].Value);
                Minutes = int.Parse(match.Groups["Minutes"].Value);
                Seconds = int.Parse(match.Groups["Seconds"].Value);
            }

            public int Hours { get; private set; }
            public int Minutes { get; private set; }
            public int Seconds { get; private set; }

            public override string ToString()
            {
                return String.Format("{0:00}:{1:00}:{2:00}", Hours, Minutes, Seconds);
            }
        }
    }
}