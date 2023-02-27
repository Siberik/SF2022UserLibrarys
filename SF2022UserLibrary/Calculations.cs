using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF2022UserLibrary
{
    public class Calculations
    {
        /// <summary>
        /// список подходящих свободных временных промежутков
        /// </summary>
        /// <param name="startTimes">
        /// начало
        /// </param>
        /// <param name="durations">
        /// длительность
        /// </param>
        /// <param name="beginWorkingTime">
        /// начало 
        /// </param>
        /// <param name="endWorkingTime">
        /// завершение 
        /// </param>
        /// <param name="consultationTime">
        /// минимальное необходимое время для работы менеджера 
        /// </param>
        /// <returns>
        /// список подходящих свободных временных промежутков 
        /// </returns>
        public string[] AvailablePeriods(TimeSpan[] startTimes, int[] durations, TimeSpan beginWorkingTime, TimeSpan endWorkingTime, int consultationTime)
        {
            if (beginWorkingTime > endWorkingTime) return Array.Empty<string>();

            List<TimeInterval> times = new List<TimeInterval>();
            List<string> availablePeriods = new List<string>();

            for (int i = 0; i < startTimes.Length; i++)
                times.Add(new TimeInterval(startTimes[i], durations[i]));

            for (TimeSpan time = beginWorkingTime; time.Add(new TimeSpan(0, consultationTime, 0)) <= endWorkingTime; time = time + new TimeSpan(0, 1, 0))
            {
                var tmp = new TimeInterval(time, consultationTime);

                if (times.All(x => x.isFalls(tmp)))
                {
                    availablePeriods.Add(tmp.ToString());
                    time = (tmp.EndTime - new TimeSpan(0, 1, 0));
                }
            }

            return availablePeriods.ToArray();
        }

        /// <summary>
        /// Проверка правильности времени
        /// </summary>
        /// <param name="timeStarting">
        /// Строка с введённым временем
        /// </param>
        /// <returns>
        /// Возвращает либо истину, либо ложь
        /// </returns>
        public static bool CheckingTheTime(string timeStarting)
        {
            var v= String.Empty;

            if (String.IsNullOrWhiteSpace(timeStarting)==true)
            {
                return false;
            }
            try
            {
                 v = DateTime.Parse(timeStarting).ToString(@"HH:mm");
            }
            catch
            {
                return false;
            }
            

            return true;
        }
        /// <summary>
        /// Проверка правильности продолжительности
        /// </summary>
        /// <param name="timeStarting">
        /// Строка с введённой продолжительностью
        /// </param>
        /// <returns>
        /// Возвращает либо истину, либо ложь
        /// </returns>
        public static bool CheckingDuration(string timeStarting)
        {

            if (String.IsNullOrWhiteSpace(timeStarting) == true)
            {
                return false;
            }
            if (Convert.ToInt32(timeStarting) > 60 || Convert.ToInt32(timeStarting) < 0)
            {
                return false;
            }



            return true;
        }
    }
   
}


public struct TimeInterval
    {
        public TimeInterval(TimeSpan startTime, int durations)
        {
            StartTime = startTime;
            EndTime = StartTime + TimeSpan.FromMinutes(durations);
        }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public override string ToString() => StartTime.ToString(@"hh\:mm") + "-" + EndTime.ToString(@"hh\:mm");

        public bool isFalls(TimeInterval time) => StartTime >= time.EndTime || EndTime <= time.StartTime;
    }
   


    

