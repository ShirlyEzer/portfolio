using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricBattery : EnergySource
    {
        public ElectricBattery()
            : base()
        {
        }

        public ElectricBattery(float i_MaxAmountOfEnergy)
            : base(i_MaxAmountOfEnergy)
        {
        }

        /// <summary>
        /// This method inherited from EnergySource class, loads electric battery type of energy
        /// </summary>
        /// <param name="i_AmountOfEnergyToAdd"> Amount of electric battery energy to add </param>
        /// <param name="i_EnergySourceToAdd"> Type of energy source </param>
        /// <exception cref="System.Exception.ValueOutOfRangeException">Thrown when adding more energy source then the max</exception>
        /// <exception cref="System.Exception.FormatException">Thrown when the energy source adding paramater is not electric battery</exception>
        public override void LoadEnergySource(float i_AmountOfEnergyToAdd, EnergySource i_EnergySourceToAdd)
        {
            ElectricBattery myElectricBattery = i_EnergySourceToAdd as ElectricBattery;

            if (myElectricBattery != null)
            {
                CurrentAmountOfEnergy += i_AmountOfEnergyToAdd;
            }
            else
            {
                throw new FormatException("The vehicle's energy source is not electric");
            }
        }

        /// <summary>
        /// This method collects information electric battery energy source
        /// </summary>
        /// <returns>String with information electric battery energy source</returns>
        public override string ToString()
        {
            string electricBatteryToString = string.Format(
@"{0}
Type of energy - Electric battery
Current amount of energy - {1} hours
Max amount of energy - {2} hours",
                                   base.ToString(),
                                   CurrentAmountOfEnergy,
                                   MaxAmountOfEnergy);

            return electricBatteryToString;
        }
    }
}
