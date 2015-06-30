using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public sealed class Car : Vehicle
    {
        private eColor m_ColorOfCar;
        private eAmountOfDoors m_AmountOfDoorsInCar;

        public Car(EnergySource i_EnergySource)
            : base(i_EnergySource)
        {
            Wheels = new Wheel[4];
        }

        public eColor ColorOfCar
        {
            get { return m_ColorOfCar; }
            set { m_ColorOfCar = value; }
        }

        public eAmountOfDoors AmountOfDoorsInCar
        {
            get { return m_AmountOfDoorsInCar; }
            set { m_AmountOfDoorsInCar = value; }
        }

        /// <summary>
        /// This method collects a general information on a car
        /// </summary>
        /// <returns>string with general information on a car</returns>
        public override string ToString()
        {
            string carToString = string.Format(
@"********** Car Details **********
{0}
Color - {1}
Amount of doors - {2} 
Amount of wheels - {3}

{4}

{5}",
    base.ToString(),
    ColorOfCar.ToString(),
    AmountOfDoorsInCar.ToString(),
    Wheels.Length.ToString(),
    Wheels[0].ToString(),
    VehicleInformation.ToString());

            return carToString;
        }
    }
}
