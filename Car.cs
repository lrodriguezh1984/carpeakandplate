using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class Car
    {
        public string PlateNumber { get; set; }

        public Car() { }
        public Car(string plate)
        {
            Regex rx = new Regex(@"\w{3}\-\d{3}");

            if (rx.IsMatch(plate))
                this.PlateNumber = plate;
            else
                throw new ArgumentException("Invalid Plate Number!!");
        }

        /// <summary>
        /// Returns if the car can be on the road.
        /// </summary>
        /// <param name="day"> Day of the week</param>
        /// <returns></returns>
        public bool CanBeOnRoad(DayOfWeek day)
        {
            if (day == getDayOfPeakAndPlate() )
                return false;
            
            return true;
        }

        /// <summary>
        /// Returns the day of the week of Peak and Plate according the plate number
        /// </summary>
        /// <returns></returns>
        private DayOfWeek getDayOfPeakAndPlate()
        {
            int intPlateLastChar = Convert.ToInt16(PlateNumber[PlateNumber.Length - 1].ToString());
            switch (intPlateLastChar)
            {
                case 1: 
                case 2:
                    return DayOfWeek.Monday;
                case 3:
                case 4:
                    return DayOfWeek.Tuesday;
                case 5:
                case 6:
                    return DayOfWeek.Wednesday;
                case 7:
                case 8:
                    return DayOfWeek.Thursday;
                case 9:
                case 0:
                    return DayOfWeek.Friday;
                default:
                    return DayOfWeek.Saturday; // never occurs
            }
        }
    }
}
