using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Fuel : EnergySource
    {
        private eFuelType m_eFuelType;

        public eFuelType FuelType
        {
            get { return m_eFuelType; }
            set { m_eFuelType = value; }
        }
        
        public Fuel()
            : base()
        {
        }

        public Fuel(float i_MaxAmountOfEnergy)
            : base(i_MaxAmountOfEnergy)
        {
        }

        /// <summary>
        /// This method inherited from EnergySource class, fueling the vehicle 
        /// </summary>
        /// <param name="i_AmountOfEnergyToAdd"> Amount of fuel to add </param>
        /// <param name="i_EnergySourceToAdd"> Type of energy source </param>
        /// <exception cref="System.Exception.ValueOutOfRangeException">Thrown when adding more energy source then the max</exception>
        /// <exception cref="System.Exception.FormatException">Thrown when the energy source adding paramater is not fuel</exception>
        public override void LoadEnergySource(float i_AmountOfEnergyToAdd, EnergySource i_EnergySourceToAdd)
        {
            Fuel myFuel = i_EnergySourceToAdd as Fuel;

            if (myFuel != null)
            {
                if (myFuel.FuelType == m_eFuelType)
                {
                    CurrentAmountOfEnergy += i_AmountOfEnergyToAdd;
                }
                else
                {
                    throw new ArgumentException("The fuel type for reffil is unsuitable");
                }
            }
            else
            {
                throw new FormatException("The vehicle's energy source is not fuel");
            }
        }

        /// <summary>
        /// This method collects information on fuel energy source
        /// </summary>
        /// <returns>string with information on fuel energy source</returns>
        public override string ToString()
        {
            string fuelToString = null;

            fuelToString = string.Format(
@"{0}
Type of energy - Fuel
Type of fuel - {1}
Current amount of energy - {2} litters
Max amount of energy - {3} litters",
                                   base.ToString(),
                                   FuelType.ToString(),
                                   CurrentAmountOfEnergy,
                                   MaxAmountOfEnergy);
            return fuelToString;
        }
    }
}
