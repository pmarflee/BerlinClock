namespace BerlinClock.Core
{
    public class FiveHourLamp : Lamp
    {
        public FiveHourLamp(int number) : base(number)
        {
        }

        public override void Set(BerlinClock.ClockTime time)
        {
            State = time.Hours < (Number + 1)*5 ? LampState.Off : LampState.Red;
        }
    }
}