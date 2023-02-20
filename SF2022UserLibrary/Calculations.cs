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
            
          
            
            
            List<string> resultList=new List<string>();
            while (beginWorkingTime <= endWorkingTime)
            {
               
                for (int i = 0; i < startTimes.Length; i++)
                {
                    if (!(beginWorkingTime >= startTimes[i] && beginWorkingTime <= startTimes[i] + new TimeSpan(00, durations[i], 00)))
                    {
                        resultList.Add( Convert.ToString( beginWorkingTime));
 beginWorkingTime += new TimeSpan(00, consultationTime, 00);

                    }

                }

            }

            return resultList.ToArray();
        }
        public bool ()
    }
}
