namespace BerlinClock.Core
{
    public class OneHourLamp : Lamp
    {
        public OneHourLamp(int number) : base(number)
        {
        }

        public override void Set(BerlinClock.ClockTime time)
        {
            State = time.Hours%5 < Number + 1 ? LampState.Off : LampState.Red;
        }
    }
}