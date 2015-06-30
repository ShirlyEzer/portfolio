using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public sealed class Motorcycle : Vehicle
    {
        private eLicenseType m_LicenseType;
        private int m_EngineCapacity = 0;

        public Motorcycle(EnergySource i_EnergySource)
            : base(i_EnergySource)
        {
            Wheels = new Wheel[2];
        }

        public eLicenseType LicenseType
        {
            get { return m_LicenseType; }
            set { m_LicenseType = value; }
        }

        public int EngineCapacity
        {
            get { return m_EngineCapacity; }
            set { m_EngineCapacity = value; }
        }

        /// <summary>
        /// This method collects a general information on Motorcycle
        /// </summary>
        /// <returns>string with information on Motorcycle</returns>
        public override string ToString()
        {
            string motorcycleToString = string.Format(
@"********** Motorcycle Details **********
{0}
License type - {1}
Engine capacity - {2} 
Amount of wheels - {3}

{4}

{5}",
    base.ToString(),
    LicenseType.ToString(),
    EngineCapacity.ToString(),
    Wheels.Length.ToString(),
    Wheels[0].ToString(),
    VehicleInformation.ToString());

            return motorcycleToString;
        }
    }
}
