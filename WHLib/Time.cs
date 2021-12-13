using System;


namespace WHLib
{
    /// <summary>
    /// Class that conceptualize time for working hours purposes.
    /// </summary>
      public class Time
    {
        private const int NBR_MINUTES_IN_HOUR = 60;
        public int Hours { get; private set; }
        public int Minutes { get; private set; }

        /// <summary>
        /// Constructor of the class Time
        /// </summary>
        /// <param name="pHours">integer representing hours<param>
        /// <param name="pMinutes">integer representing minutes<param>
        public Time(int pHours, int pMinutes)
        {
            int totalMinutes = NBR_MINUTES_IN_HOUR * pHours + pMinutes;
            Hours = totalMinutes / NBR_MINUTES_IN_HOUR;
            Minutes = totalMinutes % NBR_MINUTES_IN_HOUR;
        }
        /// <summary>
        /// Method that calculate the total amout of minute by converting
        /// the hours in minutes and add them to the orginial amount of minutes
        /// </summary>
        /// <return>total amout of minute</return>
        public int GetTotalMinutes() => NBR_MINUTES_IN_HOUR * Hours + Minutes;

        /// <summary>
        /// Method overrided of the operator '+' that can make an addition of 2 object time
        /// </summary>
        /// <param name="time1">A Time object that will me on the left side of the operation</param>
        /// <param name="time2">A Time object that will me on the right side of the operation</param>
        /// <return>A new time object with the property added</return>
        public static Time operator +(Time time1, Time time2)
        {
            int hours = time1.Hours + time2.Hours;
            int minutes = time1.Minutes + time2.Minutes;
            return new Time(hours, minutes);
        }
         /// <summary>
        /// Method overrided of the operator '++' that add an hours to the object time
        /// </summary>
        /// <param name="time">A Time object</param>
        /// <return>A new time object with the property hours incremented by one</return>
        public static Time operator ++(Time time)
        {
            return new Time(time.Hours++, time.Minutes);
        }

        /// <summary>
        /// Method overrided of the operator '-' that can make an soustraction of 2 object time
        /// </summary>
        /// <exception cref="ArgumentException">Occur if the second time parameter is grater than the first one</exception>
        /// <param name="time1">A Time object that will me on the left side of the operation</param>
        /// <param name="time2">A Time object that will me on the right side of the operation</param>
        /// <return>A new time object with the property substracted</return>
        public static Time operator -(Time time1, Time time2)
        {
            if (time1.Hours < time2.Hours) throw new ArgumentException("You're ending time must be after your starting time.");
            int hours = time1.Hours - time2.Hours;
            int minutes = time1.Minutes - time2.Minutes;
            hours = minutes < 0 ? hours-- : hours;
            return new Time(hours, minutes);
        }
        /// <summary>
        /// Method overrided of the operator '/' that can make an division of 2 object time
        /// </summary>
        /// <exception cref="DivideByZeroException">Occur if the specified denominator is 0</exception>
        /// <param name="time">A Time object that will be divided</param>
        /// <param name="denominator">integer that will be using to divide.</param>
        /// <return>A new time object with the property divided</return>
        public static Time operator /(Time time, int denominator)
        {
            if (denominator == 0) throw new DivideByZeroException("Can't accept 0 as denominator.");
            int minutesDivided = time.GetTotalMinutes() / denominator;
            return new Time(0, minutesDivided);
        }
        /// <summary>
        /// Method overrided of the operator '*' that can make an multiplication of 2 object time
        /// </summary>
        /// <param name="time">A Time object that will be multiplied</param>
        /// <param name="multiplicator">integer that will be using to multiply.</param>
        /// <return>A new time object with the property multiplied</return>
        public static Time operator *(Time time, int multiplicator)
        {
            int minutesMultiplied = time.GetTotalMinutes() * multiplicator;
            return new Time(0, minutesMultiplied);
        }

        /// <summary>
        /// Method explicit overrided of the operator of casting to float.
        /// The method will convert an time object to a float value.
        /// </summary>
        /// <param name="time">A Time object that will be converted</param>
        /// <return>The property of the paramter converted to float value</return>
        public static explicit operator float(Time time)
        {
            float minutes = Convert.ToSingle(time.Minutes) / NBR_MINUTES_IN_HOUR;
            return time.Hours + minutes;
        }

        /// <summary>
        /// Method overrided of ToString that will take the property and make
        /// an assignement with it
        /// </summary>
        /// <return>an expression containing the property of the object</return>
        public override string ToString() => $"{Hours} h {Minutes} min";
    }
}
