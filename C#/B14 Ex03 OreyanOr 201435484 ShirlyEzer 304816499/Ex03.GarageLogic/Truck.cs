using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public sealed class Truck : Vehicle
    {
        private float m_WeightCarryingCapacity = 0;
        private bool m_IsCarryingHazardousMaterials = false;

        public Truck(EnergySource i_EnergySource)
            : base(i_EnergySource)
        {
            Wheels = new Wheel[10];
        }

        public float WeightCarryingCapacity
        {
            get { return m_WeightCarryingCapacity; }
            set { m_WeightCarryingCapacity = value; }
        }

        public bool IsCarryingHazardousMaterials
        {
            get { return m_IsCarryingHazardousMaterials; }
            set { m_IsCarryingHazardousMaterials = value; }
        }

        /// <summary>
        /// This method collects a general information on Truck
        /// </summary>
        /// <returns>string with information on Truck</returns>
        public override string ToString()
        {
            string motorcycleToString = string.Format(
@"********** Truck Details **********
{0}
Weight carrying capacity - {1}
Is carrying hazardous materials - {2}
Amount of wheels - {3}

{4}

{5}",
    base.ToString(),
    WeightCarryingCapacity.ToString(),
    IsCarryingHazardousMaterials.ToString(),
    Wheels.Length.ToString(),
    Wheels[0].ToString(),
    VehicleInformation.ToString());

            return motorcycleToString;
        }
    }
}
