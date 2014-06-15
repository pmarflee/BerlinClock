namespace BerlinClock.Core
{
    public class SecondLamp : Lamp
    {
        public SecondLamp(int number) : base(number)
        {
        }

        public override void Set(BerlinClock.ClockTime time)
        {
            State = time.Seconds%2 == 0 ? LampState.Yellow : LampState.Off;
        }
    }
}