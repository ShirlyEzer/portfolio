using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly float r_MaxAirPressure = 0;
        private string m_ManufacturerName = string.Empty;
        private float m_CurrentAirPressure = 0;

        public Wheel(float i_MaxAirPressure)
        {
            r_MaxAirPressure = i_MaxAirPressure;
        }

        public string ManufacturerName
        {
            get { return m_ManufacturerName; }
            set { m_ManufacturerName = value; }
        }

        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
            set
            {
                if (value < 0)
                {
                    throw new ValueOutOfRangeException(string.Format("Can not add amount of air less then zero", r_MaxAirPressure), 0.0f, r_MaxAirPressure);
                }
                else
                {
                    if (value > r_MaxAirPressure)
                    {
                        throw new ValueOutOfRangeException(string.Format("Can not add amount of air above the max {0}", r_MaxAirPressure), 0.0f, r_MaxAirPressure);
                    }
                    else
                    {
                        m_CurrentAirPressure = value;
                    }
                }
            }
        }

        public float MaxAirPressure
        {
            get { return r_MaxAirPressure; }
        }

        /// <summary>
        /// Inflating wheel with air
        /// </summary>
        /// <param name="i_AmountOfAirToAdd"></param>
        /// <exception cref="System.Exception.ValueOutOfRangeException">Thrown when the amount of the air to add is less then zero or bigger then max</exception>
        public void WheelInflation(float i_AmountOfAirToAdd)
        {
            CurrentAirPressure += i_AmountOfAirToAdd;
        }

        /// <summary>
        /// This method collects a general information on a wheel
        /// </summary>
        /// <returns>string with general information on a wheel</returns>
        public override string ToString()
        {
            string wheelToString = string.Format(
@"Wheel detailes:
Manufacturer name - {0}
Current air pressure - {1}
Max air pressure - {2}", 
                       ManufacturerName,
                       CurrentAirPressure,
                       MaxAirPressure);
            return wheelToString;
        }
    }
}
