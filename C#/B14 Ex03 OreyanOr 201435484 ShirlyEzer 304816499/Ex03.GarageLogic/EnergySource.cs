using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class EnergySource
    {
        private readonly float r_MaxAmountOfEnergy = 0;
        private float m_CurrentAmountOfEnergy = 0;
        
        public EnergySource()
        {
        }

        public EnergySource(float i_MaxAmountOfEnergy)
        {
            r_MaxAmountOfEnergy = i_MaxAmountOfEnergy;
        }

        public float MaxAmountOfEnergy
        {
            get { return r_MaxAmountOfEnergy; }
        }

        /// <summary>
        /// Property for float  member class current amount of energy
        /// <exception cref="System.Exception.ValueOutOfRangeException">Thrown when the value for member is more then the max</exception>
        /// </summary>
        public float CurrentAmountOfEnergy
        {
            get { return m_CurrentAmountOfEnergy; }
            set
            {
                if (value <= r_MaxAmountOfEnergy)
                {
                    m_CurrentAmountOfEnergy = value;
                }
                else
                {
                    ValueOutOfRangeException valueOutOfRangeException = new ValueOutOfRangeException(string.Format("Can not add amount of energy above the max {0}", r_MaxAmountOfEnergy), 0.0f, r_MaxAmountOfEnergy);
                    throw valueOutOfRangeException;
                }
            }
        }

        public abstract void LoadEnergySource(float i_AmountOfEnergyToAdd, EnergySource i_EnergySourceToAdd);

        public override string ToString()
        {
            string energySourceToString = string.Format(
@"Energy Source detailes:");

            return energySourceToString;
        }
    }
}
