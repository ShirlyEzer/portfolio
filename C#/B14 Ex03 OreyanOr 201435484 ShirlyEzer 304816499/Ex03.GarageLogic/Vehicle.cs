using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private Wheel[] m_Wheels = null;
        private string m_VehicleModelName = string.Empty;
        private string m_VehicleLicenseNumber = string.Empty;
        private EnergySource m_VehicleEnergySource = null;
        private float m_CurrentAmountEnergySourceInPercentage = 0;
        private VehicleInformation m_VehicleInformation = new VehicleInformation();

        public Vehicle(EnergySource i_CurrentEnergySource)
        {
            VehicleEnergySource = i_CurrentEnergySource;
        }

        protected internal string VehicleModelName
        {
            get { return m_VehicleModelName; }
            set { m_VehicleModelName = value; }
        }

        protected internal string VehicleLicenseNumber
        {
            get { return m_VehicleLicenseNumber; }
            set { m_VehicleLicenseNumber = value; }
        }

        protected internal EnergySource VehicleEnergySource
        {
            get { return m_VehicleEnergySource; }
            set 
            { 
                m_VehicleEnergySource = value;
                SetCurrentAmountEnergySourceInPercentage();
            }
        }

        protected internal float CurrentAmountEnergySourceInPercentage
        {
            get { return m_CurrentAmountEnergySourceInPercentage; }
        }

        protected internal Wheel[] Wheels
        {
            get { return m_Wheels; }
            set { m_Wheels = value; }
        }

        protected internal VehicleInformation VehicleInformation
        {
            get { return m_VehicleInformation; }
            set { m_VehicleInformation = value; }
        }

        /// <summary>
        /// Sets the float member class m_CurrentAmountEnergySourceInPercentage according the current amount of energy
        /// </summary>
        public void SetCurrentAmountEnergySourceInPercentage()
        {
           m_CurrentAmountEnergySourceInPercentage = VehicleEnergySource.CurrentAmountOfEnergy / VehicleEnergySource.MaxAmountOfEnergy * 100; 
        }

        public void SetMaxAirPressureOfWheelInListOfWheels(float i_MaxAirPressureForEachWheel)
        {
            for (int i = 0; i < Wheels.Length; i++)
            {
                Wheels[i] = new Wheel(i_MaxAirPressureForEachWheel);
            }
        }

        public void SetAirPressureOfWheelInListOfWheels(float i_AmountOfAirPressureForEachWheel)
        {
            for (int i = 0; i < Wheels.Length; i++)
            {
                Wheels[i].WheelInflation(i_AmountOfAirPressureForEachWheel);
            }
        }

        public void SetManufacturerNameOfWheelInListOfWheels(string i_ManufacturerNameForEachWheel)
        {
            for (int i = 0; i < Wheels.Length; i++)
            {
                Wheels[i].ManufacturerName = i_ManufacturerNameForEachWheel;
            }
        }

        /// <summary>
        /// Loads vehicle with energy source by using the method LoadEnergySource of class EnergySource
        /// </summary>
        /// <param name="i_AmountOfEnergyToAdd">Amount of energy source</param>
        /// <param name="i_EnergySource">Type of energy source</param>
        public void LoadEnergy(float i_AmountOfEnergyToAdd, EnergySource i_EnergySource)
        {
            m_VehicleEnergySource.LoadEnergySource(i_AmountOfEnergyToAdd, i_EnergySource);
            SetCurrentAmountEnergySourceInPercentage();
        }

        /// <summary>
        /// This method collects a general information on vehicle
        /// </summary>
        /// <returns>string with information on vehicle</returns>
        public override string ToString()
        {
            string vehicleToString = string.Format(
@"Model name - {0}
License number - {1}
Current amount energy source - {2} %

{3}",
    VehicleModelName,
    VehicleLicenseNumber,
    CurrentAmountEnergySourceInPercentage,
    VehicleEnergySource.ToString());

            return vehicleToString;
        }
    }
}
