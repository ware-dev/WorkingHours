using System;


namespace WHLib
{
    public class Time
    {
        private const int NBR_MINUTES_IN_HOUR = 60;
        public int Hours { get; private set; }
        public int Minutes { get; private set; }

        public Time(int pHours, int pMinutes)
        {
            int totalMinutes = NBR_MINUTES_IN_HOUR * pHours + pMinutes;
            Hours = totalMinutes / NBR_MINUTES_IN_HOUR;
            Minutes = totalMinutes % NBR_MINUTES_IN_HOUR;
        }
        public int GetTotalMinutes() => NBR_MINUTES_IN_HOUR * Hours + Minutes;

        public static Time operator +(Time time1, Time time2)
        {
            int hours = time1.Hours + time2.Hours;
            int minutes = time1.Minutes + time2.Minutes;
            return new Time(hours, minutes);
        }
        public static Time operator ++(Time time)
        {
            return new Time(time.Hours++, time.Minutes);
        }

        public static Time operator -(Time time1, Time time2)
        {
            if (time1.Hours < time2.Hours) throw new ArgumentException("You're ending time must be after your starting time.");
            int hours = time1.Hours - time2.Hours;
            int minutes = time1.Minutes - time2.Minutes;
            hours = minutes < 0 ? hours-- : hours;
            return new Time(hours, minutes);
        }
        public static Time operator /(Time time, int denominator)
        {
            if (denominator == 0) throw new DivideByZeroException("Can't accept 0 as denominator.");
            int minutesDivided = time.GetTotalMinutes() / denominator;
            return new Time(0, minutesDivided);
        }
        public static Time operator *(Time time, int multiplicator)
        {
            int minutesMultiplied = time.GetTotalMinutes() * multiplicator;
            return new Time(0, minutesMultiplied);
        }

        public static explicit operator float(Time time)
        {
            float minutes = Convert.ToSingle(time.Minutes) / NBR_MINUTES_IN_HOUR;
            return time.Hours + minutes;
        }

        public override string ToString() => $"{Hours} h {Minutes} min";
    }
}
