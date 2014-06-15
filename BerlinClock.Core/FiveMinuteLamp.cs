namespace BerlinClock.Core
{
    public class FiveMinuteLamp : Lamp
    {
        public FiveMinuteLamp(int number) : base(number)
        {
        }

        public override void Set(BerlinClock.ClockTime time)
        {
            int minute = (Number + 1)*5;
            if (time.Minutes < minute) State = LampState.Off;
            else if (minute%15 == 0) State = LampState.Red;
            else State = LampState.Yellow;
        }
    }
}