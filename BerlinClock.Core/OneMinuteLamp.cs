namespace BerlinClock.Core
{
    public class OneMinuteLamp : Lamp
    {
        public OneMinuteLamp(int number) : base(number)
        {
        }

        public override void Set(BerlinClock.ClockTime time)
        {
            State = time.Minutes%5 < Number + 1 ? LampState.Off : LampState.Yellow;
        }
    }
}